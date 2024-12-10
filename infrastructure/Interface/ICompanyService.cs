namespace Interface;

public interface ICompanyService
{
    public bool AddCompany(Company company);
    public bool DeleteCompany(int id);
    public bool UpdateCompany(Company company);
    public void DisplayCompanies();
}