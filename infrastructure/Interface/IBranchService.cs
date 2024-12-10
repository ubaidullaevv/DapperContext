namespace Interface;

public interface IBranchService
{
    public bool AddBranch(Branch branch);
    public bool DeleteBranch(int id);
    public bool UpdateBranch(Branch branch);
    public void DisplayBranches();
}