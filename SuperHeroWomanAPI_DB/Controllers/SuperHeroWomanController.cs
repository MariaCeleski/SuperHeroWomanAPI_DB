using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroWomanAPI_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroWomanController : ControllerBase
    {

        //private static List<SuperHeroWoman> heroes = new List<SuperHeroWoman>
        //    {
        //new SuperHeroWoman{
        //Id = 1,
        //"name" : "Django Girls",
        //"firstName" : "Ola",
        //"lastName" : "SitarskaSendecka",
        //"place" : "Poland",
        //"actions" : "Investment",
        //"localActions" : "Savings"
        //        },

        //new SuperHeroWoman{
        //Id = 2,
        //"name" : "Programa Maria",
        //"firstName" : "Empoderando",
        //"lastName" : "MeninasEMulheres",
        //"place" : "Brazil",
        //"actions" : "Investment",
        //"localActions" : "Stock Exchange"
        //        },

        //new SuperHeroWoman{
        //Id = 3,
        //"name" : "GRACE",
        //"firstName" : "Kalinka Branco",
        //"lastName" : "Maria Lydya Fioravanti",
        //"place" : "Brazil",
        //"actions" : "Investment",
        //"localActions" : "Savings"
        //        },

        //new SuperHeroWoman{
        //Id = 4,
        //"name" : "WoMakersCode",
        //"firstName" : "Cynthia",
        //"lastName" : "Zanoni",
        //"place" : "Brazil",
        //"actions" : "Investment",
        //"localActions" : "Stock Exchange"
        //        }

        //    };
        private readonly DataContext _context;

        public SuperHeroWomanController(DataContext context)
        {
            _context = context;
        }
        //Create endpoints
        [HttpGet]
        public async Task<ActionResult<List<SuperHeroWoman>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroWoman>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroWoman>>> AddHero(SuperHeroWoman hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroWoman>>> UpdateHero(SuperHeroWoman request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;
            dbHero.Actions = request.Actions;
            dbHero.LocalActions = request.LocalActions;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroWoman>>> Delete(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}

    

