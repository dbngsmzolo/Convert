using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository.Interfaces;
using Backend.Services.Services.Interfaces;
using System.Threading.Tasks;

namespace Backend.Services.Services.Concrete
{
    public class ConvertRateService : IConvertRateService
    {
        private readonly IConversionRateRepository _conversionRateRepo;

        public ConvertRateService(IConversionRateRepository conversionRateRepo)
        {
            _conversionRateRepo = conversionRateRepo;
        }
        public async Task<ConversionRate> GetAsync(string rateName)
        {
            return  !string.IsNullOrEmpty(rateName)? await _conversionRateRepo.GetAsync(x => x.Name == rateName):null;
        }

        public string ConvertUnits(double amount,  ConversionRate convertionRate)
        {
            return $"{amount * convertionRate.Rate + convertionRate.Base} {convertionRate.Unit}";
        }
        public string FahrenheitToCelsius(double amount, ConversionRate convertionRate)
        {
            return $"{(amount - convertionRate.Base) * convertionRate.Rate} {convertionRate.Unit}";
        }

    }
}
