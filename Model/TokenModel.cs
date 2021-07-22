using System;
using System.Collections.Generic;

namespace expertglobal.Model
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Exp { get; set; }
        public string User { get; set; }
        public List<String> Roles { get; set; }
    }
}
