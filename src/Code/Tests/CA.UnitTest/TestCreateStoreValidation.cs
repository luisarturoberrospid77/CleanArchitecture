using System;
using System.Linq;

using Xunit;

using CA.Domain.DTO;
using CA.Application.Validators;

namespace CA.UnitTest
{
    public class TestCreateStoreValidation
    {
        private CreateStoreValidator Validator { get; }

        public TestCreateStoreValidation() => Validator = new CreateStoreValidator();

        [Fact]
        public void TestCreateStore()
        {
            CreateStoreDTO testRequest = new CreateStoreDTO()
            {
                Name = "Sucursal Oaxaca",
                Address = "Av. Siempreviva Noño 106.",
                NumberPhone = "(55)-2407-2102",
                PostalCode = 72010,
                CountryCode = 138,
                FederalEntityCode = 21,
                MunicipalityCode = 114,
                NeighborhoodCode = 12,
                AccountIdCreationDate = 1
            };

            var result = Validator.Validate(testRequest);

            if (!result.IsValid)
                throw new Exception($"Ocurrió un error: {result.Errors.Single().ErrorMessage}");
        }

        [Fact]
        public void TestCreateStoreForNumberPhone()
        {
            CreateStoreDTO testRequest = new CreateStoreDTO()
            {
                Name = "Sucursal Oaxaca",
                Address = "Av. Siempreviva Noño 106.",
                NumberPhone = "(552)-407-2102",
                PostalCode = 72010,
                CountryCode = 138,
                FederalEntityCode = 21,
                MunicipalityCode = 114,
                NeighborhoodCode = 12,
                AccountIdCreationDate = 1
            };

            var result = Validator.Validate(testRequest);

            if (!result.IsValid)
                throw new Exception($"Ocurrió un error: {result.Errors.Single().ErrorMessage}");
        }
    }
}
