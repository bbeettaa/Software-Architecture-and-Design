using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Sort
{
    public class SortByNameDesc : IComparer<Content>
    {
        public int Compare(Content x, Content y)
        {
            if (x.Name == null && y.Name == null) return 0;
            else if (x.Name == null) return -1;
            else if (y.Name == null) return 1;
            else return y.Name.CompareTo(x.Name);
        }
    }
}
