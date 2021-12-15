using System;

namespace NaturaApp.Api.Data.Entities
{
    public class UserEvent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
    }
}