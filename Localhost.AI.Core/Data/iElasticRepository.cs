namespace Localhost.AI.Core.Data
{
    using Models;
    public interface iElasticRepository<TEntity>
        where TEntity : EntityBase
    {
    }
    public interface IElasticLogRepository : iElasticRepository<Log>
    {
    }
}
