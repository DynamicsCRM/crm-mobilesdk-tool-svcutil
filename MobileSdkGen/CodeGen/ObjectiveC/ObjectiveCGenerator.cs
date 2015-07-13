using Microsoft.Xrm.Sdk.Metadata;
using MobileSdkGen.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileSdkGen.CodeGen.ObjectiveC
{
    class ObjectiveCGenerator : ICodeGenerator
    {
        private const string FILE_NAME = "{!FILE_NAME}";
        private const string ENTITY_NAME = "{!ENTITY_NAME}";
        private const string ENTITY_LOGICALNAME = "{!ENTITY_LOGICALNAME}";
        private const string ENTITY_PRIMARYID = "{!ENTITY_PRIMARYID}";
        private const string ENTITY_TYPECODE = "{!ENTITY_TYPECODE}";
        private const string ATTRIBUTE_TYPE = "{!ATTRIBUTE_TYPE}";
        private const string ATTRIBUTE_NAME = "{!ATTRIBUTE_NAME}";
        private const string ATTRIBUTE_LOGICALNAME = "{!ATTRIBUTE_LOGICALNAME}";
        private const string ATTRIBUTE_NAME_UPPER = "{!ATTRIBUTE_NAME_UPPER}";
        private const string OPTIONSET_NAME = "{!OPTIONSET_NAME}";
        private const string OPTION_NAME = "{!OPTION_NAME}";
        private const string OPTION_VALUE = "{!OPTION_VALUE}";

        private Dictionary<AttributeTypeCode, string> _typeMapping;

        private StreamWriter _hWriter;
        private StreamWriter _mWriter;

        public ObjectiveCGenerator()
        {
            _typeMapping = new Dictionary<AttributeTypeCode, string>
            {
                { AttributeTypeCode.Boolean, "CRMBoolean" },
                { AttributeTypeCode.ManagedProperty, "CRMBoolean" },
                { AttributeTypeCode.CalendarRules, "NSObject" },
                { AttributeTypeCode.Customer, "EntityReference" },
                { AttributeTypeCode.DateTime, "NSDate" },
                { AttributeTypeCode.Decimal, "NSDecimalNumber" },
                { AttributeTypeCode.Double, "CRMDouble" },
                { AttributeTypeCode.Integer, "CRMInteger" },
                { AttributeTypeCode.EntityName, "NSString" },
                { AttributeTypeCode.BigInt, "CRMBigInt" },
                { AttributeTypeCode.Lookup, "EntityReference" },
                { AttributeTypeCode.Memo, "NSString" },
                { AttributeTypeCode.Money, "Money" },
                { AttributeTypeCode.Owner, "EntityReference" },
                { AttributeTypeCode.Picklist, "OptionSetValue" },
                { AttributeTypeCode.Status, "OptionSetValue" },
                { AttributeTypeCode.State, "OptionSetValue" },
                { AttributeTypeCode.String, "NSString" },
                { AttributeTypeCode.Uniqueidentifier, "NSUUID" }
            };
        }

        public void BeginFile(string fileName)
        {
            _hWriter = new StreamWriter(string.Format("{0}.h", fileName));
            _mWriter = new StreamWriter(string.Format("{0}.m", fileName));

            _hWriter.WriteLine(TemplateResources.H_File_Begin
                .SaneReplace(FILE_NAME, fileName, ObjectiveCWordProvider.Instance));

            _mWriter.WriteLine(TemplateResources.M_File_Begin
                .SaneReplace(FILE_NAME, fileName, ObjectiveCWordProvider.Instance));
        }

        public void EndFile() { }

        public void BeginOptionSet(OptionSetMetadataBase optionSet)
        {
            _hWriter.WriteLine(TemplateResources.H_OptionSet_Begin);
        }

        public void EndOptionSet(OptionSetMetadataBase optionSet)
        {
            _hWriter.WriteLine(TemplateResources.H_OptionSet_End
                .SaneReplace(OPTIONSET_NAME, optionSet.Name, ObjectiveCWordProvider.Instance));
        }

        public void BeginOption(OptionSetMetadataBase optionSet, OptionMetadata option)
        {
            var alphaRegex = new Regex("[^a-zA-Z0-9_]");

            var label = option.Label.LocalizedLabels.FirstOrDefault(l => l.LanguageCode == 1033);
            var name = string.Format("{0}_{1}", optionSet.Name, label == null ? option.Value.ToString() : alphaRegex.Replace(label.Label, "_"));

            _hWriter.WriteLine(TemplateResources.H_Option_Begin
                .SaneReplace(OPTION_NAME, name, ObjectiveCWordProvider.Instance)
                .SaneReplace(OPTION_VALUE, option.Value.ToString(), ObjectiveCWordProvider.Instance));
        }

        public void EndOption(OptionSetMetadataBase optionSet, OptionMetadata option) { }

        public void BeginEntity(EntityMetadata entity)
        {
            _hWriter.WriteLine(TemplateResources.H_Entity_Begin
                .SaneReplace(ENTITY_NAME, entity.SchemaName, ObjectiveCWordProvider.Instance));

            _mWriter.WriteLine(TemplateResources.M_Entity_Begin
                .SaneReplace(ENTITY_NAME, entity.SchemaName, ObjectiveCWordProvider.Instance)
                .SaneReplace(ENTITY_LOGICALNAME, entity.LogicalName, ObjectiveCWordProvider.Instance)
                .SaneReplace(ENTITY_TYPECODE, entity.ObjectTypeCode.ToString(), ObjectiveCWordProvider.Instance)
                .SaneReplace(ENTITY_PRIMARYID, entity.PrimaryIdAttribute, ObjectiveCWordProvider.Instance));
        }

        public void EndEntity(EntityMetadata entity)
        {
            _hWriter.WriteLine(TemplateResources.H_Entity_End);

            _mWriter.WriteLine(TemplateResources.M_Entity_End
                .SaneReplace(ENTITY_LOGICALNAME, entity.LogicalName, ObjectiveCWordProvider.Instance));
        }

        public void BeginAttribute(EntityMetadata entity, AttributeMetadata attribute)
        {
            string type = null;

            if (attribute is ImageAttributeMetadata)
                type = "UIImage";
            else if (attribute.AttributeType.HasValue && _typeMapping.ContainsKey(attribute.AttributeType.Value))
                type = _typeMapping[attribute.AttributeType.Value];

            if (string.IsNullOrEmpty(type)) return;

            var attributeNameArray = attribute.SchemaName.ToCharArray();
            attributeNameArray[0] = char.ToUpperInvariant(attributeNameArray[0]);

            var attributeNameUpper = new string(attributeNameArray);

            _hWriter.WriteLine(TemplateResources.H_Attribute_Begin
                .SaneReplace(ATTRIBUTE_TYPE, type, ObjectiveCWordProvider.Instance)
                .SaneReplace(ATTRIBUTE_NAME, attribute.SchemaName, ObjectiveCWordProvider.Instance));

            _mWriter.WriteLine(TemplateResources.M_Attribute_Begin
                .SaneReplace(ATTRIBUTE_TYPE, type, ObjectiveCWordProvider.Instance)
                .SaneReplace(ATTRIBUTE_NAME, attribute.SchemaName, ObjectiveCWordProvider.Instance)
                .SaneReplace(ATTRIBUTE_NAME_UPPER, attributeNameUpper, ObjectiveCWordProvider.Instance)
                .SaneReplace(ATTRIBUTE_LOGICALNAME, attribute.LogicalName, ObjectiveCWordProvider.Instance));
        }

        public void EndAttribute(EntityMetadata entity, AttributeMetadata attribute) { }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_hWriter != null)
            {
                _hWriter.Close();
                _hWriter.Dispose();
                _hWriter = null;
            }

            if (_mWriter != null)
            {
                _mWriter.Close();
                _mWriter.Dispose();
                _mWriter = null;
            }

        }
    }
}
