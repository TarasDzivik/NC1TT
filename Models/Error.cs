using Newtonsoft.Json;

namespace NC1TestTask.Models
{
    /// <summary>
    /// Object for hendling errors and error messages.
    /// </summary>
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
