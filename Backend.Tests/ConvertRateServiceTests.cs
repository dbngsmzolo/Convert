using Backend.Data.Ef;
using Backend.Data.Ef.Concrete;
using Backend.Data.Ef.Repository;
using Backend.Data.Enums;
using Backend.Services.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Backend.Tests
{
    public class ConvertRateServiceTests
    {
        private readonly EfDbContext _context;
        private readonly EfConversionRateRepository _repository;
        private readonly ConvertRateService _service;

        public ConvertRateServiceTests()
        {
            var dbContext = new DbContextOptionsBuilder<EfDbContext>().UseInMemoryDatabase("TestDB");
            _context = new EfDbContext(dbContext.Options);
            _context.Database.EnsureCreated();
            _repository = new EfConversionRateRepository(_context);
            _service = new ConvertRateService(_repository);

        }

        [Fact]
        public void Get_FahrenheitToCelsius_Info()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            //act
            var result = rateService.GetAsync(Units.FahrenheitToCelsius.ToString());
            //assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_SecondsToMinutes_Info()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            //act
            var result = rateService.GetAsync(Units.SecondsToMinutes.ToString());
            //assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_MinutesToSeconds_Info()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            //act
            var result = rateService.GetAsync(Units.MinutesToSeconds.ToString());
            //assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_MetricToImperial_Info()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            //act
            var result = rateService.GetAsync(Units.MetricToImperial.ToString());
            //assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_ImperialMetric_Info()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            //act
            var result = rateService.GetAsync(Units.ImperialToMetric.ToString());
            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Convert_CelsiusToFahrenheit()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "CelsiusToFahrenheit",
                Rate = 1.8,
                Base = 32,
                Unit = "°F"
            };
            //act
            var result = rateService.ConvertUnits(1, obj);
            //assert
            Assert.Equal("33.8 °F",result);
        }
        [Fact]
        public void Convert_FahrenheitToCelsius()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "FahrenheitToCelsius",
                Rate = 0.5555555555555556,
                Base = 32,
                Unit = "°C"
            };
            //act
            var result = rateService.FahrenheitToCelsius(1, obj);
            //assert
            Assert.Equal("-17.22222222222222 °C", result);
        }
        [Fact]
        public void Convert_SecondsToMinutes()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "SecondsToMinutes",
                Rate = 0.0166666666666667,
                Base = 0,
                Unit = "min"
            };
            //act
            var result = rateService.ConvertUnits(120, obj);
            //assert
            Assert.Equal("2.000000000000004 min", result);
        }
        [Fact]
        public void Convert_MinutesToSeconds()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "CelsiusToFahrenheit",
                Rate = 60,
                Base = 0,
                Unit = "sec"
            };
            //act
            var result = rateService.ConvertUnits(3, obj);
            //assert
            Assert.Equal("180 sec", result);
        }
        [Fact]
        public void Convert_MetricToImperial()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "MetricToImperial",
                Rate = 0.03937,
                Base = 0,
                Unit = "in"
            };
            //act
            var result = rateService.ConvertUnits(1, obj);
            //assert
            Assert.Equal("0.03937 in", result);
        }
        [Fact]
        public void Convert_ImperialToMetric()
        {
            //arrange
            ConvertRateService rateService = new(_repository);
            var obj = new ConversionRate
            {
                Name = "ImperialToMetric",
                Rate = 25.400050,
                Base = 0,
                Unit = "mm"
            };
            //act
            var result = rateService.ConvertUnits(1, obj);
            //assert
            Assert.Equal("25.40005 mm", result);
        }

    }
}
