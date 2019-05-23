using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataModel
{
    public class BDMMenus
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuName { get; set; }

        [StringLength(100)]
        public string MenuIcon { get; set; }

        [StringLength(500)]
        public string MenuLink { get; set; }

        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public bool Status { get; set; }
    }
}
