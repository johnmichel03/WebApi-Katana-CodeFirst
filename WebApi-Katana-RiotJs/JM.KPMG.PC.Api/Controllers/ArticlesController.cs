
using JM.KPMG.PC.Business;
using JM.KPMG.PC.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace JM.KPMG.PC.Api.Controllers
{
    [Route("api/Articles")]
    public class ArticlesController : ApiController
    {
        private IArticleManager ArticleManager { get; set; }

        public ArticlesController(IArticleManager articleManager)
        {
            ArticleManager = articleManager;
        }
        // GET api/articles/id 
        [Route("api/Articles/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var article = ArticleManager.GetArticleById(id);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, article);

        }

        // GET api/articles 
        [HttpGet]
        // [Route("users/{id:int}"]
        [Route("api/Articles")]
        public HttpResponseMessage Get()
        {
            var article = ArticleManager.GetAllArticle();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, article);
        }

        // POST api/articles 
        [Route("api/Articles")]
        public HttpResponseMessage Post([FromBody]Article article)
        {
            var db = new
            {
                article = ArticleManager.CreateArticle(article)
            };
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, db.article);
        }

        // PUT api/articles/5 
        [HttpPost]
        [Route("api/Articles/{id:int}")]
        public HttpResponseMessage Post(int id, [FromBody]Article article)
        {
            var db = new
            {
                article = ArticleManager.UpdateArticle(id,article)
            };
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, db.article);
        }

        //// DELETE api/articles/5 
        [HttpGet]
        [Route("api/Articles/DeleteArticle/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            ArticleManager.DeleteArticle(id);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        //[Route("api/Articles/LikeArticle/{id}")]
        [HttpGet]
        [Route("api/Articles/LikeArticle/{id:int}/{likeStatus:bool}")]
        public HttpResponseMessage LikeArticle(int id, bool likeStatus)
        {
            ArticleManager.LikeArticle(id, likeStatus);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Articles/GetAllArticleByLike")]
        public HttpResponseMessage GetAllArticleByLike()
        {
            var article = ArticleManager.GetAllArticleByLike();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, article);
        }
    }
}
