using System;
using System.Text.Json.Serialization;

namespace SmallsOnline.IntuneLAPS.Lib.Models.Config
{
    public class LAPSConfig
    {
        public LAPSConfig() {}

        [JsonPropertyName("lapsUri")]
        public Uri LAPSUri { get; set; }

        [JsonPropertyName("maxPasswordAge")]
        public int MaxPasswordAge { get; set; }

        [JsonPropertyName("localAdminUserName")]
        public string LocalAdminUserName { get; set; }
    }
}