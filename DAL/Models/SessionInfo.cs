using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("SessionInfo")]
    public class SessionInfo
    {
        [Column("SessionId ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(pattern: "^[0-9]*$")]
        public int SessionId { get; set; }

        [ForeignKey("EventId")]
        [Column("EventId")]
        public int EventId { get; set; }

        [Column("SessionTitle")]
        [Required , StringLength(50)]
        public String SessionTitle { get; set; }

        [ForeignKey("SpeakerId")]
        [Column("SpeakerId")]
        public int? SpeakerId { get; set; }

        [Column("Description ")]
        public string Description { get; set; }

        [Column("SessionStart")]
        [Required]
        public DateTime SessionStart { get; set; }

        [Column("SessionEnd")]
        [Required]
        public DateTime SessionEnd {  get; set; }

        [Column("SessionUrl")]
         public string SessionUrl {  get; set; }
    }
}
