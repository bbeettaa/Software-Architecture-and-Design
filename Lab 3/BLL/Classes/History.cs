using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public class History
    {
        private String[] history = new String[30] ;

        public History() { }
        public void Add(String str) {
            for (int i = history.Length - 2; i >= 0; i--)
                history[i + 1] = history[i];

            history[0] = str;
        }
        public override string ToString()
        {
            String str="";
            for (int i = 0; i < history.Length; i++)
                if(history[i] == null)
                    str.Concat("-");
            else
            str+=(history[i])+new string(' ',30)+"\n";

            return str;
        }
    }
}
