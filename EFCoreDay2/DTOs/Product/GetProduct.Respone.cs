namespace EFCoreDay2.DTOs
{
    public class GetProductRespone
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacture { get; set; }
        public int CategoryId { get; set; }
    }
}