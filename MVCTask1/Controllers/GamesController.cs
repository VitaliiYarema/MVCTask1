using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCTask1.Models;
using MVCTask1.DAL;

namespace MVCTask1.Controllers
{
    public class GamesController : ApiController
    {
        //private MVCTask1Context db = new MVCTask1Context();

        //private IGameRepository gameRepository;

        private UnitOfWork unitOfWork = new UnitOfWork();

        public GamesController()
        {
            //this.gameRepository = new GameRepository(new MVCTask1Context());
        }

        //public GamesController(IGameRepository gameRepository)
        //{
        //    this.gameRepository = gameRepository;
        //}

        // GET: api/Games
        public IEnumerable<Game> GetGames()
        {
            //return db.Games;
            //return gameRepository.GetGames();
            return unitOfWork.GameRepository.Get(includeProperties: "Game");
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(int id)
        {
            //Game game = db.Games.Find(id);
            //Game game = gameRepository.GetGames().Where(r => r.Id == id).SingleOrDefault();
            Game game = unitOfWork.GameRepository.Get(includeProperties: "Game").Where(r => r.Id == id).SingleOrDefault();
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}