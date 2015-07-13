using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSdkGen.CodeGen
{
    class CompositeCodeGenerator : ICodeGenerator
    {
        IEnumerable<ICodeGenerator> _codeGenerators;

        public CompositeCodeGenerator(IEnumerable<ICodeGenerator> codeGenerators)
        {
            _codeGenerators = codeGenerators;
        }

        protected void Each(Action<ICodeGenerator> action)
        {
            foreach (ICodeGenerator codeGenerator in _codeGenerators)
            {
                action(codeGenerator);
            }
        }

        public void BeginFile(string fileName)
        {
            Each(cg => cg.BeginFile(fileName));
        }

        public void EndFile()
        {
            Each(cg => cg.EndFile());
        }

        public void BeginOptionSet(OptionSetMetadataBase optionSet)
        {
            Each(cg => cg.BeginOptionSet(optionSet));
        }

        public void EndOptionSet(OptionSetMetadataBase optionSet)
        {
            Each(cg => cg.EndOptionSet(optionSet));
        }

        public void BeginOption(OptionSetMetadataBase optionSet, OptionMetadata option)
        {
            Each(cg => cg.BeginOption(optionSet, option));
        }

        public void EndOption(OptionSetMetadataBase optionSet, OptionMetadata option)
        {
            Each(cg => cg.EndOption(optionSet, option));
        }

        public void BeginEntity(EntityMetadata entity)
        {
            Each(cg => cg.BeginEntity(entity));
        }

        public void EndEntity(EntityMetadata entity)
        {
            Each(cg => cg.EndEntity(entity));
        }

        public void BeginAttribute(EntityMetadata entity, AttributeMetadata attribute)
        {
            Each(cg => cg.BeginAttribute(entity, attribute));
        }

        public void EndAttribute(EntityMetadata entity, AttributeMetadata attribute)
        {
            Each(cg => cg.EndAttribute(entity, attribute));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_codeGenerators != null)
            {
                Each(cg => cg.Dispose());
                _codeGenerators = null;
            }

        }
    }
}
