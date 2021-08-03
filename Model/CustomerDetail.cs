using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class CustomerDetail
    {
        [Key]
        public int Id { get; set; }
        public string OldId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
    }
}
