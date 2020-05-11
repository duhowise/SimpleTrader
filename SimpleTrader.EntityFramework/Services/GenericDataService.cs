using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T>:IDataService<T> where T :DomainObject
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;

        public GenericDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<T>> GetAll()
        {

            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            var list = await context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            await using var context=_contextFactory.CreateDbContext(new []{""});
           var createdEntity= await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {

            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            entity.Id = id;
            context.Set<T>().Update(entity);
             await context.SaveChangesAsync();
             return entity;
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext(new[] { "" });
            var entity = await context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
           context.Set<T>().Remove(entity);
           return await context.SaveChangesAsync()>0;
           
        }
    }
}