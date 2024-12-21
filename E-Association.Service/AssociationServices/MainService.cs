using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class MainService<TEntity> : IMainService<TEntity>  where TEntity : class
    {
        private AppDbContext _app;
        private DbSet<TEntity> _entity;
        public MainService(AppDbContext app)
        {
            this._app = app;
            _entity = _app.Set<TEntity>();
        }

        public async ValueTask<string> CreateAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

            await _entity.AddAsync(entity);
            int creation = _app.SaveChanges();
            return creation > 0 ? "Created Successfuly" :"Invalid Creation";
        }

        public async ValueTask<string> DeletAsync(Guid entityId)
        {
            if (entityId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var entity = await _entity.FindAsync(entityId);
            if (entity is null)
                throw new ArgumentNullException("Entity Not Found");

            _entity.Remove(entity);
            int deletion = _app.SaveChanges();
            return deletion > 0 ? "deleted Successfuly" : "Invalid deleting";
        }

        public async ValueTask<List<TEntity>> GetAllAsync()
        {
            var entities = await _entity.ToListAsync();
            if (entities is null)
                throw new ArgumentNullException("Entity Not Found");

            return entities;

        }

        public async ValueTask<TEntity> GetOneByIdAsync(Guid id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity is null)
                throw new ArgumentNullException("Entity Not Found");

            return entity;

        }

        public async ValueTask<string> UpdateAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

             _entity.Attach(entity);
            int creation = await _app.SaveChangesAsync();
            return creation > 0 ? "Created Successfuly" : "Invalid Creation";
        }
    }
}