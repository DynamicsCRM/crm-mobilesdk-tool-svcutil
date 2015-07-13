using System;
using System.Xml.Serialization;

namespace MobileSdkGen.ModelConfig
{
    [XmlRoot("Model", Namespace = "")]
    [Serializable]
    public sealed class Model
    {
        private ModelEntity[] _entities;
        private ModelOptionSet[] _optionSets;
        private bool _includeAllEntities;
        private bool _includeAllGlobalOptionSets;

        [XmlArray("Entities")]
        public ModelEntity[] Entities
        {
            get { return this._entities; }
            set { this._entities = value; }
        }

        [XmlArray("GlobalOptionSets")]
        public ModelOptionSet[] OptionSets
        {
            get { return this._optionSets; }
            set { this._optionSets = value; }
        }

        [XmlAttribute("IncludeAllEntities")]
        public bool IncludeAllEntities
        {
            get { return this._includeAllEntities; }
            set { this._includeAllEntities = value; }
        }

        [XmlAttribute("IncludeAllGlobalOptionSets")]
        public bool IncludeAllGlobalOptionSets
        {
            get { return this._includeAllGlobalOptionSets; }
            set { this._includeAllGlobalOptionSets = value; }
        }
    }
}
