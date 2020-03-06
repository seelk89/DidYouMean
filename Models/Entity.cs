using System;

namespace Models
{
    public class Entity
    {
        public int? InstanceId { get; set; }
        public DateTime? Time { get; set; }
        public string[] Words { get; set; }
    }
}
