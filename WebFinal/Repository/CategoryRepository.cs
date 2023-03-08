
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebFinal.Models;

using WebFinal.Repository.IRepository;
using WebFinal.Data;

namespace WebFinal.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private appDbContext _db;
        public CategoryRepository(appDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }

    }
}
