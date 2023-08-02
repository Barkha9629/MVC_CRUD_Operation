using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Db.DbOperations
{
    public class EmployeeRepositary
    {
        //AddData
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new MVCEntities())
            {
                Employee emp = new Employee()
                {
                    Name= model.Name,
                    PhoneNo= model.PhoneNo,
                    EmailId= model.EmailId,
                    Code= model.Code
                };

                if(model.Address!= null)
                {
                    emp.Address = new Address()
                    {
                        Details = model.Address.Details,
                        Country = model.Address.Country,
                        State= model.Address.State
                    };
                }

                context.Employees.Add(emp);

                context.SaveChanges();

                return emp.Id;
            }



        }

        //GetData
        public List<EmployeeModel> GetAllEmployee()
        {
            using (var context = new MVCEntities())
            {
                var Get = context.Employees
                    .Select(x => new EmployeeModel()
                    
                    {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNo= x.PhoneNo,
                    EmailId= x.EmailId,
                    Code= x.Code,
                    AddressId= x.AddressId,
                    Address =  new AddressModel()
                    {
                        AddressId = x.Address.AddressId,
                        State = x.Address.State,
                        Country = x.Address.Country,
                        Details = x.Address.Details
                    }

                }).ToList();


                return Get;
            }



        }

        //GetDataWithParameter
        public  EmployeeModel GetEmployee(int Id)
        {
            using (var context = new MVCEntities())
            {
                
                var Get = context.Employees
                    .Where (x => x.Id == Id)
                    .Select(x => new EmployeeModel()

                    {
                        Id = x.Id,
                        Name = x.Name,
                        PhoneNo = x.PhoneNo,
                        EmailId = x.EmailId,
                        Code = x.Code,
                        AddressId = x.AddressId,
                        Address = new AddressModel()
                        {
                            AddressId = x.Address.AddressId,
                            State = x.Address.State,
                            Country = x.Address.Country,
                            Details = x.Address.Details
                        }

                    }).FirstOrDefault();


                return Get;
            }



        }

        //updateDataWithParameter
        public bool UpdateEmployee(int Id,EmployeeModel model)
        {
            using (var context = new MVCEntities())
            {

                var update = context.Employees
                    .FirstOrDefault(x => x.Id == Id);

                if(update != null)
                {
                    update.Name= model.Name;
                    update.PhoneNo= model.PhoneNo;
                    update.EmailId= model.EmailId;
                    update.Code= model.Code;
                    update.AddressId = model.AddressId;
                  

                }

                context.SaveChanges();
                

                return true;
            }



        }

        //DeleteDataWithParameter
        public bool DeleteEmployee(int Id)
        {
            using (var context = new MVCEntities())
            {

                var Delete = context.Employees
                    .FirstOrDefault(x => x.Id == Id);

                if (Delete != null)
                {

                    context.Employees.Remove(Delete);
                    context.SaveChanges();
                    return true;

                }

                return false;


                
            }



        }



    }
}
