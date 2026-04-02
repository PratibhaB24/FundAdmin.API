using FundAdmin.API.Data;
using FundAdmin.API.Models;
using FundAdmin.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FundAdmin.API.Tests.Repositories
{
    public class GenericRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnData()
        {
            var context = GetDbContext();

            context.Funds.Add(new Fund { FundId = Guid.NewGuid(), Name = "Fund1", Currency = "EUR" });
            context.SaveChanges();

            var repo = new GenericRepository<Fund>(context);

            var result = await repo.GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var context = GetDbContext();
            var repo = new GenericRepository<Fund>(context);

            var fund = new Fund { FundId = Guid.NewGuid(), Name = "Test Fund", Currency = "USD" };

            await repo.AddAsync(fund);
            await repo.SaveAsync();

            var result = await context.Funds.FirstOrDefaultAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_ShouldModifyEntity()
        {
            var context = GetDbContext();

            var fund = new Fund
            {
                FundId = Guid.NewGuid(),
                Name = "Old Name",
                Currency = "USD"
            };

            context.Funds.Add(fund);
            await context.SaveChangesAsync();

            var repo = new GenericRepository<Fund>(context);

            fund.Name = "Updated Name";

            repo.Update(fund);
            await repo.SaveAsync();

            var updated = await context.Funds.FindAsync(fund.FundId);

            Assert.Equal("Updated Name", updated.Name);
        }
    }
}
