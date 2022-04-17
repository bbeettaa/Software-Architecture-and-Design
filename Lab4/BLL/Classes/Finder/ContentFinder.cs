using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Finder
{
    public class ContentFinder : IFindable
    {
        public List<Content> Find(string find, List<Content> contents)
        {
            List<Content> findContent = new List<Content>();
            foreach (var content in contents)
                if (content.IsContain(find))
                    findContent.Add(content);

            return findContent;
        }
    }
}
