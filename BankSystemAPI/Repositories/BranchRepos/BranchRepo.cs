using BankSystemAPI.DTOs;
using BankSystemAPI.Models;
using BankSystemAPI.Repositories.CustomerRepos;
using Microsoft.EntityFrameworkCore;

namespace BankSystemAPI.Repositories.BranchRepos
{
    public class BranchRepo : IBranchRepo
    {
        private readonly AppDbContext _context;
        public BranchRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(PostBranchDto BranchDto)
        {
            try
            {
                var branch = new Branch
                {
                    Location = BranchDto.Location,
                    Name = BranchDto.Name,
                    Customers = BranchDto.Customers.Select(x=>new Customer
                    {
                        Name = x.Name,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,

                    }).ToList(),
                };
                _context.branches.Add(branch);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        public bool Delete(int id)
        {
            var branch = _context.branches.FirstOrDefault(x=>x.BranchId==id);
            if(branch == null)
            {
                return false;
            }
            _context.branches.Remove(branch);
            _context.SaveChanges();
            return true;
        }

        public IList<GetBranchDto> GetAll()
        {
            return _context.branches.Include(x => x.Customers).ThenInclude(x=>x.Accounts).Select(x=>new GetBranchDto
            {
                BranchId = x.BranchId,
                Location =x.Location,
                Name = x.Name,
                Customers = x.Customers.Select(x=>new CustemerRelationGetDto
                {
                    Name = x.Name,
                    Email   = x.Email,
                    CustomerId = x.CustomerId,
                    PhoneNumber = x.PhoneNumber,
                    Accounts = x.Accounts.Select(x=> new AccountForBranchDto
                    {
                        AccountId = x.AccountId,
                        AccountNumber = x.AccountNumber,    
                        Balance = x.Balance,
                    }).ToList()
                }).ToList()
            }).ToList();
            throw new NotImplementedException();
        }

        public bool Update(UpdateBranchDto BranchDto, int id)
        {
            try
            {
                var branch = _context.branches
                    .Include(b => b.Customers)
                    .FirstOrDefault(x => x.BranchId == id);

                if (branch == null)
                    return false;

                branch.Name = BranchDto.Name;
                branch.Location = BranchDto.Location;

                // التحقق من وجود عملاء
                var customers = _context.Customers
                    .Where(c => BranchDto.CustomersIds.Contains(c.CustomerId))
                    .ToList();  

                if (customers.Count != BranchDto.CustomersIds.Count)
                {
                    throw new Exception("Some customers were not found.");
                }

                // تحديث العلاقة
                branch.Customers = customers;

                _context.branches.Update(branch);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // ممكن تضيف Log هنا لو محتاج تتبع الخطأ
                return false;
            }
        }

    }
}
