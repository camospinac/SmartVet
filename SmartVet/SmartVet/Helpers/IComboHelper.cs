using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartVet.Helpers
{
    public interface IComboHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboDocumentTypeAsync();
    }
}
