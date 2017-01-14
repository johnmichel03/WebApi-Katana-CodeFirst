using JM.KPMG.PC.Data.Core;
using JM.KPMG.PC.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JM.KPMG.PC.Business
{
    public class ArticleManager : IArticleManager
    {
        public IRepository Repository { get; set; }
        public ArticleManager(IRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Article> GetAllArticle()
        {
            return Repository.Query<Article>(a => true).ToList();
        }

        public Article GetArticleById(int id)
        {
            return Repository.Query<Article>(a => a.Id == id, a => a.Posts).Single();
        }

        public Article CreateArticle(Article article)
        {
            article = Repository.Add<Article>(article);
            Repository.Save();
            return article;
        }

        public Article UpdateArticle(int id, Article article)
        {
            var db = new { article = Repository.Query<Article>(a => a.Id == id, a => a.Posts).Single() };
            // just updated few properties for demo purpose
            db.article.Title = article.Title;
            db.article.Body = article.Body;

            Repository.Save();
            return db.article;
        }
        public void DeleteArticle(int id)
        {
            var article = Repository.Query<Article>(a => a.Id == id, a => a.Posts).Single();
            Repository.Delete<Article>(article);
            Repository.Save();
        }

        public void LikeArticle(int id, bool likeStatus)
        {
            var article = Repository.Query<Article>(a => a.Id == id).FirstOrDefault();
            if (likeStatus == true)
                article.LikeCount = (article.LikeCount ?? 0) + 1;
            else
                article.LikeCount = (article.LikeCount ?? 0) - 1;

            Repository.Save();
        }

        public IEnumerable<Article> GetAllArticleByLike()
        {
            var query = Repository
                .Query<Article>(a => true)
                .Select(sel => new { sel.Id, sel.LikeCount, sel.Title })
                .ToList();
            var articles = new List<Article>();
            foreach (var item in query)
            {
                articles.Add(new Article()
                {
                    Id = item.Id,
                    LikeCount = item.LikeCount ?? 0,
                    Title = item.Title
                });

            }
            return articles;

        }
    }
}
