using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalManagementSystems.Domain.Dtos.Authentication
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken RefreshToken { get; set; }

     [JsonPropertyName("expiredAt")]

    public DateTime ExpirationTime { get; set; }
    }


}


