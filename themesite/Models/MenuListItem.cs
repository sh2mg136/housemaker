using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace themesite.Models
{

    public class MenuListItem
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string CssClass { get; set; }
        public bool IsActive { get; set; }
        public bool IsRootElement { get; set; }
        public bool HasChilds { get; set; }
        public int SortOrder { get; set; }

        public string ElementStyle
        {
            get
            {
                return IsActive ? "active" : "";
            }
        }
    }

}