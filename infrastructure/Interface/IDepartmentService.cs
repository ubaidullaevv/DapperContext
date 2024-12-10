namespace Interface;

public interface IDepartmentService
{
    public bool AddDepartment(Department department);
    public bool DeleteDepartment(int id);
    public bool UpdateDepartment(Department department);
    public void DisplayDepartments();
}