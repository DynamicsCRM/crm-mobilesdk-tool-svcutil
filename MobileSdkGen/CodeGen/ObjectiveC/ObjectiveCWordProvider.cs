using MobileSdkGen.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileSdkGen.CodeGen.ObjectiveC
{
    class ObjectiveCWordProvider : IReservedWordProvider
    {
        #region Words and Characters

        private static List<string> _keywords = new List<string>
        {
            "auto",
            "break",
            "case",
            "char",
            "const",
            "continue",
            "default",
            "do",
            "double",
            "else",
            "enum",
            "extern",
            "float",
            "for",
            "goto",
            "if",
            "inline",
            "int",
            "long",
            "register",
            "restrict",
            "return",
            "short",
            "signed",
            "sizeof",
            "static",
            "struct",
            "switch",
            "typedef",
            "union",
            "unsigned",
            "void",
            "volatile",
            "while",
            "_Bool",
            "_Complex",
            "_Imaginary",
            "BOOL",
            "Class",
            "bycopy",
            "byref",
            "id",
            "IMP",
            "in",
            "inout",
            "nil",
            "NO",
            "NULL",
            "oneway",
            "out",
            "Protocol",
            "SEL",
            "self",
            "super",
            "YES",
            "interface",
            "end",
            "implementation",
            "protocol",
            "class",
            "public",
            "protected",
            "private",
            "property",
            "try",
            "throw",
            "catch",
            "finally",
            "synthesize",
            "dynamic",
            "selector",
            "atomic",
            "nonatomic",
            "retain"
        };

        private static List<char> _chars = new List<char>
        {
            ';', '.', '(', ')', '+', '-', '/', '*', '=', '[', ']', '{', '}', '?', ':', ',', '!', '@', '%', '^', '&', '|', '\'', '"', '<', '>'
        };

        #endregion

        private static ObjectiveCWordProvider _instance = null;
        public static ObjectiveCWordProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ObjectiveCWordProvider();
                }

                return _instance;
            }
        }

        private ObjectiveCWordProvider() { }

        public IEnumerable<string> ReservedWords
        {
            get { return _keywords.ToArray(); }
        }


        public IEnumerable<char> ControlChars
        {
            get { return _chars.ToArray(); }
        }
    }
}
