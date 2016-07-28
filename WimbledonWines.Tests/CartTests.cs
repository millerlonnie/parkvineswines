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
        public void Can_Add_New_Lines()
        {

        //Arrange - create some test products/wines

            Wine p1 = new Wine { Id = 1, Name = "P1" };
            Wine p2 = new Wine { Id = 2, Name = "P2" };

        //Arange -create a new cart

            Cart target = new Cart();

        //Act
           // target.AddItem(p1, 1);
           // target.AddItem(p2, 1);
           /// CartLine[] results = target.Lines.ToArray();




        }




    }
}
