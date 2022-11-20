using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class InternalDefines
    {
        //"../../Gramatica.txt";
        public static string initial_path = System.IO.Directory.GetCurrentDirectory() + @"\Gramatica.txt";
        public static int contor = 0;
    }

    public class DataStruct
    {
        public string strKey { get; set; }
        public string strProduction { get; set; }

        public DataStruct(string strValue1, string strValue2)
        {
            strKey = strValue1;
            strProduction = strValue2;
        }

        public DataStruct()
        {
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                DataStruct d = (DataStruct)obj;
                if ((strKey != d.strKey) || (strProduction != d.strProduction))
                {
                    InternalDefines.contor++;
                }
                return (strKey == d.strKey) && (strProduction == d.strProduction);
            }
        }
    }

    public class Colection
    {
        public object resultList { get; set; }
        public object listNumber { get; set; }
        public object character { get; set;  }

        public Colection(object firstList, object with, object bValue) 
        {
            listNumber = firstList;
            character = with;
            resultList = bValue;
        }
    }

    public class Actions
    {
        public Actions(int intValue_of_Status_Member, string strValue_of_Terminal, string strValue_of_Data)
        {
            intStatusNumber = intValue_of_Status_Member;
            strTerminal = strValue_of_Terminal;
            strData = strValue_of_Data;
        }
        public int intStatusNumber { get; set; }
        public string strTerminal { get; set; }
        public string strData { get; set; }
    }

    public class Jump
    {
        public Jump(int intValue1, string strValue1, int intValue2)
        {
            intStatusNumber = intValue1;
            intData = intValue2;
            strData = strValue1;
        }
        public int intStatusNumber { get; set; }
        public int intData { get; set; }
        public string strData { get; set; }
    }
}
