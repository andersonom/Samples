using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileContent.API.Controllers;
using AgileContent.Core;
using System;
using Microsoft.AspNetCore.Mvc;

namespace AgileContent.Tests
{
    [TestClass()]
    public class AgileContentTests
    {
        Sibling _sibling;
        CdnConverterController _apiCDNController;

        public AgileContentTests()
        {
            _sibling = new Sibling();
            _apiCDNController = new CdnConverterController(null, new CDN());
        }

        [TestMethod()]
        public void SiblingsTest()//Ex 1
        {
            Assert.AreEqual(_sibling.GetBiggestSibling(355), 553);
            Assert.AreEqual(_sibling.GetBiggestSibling(213), 321);
            Assert.AreEqual(_sibling.GetBiggestSibling(553), 553);
            Assert.AreEqual(_sibling.GetBiggestSibling(-10), 0);
            Assert.AreEqual(_sibling.GetBiggestSibling(100000001), -1);
            Assert.AreEqual(_sibling.GetBiggestSibling(100000000), 100000000);
        }

        [TestMethod()]
        public void CDNAPITest()//Ex 2
        {
            var result = _apiCDNController.Post("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\AgileContentCDN.txt") 
                as OkResult;            
            Assert.IsNotNull(result);
        }
    }
}