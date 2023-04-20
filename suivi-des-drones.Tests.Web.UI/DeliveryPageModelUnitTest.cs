using suivi_des_drones.Core.Application.Repositories;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;
using suivi_des_drones.Tests.Web.UI.Fakes;
using suivi_des_drones.Web.UI.Pages;

namespace suivi_des_drones.Tests.Web.UI
{
    public class DeliveryPageModelUnitTest
    {
        [Fact]
        public void ShouldListTwoDeliveries()
        {
            //le pattern 3A
            //Arrange
            var mockLayer=new Moq.Mock<IDeliveryDataLayer>();
            IDeliveryRepository repository = new DeliveryRepository(mockLayer.Object);            
            mockLayer.Setup(item => item.GetAll()).Returns(new List<Delivery>() { new(),new() });
            DeliveryListModel model= new DeliveryListModel(repository);

            //Act
            var result=model.OnGet();
            var list= model.List;

            //Assert
            mockLayer.Verify();
            Assert.IsType<List<Delivery>>(list);
            Assert.NotNull(result);
            Assert.NotNull(list);
            Assert.Equal(2, list.Count);

        }
    }
}