using System;
using System.Collections.Generic;
using System.Text;

namespace FundAdmin.API.Models
{
    public class Fund
    {
        public Guid FundId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateTime LaunchDate { get; set; }

        public ICollection<Investor> Investors { get; set; }
    }
}
