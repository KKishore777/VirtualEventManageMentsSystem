using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Column("Emailid")]
        [Key]
        [Required, StringLength(50)]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmailId { get; set; }

        [Column("UserName")]
        [Required, StringLength(100 ,MinimumLength =1)]
        public string UserName { get; set; }

        [Column("Role")]
        [Required]
        public string Role { get; set; } // Admin / Participant

        [Column("Password")]
        [Required, StringLength(20, MinimumLength = 6)]
        public string password { get; set; }
    }
}
