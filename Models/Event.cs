using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(150)]
        public string Venue { get; set; } = string.Empty;

        [Range(1, 100000)]
        public int MaximumAttendees { get; set; }
    }
}