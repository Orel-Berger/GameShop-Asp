
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Models;

namespace WebFinal.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {   
        //IEnumerable<Comment> GetComments();
        IEnumerable<Game> TopTwoCommented();
        IEnumerable<Game> Top3Commented();
        IEnumerable<Comment> GetCommentsByGameId(int id);
        IEnumerable<Game> NumOfComment();
    }
}
