using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace WebAPI_Inlämning_1
{
    internal class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } 
        public string  UrlSlug { get; set; }

        public Product()
        {
            
        }


        public List<Category> Categories { get; set; }=  new List<Category>();




    }
}