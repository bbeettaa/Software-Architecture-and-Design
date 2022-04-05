using BLL.Classes.File;
using DAL.Classes.Context;
using DAL.Classes.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
/*            var s = new EntityRepository();

            var ls= s.Read();
            foreach(var  lss in ls)
            Console.WriteLine(lss.Name);
            foreach (var lss in ls)
                s.Delete(ls[0]);
            
            Console.ReadKey();*/



        }
    }

   /* public class sql
    {
        public void Read()
        {
            using (var db = new ContentContext())
            {
                foreach (var book in db.Files)
                    Console.WriteLine(book.Name);
            }
        }
        public void Delete()
        {
            using (var db = new ContentContext())
            {
                Console.WriteLine(db.Files.ToList()[0].Name + " - deleted");
                db.Files.Remove(db.Files.ToList()[0]);
                db.SaveChanges();
            }
        }

        public void write()
        {
            using (var db = new ContentContext())
            {
                var cc = new Content("123.dat", "dat", "F:\\folder");
                db.Files.Add(cc);
                db.SaveChanges();
            }
        }
    }*/



    /* public class CoC : IComparable
     {
         public int Id { get; set; }
         public String Extension { get; set; }
         public String Name { get; set; }
         public String Path { get; set; }

         protected DateTime Date;
         public DateTime CreateDate
         {
             get { return Date; }
             set { if (value.GetType() == typeof(DateTime)) Date = value; }
         }

         public CoC() : this(null, null, null)
         {
         }
         public CoC(String name, String extension, String path) : this(name, extension, path, DateTime.Now)
         {
         }
         public CoC(String name, String extension, String path, DateTime dateTime)
         {
             Extension = extension;
             Name = name;
             Path = path;
             CreateDate = dateTime;
         }
         public override int GetHashCode()
         {
             return Extension.GetHashCode() + Name.GetHashCode() + Path.GetHashCode();
         }

         public int CompareTo(object obj)
         {
             return this.GetHashCode().CompareTo(obj.GetHashCode());
         }
     }*/
    /*    public class ContentContext1 : DbContext
        {
            public ContentContext1() : base("Newmy") { }
            public DbSet<Content> Files { get; set; }
        }*/



}
