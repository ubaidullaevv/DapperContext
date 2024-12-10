namespace Service;
using Interface;
using Models;
using Npgsql;
using Dapper;
using DataContext;


public class EmployeeService:IEmployeeService
{
    public List<Employee>? Employees { get; set; }

   
    private readonly DapperContext context;
    public EmployeeService()
    {
        context = new DapperContext();
    }

    public bool AddEmployee(Employee employee)
    {
        try{
         string insertCommand="insert into Employees(fullname,position,department,hireDate) values (@Fullame,@Position,@Department,@HireDate)";
        var res=context.Connection().Execute(insertCommand,employee);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteEmployee(int id)
    {
        try{
        string deleteCommand=$"Delete from Employees where id=@EmployeeId";
        var res=context.Connection().Execute(deleteCommand,new {EmployeeId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayEmployees()
    {
        try{
         string readCommand=$"select * from Employees";
         var res=context.Connection().Query<Employee>(readCommand).ToList();
         foreach(Employee c in Companies)
         {
            System.Console.WriteLine($@"""
            Fullname = {c.Fullname}
            Position = {c.Position}
            Department = {c.Departmnt}
            HireDate = {c.HireDate}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateEmployee(Employee employee)
    {
        try{
          string updateComand=$"Update Employees set EmployeeId=@EmployeeId fullname=@Fullname, position=@Position,department=@Department, hireDate=@HireDate";
          var res=context.Connection().Execute(updateComand,employee);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    
