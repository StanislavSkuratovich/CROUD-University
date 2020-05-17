using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using University.DI;
using University.VewModels;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private const string AllGroupTrigger = "Show All";
        private readonly IUnitOfWork _unitOfWork;


        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            
            return View();
        }



        private StudentIndexViewModelWithGroups BuildFilledStudentViewModel()// i could try to fake it
        {
            var newModel = new StudentIndexViewModelWithGroups
            {
                Students = _unitOfWork.Students.GetAll(),
                Groups =  _unitOfWork.Groups.GetAll()
            };
            

            return newModel;
        }

        public ActionResult GetStudents()
        {
            var model = BuildFilledStudentViewModel();

            return View(model);
        }

        public PartialViewResult GetStudentsData(StudentIndexViewModelWithGroups inputViewModel)
        {
            var outputModel = BuildFilledStudentViewModel();
            if (inputViewModel.GroupAsName == null || inputViewModel.GroupAsName == "All")

            {
                return PartialView(outputModel);
            }

            outputModel.Students = _unitOfWork.Students.GetAll().Where(i => i.Group.Name == inputViewModel.GroupAsName).ToList();

            return PartialView(outputModel);
        }

        public ActionResult New()
        {
            var groups = _unitOfWork.Groups.GetAll().ToList();
            var newStudentModel = new StudentFormViewModel
            {
                Groups = groups
            };
            return View(newStudentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StudentFormViewModel newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View(viewName: nameof(New), new StudentFormViewModel 
                    { Groups = _unitOfWork.Groups.GetAll().ToList(), Student = newStudent.Student });
            }
            _unitOfWork.Students.Add(newStudent.Student);
            _unitOfWork.Complete();
            return RedirectToAction(actionName: nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var studentInDb = _unitOfWork.Students.Get(id);
            if (null == studentInDb)
            {
                return HttpNotFound();
            }
            _unitOfWork.Students.Remove(studentInDb);
            _unitOfWork.Complete();
            return Redirect(Request.UrlReferrer?.AbsolutePath);
        }

        public ActionResult Details(int id= 1)
        {
            var student = _unitOfWork.Students.Get(id);
            if (null != student)
            {
                return View(student);
            }
            return new HttpNotFoundResult();
        }

        public ActionResult Edit(int id=1)
        {
            var student = _unitOfWork.Students.Get(id);
            if (null == student)
            {
                return HttpNotFound();
            }
            var viewModel = new StudentFormViewModel
            {
                Groups = _unitOfWork.Groups.GetAll().ToList(),
                Student = student
            };
            return View(nameof(New), viewModel);
            
        }
    }
}