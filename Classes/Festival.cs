namespace RiwiMusic.Classes
{
    public class Festival
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public List<string> Artists { get; set; } = new List<string>();
        public DateTime Hour { get; set; }
        public int Capacity { get; set; }
        public string Place { get; set; } = "";
        public string City { get; set; } = "";
        public double TicketPrice { get; set; }
        public int SelledTickets { get; set; } = 0;

        public Festival() { }
    }
};