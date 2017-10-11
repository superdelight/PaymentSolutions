using PaymentBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.DAL.Core.Model;
using Payment.DAL.Core.Repository.Interface;
using Microsoft.Practices.Unity;
using Payment.DAL.Core.Service;
using PaymentBLL.Utility;

namespace PaymentBLL.Implementation
{
    public class AdminManager : IAdminManager
    {

        PaymentCoreContext context = new PaymentCoreContext();
        public bool CreateNewBank(Bank bank)
        {
            if (!context.BankDAL.ConfirmBank(bank.BankName, bank.Acronyms))
            {
                context.BankDAL.Add(bank);
                if(context.SaveChanges()>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CreateSchool(string schoolName, string schoolCode)
        {
            if (!context.SchoolDAL.ConfirmSchool(schoolName, schoolCode))
            {
                School sch = new School();
                sch.SchoolName = schoolName;
                sch.SchoolCode = schoolCode;
                context.SchoolDAL.Add(sch);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Bank GetBankByCode(string bankCode)
        {
            return context.BankDAL.GetBank(null, bankCode);
        }

        public Bank GetBankByName(string bankName)
        {
            return context.BankDAL.GetBank(bankName,null);
        }

        public School GetSchoolByCode(string schoolCode)
        {
            return context.SchoolDAL.GetSchool(null,schoolCode);
        }
    }
}
