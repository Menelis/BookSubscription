using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters
{
    /// <summary>
    /// Custom Json Serialization class
    /// </summary>
    public sealed class JsonContentResult : ContentResult
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
