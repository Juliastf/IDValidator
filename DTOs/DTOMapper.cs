using IDValidator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public static class RequestDTOMapper
    {
        public static Request MapRequestDTOToRequest(this RequestDTO requestDTO)
        {
            var request = new Request();
            request.EGN = requestDTO.EGN;
            request.RequestIp = requestDTO.RequestIp;
            return request;
        
        }
    }
}
