using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Metadata;
using MobileSdkGen.CodeGen;
using MobileSdkGen.CodeGen.Java;
using MobileSdkGen.CodeGen.ObjectiveC;
using MobileSdkGen.CommandLine;
using MobileSdkGen.ModelConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MobileSdkGen
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parameters = AppParameters.Parse(args);

                Model model = null;
                if (!string.IsNullOrEmpty(parameters.ModelFile))
                {
                    using (var fileStream = File.OpenRead(parameters.ModelFile))
                    {
                        var serializer = new XmlSerializer(typeof(Model));
                        model = serializer.Deserialize(fileStream) as Model;
                    }
                }

                var connection = CrmConnection.Parse(parameters.ConnectionString);
                var orgService = new OrganizationService(connection);
                var orgData = new OrganizationData(orgService);

                var generators = new List<ICodeGenerator>();
                if (parameters.Java) generators.Add(new JavaGenerator());
                if (parameters.ObjC) generators.Add(new ObjectiveCGenerator());

                if (generators.Count == 0)
                {
                    generators.Add(new JavaGenerator());
                    generators.Add(new ObjectiveCGenerator());
                }
                
                using (var generator = new CompositeCodeGenerator(generators))
                {
                    generator.BeginFile(parameters.OutputFile);

                    foreach (var optionSet in orgData.OptionSets)
                    {
                        var options = optionSet as OptionSetMetadata;
                        if (options == null) continue;

                        if (model == null || model.IncludeAllGlobalOptionSets || (model.OptionSets != null && model.OptionSets.Any(o => o.Name == optionSet.Name)))
                        {
                            generator.BeginOptionSet(optionSet);

                            foreach (var option in options.Options)
                            {
                                generator.BeginOption(optionSet, option);
                                generator.EndOption(optionSet, option);
                            }

                            generator.EndOptionSet(optionSet);
                        }
                    }

                    foreach (var entity in orgData.Entities)
                    {
                        var modelEntity = (model == null) ? null : model.Entities.FirstOrDefault(e => e.Name == entity.LogicalName);
                        if (model == null || model.IncludeAllEntities || modelEntity != null)
                        {
                            generator.BeginEntity(entity);

                            foreach (var attribute in entity.Attributes.OrderBy(a => a.LogicalName))
                            {
                                if (modelEntity == null || modelEntity.AllAttributes || modelEntity.Attributes.Any(a => a.Name == attribute.LogicalName))
                                {
                                    generator.BeginAttribute(entity, attribute);
                                    generator.EndAttribute(entity, attribute);
                                }
                            }

                            generator.EndEntity(entity);
                        }
                    }

                    generator.EndFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}", ex.Message));
                Console.WriteLine(string.Format("Stack Trace: {0}", ex.StackTrace));
                Environment.Exit(1);
            }
        }
    }
}
