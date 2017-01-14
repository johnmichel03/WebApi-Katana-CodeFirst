using JM.KPMG.PC.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Data.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PCDbContext dbContext;
        private IArticleRepository articleRepository;
        public UnitOfWork(PCDbContext context)
        {
            dbContext = context;
            //Articles = new ArticleRepository(dbContext);
        }


        public IArticleRepository Articles
        {
            get
            {
                if (articleRepository != null)
                    return new ArticleRepository(dbContext);
                else
                    return articleRepository;
            }
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                    dbContext.Dispose();
            }

        }
    }
}
