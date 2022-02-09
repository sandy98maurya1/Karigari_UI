namespace Models
{
    public class AddressRequest
    {
        public int Id { get; set; }
        public string? Village { get; set; }
        public int Taluka { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string? Zip { get; set; }
    }
}