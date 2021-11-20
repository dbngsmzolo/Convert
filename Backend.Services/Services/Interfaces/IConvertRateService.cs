using Backend.Data.Ef.Concrete;
using System.Threading.Tasks;

namespace Backend.Services.Services.Interfaces
{
    public interface IConvertRateService
    {
        Task<ConversionRate> GetAsync(string rateName);
        string ConvertUnits(double amount, ConversionRate convertionRate);
        string FahrenheitToCelsius(double amount, ConversionRate convertionRate);
    }
}
