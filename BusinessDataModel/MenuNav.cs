using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpiritWorx.Utility;

namespace SpiritWorx.BO
{
    public class MenuNav
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString
        {
            get { return CreatedDate.ToString(WebConstant.DateTimeFormat.FormatDate); }
        }
    }
}