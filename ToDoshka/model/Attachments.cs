using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoshka.Model
{
    public class Attachments
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? TaskID { get; set; }
        public int? SubtaskID { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        [StringLength(100)]
        public string FilePath { get; set; }
        public byte[] File { get; set; }

        public virtual Subtasks Subtasks { get; set; }
        public virtual Tasks Tasks { get; set; }
        public virtual Users Users { get; set; }
    }
}
