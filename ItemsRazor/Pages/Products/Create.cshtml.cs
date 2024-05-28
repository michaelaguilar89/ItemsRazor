using ItemsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using ItemsRazor.Models;
using Microsoft.EntityFrameworkCore;
using ItemsRazor.Dto_s;

namespace ItemsRazor.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Context _context;

        public CreateModel(Context context)
        {
            _context = context;
        }


        [BindProperty]
        public Product product { get; set; }

      
       
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Model Is Invalid!";
                    return Page();
                }
                var item = await _context.Products.FirstOrDefaultAsync(x => x.Name.Equals(product.Name));
                if (item==null)
                {
                  
                    product.CreationDate = DateTime.Now;
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Products/Index");

                }ErrorMessage = "concurrency error, product name already exists";
                return Page();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
                ErrorMessage = e.Message;
                return Page();
            }
        }
    }
}
