using ContactApp.Models;

namespace ContactApp.Services
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;
        private int _nextId = 1;

        public InMemoryContactRepository()
        {
            _contacts = new List<Contact>();

            var seed = new List<Contact>() 
            {
                new Contact(){FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet.yilmaz@example.com", Phone = "+905551112233", Company = "BTK Akademi", Title = "Yazılım Geliştirme Uzmanı", Notes = ".NET"},
                new Contact(){FirstName = "Ayşe", LastName = "Kaya", Email = "ayse.kaya@example.com", Phone = "+905552223344", Company = "BTK Akademi", Title = "Grafik Tasarım Uzman Yardımcısı", Notes = "Photoshop"},
                new Contact(){FirstName = "Mehmet", LastName = "Olgun", Email = "mehmet.olgun@example.com", Phone = "+905553334455", Company = "BTK Akademi", Title = "Muhasebe Uzmanı", Notes = "Excel"},
                new Contact(){FirstName = "Fatma", LastName = "Kaçar", Email = "fatma.kacar@example.com", Phone = "+905554445566", Company = "BTK Akademi", Title = "Müdür Yardımcısı", Notes = "Contacts"},
                new Contact(){FirstName = "Cemil", LastName = "Şaşmaz", Email = "cemil.sasmaz@example.com", Phone = "+905555556677", Company = "BTK Akademi", Title = "Sekreter", Notes = "Reminder"},
                new Contact(){FirstName = "Hayriye", LastName = "Atan", Email = "hayriye.atan@example.com", Phone = "+905556667788", Company = "BTK Akademi", Title = "Editör", Notes = "Canva"},
                new Contact(){FirstName = "Kerem", LastName = "Duyum", Email = "kerem.duyum@example.com", Phone = "+905557778899", Company = "BTK Akademi", Title = "Kameraman", Notes = "Canon"},
                new Contact(){FirstName = "Ceren", LastName = "Güzel", Email = "ceren.guzel@example.com", Phone = "+905558889900", Company = "BTK Akademi", Title = "Müdür", Notes = "Master"}
            };

            foreach(var c in seed)
            {
                c.Id = _nextId++;
                _contacts.Add(c);
            }
        }

        public Contact Add(Contact contact)
        {
            contact.Id = _nextId++;
            _contacts.Add(contact);
            return contact;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null)
                return false;
            _contacts.Remove(existing);
            return true;
        }

        public IEnumerable<Contact> GetAll() => 
            _contacts
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);

        public Contact? GetById(int id) =>
            _contacts.FirstOrDefault(c => c.Id == id);

        public bool Update(Contact contact)
        {
            var existing = GetById(contact.Id);
            if (existing is null)
                return false;
            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            existing.Company = contact.Company;
            existing.Title = contact.Title;
            existing.Notes = contact.Notes;
            return true;
        }
    }
}
