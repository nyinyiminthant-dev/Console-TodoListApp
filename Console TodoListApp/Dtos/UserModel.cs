using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Console_TodoListApp.Dtos
{
    [Table("User_Tbl")]

    public class UserModel
    {
        [Key]
        public int userid { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
