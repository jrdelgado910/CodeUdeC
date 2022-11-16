using CodeUdeC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeUdeC.Core.ViewModels
{
    public class EditUserViewModels
    {
       public AppUser User { get; set; }
       public IList<SelectListItem>Roles { get; set; }
    }
}
