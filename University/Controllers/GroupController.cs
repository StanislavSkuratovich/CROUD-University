using System.Linq;
using System.Web.Mvc;
using University.DI;
using University.VewModels;

namespace University.Controllers
{
    public class GroupController : Controller
    {
        private UniversityContext _context = new UniversityContext();
        private readonly IUnitOfWork _unitOfWork;

        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Group
        public ActionResult Index()
        {
            var groups = _unitOfWork.Groups.GetAll();
            return View(groups);
        }

        public ActionResult Details(int id=1)
        {            
            var model = new GroupFormViewModel
            {
                Group = _unitOfWork.Groups.Get(id),
                Students = _unitOfWork.Students.GetAll().Where(i => i.GroupId == id)
            };
            if (null == model.Group)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var group = _unitOfWork.Groups.Get(id);
            if (null == group)
            {
                return HttpNotFound();
            }
            var viewModel = new GroupFormCreateModel
            {
                Group = group,
                Courses = _unitOfWork.Courses.GetAll()
            };
            return View(nameof(New), viewModel);
        }

        public ActionResult New()
        {
            var courses = _unitOfWork.Courses.GetAll().ToList();
            var newGroupModel = new GroupFormCreateModel
            {
                Courses = courses
            };
            return View(newGroupModel);
        }

        [HttpPost]
        public ActionResult Save(GroupFormCreateModel newGroup)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(New), new GroupFormCreateModel { Courses = _context.Courses.ToList(), Group = newGroup.Group });
            }
            _unitOfWork.Groups.Add(newGroup.Group);
            _unitOfWork.Complete();
            return RedirectToAction(actionName: nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            var group = _unitOfWork.Groups.Get(id);
            if (null == group)
            {
                return HttpNotFound();
            }
            _unitOfWork.Groups.Remove(group);
            _unitOfWork.Complete();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }

    
}