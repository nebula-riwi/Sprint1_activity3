using RiwiMusic.Classes;
namespace RiwiMusic.Controllers
{
    public class FestivalController
    {
        private List<Festival> festivals = new List<Festival>();
        private int nextId = 1;

        public void RegisterFest()
        {
            Festival fest = new Festival();
            fest.ID = nextId++;

            Console.Write("Nombre del festival: ");
            fest.Name = Console.ReadLine() ?? "";

            Console.Write("Artistas (separados por coma): ");
            string? artists = Console.ReadLine();
            fest.Artists = artists?.Split(',').Select(a => a.Trim()).ToList() ?? new List<string>();

            Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
            fest.Hour = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Console.Write("Capacidad: ");
            fest.Capacity = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Lugar: ");
            fest.Place = Console.ReadLine() ?? "";

            Console.Write("Ciudad: ");
            fest.City = Console.ReadLine() ?? "";

            Console.Write("Precio del tiquete: ");
            fest.TicketPrice = double.Parse(Console.ReadLine() ?? "0");

            festivals.Add(fest);
            Console.WriteLine("Festival registrado con éxito.");
        }

        public void ShowFest()
        {
            if (festivals.Count == 0)
            {
                Console.WriteLine("No hay festivales registrados.");
                return;
            }

            foreach (var f in festivals)
            {
                Console.WriteLine($"{f.ID}. {f.Name} - {f.City} - {f.Hour}");
            }
        }

        public void EditFest()
        {
            ShowFest();
            Console.Write("Ingrese el ID del festival a editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var fest = festivals.FirstOrDefault(f => f.ID == id);
                if (fest != null)
                {
                    Console.Write("Nuevo nombre (enter para mantener): ");
                    string? name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) fest.Name = name;

                    Console.Write("Nuevo lugar (enter para mantener): ");
                    string? place = Console.ReadLine();
                    if (!string.IsNullOrEmpty(place)) fest.Place = place;

                    Console.WriteLine("Festival editado.");
                }
                else Console.WriteLine("No se encontró el festival.");
            }
        }

        public void DeleteFest()
        {
            ShowFest();
            Console.Write("Ingrese el ID del festival a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var fest = festivals.FirstOrDefault(f => f.ID == id);
                if (fest != null)
                {
                    festivals.Remove(fest);
                    Console.WriteLine("Festival eliminado.");
                }
                else Console.WriteLine("No se encontró el festival.");
            }
        }

        public List<Festival> GetFestivals() => festivals;
    }
}
