using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class InqueryVendor
    {
        [Key]
        public int  Id { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public Inquery Inquery { get; set; }
        public int InqueryId { get; set; }
    }
}
