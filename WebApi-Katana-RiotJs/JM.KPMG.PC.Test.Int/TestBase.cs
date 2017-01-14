using JM.KPMG.PC.Api;
using Microsoft.Owin.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace JM.KPMG.PC.Test.Int
{
    [Binding]
    public class TestBase
    {
        public static TestServer ArticleServer { get; set; }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ArticleServer = TestServer.Create<Startup>();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ArticleServer.Dispose();
        }

        

    }
}
