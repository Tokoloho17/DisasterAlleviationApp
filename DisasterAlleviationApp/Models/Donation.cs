
namespace DisasterAlleviationApp.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorName { get; set; } = string.Empty;
        public string ResourceType { get; set; } = string.Empty; // Food, Clothes, Medicine
        public int Quantity { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
