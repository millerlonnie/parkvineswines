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

namespace WimbledonWines.Tests
{
     
    class CartTests
    {

    [TestMethod]
        public void Can_Add_New_Li()
        {

        //Arrange - create some test products/wines

          //  Wine p1 = new Wine { Id = 1, Name = "WineA" };
         //   Wine p2 = new Wine { Id = 2, Name = "WineB" };

         

        //Act
           Cart target = new Cart ();
        // target.AddItem(p1);
        // target.AddItem(p2, 3);
           /// CartLine[] results = target.Lines.ToArray();




        }

        [TestMethod]
        public void Can_Add_To_Cart()
    {

       // Mock<IProductRespository> mock = new Mock<IProductRespository>;

    }


    }
}
