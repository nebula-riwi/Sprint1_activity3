using RiwiMusic.Classes;
namespace RiwiMusic.Controllers
{
    public class CustomerController
    {
        private List<Customer> customers = new List<Customer>();
        private int nextId = 1;

        public void RegisterCust()
        {
            Customer cust = new Customer();
            cust.ID = nextId++;

            Console.Write("Nombre: ");
            cust.Name = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            cust.Email = Console.ReadLine() ?? "";

            Console.Write("Teléfono: ");
            cust.PhoneNumber = Console.ReadLine() ?? "";

            customers.Add(cust);
            Console.WriteLine("Cliente registrado.");
        }

        public void ShowCust()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            foreach (var c in customers)
            {
                Console.WriteLine($"{c.ID}. {c.Name} - {c.Email} - {c.PhoneNumber}");
            }
        }

        public void EditCust()
        {
            ShowCust();
            Console.Write("Ingrese el ID del cliente a editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cust = customers.FirstOrDefault(c => c.ID == id);
                if (cust != null)
                {
                    Console.Write("Nuevo nombre (enter para mantener): ");
                    string? name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) cust.Name = name;

                    Console.Write("Nuevo email (enter para mantener): ");
                    string? email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email)) cust.Email = email;

                    Console.WriteLine("Cliente editado.");
                }
                else Console.WriteLine("Cliente no encontrado.");
            }
        }

        public void DeleteCust()
        {
            ShowCust();
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cust = customers.FirstOrDefault(c => c.ID == id);
                if (cust != null)
                {
                    customers.Remove(cust);
                    Console.WriteLine("Cliente eliminado.");
                }
                else Console.WriteLine("Cliente no encontrado.");
            }
        }

        public List<Customer> GetCustomers() => customers;
    }
}
