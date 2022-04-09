using SmartVet.Data.Entities;
using SmartVet.Enums;
using SmartVet.Helpers;

namespace SmartVet.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckAnimalSpecieTypeAsync();
            await CheckAnimalBreedTypeAsync();
            await CheckDocumentTypeTypeAsync();
            await CheckProcedureTypeAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1193410704", "Camilo", "Ospina", "camospinac@yopmail.com", "302 4042842", "Calle 22 #12-59", UserType.Admin);
            await CheckUserAsync("39620351", "Miryam", "Cruz Torres", "miryamcruzt@yopmail.com", "316 8242064", "Calle 21 #14-54", UserType.User);
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,  
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address, 
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckProcedureTypeAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Name = "Cirugía General", Description = "Se realiza extracción de organo con falencia.", Price = 3400000 });
                _context.Procedures.Add(new Procedure { Name = "Esterilización", Description = "Se realiza esterilización de manera exitosa.", Price = 98000 });
                _context.Procedures.Add(new Procedure { Name = "Peluquería", Description = "Se realiza el corte de pelo a la mascota.", Price = 45000 });
                _context.Procedures.Add(new Procedure { Name = "Vacuna Antirrábica", Description = "Se realiza vacunación contra la rabia.", Price = 28500 });
                _context.Procedures.Add(new Procedure { Name = "Desparasitación", Description = "Se realiza desparasitación a la mascota.", Price = 34400 });
                _context.Procedures.Add(new Procedure { Name = "Baño", Description = "Se realiza baño y estética a la mascota.", Price = 25600 });
                _context.Procedures.Add(new Procedure { Name = "Transfusión de sangre", Description = "Se realiza transfusión de sangre.", Price = 455900 });
                _context.Procedures.Add(new Procedure { Name = "Consulta General", Description = "Se realiza consulta general.", Price = 20000 });
                _context.Procedures.Add(new Procedure { Name = "Laboratorio clínico", Description = "Se realiza exámenes de laboratorio.", Price = 35700 });
                _context.Procedures.Add(new Procedure { Name = "Ecografía", Description = "Se realiza ecografía a la mascota.", Price = 67000 });
                _context.Procedures.Add(new Procedure { Name = "Hospitalización", Description = "Se realiza la hospitalización de la mascota.", Price = 122500 });
                _context.Procedures.Add(new Procedure { Name = "Etología", Description = "Se realiza análisis de comportamiento a la mascota.", Price = 36000 });
                _context.Procedures.Add(new Procedure { Name = "Entrenamiento Canino", Description = "Se realiza sesión de adiestramiento.", Price = 400000 });
                _context.Procedures.Add(new Procedure { Name = "Inyectología", Description = "Se realiza servicio de inyectología.", Price = 12000 });
                _context.Procedures.Add(new Procedure { Name = "Curación", Description = "Se realiza curación a la mascota.", Price = 11800 });
                _context.Procedures.Add(new Procedure { Name = "Hospitalización estado Crítico", Description = "Se realiza hospitalización UCI.", Price = 455000 });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypeTypeAsync()
        {
            if (!_context.AnimalBreeds.Any())
            {
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Pastor Aleman" });
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Beagle" });
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Chihuahua" });
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Criollo" });
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Mastín" });
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Siamés" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAnimalBreedTypeAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Name = "Cédula de Ciudadanía" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Cédula de Extranjería" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Pasaporte" });
                _context.DocumentTypes.Add(new DocumentType { Name = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Name = "PEP" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAnimalSpecieTypeAsync()
        {
            if (!_context.AnimalSpecies.Any())
            {
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Felino" });
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Canino" });
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Equino" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
