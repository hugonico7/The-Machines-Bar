namespace ApiRest.Repository;

public interface IMasterRepository<TEntity> 
    where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(int id);
    Task<TEntity> Add(TEntity model);
    Task<TEntity> Update(TEntity model);
    Task Delete(int id);
}