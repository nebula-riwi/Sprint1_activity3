namespace RiwiMusic.Classes
{
    public class Ticket
    {
        public int ID { get; set; }
        public int ID_Customer { get; set; }
        public int ID_Festival { get; set; }
        public int Quantity { get; set; }
        public DateTime DateBuy { get; set; }
        public double TotalValue { get; set; }

        public Ticket() { }
    }
}
