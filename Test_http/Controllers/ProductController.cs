using Microsoft.AspNetCore.Mvc;
using Test_http.Models;


namespace Test_http.Controllers
{

    //  בנית השרת
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController :ControllerBase//מחלקה שאחראית ספיציפית ל-יצירת קונטרולר ל-אי פי אי
    {


         


        //להביא את כל מוצרים שקיימים  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            //Define your baseUrl
            string baseUrl = "https://fakestoreapi.com/products";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    //The HttpResponseMessage which contains status code, and data from response.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Then get the data or content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                //Now log your data in the console
                               
                                return Ok(data);
                            }
                            else
                            {
                                return NoContent();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
                return NoContent();
            }
        }

 



        //[HttpGet("{id}")]
        //public async Task<ActionResult<CoffeeOrder>> GetById(int id)
        //{
        //    var TheOrder = await _firstAspDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        //    if (TheOrder == null)
        //    {
        //        return NotFound($"אין לקוח עם מס' מזהה {id}");//status 404
        //    }
        //    return Ok(TheOrder);//status 200
        //}





        //[HttpPost("Create")]
        //public async Task<ActionResult> CreateCoffeOrder(CoffeeOrder coffeeOrder)
        //{
        //    coffeeOrder.OrderDate = DateTime.Now.AddHours(2);
        //    _firstAspDbContext.Orders.Add(coffeeOrder);
        //    await _firstAspDbContext.SaveChangesAsync();
        //    return Created("api/CoffeeShop/" + coffeeOrder.Id, coffeeOrder); ;//status 201 נוצר בהצלחה והטופס ששלחת הוכנס
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<CoffeeOrder>> UpdaetCoffe(int id, CoffeeOrder coffeeOrder)
        //{
        //    var TheOrder = await _firstAspDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        //    if (TheOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    TheOrder.CustomerName = coffeeOrder.CustomerName;
        //    TheOrder.Quantity = coffeeOrder.Quantity;
        //    TheOrder.CoffeeType = coffeeOrder.CoffeeType;
        //    await _firstAspDbContext.SaveChangesAsync();
        //    return NoContent();//204 ביצענו בהצלחה. אין לנו מה להחזיר לך
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CoffeeOrder>> DeleteCoffe(int id)
        //{
        //    var TheOrder = await _firstAspDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        //    if (TheOrder == null)
        //    {
        //        return NotFound();
        //    }
        //    _firstAspDbContext.Orders.Remove(TheOrder);
        //    await _firstAspDbContext.SaveChangesAsync();
        //    return Ok($"{TheOrder.CustomerName} נמחק בהצלחה");
        //}



    }

}
