using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFinal.Repository.IRepository
{
    public interface IUnitofWork
    {
        ICategoryRepository Category { get; }
        IGameRepository Game { get; }
        ICommentRepository Comment{ get; }
        void Save();
    }
}
