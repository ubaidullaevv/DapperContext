namespace Service;
using Interface;
using Models;
using Npgsql;
using Dapper;
using DataContext;


public class DepartmentService:IDepartmentService
{
    public List<Department>? Departments { get; set; }

   
    private readonly DapperContext context;
    public DepartmentService()
    {
        context = new DapperContext();
    }

    public bool AddDepartment(Department department)
    {
        try{
         string insertCommand="insert into Departments(name,manager,employeeId,location,budget) values (@Name,@Manager,@EmployeeId,@Location,@Budget)";
        var res=context.Connection().Execute(insertCommand,department);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteDepartment(int id)
    {
        try{
        string deleteCommand=$"Delete from Departments where id=@DepartmentId";
        var res=context.Connection().Execute(deleteCommand,new {DepartmentId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayDepartments()
    {
        try{
         string readCommand=$"select * from Departments";
         var res=context.Connection().Query<Department>(readCommand).ToList();
         foreach(Department c in Companies)
         {
            System.Console.WriteLine($@"""
            Name = {c.Name}
            Manager = {c.Manager}
            EmployeeId = {c.EmployeeId}
            Location = {c.Location}
            Budget = {c.Budget}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateDepartment(Department Department)
    {
        try{
          string updateComand=$"Update Departments set DepartmentId=@departmentId name=@Name, manager=@Manager,employeeId=@EmployeeId, location=@Location, budget=@Budget";
          var res=context.Connection().Execute(updateComand,Department);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    }
}