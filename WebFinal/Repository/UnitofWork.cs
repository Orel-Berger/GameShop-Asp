
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Data;
using WebFinal.Repository.IRepository;

namespace WebFinal.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private appDbContext _db;
        public UnitofWork(appDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Game = new GameRepository(_db);
            Comment = new CommentRepository(_db);
        }
        public ICategoryRepository Category { get;private set; }     
        public IGameRepository Game { get; private set;}
        public ICommentRepository Comment { get; private set; }
        public void Save()
        {
           _db.SaveChanges();
        }

    }
}
