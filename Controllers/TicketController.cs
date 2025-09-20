using RiwiMusic.Classes;
namespace RiwiMusic.Controllers
{
    public class TicketController
    {
        private List<Ticket> tickets = new List<Ticket>();
        private int nextId = 1;

        private CustomerController customerController;
        private FestivalController festivalController;

        public TicketController(CustomerController custCtrl, FestivalController festCtrl)
        {
            customerController = custCtrl;
            festivalController = festCtrl;
        }

        public void RegisterTicket()
        {
            Console.WriteLine("Clientes disponibles:");
            customerController.ShowCust();

            Console.Write("ID del cliente: ");
            int custId = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Festivales disponibles:");
            festivalController.ShowFest();

            Console.Write("ID del festival: ");
            int festId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cantidad de tiquetes: ");
            int qty = int.Parse(Console.ReadLine() ?? "0");

            var fest = festivalController.GetFestivals().FirstOrDefault(f => f.ID == festId);
            var cust = customerController.GetCustomers().FirstOrDefault(c => c.ID == custId);

            if (fest != null && cust != null && qty > 0 && fest.SelledTickets + qty <= fest.Capacity)
            {
                Ticket ticket = new Ticket()
                {
                    ID = nextId++,
                    ID_Customer = custId,
                    ID_Festival = festId,
                    Quantity = qty,
                    DateBuy = DateTime.Now,
                    TotalValue = qty * fest.TicketPrice
                };

                tickets.Add(ticket);
                fest.SelledTickets += qty;
                cust.BuyRecord.Add(ticket);

                Console.WriteLine("Tiquete registrado con éxito.");
            }
            else
            {
                Console.WriteLine("Error en la compra: revise capacidad, cliente o festival.");
            }
        }

        public void ShowTicket()
        {
            if (tickets.Count == 0)
            {
                Console.WriteLine("No hay tiquetes vendidos.");
                return;
            }

            foreach (var t in tickets)
            {
                Console.WriteLine($"ID: {t.ID} | Cliente: {t.ID_Customer} | Festival: {t.ID_Festival} | Cantidad: {t.Quantity} | Total: {t.TotalValue}");
            }
        }

        public void EditTicket()
        {
            ShowTicket();
            Console.Write("Ingrese el ID del tiquete a editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var ticket = tickets.FirstOrDefault(t => t.ID == id);
                if (ticket != null)
                {
                    Console.Write("Nueva cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int newQty))
                    {
                        ticket.Quantity = newQty;
                        var fest = festivalController.GetFestivals().First(f => f.ID == ticket.ID_Festival);
                        ticket.TotalValue = newQty * fest.TicketPrice;
                        Console.WriteLine("Tiquete editado.");
                    }
                }
                else Console.WriteLine("No se encontró el tiquete.");
            }
        }

        public void DeleteTicket()
        {
            ShowTicket();
            Console.Write("Ingrese el ID del tiquete a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var ticket = tickets.FirstOrDefault(t => t.ID == id);
                if (ticket != null)
                {
                    tickets.Remove(ticket);
                    Console.WriteLine("Tiquete eliminado.");
                }
                else Console.WriteLine("No se encontró el tiquete.");
            }
        }
    }
}

