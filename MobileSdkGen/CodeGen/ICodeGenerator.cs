using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace MobileSdkGen.CodeGen
{
    interface ICodeGenerator : IDisposable
    {
        void BeginFile(string fileName);
        void EndFile();

        void BeginOptionSet(OptionSetMetadataBase optionSet);
        void EndOptionSet(OptionSetMetadataBase optionSet);

        void BeginOption(OptionSetMetadataBase optionSet, OptionMetadata option);
        void EndOption(OptionSetMetadataBase optionSet, OptionMetadata option);

        void BeginEntity(EntityMetadata entity);
        void EndEntity(EntityMetadata entity);

        void BeginAttribute(EntityMetadata entity, AttributeMetadata attribute);
        void EndAttribute(EntityMetadata entity, AttributeMetadata attribute);
    }
}
