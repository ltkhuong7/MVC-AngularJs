using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Service;
using DataAccess.Provider;
using Utility;
using DataAccess.Provider.Contract;
using Utility.Contract;
using Moq;
using Business.Service.Contract;
using System.Collections.Generic;

namespace Business.Service.Test
{
    [TestClass]
    public class HtmlStringGoogleServiceTest
    {
        [TestMethod]
        public void ParseCiteElementTest()
        {
            var googleProvider = new Mock<IHtmlStringProvider>();
            googleProvider.Setup(c => c.GetHtmlString(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(GetHtmlStringData());

            var htmlHelper = new Mock<IHtmlStringHelper>();
            htmlHelper.Setup(c => c.ListCiteElement(It.IsAny<string>())).Returns(ListCiteElementData());
            var googleService = new HtmlStringGoogleService(googleProvider.Object, htmlHelper.Object);
            var keywork = "online title search";
            var seUrl = "https://www.google.com.au/search";
            var result = googleService.ParseCiteElement(keywork, seUrl, 10);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void SearchTest()
        {
            var googleProvider = new Mock<IHtmlStringProvider>();
            googleProvider.Setup(c => c.GetHtmlString(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(GetHtmlStringData());

            var htmlHelper = new Mock<IHtmlStringHelper>();
            htmlHelper.Setup(c => c.ListCiteElement(It.IsAny<string>())).Returns(ListCiteElementData());
            htmlHelper.Setup(c => c.FormatSearchResult(It.IsAny<List<string>>(), It.IsAny<string>())).Returns("1, 3");
            var googleService = new HtmlStringGoogleService(googleProvider.Object, htmlHelper.Object);
            var keywork = "online title search";
            var targetSite = "infotrack.com.au";
            var seUrl = "https://www.google.com.au/search";

            var result = googleService.Search(keywork, seUrl, targetSite, 10);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.TotalResultCount == 2);
            Assert.IsTrue(string.Equals(result.Result, "1, 3"));
        }

        [TestMethod]
        public void SearchNotFoundTest()
        {
            var googleProvider = new Mock<IHtmlStringProvider>();
            googleProvider.Setup(c => c.GetHtmlString(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(GetHtmlStringData());

            var htmlHelper = new Mock<IHtmlStringHelper>();
            htmlHelper.Setup(c => c.ListCiteElement(It.IsAny<string>())).Returns(ListCiteElementData());
            htmlHelper.Setup(c => c.FormatSearchResult(It.IsAny<List<string>>(), It.IsAny<string>())).Returns("0");
            var googleService = new HtmlStringGoogleService(googleProvider.Object, htmlHelper.Object);
            var keywork = "online title search";
            var targetSite = "test.com.au";
            var seUrl = "https://www.google.com.au/search";

            var result = googleService.Search(keywork, seUrl, targetSite, 10);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.TotalResultCount == 0);
            Assert.IsTrue(string.Equals(result.Result, "0"));
        }

        private string GetHtmlStringData() {
            var htmlData = "<cite>https://www.infotrack.com.au</cite>" +
                "<cite>https://www.google.com.au</cite>" +
                "<cite>https://www.infotrack.com.au</cite>";

            return htmlData;
        }

        private List<string> ListCiteElementData()
        {
            var cites = new List<string>
            {
                "<cite>https://www.infotrack.com.au</cite>",
                "<cite>https://www.google.com.au</cite>",
                "<cite>https://www.infotrack.com.au</cite>"
            };

            return cites;
        }

        private List<string> ListTargetSiteData()
        {
            var cites = new List<string>
            {
                "<cite>https://www.infotrack.com.au</cite>",
                "<cite>https://www.infotrack.com.au</cite>"
            };

            return cites;
        }
    }
}
