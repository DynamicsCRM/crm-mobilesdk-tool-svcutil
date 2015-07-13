using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MobileSdkGen.CommandLine
{
    class AppParameters
    {
        private const int ERROR_INVALID_COMMAND_LINE = 1639;

        [CommandLineArgument("c", Name = "Connection String", Description = "The connection string to be used to connect to the CRM Organization.", IsRequired = true)]
        public string ConnectionString { get; set; }

        [CommandLineArgument("o", Name = "Output File", Description = "The path or name for the code file(s) to be generated. Should not include a file suffix.", IsRequired = true)]
        public string OutputFile { get; set; }

        [CommandLineArgument("m", Name = "Model File", Description = "The path or file name for the XML model file used to select entities to generate.")]
        public string ModelFile { get; set; }

        [CommandLineArgument("j", Name = "Generate Java", Description = "Generate the code in Java.")]
        public bool Java { get; set; }

        [CommandLineArgument("i", Name = "Generate Objective C", Description = "Generate the code for iOS Objective C.")]
        public bool ObjC { get; set; }

        public static AppParameters Parse(string[] args)
        {
            var appParams = new AppParameters();

            var properties = new Dictionary<string, PropertyInfo>();
            var arguments = new Dictionary<string, CommandLineArgumentAttribute>();

            foreach (var propertyInfo in typeof(AppParameters).GetProperties())
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(CommandLineArgumentAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    var attribute = (CommandLineArgumentAttribute)attributes[0];
                    properties.Add(attribute.Flag, propertyInfo);
                    arguments.Add(attribute.Flag, attribute);
                }
            }

            PropertyInfo currentProperty = null;
            foreach (var arg in args)
            {
                if (arg == "?")
                {
                    ShowHelp();
                    Environment.Exit(0);
                }

                var flag = GetArgumentFlag(arg);
                if ((currentProperty != null && flag != null) || (currentProperty == null && flag == null))
                {
                    // Undeclared or unused declared argument
                    ShowHelp();
                    Environment.Exit(ERROR_INVALID_COMMAND_LINE);
                }
                else if (currentProperty == null)
                {
                    // Undefined or doubly used argument
                    if (!properties.ContainsKey(flag))
                    {
                        ShowHelp();
                        Environment.Exit(ERROR_INVALID_COMMAND_LINE);
                    }

                    currentProperty = properties[flag];
                    properties.Remove(flag);
                    arguments.Remove(flag);

                    if (currentProperty.PropertyType == typeof(bool))
                    {
                        currentProperty.SetValue(appParams, true);
                        currentProperty = null;
                    }
                }
                else
                {
                    currentProperty.SetValue(appParams, arg);
                    currentProperty = null;
                }
            }

            // Unused declared argument
            if (currentProperty != null)
            {
                ShowHelp();
                Environment.Exit(ERROR_INVALID_COMMAND_LINE);
            }

            // Unused required arguments
            if (arguments.Any(a => a.Value.IsRequired))
            {
                ShowHelp();
                Environment.Exit(ERROR_INVALID_COMMAND_LINE);
            }

            return appParams;
        }

        private static string GetArgumentFlag(string argument)
        {
            if (argument[0] == '-') return argument.Substring(1);
            return null;
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: Argument flags begin with - and are followed by the argument value. Boolean arguments do not take a value. If all code types are omitted, all are generated.");
            Console.WriteLine();
            Console.WriteLine("Example: MobileSdkGen -c \"Url=https://myorg.crm.dynamics.com/; Username=un; Password=pw\" -o MyModel -j");
            Console.WriteLine();
            Console.WriteLine("Parameters:");

            foreach (var propertyInfo in typeof(AppParameters).GetProperties())
            {
                var attributes = propertyInfo.GetCustomAttributes(typeof(CommandLineArgumentAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    var attribute = (CommandLineArgumentAttribute)attributes[0];
                    Console.WriteLine(string.Format("\r\n\t-{0}\tName: {1}\r\n\t\tDescription: {2}\r\n\t\tBoolean: {3}\r\n\t\tRequired: {4}",
                        attribute.Flag, attribute.Name, attribute.Description,
                        propertyInfo.PropertyType == typeof(bool) ? "Yes" : "No", attribute.IsRequired ? "Yes" : "No"));
                }
            }
        }
    }
}
