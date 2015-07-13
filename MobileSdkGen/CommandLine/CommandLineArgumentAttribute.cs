using System;

namespace MobileSdkGen.CommandLine
{
    [AttributeUsage(AttributeTargets.Property)]
    class CommandLineArgumentAttribute : Attribute
    {
        public string Flag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }

        public CommandLineArgumentAttribute(string flag)
        {
            Flag = flag;
        }
    }
}
