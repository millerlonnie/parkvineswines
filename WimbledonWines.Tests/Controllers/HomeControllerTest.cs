using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WimbledonWines;
using WimbledonWines.Controllers;
using WimbledonWines.Models;
using WimbledonWines.HtmlHelpers;
//using WimbledonWines.HtmlHelpers;

namespace WimbledonWines.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        


        [TestMethod]
        public void Can_Paginate()
        {

          //////////


        }

        [TestMethod]
        public void can_Generate_Page_Links()
        {
            //define an html helper so as to apply the extrension method
            HtmlHelper myHelper = null;

            //Arange - create pagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage =2,
                TotalItems =28,
                ItemsPerPage= 10

            };

            //Arange -set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(@"<a class="" btn btn-default "" href= ""Page1"">1</a>"
             + @"<a class="" btn btn-default btn-primary selected"" href=""Page2"">2 </a>)"
             + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
             result.ToString());

            


        }

        [TestMethod]
        public void Can_Filter_Products()
        {

            
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange

           
        }

        



    }
}
