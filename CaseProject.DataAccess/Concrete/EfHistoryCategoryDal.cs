using CaseProject.DataAccess.Abstract;
using CaseProject.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System.Linq;

namespace CaseProject.DataAccess.Concrete
{
    public class EfHistoryCategoryDal: EfEntityRepositoryBase<HistoryCategory,AppDbContext>, IHistoryCategoryDal
    {
        public override IQueryable<HistoryCategory> QueryInclude => base.QueryInclude;
        public EfHistoryCategoryDal(AppDbContext context):base(context)
        {
        }
    }
}
