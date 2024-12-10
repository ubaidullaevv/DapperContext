namespace Service;
using Interface;
using Models;
using Npgsql;
using Dapper;
using DataContext;


public class CompanyService:ICompanyService
{
    public List<Company>? Companies { get; set; }

   
    private readonly DapperContext context;
    public CompanyServics()
    {
        context = new DapperContext();
    }

    public bool AddCompany(Company company)
    {
        try{
         string insertCommand="insert into Companies(name,industry,location,foundedYear) values (@Name,@Industry,@Location,@FoundedYear)";
        var res=context.Connection().Execute(insertCommand,company);
        return res>0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public bool DeleteCompany(int id)
    {
        try{
        string deleteCommand=$"Delete from Companys where id=@CompanyId";
        var res=context.Connection().Execute(deleteCommand,new {CompanyId=id});
        return res!=0;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
            return false;
        }
    }

    public void DisplayCompanys()
    {
        try{
         string readCommand=$"select * from Companies";
         var res=context.Connection().Query<Company>(readCommand).ToList();
         foreach(Company c in Companies)
         {
            System.Console.WriteLine($@"""
            Name = {c.Name}
            Industry = {c.Industry}
            Location = {c.Location}
            FoundedYear = {c.FoundedYear}
            """);
         }
        }
        catch(Exception e)
        {
            System.Console.WriteLine("This exeption "+e.Message);
        }
    }

    public bool UpdateCompany(Company company)
    {
        try{
          string updateComand=$"Update Companys set CompanyId=@CompanyId name=@Name, industry=@Industry, location=@Location, FoundedYear=@FoundedYear";
          var res=context.Connection().Execute(updateComand,company);
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