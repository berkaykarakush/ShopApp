using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class BaseEntity
    {
        public string CreatedDate { get; set; } = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string? UpdatedDate { get; set; }
    }
}
