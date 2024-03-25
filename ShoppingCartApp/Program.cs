using System.Diagnostics;
using System.Globalization;

namespace ShopingCartApp
{

    public enum ProductCategory
    {

        Clothing ,     //Clothings Products
        Electronics ,  //Electronic Products
        Home ,         //Home Products
        Beauty ,       //Beuty Products
        Groceries      //Grocercy Products


    }

    //Base class for all products
    public class Product
    {

        private string name;
        private double price;
        private ProductCategory category;


        public string Name { get => name; }
        public double Price { get => price; }

        public ProductCategory Category {get => category;}

        
        public Product(string name , double price , ProductCategory category)
        {

            this.name = name;
            this.price = price;
            this.category = category;
        }


        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Price: {price} , Category: {category}");
        }

    }


    public class ClothingProduct : Product
    {

        //Fields
        private readonly string size;
        private readonly string colour;

        //Properties
        public string Size { get => size; }
        public string Color { get => colour; }

        //Construvtor 
        public ClothingProduct(string name, double price, ProductCategory category, string size, string colour) : base(name , price , category)
        {

            this.size = size;
            this.colour = colour;

        }

        //Method to get information about the clothing product 
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Size: {size} , Colour: {colour}");
            
        }
    }

    //Derived class for electronics products 
    public class ElectronicsProduct : Product
    {

        //Fields 
        private readonly string brand;
        private readonly string model;

        //Properties 
        public string Brand { get => brand; }
        public string Model { get => model; }

        //Constructor
        public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model):base (name , price , category)
        {
            this.brand = brand;
            this.model = model;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Brand: {brand}, Model: {model}");

        }
    }

    //Class representing a shopping cart 
    public class ShoppingCart
    {

        //Fields
        private Product[] products;
        private int itemCount;

        //Properties
        public Product[] Products { get => products; }
        public int ItemCount { get => itemCount; }


        //Constructor
        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;
        }


        //Method to add a product to the shopping cart
        public void AddProduct(Product Product)
        {
            if(itemCount < products.Length)
            {
                products[itemCount] = Product;
                itemCount++;
                Console.WriteLine($"{Product.Name} added to the cart.");
            }
            else
            {
                Console.WriteLine("The cart is full . Cannot add more items.");
            }
        }


        //Method to remove a product from the shopping cart
        public void RemoveProduct(Product product)
        {
            bool found = false;
            for (int i = 0; i < itemCount;itemCount++)
            {
                if (products[itemCount] == product)
                {
                    for(int j = i;j < itemCount - 1;j++)
                    {
                        products[j] = products[j + 1];
                    }
                    itemCount--;
                    found = true;
                    Console.WriteLine($"{product.Name} removed from the cart.");
                    break;
                }

            }
            if(!found)
            {
                Console.WriteLine("Product not found in shopping cart");
            }
           
        }

    }

    class Program
    {
        static void Main(string[]args)
        {

            Product shirt = new ClothingProductProduct("T-Shirt", 35.00, ProductCategory.Clothing, "M", "Blue");
            Product tv = new ElectronicsProduct("Smart TV" , 600.00 , ProductCategory.Electronics , "Sony", "XBR-9000");)
           

            ShoppingCart cart = new ShoppingCart(5);

            cart.AddProduct(shirt);
            cart.AddProduct(tv);

            cart.RemoveProduct(shirt);
        }
    }

}

