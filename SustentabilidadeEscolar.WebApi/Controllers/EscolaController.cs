using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace SustentabilidadeEscolar.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EscolaController : Controller
    {
        private readonly IMongoCollection<Models.Activity> place;

        public EscolaController(MongoClient client)
        {
            var database = client.GetDatabase("appsustentabilidadeescolar");
            place = database.GetCollection<Models.Activity>(nameof(place));
        }

        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Models.Activity model)
        {
            try
            {
                await place.DeleteOneAsync(c => c.Key == model.Key);

                await place.InsertOneAsync(model);
                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllPlaces()
        {
            var allPlacesCursor = await place.FindAsync(FilterDefinition<Models.Activity>.Empty);
            var allPlaces = await allPlacesCursor.ToListAsync();
            return Ok(allPlaces);
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var allPlacesCursor = await place.FindAsync(model => model.Key == key);
            var allPlaces = await allPlacesCursor.ToListAsync();
            return Ok(allPlaces.FirstOrDefault());
        }
    }
}
