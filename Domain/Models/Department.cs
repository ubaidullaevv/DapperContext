namespace Models;


public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Manager { get; set; }
    public int EmployeeId { get; set; }
    public double Budget { get; set; }
    public string Location { get; set; }
}