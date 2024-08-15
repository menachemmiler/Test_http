
namespace Test_http.Models
{
    public class Product
    {
        public Product(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string title { get; set; }

        public float price { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public string image { get; set; }

        public Rating rating {  get; set; }

    }
}
