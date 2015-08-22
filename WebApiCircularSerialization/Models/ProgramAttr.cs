using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiCircularSerialization.Models
{
    public class ProgramAttr
    {
        public long Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAttr> UserAttrs { get; set; }
    }
}
