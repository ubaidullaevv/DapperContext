namespace Interface;

public interface IEmployeeService
{
    public bool AddEmployee(Employee employee);
    public bool DeleteEmployee(int id);
    public bool UpdateEmployee(Employee employee);
    public void DisplayEmployees();
}