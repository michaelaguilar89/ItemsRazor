using ItemsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ItemsRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;
        public IndexModel(Context context)
        {
            _context = context;
        }

        public IList<Product> list { get; set; }
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                list = await _context.Products.ToListAsync();
                if (list == null||list.Count==0)
                {
                    ErrorMessage = "Data Not Found,try again later...";
                }
            }
            catch (Exception e)
            {

                ErrorMessage=e.Message;
            }
          
          
        }
    }
}
