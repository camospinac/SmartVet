using SmartVet.Data.Entities;

namespace SmartVet.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckAnimalSpecieTypeAsync();
            await CheckAnimalBreedTypeAsync();
            await CheckDocumentTypeTypeAsync();
            await CheckProcedureTypeAsync();
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
                _context.AnimalBreeds.Add(new AnimalBreed { Name = "Pastor Aleman"});
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
           if(!_context.AnimalSpecies.Any())
            {
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Felino" });
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Canino" });
                _context.AnimalSpecies.Add(new AnimalSpecie { Name = "Equino" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
