using Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BookSubscription : BaseEntity
    {
        
        public string UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        //public User User { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
        public DateTime SubscriptionDate { get; set; }
    }
}
