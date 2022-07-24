using CaseProject.DataAccess.Abstract;
using CaseProject.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CaseProject.DataAccess.Concrete
{
    public class EfHistoryDal: EfEntityRepositoryBase<History,AppDbContext>, IHistoryDal
    {
        public override IQueryable<History> QueryInclude => base.QueryInclude
            .Include(x=>x.Language)
            .Include(x=>x.HistoryCategory);

        public EfHistoryDal(AppDbContext context):base(context)
        {
        }
    }
}
