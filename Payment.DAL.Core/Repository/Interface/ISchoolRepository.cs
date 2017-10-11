using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface ISchoolRepository : IRepository<School>
    {
        bool ConfirmSchool(string schoolName, string schoolCode);
        School GetSchool(string schoolName, string schoolCode);
    }
}
