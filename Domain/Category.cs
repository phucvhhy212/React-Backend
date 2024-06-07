namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Book>? Books { get; set; } 
    }
}
