using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.FileFound
{
    public class FileFinder : IFileFinder
    {
        public List<Content> ContentFound()
        {
            List<Content> contents = new List<Content>();
            DirectorySearcher(new DirectoryInfo(@"C:\Users\bedu_s_bashkoy\Desktop\Новая папка (2)"),contents);
            return contents;
        }

        private void DirectorySearcher(DirectoryInfo currDir,List<Content> contents) {
            DirectoryInfo[] dirs = currDir.GetDirectories();
            FileInfo[] files = currDir.GetFiles();
            foreach (var file in files)
                contents.Add(CreateContent(file));
            
            foreach (var dir in dirs) {
                DirectorySearcher(dir, contents);
            }
        }

        private Content CreateContent(FileInfo file) {
            Content content = new Content(file.Name,file.Extension,file.DirectoryName,file.CreationTime);
            return content;
        }
    }
}
