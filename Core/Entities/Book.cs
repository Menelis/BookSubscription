using Core.Entities.Base;

namespace Core.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
    }
}
