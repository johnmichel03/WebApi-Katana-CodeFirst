using JM.KPMG.PC.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        IArticleRepository Articles { get; }
    }
}
