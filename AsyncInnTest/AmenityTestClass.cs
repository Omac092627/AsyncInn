using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public abstract class AmenityTestClass : DatabaseTestClass
    {
     
        private IAmenity BuildRepository()
        {
            return new AmenityRepository(_db);
        }


        [Fact]
        public async Task CanSaveAndGet()
        {
            var amenity = new AmenityDTO
            {
                Id = 1,
                Name = "pool",

            };
            var repository = BuildRepository();

            //Act//
            var saved = await repository.Create(amenity);

            //Assert//
            Assert.NotNull(saved);
            Assert.NotEqual(0, amenity.Id);
            Assert.Equal(saved.Id, amenity.Id);
            Assert.Equal(amenity.Name, saved.Name);
        }
    }
}
