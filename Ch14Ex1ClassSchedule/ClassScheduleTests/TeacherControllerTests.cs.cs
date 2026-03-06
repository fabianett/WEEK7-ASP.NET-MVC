using Moq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;
using ClassSchedule.Controllers;

namespace ClassScheduleTests
{
    public class TeacherControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {

            var repo = new Mock<IRepository<Teacher>>();
            var controller = new TeacherController(repo.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexActionMethod_ModelIsAListOfTeacherObjects()
        {
            var repo = new Mock<IRepository<Teacher>>();
            repo.Setup(r => r.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            var controller = new TeacherController(repo.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Teacher>>(viewResult.Model);
        }
    }
}