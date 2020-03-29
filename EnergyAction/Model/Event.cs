using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public long ScheduledTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Location { get; set; }
        [Required]
        [MaxLength(250)]
        public string Members { get; set; }
        [Required]
        [MaxLength(20)]
        public string EventOrganizer { get; set; }
    }
}
