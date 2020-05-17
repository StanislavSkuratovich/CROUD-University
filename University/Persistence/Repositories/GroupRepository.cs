using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.DI.Repositories;

namespace University.Persistence.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(UniversityContext context) : base(context)
        {
        }
        public override void Add(Group newGroup)
        {
            if (0 == newGroup.Id)
            {
                _context.Set<Group>().Add(newGroup);
            }
            else
            {
                var groupInDb = _context.Set<Group>().Find(newGroup.Id);
                groupInDb.Name= newGroup.Name;
                groupInDb.CourseId = newGroup.CourseId;
            }

        }
    }
}