using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;
    }
    class ProductProgam
    {
        static void Main()
        {
            int n;
            Console.WriteLine("Enter the number of products :");
            n = Convert.ToInt32(Console.ReadLine());
            Product[] products = new Product[n];

            for (int i = 0; i < products.Length; i++)
            {
                products[i] = new Product();
                
                Console.WriteLine("Product ID : ");
                products[i].ProductId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Product Name : ");
                products[i].ProductName = Console.ReadLine();
                Console.WriteLine("Product Price : ");
                products[i].Price = Convert.ToDouble(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    if (products[i].Price > products[j].Price)
                    {
                        Product t=products[i];
                        products[i] =products[j];
                        products[j] =t;
                    }
                }
            }
            Console.WriteLine("\nProducts in ascending order of price : ");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Product id : " + products[i].ProductId + ", product name : " + products[i].ProductName + ", product price : " + products[i].Price);
            }
            Console.ReadLine();
        }
    }
}