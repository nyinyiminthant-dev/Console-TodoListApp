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
        public int taskid { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int status { get; set; }
        public DateTime datetime { get; set; }

    }
}
