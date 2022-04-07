using BLL.Classes.File;
using BLL.Classes.FileFound;
using BLL.Classes.Memento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.BLL.Context
{
    public class UserContext 
    {
        List<Content> contents;
        CareTaker careTaker;
        protected IRepositoryContext repositoryContext;

        public UserContext(IRepositoryContext repositoryContext, CareTaker careTaker)
        {
            this.repositoryContext = repositoryContext;
            contents = new List<Content>();
            ReadFromRepository();
            this.careTaker = careTaker;
        }

        //Update frome repository
        public void ReadFromRepository()
        {
            this.contents= repositoryContext.Read();
        }



        public List<Content> GetContents()
        {
            return contents;
        }

        public List<String> GetExtensions()
        {
            List<String> extensions = new List<string>();

            foreach (var content in contents)
                if (!extensions.Contains(content.Extension))
                    extensions.Add(content.Extension);
            return extensions;
        }

        public List<Content> Sort(IComparer<Content> comparer)
        {
            if (comparer != null)
                contents.Sort(comparer);
            return contents;
        }

        public void DeleteFile(Content file)
        {
            careTaker.Save(file);
            repositoryContext.Delete(file);
            contents.Remove(file);
        }

        public void CreateFile(String path)
        {
            string fileName = path.Remove(0, path.LastIndexOf("\\") + 1);
            string ext = fileName.Remove(0, fileName.LastIndexOf('.'));

            FileInfo fileInfo = new FileInfo(path);
            using (fileInfo.OpenRead())
            {
                var content = new Content(fileName, ext, path.Replace("\\" + fileName, ""), fileInfo.CreationTime);
                contents.Add(content);
                repositoryContext.Write(content);
            }
        }

        public void AddContent(Content content) {
            contents.Add(content);
        }

        public void Undo() {
            Content content = careTaker.Ubdo();
            if (content != null)
            {
                repositoryContext.Write(content);
                contents.Add(content);
            }
        }

    }
}