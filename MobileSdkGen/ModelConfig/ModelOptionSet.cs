using System;
using System.Xml.Serialization;

namespace MobileSdkGen.ModelConfig
{
    [XmlType("GlobalOptionSet")]
    [Serializable]
    public sealed class ModelOptionSet
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
