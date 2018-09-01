using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoubleDriver.Models
{
    public class BunqUser
    {
        [Key]
        public int Id { get; set; }
        public int user_id { get; set; }
        public string user_public_key { get; set; }
        public string user_private_key { get; set; }
        public string server_public_key { get; set; }
        public string token { get; set; }

    }
}
