using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpiritWorx.Utility;

namespace SpiritWorx.BO
{
    public class SubMenu
    {
        public int Id { get; set; }
        public string SubMenuName { get; set; }
        public string MenuName { get; set; }
        public string MenuLink{ get; set; }
        public int MenuId { get; set; }
        public int DisplayOrder { get; set; }
        public string ListPageHeading { get; set; }
        public string ListPageDescription { get; set; }
        public string AddPageHeading { get; set; }
        public string AddPageDescription { get; set; }
        public bool IsAddPage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString
        {
            get { return CreatedDate.ToString(WebConstant.DateTimeFormat.FormatDate); }
        }
    }
}