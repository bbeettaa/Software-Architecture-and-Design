using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class ContentDTO
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

        public override string ToString()
        {
            return String.Format($"{Id}) {Name} {Extension} {GetHashCode()}");
        }

        public override int GetHashCode()
        {
            return Extension.GetHashCode() + Name.GetHashCode() + Path.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this.GetHashCode().CompareTo(obj.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) != 0 ? false : true;
        }

       // public static ContentDTO operator ==(ContentDTO a, ContentDTO b) => a.CompareTo(b);
        //public static Fraction operator *(Fraction a, Fraction b)

    }
}
