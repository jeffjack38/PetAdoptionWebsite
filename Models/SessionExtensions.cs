using Newtonsoft.Json;

namespace PetAdoptionWebsite.Models
{
    public static class SessionExtensions
    {
        // Extension method to set an object in session
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error setting object in session: {ex.Message}");
            }
        }

        // Extension method to get an object from session
        public static T GetObject<T>(this ISession session, string key)
        {
            try
            {
                var value = session.GetString(key);
                return (value == null) ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error getting object from session: {ex.Message}");
                return default(T);
            }
        }
    }
}
