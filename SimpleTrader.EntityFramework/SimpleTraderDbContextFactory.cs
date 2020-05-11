using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory:IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args)
        {
            var options=new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer("server=localhost;Database=SimpleTrader;Trusted_Connection=true;");
            return new SimpleTraderDbContext(options.Options);
        }
    }
}