using System;
using System.Xml.Serialization;

namespace MobileSdkGen.ModelConfig
{
    [XmlType("Attribute")]
    [Serializable]
    public sealed class ModelAttribute
    {
        private string _name;

        [XmlAttribute("Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
