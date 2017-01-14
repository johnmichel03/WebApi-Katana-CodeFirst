using JM.KPMG.PC.Business;
using JM.KPMG.PC.Data.Core;
using JM.KPMG.PC.Data.Core.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace JM.KPMG.PC.Api
{
    public static class UnityConfig
    {
        public static UnityContainer GetContainer()
        {
			var container = new UnityContainer();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IArticleManager, ArticleManager>();
            return container;
        }
    }
}