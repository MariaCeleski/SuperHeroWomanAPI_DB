using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroWomanAPI_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroWomanController : ControllerBase
    {
         
        private static List<SuperHeroWoman> heroes = new List<SuperHeroWoman>
            {
                new SuperHeroWoman{
                    Id = 1,
                    Name = "Django Girls",
                    FirstName = "Ola",
                    LastName = "SitarskaSendecka",
                    Place = "Poland",
                    Actions = "Investment",
                    LocalActions = "Savings"
                },

                new SuperHeroWoman{
                    Id = 2,
                    Name = "Programa Maria",
                    FirstName = "Empoderando",
                    LastName = "MeninasEMulheres",
                    Place = "Brazil",
                    Actions = "Investment",
                    LocalActions = "Stock Exchange"
                },

                new SuperHeroWoman{
                    Id = 3,
                    Name = "GRACE",
                    FirstName = "Kalinka Branco",
                    LastName = "Maria Lydya Fioravanti",
                    Place = "Brazil",
                    Actions = "Investment",
                    LocalActions = "Savings"
                },

                new SuperHeroWoman{
                    Id = 4,
                    Name = "WoMakersCode",
                    FirstName = "Cynthia",
                    LastName = "Zanoni",
                    Place = "Brazil",
                    Actions = "Investment",
                    LocalActions = "Stock Exchange"
                }

            };
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHeroWoman>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet]
        public async Task<ActionResult<SuperHeroWoman>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroWoman>>> AddHero(SuperHeroWoman hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroWoman>>> UpdateHero(SuperHeroWoman request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Actions = request.Actions;
            hero.LocalActions = request.LocalActions;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroWoman>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }

    }
}

    

