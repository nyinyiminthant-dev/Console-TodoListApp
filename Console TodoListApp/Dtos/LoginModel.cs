using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_TodoListApp.Dtos
{
    [Table("Login_Tbl")]
    public class LoginModel
    {
        [Key]
        public int loginid { get; set; }
        public string? emali { get; set; }
        public string? password { get; set; }
    }
}
