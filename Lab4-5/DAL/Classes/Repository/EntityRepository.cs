using BLL.Classes.BLL.Context;
using BLL.Classes.File;
using DAL.Classes.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Content, ContentDTO>()));
            var index = db.Files.ToList().IndexOf(mapper.Map<ContentDTO>(file));
            var fileDto = db.Files.ToArray()[index];

            try
            {
                db.Files.Remove(fileDto);
                db.SaveChanges();
            }
            catch (System.InvalidOperationException ex) { throw new ArgumentException(ex.Message); }
        }

        public List<Content> Read()
        {

            db.Files.ToList().ForEach(x => System.Diagnostics.Debug.WriteLine(x)) ;
            var l = db.Files.ToList();

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ContentDTO, Content>()));
            var files = mapper.Map<List<Content>>(l);

            return files;
        }

        public void Update(Content file)
        {
            throw new NotImplementedException();
        }

        public void Write(Content file)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Content, ContentDTO>()));
            var fileDT = mapper.Map<ContentDTO>(file);

            db.Files.Add(fileDT);
            db.SaveChanges();

            //System.Diagnostics.Debug.WriteLine(db.Files.ToList());
        }
    }
}