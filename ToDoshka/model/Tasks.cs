using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoshka.Model
{
    public class Tasks
    {
        public Tasks()
        {
            Attachments = new HashSet<Attachments>();
            Subtasks = new HashSet<Subtasks>();
        }

        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Task { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? Time { get; set; }
        public int? Importance { get; set; }
        public bool? isWork { get; set; }
        public bool? isCheck { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? CheckTime { get; set; }

        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual ICollection<Subtasks> Subtasks { get; set; }
        public virtual Users Users { get; set; }
    }
}
