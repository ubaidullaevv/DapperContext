namespace Service;
using Interface;
using Models;
using Npgsql;
using Dapper;
using DataContext;


public class BranchService:IBranchService
{
    public List<Branch>? Branches { get; set; }

   
    private readonly DapperContext context;
    public BranchService()
    {
        context = new DapperContext();
    }

    public bool AddBranch(Branch branch)
    {
        try{
         string insertCommand="insert into Branches(name,location,manager,employeeCount,establishedYear) values (@Name,@Location,@Manager,@EmployeeCount,@EstablishedYear)";
        var res=context.Connection().Execute(insertCommand,branch);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteBranch(int id)
    {
        try{
        string deleteCommand=$"Delete from Branches where id=@BranchId";
        var res=context.Connection().Execute(deleteCommand,new {BranchId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayBranchs()
    {
        try{
         string readCommand=$"select * from Branches";
         var res=context.Connection().Query<Branch>(readCommand).ToList();
         foreach(Branch c in Companies)
         {
            System.Console.WriteLine($@"""
            Name = {c.Name}
            Location = {c.Location}
            Manager = {c.Manager}
            EmployeeCount = {c.EmployeeCount}
            EstablishedYear = {c.EstablishedYear}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateBranch(Branch branch)
    {
        try{
          string updateComand=$"Update Branches set BranchId=@BranchId name=@Name, manager=@Manager,employeeCount=@EmployeeCount, location=@Location, establishedYear=@EstablishedYear";
          var res=context.Connection().Execute(updateComand,branch);
          return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }
}

    
