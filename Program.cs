using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace WebAPI_Inlämning_1
{
    class Program
    {

        static async Task Main(string[] args)
        {




            Menu();





        }

        static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();


                WriteLine("1. Products");
                WriteLine("2. Category");
                WriteLine("3. Exit");



                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        ProductMenu();

                        break;

                    case ConsoleKey.D2:

                        Clear();
                        CategoryMenu();

                        break;

                    case ConsoleKey.D3:

                        Clear();

                        shouldNotExit = false;

                        break;

                    case ConsoleKey.D4:

                        Clear();


                        break;

                    case ConsoleKey.D5:


                        break;




                }

            }
        }


        static void ProductMenu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();

                WriteLine("1. List Products");
                WriteLine("2. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        ListProducts();

                        break;

                    case ConsoleKey.D2:

                        Clear();

                        shouldNotExit = false;

                        break;






                }

            }
        }



        static public void ListProducts()
        {

            Clear();

            Program p = new Program();

            Uri productAPI = new Uri("https://localhost:44373/api/product");

            List<Product> products = p.GetResourceAsync<Product>(productAPI).Result;

            foreach (var product in products)
            {

                Console.WriteLine($"Id {product.Id} | Name {product.Name}");

            }

            Console.WriteLine("View (ID): ");

            int id = Convert.ToInt32(Console.ReadLine());

            Product chosenProduct = products.FirstOrDefault(x => x.Id == id);
            ListProuct(chosenProduct);


        }






        static public async Task ListProuct(Product product)
        {

            Clear();

            Console.WriteLine($"Id {product.Id}");
            Console.WriteLine($"Name {product.Name}");
            Console.WriteLine($"Description {product.Description}");
            Console.WriteLine($"Price {product.Price} kr");
            foreach (var category in product.Categories)
            {
                Console.WriteLine($"{category.Name}");
            }

            ConsoleKeyInfo inputKey;
            bool incorrectKey;
            do
            {

                inputKey = ReadKey(true);

                incorrectKey = !(inputKey.Key == ConsoleKey.Escape);



            } while (incorrectKey);

            ListProducts();

        }


        static void CategoryMenu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();

                WriteLine("1. List Categories");
                WriteLine("2. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        ListCategories();

                        break;

                    case ConsoleKey.D2:

                        Clear();


                        shouldNotExit = false;
                        break;




                }



            }




        }



        static public void ListCategories()
        {

            Clear();

            Program p = new Program();

            Uri productAPI = new Uri("https://localhost:44373/api/category");

            List<Category> categories = p.GetResourceAsync<Category>(productAPI).Result;


            foreach (var category in categories)
            {

                Console.WriteLine($"Id {category.Name} | Name {category.Id}");

            }

            Console.WriteLine("View (ID): ");

            
            int id = Convert.ToInt32(Console.ReadLine());

            Category chosenCategory = categories.FirstOrDefault(x => x.Id == id);
            ListCategory(chosenCategory);


        }


        static public async Task ListCategory(Category category)
        {

            Clear();

            Console.WriteLine($"Id {category.Id}");
            Console.WriteLine($"Name {category.Name}");
            Console.WriteLine($"Image Url {category.ImageUrl}");

            ConsoleKeyInfo inputKey;
            bool incorrectKey;
            do
            {

                inputKey = ReadKey(true);

                incorrectKey = !(inputKey.Key == ConsoleKey.Escape);



            } while (incorrectKey);

            ListProducts();




        }

        public async Task<List<T>> GetResourceAsync<T>(Uri resourceUri)
        {
             HttpClient client = new HttpClient();

             HttpResponseMessage response = await client.GetAsync(resourceUri);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<T> deserializedResource = JsonConvert.DeserializeObject<List<T>>(responseBody);

            return deserializedResource;

        }


    }

}
