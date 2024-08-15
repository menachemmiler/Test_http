using System.ComponentModel.DataAnnotations;

namespace Test_http.Models
{
    public class Rating
    {
        [Key] public int Id { get; set; }

        public Product Product { get; set; }
        public float Rate {  get; set; }

        public int Count {  get; set; }
                

    }
}
