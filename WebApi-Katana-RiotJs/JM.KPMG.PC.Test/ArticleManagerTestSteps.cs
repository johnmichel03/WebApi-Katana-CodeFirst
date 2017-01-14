using JM.KPMG.PC.Business;
using JM.KPMG.PC.Data.Core.Repository;
using JM.KPMG.PC.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace JM.KPMG.PC.Test
{
    [Binding]
    public class ArticleManagerTestSteps
    {
        [Given(@"I have a Article (.*),(.*),(.*)")]
        public void GivenIHaveAArticleApprisalMeetingAtFoodCourtJohn(string title, string body, string authourName)
        {
            ScenarioContext.Current["Title"] = title;
            ScenarioContext.Current["Body"] = body;
            ScenarioContext.Current["AuthourName"] = authourName;
        }
        
        [Given(@"I Save the Article")]
        public void GivenISaveTheArticle()
        {
           // IArticleManager manager = new ArticleManager();
            var articleManager = new ArticleManager(new Repository());
            var article = articleManager.CreateArticle(new Article
            {
                Title = ScenarioContext.Current["Title"] as string,
                Body = ScenarioContext.Current["Body"] as string,
                AuthourName = ScenarioContext.Current["AuthourName"] as string
            });
           
            ScenarioContext.Current["ArticleId"] = article.Id;
        }

        //[Given(@"I have an (.*)")]
        //public void GivenIHaveAn(int articleId)
        //{
        //    ScenarioContext.Current["ArticleId"] = articleId;
        //}

        [When(@"I Query the Article Repository")]
        public void WhenIQueryTheArticleRepository()
        {
            var articleManager = new ArticleManager(new Repository());

            var articleId = ScenarioContext.Current["ArticleId"] as int?;
            var article = articleManager.GetArticleById(articleId ?? 0);
            ScenarioContext.Current["Article"] = article;
        }
        
        [Then(@"the result should be an Article")]
        public void ThenTheResultShouldBeAnArticle()
        {
            var article = ScenarioContext.Current["Article"] as Article;

            Assert.AreEqual(ScenarioContext.Current["Title"] as string, article.Title, "Mismatch in article Title");
            Assert.AreEqual(ScenarioContext.Current["Body"] as string, article.Body, "Mismatch in article Body");
            Assert.AreEqual(ScenarioContext.Current["AuthourName"] as string, article.AuthourName, "Mismatch in article AuthourName");
        }
    }
}
