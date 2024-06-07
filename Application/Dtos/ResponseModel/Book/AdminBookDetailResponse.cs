namespace Application.Dtos.ResponseModel.Book
{
    public class AdminBookDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
