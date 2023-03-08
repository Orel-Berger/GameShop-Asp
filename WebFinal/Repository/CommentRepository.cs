
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Models;
using WebFinal.Repository.IRepository;
using WebFinal;
using WebFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace WebFinal.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private appDbContext _db;
        public CommentRepository(appDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public IEnumerable<Comment> GetCommentsByGameId(int id)
        {
            return _db.Comments!.Where(c => c.GameId == id);
        }
        public IEnumerable<Game> TopTwoCommented()
        {
            return _db.Games!.OrderByDescending(a => a.Comments!.Count).Take(2);
        }
        public IEnumerable<Game> Top3Commented()
        {
            return _db.Games!.OrderByDescending(a => a.Comments!.Count).Take(3);
        }
        public IEnumerable<Game> NumOfComment()
        {
            return _db.Games!.OrderByDescending(a => a.Comments!.Count);
        }
    }
}
