
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Models;

namespace WebFinal.Repository.IRepository
{
    public interface IGameRepository : IRepository<Game>
    {
        void Update(Game obj);
        IEnumerable<Game> GetGameByCategoryId(int id);

    }
}
