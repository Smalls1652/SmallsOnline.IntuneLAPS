using System.Text.Json;
using System.Text.Json.Serialization;

using SmallsOnline.IntuneLAPS.Lib.Helpers;

namespace SmallsOnline.IntuneLAPS.Lib.Models.Communication
{
    public class SetPasswordPost
    {
        public SetPasswordPost() {}
        public SetPasswordPost(string computerName, string value)
        {
            ComputerName = computerName;
            Value = value;
        }

        [JsonPropertyName("computerName")]
        public string ComputerName { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public string ToJsonString()
        {
            return JsonConverterHelper.ConvertToJson<SetPasswordPost>(this);
        }
    }
}