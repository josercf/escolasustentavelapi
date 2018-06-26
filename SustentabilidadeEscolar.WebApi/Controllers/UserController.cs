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
            var currentUser = await user.Find(c => c.Email == model.Email &&
                                                   c.Provider == model.Provider).FirstOrDefaultAsync();

            if (currentUser != null)
                return Ok(currentUser);

            await user.InsertOneAsync(model);
            return Ok(model);
        }

        // POST: User/Create
        [HttpPost]
        [Route("auth/")]
        public async Task<IActionResult> Auth([FromBody]Models.User model)
        {
            var currentUser = await user.Find(c => c.Email == model.Email &&
                                                   c.Password == model.Password)
                                                   .FirstOrDefaultAsync();

            if (currentUser != null)
                return Ok(currentUser);

            return Ok(null);
        }


        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var allPeopleCursor = await user.FindAsync(FilterDefinition<Models.User>.Empty);
            var allPeople = await allPeopleCursor.ToListAsync();
            return Ok(allPeople);
        }
    }
}
