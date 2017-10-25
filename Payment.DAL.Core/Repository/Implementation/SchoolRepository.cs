
using Payment.DAL.Core.Model;
using Payment.DAL.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Implementation
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        private DbContext Context;
        public SchoolRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }
        public bool ConfirmSchool(string schoolName, string schoolCode)
        {
            return Context.Set<School>().Any(c=> c.SchoolName.Trim().ToLower() == schoolName.Trim().ToLower() || schoolCode.Trim().ToLower() == schoolCode.Trim().ToLower());
        }
        public School GetSchool(string schoolName, string schoolCode)
        {
            return Context.Set<School>().Where(c => c.SchoolName.Trim().ToLower() == schoolName.Trim().ToLower() || schoolCode.Trim().ToLower() == schoolCode.Trim().ToLower()).FirstOrDefault();

        }
        public School GetDefaultSchool()
        {
            return Context.Set<School>().FirstOrDefault();

        }
    }
}