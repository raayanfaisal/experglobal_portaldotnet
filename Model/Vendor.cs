using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        public string OldKey { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
