using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("EventDetails")]
    public class EventDetails
    {
        [Column("EventId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(pattern: "^[0-9]*$")]
        public int EventId { get; set; }

        [Column("EventName")]
        [Required,StringLength(100,MinimumLength =4)]
        public string EventName { get; set; }

        [Column("EventCategory")]
        [Required, StringLength(50)]
        public string EventCategory { get; set; }

        [Column("EventDate")]
        [Required]
        public DateTime EventDate { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Status")]
        [Required]
        public string Status { get; set; } // Active / Inactive
    }
}
