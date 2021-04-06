using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class BookRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
