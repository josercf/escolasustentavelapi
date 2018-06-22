using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace SustentabilidadeEscolar.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMongoCollection<Models.User> user;

        public UserController(MongoClient client)
        {
            var database = client.GetDatabase("appsustentabilidadeescolar");
            user = database.GetCollection<Models.User>(nameof(user));
        }

        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Models.User model)
        {
            var builder = Builders<Models.User>.Filter;
            var filter = builder.Lt("Email", model.Email) &
                         builder.Eq("Provider", model.Provider);

            //var filter = Builders<>.Filter.Eq("Email", model.Email);
            var currentUser = await user.Find(filter).FirstOrDefaultAsync();

            if (currentUser != null)
                return Ok(currentUser);

            await user.InsertOneAsync(model);
            return Ok(model);
        }
    }
}
