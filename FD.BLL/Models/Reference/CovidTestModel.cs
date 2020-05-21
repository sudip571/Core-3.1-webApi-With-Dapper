using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Models.Reference
{
   public  class CovidTestModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public bool IsLocationSafe { get; set; }
        public string Person { get; set; }
        public string Disease { get; set; }
    }
}
