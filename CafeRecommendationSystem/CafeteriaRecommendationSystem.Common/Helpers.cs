using Newtonsoft.Json;

namespace CafeteriaRecommendationSystem.Common
{
    public static class Helpers
    {
        public static string SerializeObjectIgnoringCycles(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() }
            };
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }
    }
}
