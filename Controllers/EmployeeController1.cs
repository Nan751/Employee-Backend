using Microsoft.AspNetCore.Mvc;
using System.Linq;
// using System.Web.Http;
using Emp.Models;

namespace EmpWebApi.Controllers;
[ApiController]
[Route("api/Employee")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeContext DB;

    public EmployeeController(EmployeeContext db)
    {
        this.DB=db;
    }
     [HttpGet("GetAlldetails")]
  public IQueryable<TbEmployee> GetAlldetails()
  { 
        var users = this.DB.TbEmployees;
        return users;
    
  }

    [HttpGet("GetUserDetailsById/{uid}")]
    public IActionResult GetById(int uid)
    {
        var users =this.DB.TbEmployees.FirstOrDefault(o=>o.Id==uid);
       return Ok(users);
    }


    [HttpDelete("DeleteCustomerDetails")]
    public IActionResult DeleteUser(int uid)
    {
        string message = "";
            var user = this.DB.TbEmployees.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            this.DB.TbEmployees.Remove(user);
            int result = this.DB.SaveChanges();
            if (result > 0)
            {
                message = "User has deleted sussfully ";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }
[HttpPost("InsertDetails")]
  public object InsertDetails(Register Reg)
  {
         string message = ""; 

    try
    {
        TbEmployee List = new TbEmployee();
        if(List.Id==0)
        {
            List.Id = Reg.RegId;
            List.EmployeeCode = Reg.RegEmployeeCode;
            List.EmployeeName = Reg.RegEmployeeName;
            List.Ctc = Reg.RegCtc;
            List.Basic = Reg.RegBasic;
            List.Pf = Reg.RegPf;
            List.Medical = Reg.RegMedical;
            List.Telephone = Reg.RegTelephone;
            List.Lta = Reg.RegLta;
            List.Spiallowance = Reg.RegSpiallowance ;

            DB.TbEmployees.Add(List);

              
                    int result = this.DB.SaveChanges();
                    if (result > 0)
                    {
                        message = "User has been sucessfully added";
                    }
                    else
                    {
                        message = "failed";
                    }

                     return Ok(message);
            //Add

            //save it in the database
            DB.SaveChanges();

            return new Response{Status="Success" , Message = "Employee Added!"};

        }
    }
    catch(System.Exception)
    {
          throw;
    }

    return new Response{Status="Error" , Message="Invalid Information"};
  }
[HttpPut]
[Route("UpdateEmployeeDetails")]
public IActionResult putEmployee(Register user)
{
    string message = "";
    if(!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    try{
         TbEmployee obj = new TbEmployee();
        // obj= DB.TbEmployees.Find(user.Id);
        obj = this.DB.TbEmployees.Find(user.RegId);
        if(obj !=null){
             obj.Id=user.RegId;
            obj.EmployeeCode = user.RegEmployeeCode;
            obj.EmployeeName=user.RegEmployeeName;
            obj.Ctc=user.RegCtc;
            obj.Basic=user.RegBasic;
            obj.Pf=user.RegPf;
            obj.Medical=user.RegMedical;
            obj.Telephone=user.RegTelephone;
            obj.Lta=user.RegLta;
            obj.Spiallowance =user.RegSpiallowance ;


        }
        int result=this.DB.SaveChanges();
        if(result>0){
            message="updated";
        }
        else{
            message="failed";
        }
       
    }
    catch(Exception){
        throw;
    }
    return Ok(message);
}





//   [HttpGet]
//   public ActionResult edit(int id)
//   {
//     TbEmployee temp = new TbEmployee();
//     return View(temp.GetAlldetails().Find(euser=>euser.id==i));
//   }
//   [HttpPost]
//   public ActionResult edit(int id)
//   {

//   }
//   public async IQueryable<TbEmployee> Edit(int? id)
// {
//     if(id == null)
//     {
//         return NotFound();
//     }
//     var Employee= await DB.TbEmployees.FindAsync(id);
//     if(Employee == null )
//     {
//         return NotFound();
//     }
//     return View(Employee);
//     }
}