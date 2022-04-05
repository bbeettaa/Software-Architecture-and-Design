using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Sort
{
    public class SortByDateAsc : IComparer<Content>
    {
        public int Compare(Content x, Content y)
        {
            if (x.CreateDate == null && y.CreateDate == null) return 0;
            else if (x.CreateDate == null) return -1;
            else if (y.CreateDate == null) return 1;
            else return x.CreateDate.CompareTo(y.CreateDate);
        }
    }
}
