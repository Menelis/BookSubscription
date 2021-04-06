using System;

namespace Api.Models.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class BookSubscriptionRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }
    }
}
