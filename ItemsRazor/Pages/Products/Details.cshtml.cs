using ItemsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemsRazor.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Context _context;
        public DetailsModel(Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Product product{get;set;}
        public string Title { get; set; } = "Product Details";
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync(int id,string action)
        {
            if (action=="delete")
            {
                Title = "Confirm remove Item?";
            }
            
            product = await _context.Products.FindAsync(id);
            if (product ==null)
            {
                ErrorMessage = "Product Not Found!";
            }
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var item= await _context.Products.FindAsync(product.Id);
            if (item!=null)
            {
                try
                {
                    _context.Products.Remove(item);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Products/Index");

                }
                catch (Exception e)
                {

                    ErrorMessage = e.Message;
                    return Page();
                }
              
            }
           
                ErrorMessage = "Product not found!";
                return Page();
            
          
           


        }
    }
}
