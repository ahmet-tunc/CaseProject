using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete.BaseManagers;
using CaseProject.Business.ValidationRules.FluentValidation;
using CaseProject.Core.Utilities.Results.Abstract;
using CaseProject.DataAccess.Abstract;
using CaseProject.Entities.Concrete;
using CaseStudy.Core.Aspects.Autofac.Validation;
using Core.Utilities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete
{
    public class HistoryManager:BaseManager<History>,IHistoryService
    {
        private readonly IHistoryDal _historyDal;
        private readonly IHistoryCategoryDal _historyCategoryDal;
        public HistoryManager(IHistoryDal historyDal, IHistoryCategoryDal historyCategoryDal) :base(historyDal)
        {
            _historyDal = historyDal;
            _historyCategoryDal = historyCategoryDal;
        }

        [ValidationAspect(typeof(HistoryValidator))]
        public override Task<IDataResult<History>> AddAsync(History entity, int lang)
        {
            var checkCategory = _historyCategoryDal.GetAsync(x => x.Name == entity.CategoryName, false).Result;
            if (checkCategory.Success && checkCategory.Data != null)
            {
                entity.HistoryCategoryId = checkCategory.Data.Id;
            }
            entity.LanguageId = lang;
            return base.AddAsync(entity, lang);
        }

        public override Task<IResult> AddListAsync(List<History> listEntity, int lang)
        {
            foreach (var entity in listEntity)
            {
                entity.LanguageId = lang;
                var checkCategory = _historyCategoryDal.GetAsync(x => x.Name == entity.CategoryName).Result;
                if (checkCategory.Success && checkCategory.Data != null)
                {
                    entity.HistoryCategoryId = checkCategory.Data.Id;
                }
                else
                {
                    var newCategory = _historyCategoryDal.AddAsync(new HistoryCategory
                    {
                        LanguageId = lang,
                        Name = entity.CategoryName,
                        CreatedUserId = entity.CreatedUserId,
                        UpdatedUserId = entity.UpdatedUserId
                    }).Result;
                    if (newCategory.Success)
                    {
                        entity.HistoryCategoryId = newCategory.Data.Id;
                    }
                }
            }
            return base.AddListAsync(listEntity, lang);
        }

        public override async Task<IResult> DeleteAsync(int id, int lang)
        {
            return await _historyDal.DeleteAsync(x => x.Id == id && x.LanguageId == lang);
        }

        public override async Task<IResult> DeleteListAsync(int[] id, int lang)
        {
            if (id != null && id.Length > 0)
            {
                return await _historyDal.DeleteListAsync(x => id.Contains(x.Id) && x.LanguageId == lang);
            }
            return new ErrorResult();
        }


        public override async Task<IDataResult<List<History>>> GetAllAsync(int page, int pagesize, int lang, bool includeRelationShips = false)
        {
            return await _historyDal.GetAllAsync(page, pagesize, includeRelationShips, x => x.LanguageId == lang);
        }

        public override async Task<IDataResult<History>> GetByIdAsync(int id, int lang, bool includeRelationShips = false)
        {
            return await _historyDal.GetAsync(x => x.Id == id && x.LanguageId == lang, includeRelationShips);
        }

    }
}
