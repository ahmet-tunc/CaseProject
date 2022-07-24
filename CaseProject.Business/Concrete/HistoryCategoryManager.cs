using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete.BaseManagers;
using CaseProject.Core.Utilities.Results.Abstract;
using CaseProject.DataAccess.Abstract;
using CaseProject.Entities.Concrete;
using Core.Utilities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete
{
    public class HistoryCategoryManager:BaseManager<HistoryCategory>,IHistoryCategoryService
    {
        private readonly IHistoryCategoryDal _historyCategoryDal;
        public HistoryCategoryManager(IHistoryCategoryDal historyCategoryDal) :base(historyCategoryDal)
        {
            _historyCategoryDal = historyCategoryDal;
        }

        public override async Task<IDataResult<HistoryCategory>> AddAsync(HistoryCategory entity, int lang)
        {
            var checkCategory = _historyCategoryDal.GetAsync(x => x.Name == entity.Name && x.LanguageId == lang, false).Result;
            if (!checkCategory.Success)
            {
                await _historyCategoryDal.AddAsync(new HistoryCategory
                {
                    LanguageId = lang,
                    Name = entity.Name,
                    CreatedUserId = entity.CreatedUserId,
                    UpdatedUserId = entity.UpdatedUserId
                });
            }
            entity.LanguageId = lang;
            return new SuccessDataResult<HistoryCategory>(entity);
        }

        public override async Task<IResult> AddListAsync(List<HistoryCategory> listEntity, int lang)
        {
            foreach (var entity in listEntity)
            {
                var checkCategory = _historyCategoryDal.GetAsync(x => x.Name == entity.Name && x.LanguageId == lang).Result;
                entity.LanguageId = lang;
                if (!checkCategory.Success)
                {
                    await _historyCategoryDal.AddAsync(new HistoryCategory
                    {
                        LanguageId = lang,
                        Name = entity.Name,
                        CreatedUserId = entity.CreatedUserId,
                        UpdatedUserId = entity.UpdatedUserId
                    });
                }
            }
            return new SuccessDataResult<List<HistoryCategory>>(listEntity);
        }


        public override async Task<IResult> DeleteAsync(int id, int lang)
        {
            return await _historyCategoryDal.DeleteAsync(x => x.Id == id && x.LanguageId == lang);
        }

        public override async Task<IResult> DeleteListAsync(int[] id, int lang)
        {
            if (id != null && id.Length > 0)
            {
                return await _historyCategoryDal.DeleteListAsync(x => id.Contains(x.Id) && x.LanguageId == lang);
            }
            return new ErrorResult();
        }


        public override async Task<IDataResult<List<HistoryCategory>>> GetAllAsync(int page, int pagesize, int lang, bool includeRelationShips = false)
        {
            return await _historyCategoryDal.GetAllAsync(page, pagesize, includeRelationShips, x => x.LanguageId == lang);
        }

        public override async Task<IDataResult<HistoryCategory>> GetByIdAsync(int id, int lang, bool includeRelationShips = false)
        {
            return await _historyCategoryDal.GetAsync(x => x.Id == id && x.LanguageId == lang, includeRelationShips);
        }
    }
}
