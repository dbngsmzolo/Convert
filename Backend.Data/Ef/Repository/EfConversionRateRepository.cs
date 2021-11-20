using Backend.Core.Data.Ef;
using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository.Interfaces;

namespace Backend.Data.Ef.Repository
{
    public class EfConversionRateRepository :
        EfRepository<ConversionRate>,
        IConversionRateRepository
    {
        public EfConversionRateRepository(EfDbContext context) : base(context)
        {
        }
    }
}
