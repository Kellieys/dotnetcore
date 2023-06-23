using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Test.Models
{
    [Table("Organization")]
    public class Organization
    {
        public Organization()
        {
        }

        public int OrgID { get; set; }
        public string Name { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string Address { get; set; }
        public int Postcode { get; set; }
        public string ContactNo { get; set; }
        public DateTime LastUpdatedDatetime { get; set; }
    }
}