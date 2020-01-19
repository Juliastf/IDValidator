using System;

namespace DTOs
{
    public class RequestDTO
    {
        public string Id { get; set; }
        
        public string EGN { get; set; }

        public bool IsValid { get; set; }

        public string RequestIp { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
