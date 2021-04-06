using Core.Entities.Base;

namespace Core.Dto
{
    public class BookSubscriptionDto : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public string Subscribed { get; set; }
    }
}
