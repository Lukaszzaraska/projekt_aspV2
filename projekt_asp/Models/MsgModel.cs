using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public class MsgModel
    {
        [Key]
        public int MsgId { get; set; }
        public DateTime Date_send { get; set; }
        [MaxLength(100, ErrorMessage = "Too long a message")]
        public string Msg { get; set; }
        public string Login_for { get; set; }
        public bool Msg_readed { get; set; } = false;
        public string Login_from { get; set; }

        public RegisterModel registerModel { get; set; }
    }
}
