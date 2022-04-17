using BLL.Classes.BLL.Context;
using BLL.Classes.File;
using DAL.Classes.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.Repository
{
    public class EntityRepository : IRepositoryContext
    {
        ContentContext db;
        public EntityRepository()
        {
            db = new ContentContext();
        }

        public void Delete(Content file)
        {
            try
            {
                db.Files.Remove(file);
                db.SaveChanges();
            }
            catch (System.InvalidOperationException ex) { throw new ArgumentException(ex.Message); }
        }

        public List<Content> Read()
        {
            var l = db.Files.ToList();
            return l;
        }

        public void Update(Content file)
        {
            throw new NotImplementedException();
        }

        public void Write(Content file)
        {
            db.Files.Add(file);
            db.SaveChanges();
        }
    }
}
