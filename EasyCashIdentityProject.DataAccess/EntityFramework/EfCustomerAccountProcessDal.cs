using EasyCashIdentityProject.DataAccess.Abstract;
using EasyCashIdentityProject.DataAccess.Concrete;
using EasyCashIdentityProject.DataAccess.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccess.EntityFramework
{
    public class
        EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses
                .Include(y=>y.SenderCustomer)
                .ThenInclude(z => z.AppUser)
                .Include(w=>w.ReceiverCustomer)
                .ThenInclude(z=>z.AppUser)
                .Where(x=>x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}
