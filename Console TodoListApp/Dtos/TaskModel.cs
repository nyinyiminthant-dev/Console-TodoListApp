using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_TodoListApp.Dtos
{
    [Table("Task_Tbl")]
    public class TaskModel
    {
        [Key]
        public int Task_Id { get; set; }
        public string? title { get; set; }
        public DateTime DataTime { get; set; }
        public string? email { get; set; }
    }
}
