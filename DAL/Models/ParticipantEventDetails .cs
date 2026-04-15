using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ParticipantEventDetails")]
    public class ParticipantEventDetails
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [RegularExpression(pattern:"^[0-9]*$")]
        public int ID { get; set; }

        [Required]
        [Column("EmailId")]
        [StringLength(50)]
        public string EmailId { get; set; }

        // This property fixes the SQL NULL error and CS0117 error
        [Required]
        [Column("UserEmailId")]
        public string UserEmailId { get; set; }


        [ForeignKey("EventId")]
        [Column ("EventId")]
        public int EventId { get; set; }

        [Column("IsAttended")]
        public bool IsAttended { get; set; }

        [ForeignKey("SessionId")]
        [Column("SessionId")]
        public int? SessionId { get; set; }
    }
}
