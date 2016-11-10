using BDSA2016.Lecture08.Web.Controllers;
using BDSA2016.Lecture08.Web.Models;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2016.Lecture08.Web.Tests
{
    public class StudiesControllerTests
    {
        [Fact]
        public async Task Post_when_not_ModelState_IsValid_returns_BadRequest()
        {
            var controller = new StudiesController(null);
            controller.ModelState.AddModelError("", "");

            var study = new StudyDTO();

            var result = await controller.Post(study);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_when_not_ModelState_IsValid_does_not_call_repository()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);
            controller.ModelState.AddModelError("", "");

            var study = new StudyDTO { Name = "Name" };

            await controller.Post(study);

            repository.Verify(r => r.CreateAsync(study), Times.Never);
        }

        [Fact]
        public async Task Post_calls_repository_Create()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            var study = new StudyDTO { Name = "Name" };

            await controller.Post(study);

            repository.Verify(r => r.CreateAsync(study), Times.Once);
        }

        [Fact]
        public async Task Post_when_valid_returns_Created()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            var study = new StudyDTO { Name = "Name" };

            var result = await controller.Post(study);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Post_when_valid_returns_study_with_new_id()
        {
            var study = new StudyDTO { Name = "Name" };
            var repository = new Mock<IStudyRepository>();
            repository.Setup(r => r.CreateAsync(study)).ReturnsAsync(42);
            var controller = new StudiesController(repository.Object);

            var result = await controller.Post(study) as CreatedAtActionResult;
            var created = result.Value as StudyDTO;

            Assert.Equal(42, created.Id);
        }

        [Fact]
        public async Task Post_when_valid_returns_Get_action()
        {
            var study = new StudyDTO { Name = "Name" };
            var repository = new Mock<IStudyRepository>();
            repository.Setup(r => r.CreateAsync(study)).ReturnsAsync(42);
            var controller = new StudiesController(repository.Object);

            var result = await controller.Post(study) as CreatedAtActionResult;

            Assert.Equal("Get", result.ActionName);
            Assert.Null(result.ControllerName); // null means current controller
            Assert.Equal(42, result.RouteValues["id"]);
        }

        [Fact]
        public void Get_returns_repository_Read()
        {
            var repository = new Mock<IStudyRepository>();
            var studies = new HashSet<StudyDTO>().AsQueryable();
            repository.Setup(r => r.Read()).Returns(studies);
            var controller = new StudiesController(repository.Object);

            var result = controller.Get();

            Assert.Same(studies, result);
        }

        [Fact]
        public async Task Get_invalid_id_returns_NotFound()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            var result = await controller.Get(42);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_valid_id_returns_Ok()
        {
            var repository = new Mock<IStudyRepository>();
            repository.Setup(r => r.FindAsync(42)).ReturnsAsync(new StudyDTO());
            var controller = new StudiesController(repository.Object);

            var result = await controller.Get(42);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_42_returns_repository_FindAsync_42()
        {
            var repository = new Mock<IStudyRepository>();
            var study = new StudyDTO { Id = 42 };
            repository.Setup(r => r.FindAsync(42)).ReturnsAsync(study);
            var controller = new StudiesController(repository.Object);

            var result = await controller.Get(42) as OkObjectResult;

            Assert.Same(study, result.Value);
        }

        [Fact]
        public async Task Delete_calls_repository_Delete()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            await controller.Delete(42);

            repository.Verify(r => r.DeleteAsync(42), Times.Once);
        }

        [Fact]
        public async Task Put_when_not_ModelState_IsValid_does_not_call_repository()
        {
            var study = new StudyDTO { Id = 42, Name = "Name" };
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);
            controller.ModelState.AddModelError("", "");

            await controller.Put(42, study);

            repository.Verify(r => r.UpdateAsync(study), Times.Never);
        }

        [Fact]
        public async Task Put_when_not_ModelState_IsValid_returns_BadRequest()
        {
            var study = new StudyDTO { Id = 42 };
            var controller = new StudiesController(null);
            controller.ModelState.AddModelError("", "");

            var result = await controller.Put(42, study);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_when_repository_Update_returns_false_returns_NotFound()
        {
            var study = new StudyDTO { Id = 42, Name = "Name" };
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            var result = await controller.Put(42, study);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Put_when_repository_Update_returns_true_returns_NoContent()
        {
            var study = new StudyDTO { Id = 42, Name = "Name" };
            var repository = new Mock<IStudyRepository>();
            repository.Setup(r => r.UpdateAsync(study)).ReturnsAsync(true);
            var controller = new StudiesController(repository.Object);

            var result = await controller.Put(42, study);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact(DisplayName = "Delete when repo return true return NoContent")]
        public async Task Delete_when_repository_Delete_returns_true_returns_NoContent()
        {
            var repository = new Mock<IStudyRepository>();
            repository.Setup(r => r.DeleteAsync(42)).ReturnsAsync(true);
            var controller = new StudiesController(repository.Object);

            var result = await controller.Delete(42);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_when_repository_Delete_returns_false_returns_NotFound()
        {
            var repository = new Mock<IStudyRepository>();
            var controller = new StudiesController(repository.Object);

            var result = await controller.Delete(42);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
