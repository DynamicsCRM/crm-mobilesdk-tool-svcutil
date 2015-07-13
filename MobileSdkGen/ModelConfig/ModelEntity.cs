using System;
using System.Xml.Serialization;

namespace MobileSdkGen.ModelConfig
{
    [XmlType("Entity")]
    [Serializable]
    public sealed class ModelEntity
    {
        private ModelAttribute[] _attributes;
        private string _name;

        [XmlArray("Attributes")]
        public ModelAttribute[] Attributes
        {
            get { return this._attributes; }
            set { this._attributes = value; }
        }

        [XmlAttribute("Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [XmlIgnore]
        public bool AllAttributes
        {
            get { return this._attributes == null; }
        }
    }
}
