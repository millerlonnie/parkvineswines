using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimbledonWines.Models;
using WimbledonWines.Abstract;
using Ninject;



namespace WimbledonWines.Abstract
{
    interface IProductsRespository
    {

        IEnumerable<Wine> Wines { get; } //allws caller to obtain a sequence of 
        //products without saying how or where data is stored or retrieved


        //maybe add wineries 
    }


}
