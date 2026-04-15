using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("SpeakersDetails")]
    public class SpeakersDetails
    {

        [Column("SpeakerId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(pattern: "^[0-9]*$")]
        public int SpeakerId { get; set; }

        [Column("SpeakerName")]
        [Required,StringLength(100,MinimumLength =4)]
        public string SpeakerName { get; set; }
    }
}
