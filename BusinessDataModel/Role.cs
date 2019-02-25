using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpiritWorx.Utility;

namespace SpiritWorx.BO
{
    public class Role
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string MenuLink { get; set; }
        public string MenuName { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString
        {
            get { return CreatedDate.ToString(WebConstant.DateTimeFormat.FormatDate); }
        }
    }
}