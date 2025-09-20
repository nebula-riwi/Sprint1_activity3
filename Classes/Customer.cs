namespace RiwiMusic.Classes
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public List<Ticket> BuyRecord { get; set; } = new List<Ticket>();

        public Customer() { }
    }
}