using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiCircularSerialization.Models
{
    public class UserAttr
    {
        public long Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public virtual ICollection<ProgramAttr> ProgramAttrs { get; set; }
    }
}
