using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Staff { get; set; }
        public string Action { get; set; }
        public string Task { get; set; }
    }
}
