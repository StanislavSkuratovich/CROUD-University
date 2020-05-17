using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using University;
using University.Controllers;
using System.Web;
using System.Web.Mvc;
using University.VewModels;
using University.DI;
using System.ComponentModel.DataAnnotations;

namespace UniversityUnitTests
{
    [TestFixture]
    public class StudentControllerTests
    {
        [Test]
        public void Save_Student_ReturnRedurrectToAction()
        {
            // Arrange
            var student = new Student { Id = 0, FirstName = "Vasia", LastName = "Pupkin", GroupId = 5 };
            var studentModel = new University.VewModels.StudentFormViewModel { Student = student };
            var fakeUnit = new Mock<IUnitOfWork>();
            fakeUnit.Setup(p => p.Students.Add(student)).Verifiable();
            fakeUnit.Setup(p => p.Complete()).Verifiable();
            var controller = new StudentController(fakeUnit.Object);


            // act
            ActionResult result = controller.Save(studentModel);
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;



            //Assert
            Mock.Verify(fakeUnit);
            Assert.That(result, Is.InstanceOf<RedirectToRouteResult>());
        }

        [Test]
        public void Delete_Student_ReturnRedurrectToAction()
        {
            // Arrange
            var student = new Student { Id = 0, FirstName = "Vasia", LastName = "Pupkin", GroupId = 5 };
            //var studentModel = new University.VewModels.StudentFormViewModel { Student = student };
            var fakeUnit = new Mock<IUnitOfWork>();
            fakeUnit.Setup(p => p.Students.Get(student.Id)).Returns(student);
            //fakeUnit.Setup(p => p.Students.Remove(student)).Verifiable();
            //fakeUnit.Setup(p => p.Complete()).Verifiable();
            //fakeUnit.Setup(p => p.Complete()).Verifiable();
            //fakeUnit.Setup(p => p.Students.Remove(student)).Verifiable();
            //fakeUnit.Setup(p => p.Students.Add(student)).Verifiable();
            //fakeUnit.Setup(p => p.Complete()).Verifiable();
            var controller = new StudentController(fakeUnit.Object);
            


            // act

            ActionResult result = controller.Delete(student.Id);
            //RedirectToRouteResult routeResult = result as RedirectToRouteResult;



            //Assert
            //Mock.Verify(fakeUnit);
            fakeUnit.VerifyAll();
            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }

    }
}
