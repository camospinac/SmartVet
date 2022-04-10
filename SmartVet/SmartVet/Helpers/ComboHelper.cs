using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartVet.Data;

namespace SmartVet.Helpers
{
    public class ComboHelper : IComboHelper
    {
        private readonly DataContext _context;

        public ComboHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboDocumentTypeAsync()
        {
            List<SelectListItem> list = await _context.DocumentTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "Seleccione tipo de documento...",
                Value = "0"
            });
            return list;
        }


    }
}
