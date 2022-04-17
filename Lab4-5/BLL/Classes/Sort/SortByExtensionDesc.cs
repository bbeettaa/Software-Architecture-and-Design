using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Sort
{
    public class SortByExtensionDesc : IComparer<Content>
    {
        public int Compare(Content x, Content y)
        {
            if (x.Extension == null && y.Extension == null) return 0;
            else if (x.Extension == null) return -1;
            else if (y.Extension == null) return 1;
            else return y.Extension.CompareTo(x.Extension);
        }
    }
}
