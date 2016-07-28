using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using WimbledonWines.Models;
using WimbledonWines.Infrastructure;




namespace WimbledonWines.WebUI.Infrastructure{

    public class NinjectDependencyResolver : IDependencyResolver {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam){

            kernel = kernelParam;
            AddBindings();


        }

        public object GetService(Type serviceType){

            return kernel.TryGet(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            
            //put binidnsg here
 
    
          // Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            /*
           mock.Setup(m => m.Wines).Returns(new List<Wine>{

                new Wine {Name = "Airen", Price=25 },
              new Wine {Name = "Baco Noir", Price= 32},
                new Wine {Name = "Mead", Price= 32}

            });
            kernel.Bind<IProductsRepository>().ToConstant(mock.object);

          */  
            
        }

        

    }
}