using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_Gramatici_1
{
    class StackData
    {
        private string key;
        private int value;

        public string getKey()
        {
            return this.key;
        }

        public void setKey(string key)
        {
            this.key = key;
        }

        public int getValue()
        {
            return this.value;
        }

        public void setValue(int value)
        {
            this.value = value;
        }
    }
}
