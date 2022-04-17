using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.Context
{
    public class ContentContext : DbContext
    {
        public ContentContext() : base("Contents1") {
            var ensureDLLIsCopied =
                   System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Content> Files { get; set; }
    }
}

