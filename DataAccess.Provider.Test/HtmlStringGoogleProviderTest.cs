using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Provider;
using DataAccess.Provider.Contract;
using Utility;
using Utility.Contract;
using Moq;

namespace DataAccess.Provider.Test
{
    [TestClass]
    public class HtmlStringGoogleProviderTest
    {
        [TestMethod]
        public void GetHtmlStringTest()
        {
            var _htmlStringGoogleProvider = new HtmlStringGoogleProvider();
            var keywork = "online title search";
            var seUrl = "https://www.google.com.au/search";
            var result = _htmlStringGoogleProvider.GetHtmlString(keywork, seUrl, 2);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
