using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoshka.Model
{
    public class Subtasks
    {
        public Subtasks()
        {
            this.Attachments = new HashSet<Attachments>();
        }

        [Key]
        public int ID { get; set; }
        public int? TaskID { get; set; }
        public string Subtask { get; set; }
        public bool? isCheck { get; set; }

        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual Tasks Tasks { get; set; }
    }
}
