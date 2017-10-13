﻿using PaymentBLL.Interface;
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

        IPaymentCoreContext context;
        public AdminManager(PaymentCoreContext context)
        {
            this.context = context;
        }
        public BusinessMessage<bool> CreateNewBank(string bankName, string bankCode, string bankId)
        {
            Bank bank = new Bank
            {
                BankName = bankName,
                BankNo = int.Parse(bankId),
                Acronyms = bankCode
            };
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            try
            {
                if (!context.BankDAL.ConfirmBank(bank.BankName, bank.Acronyms))
                {
                    context.BankDAL.Add(bank);
                    if (context.SaveChanges() > 0)
                    {
                        response.Response = ResponseCode.OK;
                        response.Message = string.Format("{0} has been successfully created", bank.BankName);
                        response.Result = true;
                    }
                    else
                    {
                        response.Response = ResponseCode.Error;
                        response.Message = string.Format("The system was unable to complete the operation");
                        response.Result = false;
                    }
                }
                else
                {
                    response.Response = ResponseCode.Error;
                    response.Message = string.Format("Duplicate entry is not allowed ");
                    response.Result = false;
                }
            }
            catch(Exception ex)
            {
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
                response.Result = false;
            }
            return response;
        }
        public BusinessMessage<bool> CreateSchool(string schoolName, string schoolCode)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            try
            {
                if (!context.SchoolDAL.ConfirmSchool(schoolName, schoolCode))
                {
                    School sch = new School();
                    sch.SchoolName = schoolName;
                    sch.SchoolCode = schoolCode;
                    context.SchoolDAL.Add(sch);
                    if (context.SaveChanges() > 0)
                    {
                        response.Response = ResponseCode.OK;
                        response.Message = string.Format("{0} has been successfully created", schoolName);
                        response.Result = true;
                    }
                    else
                    {
                        response.Response = ResponseCode.Error;
                        response.Message = string.Format("The system was unable to complete the operation");
                        response.Result = false;
                    }
                }
                else
                {
                    response.Response = ResponseCode.Error;
                    response.Message = string.Format("Duplicate entry is not allowed ");
                    response.Result = false;
                }
            }
            catch(Exception ex)
            {
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
                response.Result = false;
            }
            return response;
        }

        public BusinessMessage<Bank> GetBankByCode(string bankCode)
        {
            BusinessMessage<Bank> response = new BusinessMessage<Bank>();
            response.Result= context.BankDAL.GetBank(null, bankCode);
            return response;
        }

        public BusinessMessage<Bank> GetBankByName(string bankName)
        {
            BusinessMessage<Bank> response = new BusinessMessage<Bank>();
            response.Result = context.BankDAL.GetBank(bankName,null);
            return response;
        }
        public BusinessMessage<List<Bank>> GetAllBanks()
        {
            BusinessMessage<List<Bank>> response = new BusinessMessage<List<Bank>>();
            response.Result = context.BankDAL.GetAll().ToList();
            return response;
        }

        public BusinessMessage<School> GetSchoolByCode(string schoolCode)
        {
            BusinessMessage<School> response = new BusinessMessage<School>();
            response.Result= context.SchoolDAL.GetSchool(null,schoolCode);
            return response;
        }

        public BusinessMessage<Bank> GetBankById(string Id)
        {
            BusinessMessage<Bank> response = new BusinessMessage<Bank>();
            response.Result = context.BankDAL.GetBankById(Id);
            return response;
        }
    }
}
