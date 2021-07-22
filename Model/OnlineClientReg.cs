using System;
using System.ComponentModel.DataAnnotations;

namespace expertglobal.Model
{
    public class OnlineClientReg
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        public string CNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
