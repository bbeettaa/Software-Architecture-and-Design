using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Sort
{
    public enum SortingOreder { Asc, Desc }
    public class SortByNameAsc : IComparer<Content>
    {
        public int Compare(Content x, Content y)
        {
            if (x.Name == null && y.Name == null) return 0;
            else if (x.Name == null) return -1;
            else if (y.Name == null) return 1;
            else return x.Name.CompareTo(y.Name);
        }

        /*       static public List<Content> SortByName(List<Content> contents)
               {
                   contents.Sort(delegate (Content x, Content y)
                   {
                       if (x.Name == null && y.Name == null) return 0;
                       else if (x.Name == null) return -1;
                       else if (y.Name == null) return 1;
                       else return x.Name.CompareTo(y.Name);
                   });
                   return contents;
               }

               static public List<Content> SortByExtension(List<Content> contents)
               {
                   contents.Sort(delegate (Content x, Content y)
                   {
                       if (x.Extension == null && y.Extension == null) return 0;
                       else if (x.Extension == null) return -1;
                       else if (y.Extension == null) return 1;
                       else return x.Extension.CompareTo(y.Extension);
                   });
                   return contents;
               }

               static public List<Content> SortByCreateDate (List<Content> contents)
               {
                   contents.Sort(delegate (Content x, Content y)
                   {
                       if (x.CreateDate == null && y.CreateDate == null) return 0;
                       else if (x.CreateDate == null) return -1;
                       else if (y.CreateDate == null) return 1;
                       else return x.CreateDate.CompareTo(y.CreateDate);
                   });
                   return contents;
               }*/


    }
}
