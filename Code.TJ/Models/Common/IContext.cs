using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.TJ.Models.Common
{
    public interface IContext
    {
        IQueryable<T> GetEntities<T>() where T : EntityBase;
        int SaveChanges();
        void Add<T>(T enttiy) where T : EntityBase;
    }
}
