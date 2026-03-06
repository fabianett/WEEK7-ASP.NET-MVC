using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;

namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            var classRepo = new Mock<IRepository<Class>>();
            var dayRepo = new Mock<IRepository<Day>>();

            var controller = new HomeController(classRepo.Object, dayRepo.Object);

            var result = controller.Index(0);

            Assert.IsType<ViewResult>(result);
        }
    }
}