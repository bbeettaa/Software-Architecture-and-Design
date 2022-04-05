using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.File
{
    public class Content : IComparable
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

        public Content() : this(null, null, null)
        {
        }

        public Content(String name, String extension, String path) : this(name, extension, path, DateTime.Now)
        {
        }

        public Content(String name, String extension, String path, DateTime dateTime)
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
    }

}

