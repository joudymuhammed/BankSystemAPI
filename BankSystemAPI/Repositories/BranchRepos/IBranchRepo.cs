using BankSystemAPI.DTOs;

namespace BankSystemAPI.Repositories.BranchRepos
{
    public interface IBranchRepo
    {
        bool Add(PostBranchDto BranchDto);
        bool Update (UpdateBranchDto BranchDto,int id);
        IList<GetBranchDto>GetAll();
        bool Delete (int id);
    }
}
