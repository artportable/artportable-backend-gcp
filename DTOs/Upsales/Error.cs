using System.Text.Json.Serialization;

namespace Artportable.API.DTOs.Upsales
{
    public class Error
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }

}