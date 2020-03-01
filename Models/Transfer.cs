using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiEFTest.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public int Powwwers { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }

    }
}