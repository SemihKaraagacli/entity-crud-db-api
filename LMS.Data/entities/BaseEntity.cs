using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = new DateTime();
        public DateTime? LastUpdateDate { get; set; } = new DateTime();
        public bool? IsActive { get; set; }
    }
}
