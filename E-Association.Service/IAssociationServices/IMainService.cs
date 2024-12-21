namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IMainService<TEntity> where TEntity : class
    {
        ValueTask<string> CreateAsync(TEntity entity);
        ValueTask<string> UpdateAsync(TEntity entity);
        ValueTask<string> DeletAsync(Guid entityId);
        ValueTask<List<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetOneByIdAsync(Guid id);
    }

}
