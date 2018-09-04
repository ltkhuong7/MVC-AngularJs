using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;
using System.Collections.Generic;

namespace Utility.Test
{
    [TestClass]
    public class HtmlStringHelperTest
    {
        [TestMethod]
        public void ListCiteElementTest()
        {
            var htmlHelper = new HtmlStringHelper();
            var result = htmlHelper.ListCiteElement(GetHtmlStringData());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void ListCiteElementNotFoundTest()
        {
            var htmlHelper = new HtmlStringHelper();
            var result = htmlHelper.ListCiteElement("");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FormatSearchResultTest()
        {
            var htmlHelper = new HtmlStringHelper();
            var targetSite = "infotrack.com.au";
            var result = htmlHelper.FormatSearchResult(ListCiteElementData(), targetSite);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Equals(result, "1, 3"));
        }

        [TestMethod]
        public void FormatSearchResultNotFoundTest()
        {
            var htmlHelper = new HtmlStringHelper();
            var targetSite = "test.com.au";
            var result = htmlHelper.FormatSearchResult(ListCiteElementData(), targetSite);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Equals(result, "0"));
        }

        private string GetHtmlStringData()
        {
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
    }
}
