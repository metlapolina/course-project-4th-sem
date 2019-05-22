using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoshka.Model
{
    public class Users
    {
        public Users()
        {
            this.Attachments = new HashSet<Attachments>();
            this.Tasks = new HashSet<Tasks>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string User { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Contact { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
        public virtual ICollection<Attachments> Attachments { get; set; }
    }
}
