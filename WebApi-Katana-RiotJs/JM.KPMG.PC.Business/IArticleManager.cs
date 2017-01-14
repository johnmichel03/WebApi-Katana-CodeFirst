using JM.KPMG.PC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.KPMG.PC.Business
{
    public interface IArticleManager
    {

        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticle();
        Article CreateArticle(Article article);
        Article UpdateArticle(int id, Article article);
        void DeleteArticle(int id);
        void LikeArticle(int id, bool likeStatus);
        IEnumerable<Article> GetAllArticleByLike();

    }
}
