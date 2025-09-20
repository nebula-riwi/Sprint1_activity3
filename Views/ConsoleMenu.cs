using RiwiMusic.Controllers;

namespace RiwiMusic
{
    public class ConsoleMenu
    {
        private FestivalController festivalController;
        private CustomerController customerController;
        private TicketController ticketController;

        public ConsoleMenu()
        {
            festivalController = new FestivalController();
            customerController = new CustomerController();
            ticketController = new TicketController(customerController, festivalController);
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("     🎶 Bienvenido a RiwiMusic 🎶");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Gestión de Conciertos");
                Console.WriteLine("2. Gestión de Clientes");
                Console.WriteLine("3. Gestión de Tiquetes");
                Console.WriteLine("4. Salir");
                Console.WriteLine("==================================");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        FestivalMenu();
                        break;
                    case "2":
                        CustomerMenu();
                        break;
                    case "3":
                        TicketMenu();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("👋 Gracias por usar RiwiMusic.");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción no válida.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void FestivalMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Gestión de Conciertos =====");
            Console.WriteLine("1. Registrar concierto");
            Console.WriteLine("2. Listar conciertos");
            Console.WriteLine("3. Editar concierto");
            Console.WriteLine("4. Eliminar concierto");
            Console.WriteLine("5. Volver");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    festivalController.RegisterFest();
                    break;
                case "2":
                    festivalController.ShowFest();
                    break;
                case "3":
                    festivalController.EditFest();
                    break;
                case "4":
                    festivalController.DeleteFest();
                    break;
                default:
                    Console.WriteLine("↩️ Volviendo al menú principal...");
                    break;
            }
        }

        private void CustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Gestión de Clientes =====");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Editar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Volver");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    customerController.RegisterCust();
                    break;
                case "2":
                    customerController.ShowCust();
                    break;
                case "3":
                    customerController.EditCust();
                    break;
                case "4":
                    customerController.DeleteCust();
                    break;
                default:
                    Console.WriteLine("↩️ Volviendo al menú principal...");
                    break;
            }
        }

        private void TicketMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Gestión de Tiquetes =====");
            Console.WriteLine("1. Registrar compra de tiquete");
            Console.WriteLine("2. Listar tiquetes vendidos");
            Console.WriteLine("3. Editar compra");
            Console.WriteLine("4. Eliminar compra");
            Console.WriteLine("5. Volver");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ticketController.RegisterTicket();
                    break;
                case "2":
                    ticketController.ShowTicket();
                    break;
                case "3":
                    ticketController.EditTicket();
                    break;
                case "4":
                    ticketController.DeleteTicket();
                    break;
                default:
                    Console.WriteLine("↩️ Volviendo al menú principal...");
                    break;
            }
        }
    }
}
