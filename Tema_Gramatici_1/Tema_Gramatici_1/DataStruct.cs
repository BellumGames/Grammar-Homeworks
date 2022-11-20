using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tema_Gramatici_1
{
    class DataStruct
    {
        private char key;
        private string value;

        public DataStruct(){}

        public void Add(char key, string value) 
        {
            this.key = key;
            this.value = value;
        }

        public char getKey()
        {
            return this.key;
        }
        public void setKey(char first)
        {
            this.key = first;
        }
        public string getValue()
        {
            return this.value;
        }
        public void setValue(string transform)
        {
            this.value = transform;
        }
    }
}
