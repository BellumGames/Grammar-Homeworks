using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class InternalDefinitions
    {
        public static string path = System.IO.Directory.GetCurrentDirectory() + @"\Gramatica.txt";
        public static int cx_register = 0;
    }

    public class DataStruct
    {
        public string key { get; set; }
        public string value { get; set; }

        public DataStruct(string strValue1, string strValue2)
        {
            key = strValue1;
            value = strValue2;
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
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                DataStruct d = (DataStruct)obj;
                if ((key != d.key) || (value != d.value))
                {
                    InternalDefinitions.cx_register++;
                }
                return (key == d.key) && (value == d.value);
            }
        }
    }

    public class Colection
    {
        public object resultList { get; set; }
        public object listNumber { get; set; }
        public object character { get; set; }

        public Colection(object firstList, object with, object bValue)
        {
            listNumber = firstList;
            character = with;
            resultList = bValue;
        }
    }

    public class Action
    {
        public Action(int intValue_of_Status_Member, string strValue_of_Terminal, string strValue_of_Data)
        {
            intStatusNumber = intValue_of_Status_Member;
            stringTerminal = strValue_of_Terminal;
            stringData = strValue_of_Data;
        }
        public int intStatusNumber { get; set; }
        public string stringTerminal { get; set; }
        public string stringData { get; set; }
    }

    public class Jump
    {
        public Jump(int intValue1, string stringValue1, int intValue2)
        {
            intStatusNumber = intValue1;
            intData = intValue2;
            stringData = stringValue1;
        }
        public int intStatusNumber { get; set; }
        public int intData { get; set; }
        public string stringData { get; set; }
    }
}
