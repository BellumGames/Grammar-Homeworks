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
        private int index;
        private char key;
        private string value;

        public DataStruct(){}

        public void Add(int index, char key, string value) 
        {
            this.index = index;
            this.key = key;
            this.value = value;
        }

        public int getIndex() 
        {
            return this.index;
        }

        public void setIndex(int index)
        {
            this.index = index;
        }

        public char getKey()
        {
            return this.key;
        }
        public void setKey(char key)
        {
            this.key = key;
        }
        public string getValue()
        {
            return this.value;
        }
        public void setValue(string value)
        {
            this.value = value;
        }
    }
}
