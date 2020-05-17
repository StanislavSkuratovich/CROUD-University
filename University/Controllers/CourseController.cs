using System.Web.Mvc;
using University.DI;
using University.VewModels;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        //private UniversityContext _context = new UniversityContext();
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            //_unitOfWork = ninjectKernel.Get<IUnitOfWork>();
            _unitOfWork = unitOfWork;
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = _unitOfWork.Courses.GetAll();
            return View(courses);
        }

        public ActionResult Details(int id=1)
        {
            CouseFormViewModel formModel = new CouseFormViewModel
            {
                Course = _unitOfWork.Courses.Get(id),
                Groups = _unitOfWork.Groups.GetAll()
            };
            if (null == formModel.Course)
            {
                return HttpNotFound();
            }
            return View(formModel);
        }
    }
}