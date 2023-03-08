
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebFinal;
using WebFinal.Data;
using WebFinal.Models;
using WebFinal.Repository.IRepository;

namespace WebFinal.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private appDbContext _db;
        public GameRepository(appDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Game> GetGameByCategoryId(int id)
        {
            return _db.Games!.Where(c => c.CategoryId == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Game obj)
        {
            var objFromDb = _db.Games.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Publisher = obj.Publisher;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
