using Microsoft.Xrm.Sdk.Metadata;
using MobileSdkGen.CodeGen.ObjectiveC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MobileSdkGen.CodeGen.Java
{
    class JavaGenerator : ICodeGenerator
    {
        private const string FILE_NAME = "{!FILE_NAME}";
        private const string ENTITY_NAME = "{!ENTITY_NAME}";
        private const string ENTITY_LOGICALNAME = "{!ENTITY_LOGICALNAME}";
        private const string ENTITY_PRIMARYID_NAME = "{!ENTITY_PRIMARYID_NAME}";
        private const string ENTITY_PRIMARYID_LOGICALNAME = "{!ENTITY_PRIMARYID_LOGICALNAME}";
        private const string ENTITY_TYPECODE = "{!ENTITY_TYPECODE}";
        private const string ATTRIBUTE_TYPE = "{!ATTRIBUTE_TYPE}";
        private const string ATTRIBUTE_NAME = "{!ATTRIBUTE_NAME}";
        private const string ATTRIBUTE_LOGICALNAME = "{!ATTRIBUTE_LOGICALNAME}";
        private const string ATTRIBUTE_NAME_UPPER = "{!ATTRIBUTE_NAME_UPPER}";
        private const string OPTIONSET_NAME = "{!OPTIONSET_NAME}";
        private const string OPTION_NAME = "{!OPTION_NAME}";
        private const string OPTION_VALUE = "{!OPTION_VALUE}";
        private const string OPTION_SEPARATOR = "{!OPTION_SEPARATOR}";
        private const string OPTIONSET_TO_OBJECT_CASES = "{!OPTIONSET_TO_OBJECT_CASES}";

        private StreamWriter _writer;
        private StringBuilder _optionToObjectCases;
        private Dictionary<AttributeTypeCode, string> _typeMapping;

        public JavaGenerator()
        {
            _typeMapping = new Dictionary<AttributeTypeCode, string>
            {
                { AttributeTypeCode.Boolean, "boolean" },
                { AttributeTypeCode.Customer, "EntityReference" },
                { AttributeTypeCode.DateTime, "Date" },
                { AttributeTypeCode.Decimal, "BigDecimal" },
                { AttributeTypeCode.Double, "double" },
                { AttributeTypeCode.Integer, "int" },
                { AttributeTypeCode.BigInt, "BigInteger" },
                { AttributeTypeCode.Lookup, "EntityReference" },
                { AttributeTypeCode.Memo, "String" },
                { AttributeTypeCode.Money, "Money" },
                { AttributeTypeCode.Owner, "EntityReference" },
                { AttributeTypeCode.Picklist, "OptionSetValue" },
                { AttributeTypeCode.Status, "OptionSetValue" },
                { AttributeTypeCode.State, "OptionSetValue" },
                { AttributeTypeCode.String, "String" },
                { AttributeTypeCode.Uniqueidentifier, "UUID" }
            };
        }

        public void BeginFile(string fileName)
        {
            String newFolder = Path.Combine(Environment.CurrentDirectory, fileName);
            Directory.CreateDirectory(newFolder);
            Environment.CurrentDirectory = newFolder;

        }

        public void EndFile()
        {

        }

        public void BeginOptionSet(OptionSetMetadataBase optionSet)
        {
            _writer = new StreamWriter(string.Format("{0}.java", optionSet.Name));
            _writer.WriteLine(TemplateResources.Java_File_Begin.Replace(FILE_NAME, optionSet.Name));

            _writer.WriteLine(TemplateResources.Java_OptionSet_Begin.Replace(OPTIONSET_NAME, optionSet.Name));
            _optionToObjectCases = new StringBuilder();
        }

        public void EndOptionSet(OptionSetMetadataBase optionSet)
        {
            _writer.WriteLine(TemplateResources.Java_OptionSet_End
                .Replace(OPTIONSET_NAME, optionSet.Name)
                .Replace(OPTIONSET_TO_OBJECT_CASES, _optionToObjectCases.ToString()));

            _optionToObjectCases = null;
            _writer.Flush();
            _writer.Close();
        }

        public void BeginOption(OptionSetMetadataBase optionSet, OptionMetadata option)
        {
            var optionSetMetadata = optionSet as OptionSetMetadata;
            if(optionSetMetadata == null) throw new NotImplementedException("Unsupported option set type.");

            bool isLast = optionSetMetadata.Options.IndexOf(option) == optionSetMetadata.Options.Count - 1;
            string separator = isLast ? ";" : ",";

            string label = Regex.Replace(option.Label.LocalizedLabels.FirstOrDefault().Label, @"\'|\s|:|&|-|,|\(|\)|\.|\/|>|%|\+|{|}", "");

            _writer.WriteLine(TemplateResources.Java_Option_Begin
                .Replace(OPTION_NAME, label)
                .Replace(OPTION_VALUE, option.Value.ToString())
                .Replace(OPTION_SEPARATOR, separator));

            _optionToObjectCases.AppendLine(TemplateResources.Java_Option_ToObjectCase
                .Replace(OPTION_NAME, label)
                .Replace(OPTION_VALUE, option.Value.ToString()));
        }

        public void EndOption(OptionSetMetadataBase optionSet, OptionMetadata option)
        {
        }

        public void BeginEntity(EntityMetadata entity)
        {
            _writer = new StreamWriter(string.Format("{0}.java", entity.SchemaName));
            _writer.WriteLine(TemplateResources.Java_File_Begin.Replace(FILE_NAME, entity.SchemaName));

            var primaryIdAttrib = entity.Attributes.First(a => a.LogicalName == entity.PrimaryIdAttribute);

            _writer.WriteLine(TemplateResources.Java_Entity_Begin
                .Replace(ENTITY_LOGICALNAME, entity.LogicalName)
                .Replace(ENTITY_NAME, entity.SchemaName)
                .Replace(ENTITY_TYPECODE, entity.ObjectTypeCode.ToString())
                .Replace(ENTITY_PRIMARYID_LOGICALNAME, primaryIdAttrib.LogicalName)
                .Replace(ENTITY_PRIMARYID_NAME, primaryIdAttrib.SchemaName));
        }

        public void EndEntity(EntityMetadata entity)
        {
            _writer.WriteLine(TemplateResources.Java_Entity_End);

            _writer.Flush();
            _writer.Close();
        }

        public void BeginAttribute(EntityMetadata entity, AttributeMetadata attribute)
        {
            var primaryIdAttrib = entity.Attributes.First(a => a.LogicalName == entity.PrimaryIdAttribute);
            if (attribute.LogicalName == primaryIdAttrib.LogicalName || !attribute.AttributeType.HasValue 
                || !_typeMapping.ContainsKey(attribute.AttributeType.Value))
                return;

            var attributeNameArray = attribute.SchemaName.ToCharArray();
            attributeNameArray[0] = char.ToUpperInvariant(attributeNameArray[0]);

            var attributeNameUpper = new string(attributeNameArray);

            _writer.WriteLine(TemplateResources.Java_Attribute_Begin
                .Replace(ENTITY_NAME, entity.SchemaName)
                .Replace(ATTRIBUTE_TYPE, _typeMapping[attribute.AttributeType.Value])
                .Replace(ATTRIBUTE_NAME, attribute.SchemaName)
                .Replace(ATTRIBUTE_NAME_UPPER, attributeNameUpper)
                .Replace(ATTRIBUTE_LOGICALNAME, attribute.LogicalName));
        }

        public void EndAttribute(EntityMetadata entity, AttributeMetadata attribute)
        {

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_writer != null)
            {
                _writer.Close();
                _writer.Dispose();
                _writer = null;
            }
        }
    }
}
