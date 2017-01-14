
using TechTalk.SpecFlow;
using System.Net.Http;
using JM.KPMG.PC.Model;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JM.KPMG.PC.Test.Int.ArticleScenario
{
    [Binding]
    public class ArticelTestSteps : TestBase
    {
        private const string uri = "api/Articles";

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

            var article = new Article
            {
                Title = ScenarioContext.Current["Title"] as string,
                Body = ScenarioContext.Current["Body"] as string,
                AuthourName = ScenarioContext.Current["AuthourName"] as string
            };

            var response = ArticleServer.HttpClient.PostAsJsonAsync<Article>(uri, article).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            article = JsonConvert.DeserializeObject<Article>(json);

            ScenarioContext.Current["ArticleId"] = article.Id;
        }

        [Given(@"I have an (.*)")]
        public void GivenIHaveAn(int articleId)
        {
            ScenarioContext.Current["ArticleId"] = articleId;
        }

        [When(@"I Query the Article Repository")]
        public void WhenIQueryTheArticleRepository()
        {
            var articleId = ScenarioContext.Current["ArticleId"] as int? ?? 0;
            var uri = string.Format("api/Articles/{0}", articleId);
            var response = ArticleServer.HttpClient.GetAsync(uri).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var article = JsonConvert.DeserializeObject<Article>(json);

            ScenarioContext.Current["Article"] = article;
        }

        [Given(@"I have a Article (.*)")]
        public void GivenIHaveAArticle(int id)
        {
            ScenarioContext.Current["ArticleId"] = id;
        }

        [Given(@"I update the Article Welcome(.*),(.*),(.*),(.*)")]
        public void GivenIUpdateTheArticleWelcomeLunchAtCasinoJohn(int id, string title, string body, string authourName)
        {
            ScenarioContext.Current["Title"] = title;
            ScenarioContext.Current["Body"] = body;
            ScenarioContext.Current["AuthourName"] = authourName;
            ScenarioContext.Current["ArticleId"] = id;

            var article = new Article
            {
                Title = ScenarioContext.Current["Title"] as string,
                Body = ScenarioContext.Current["Body"] as string,
                AuthourName = ScenarioContext.Current["AuthourName"] as string
            };

            var updateUri = string.Format("{0}/{1}", uri, ScenarioContext.Current["ArticleId"] ?? 0);
            var response = ArticleServer.HttpClient.PostAsJsonAsync<Article>(uri, article).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            article = JsonConvert.DeserializeObject<Article>(json);

            ScenarioContext.Current["ArticleId"] = article.Id;
        }


        [Then(@"the result should be an Article")]
        public void ThenTheResultShouldBeAnArticle()
        {
            var article = ScenarioContext.Current["Article"] as Article;

            Assert.AreEqual(ScenarioContext.Current["Title"] as string, article.Title, true, "Mismatch in article Title");
            Assert.AreEqual(ScenarioContext.Current["Body"] as string, article.Body, true, "Mismatch in article Body");
            Assert.AreEqual(ScenarioContext.Current["AuthourName"] as string, article.AuthourName, true, "Mismatch in article AuthourName");
        }


        [Given(@"I update the Article (.*),(.*),(.*),(.*)")]
        public void AndIUpdateTheArticle(int id, string title, string body, string authourName)
        {
            ScenarioContext.Current["Id"] = id;
            ScenarioContext.Current["Title"] = title;
            ScenarioContext.Current["Body"] = body;
            ScenarioContext.Current["AuthourName"] = authourName;

            var article = new Article
            {
                Id = ScenarioContext.Current["Id"] as int? ?? 0,
                Title = ScenarioContext.Current["Title"] as string,
                Body = ScenarioContext.Current["Body"] as string,
                AuthourName = ScenarioContext.Current["AuthourName"] as string

            };

            var response = ArticleServer.HttpClient.PostAsJsonAsync<Article>(string.Format("{0}/{1}", uri, id), article).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            article = JsonConvert.DeserializeObject<Article>(json);

            ScenarioContext.Current["ArticleId"] = article.Id;
        }

        [Given(@"I delete the Article (.*)")]
        public void GivenIDeleteTheArticle(int id)
        {
            ScenarioContext.Current["Id"] = id;
        }

        [Then(@"the result should be null")]
        public void ThenTheResultShouldBeNull()
        {
            ScenarioContext.Current["Article"] = null;
        }


    }
}
