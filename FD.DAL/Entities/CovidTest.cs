using System;
using System.Collections.Generic;
using System.Text;

namespace FD.DAL.Entities
{
    public class CovidTest
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public bool IsLocationSafe { get; set; }
        public string Person { get; set; }
        public string Disease { get; set; }
    }
}
