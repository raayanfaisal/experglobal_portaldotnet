using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class Inquery
    {
        [Key]
        public int Id { get; set; }
        public string IDard { get; set; }
        public string Discription { get; set; }
        public DateTime Date { get; set; }
        public string AssignTo { get; set; }
        public string CustomertStatus { get; set; }
        public string InquStatus { get; set; }
        public string Action { get; set; }
        public bool Active { get; set; }
        public string CustomerName { get; set; }
    }
}
