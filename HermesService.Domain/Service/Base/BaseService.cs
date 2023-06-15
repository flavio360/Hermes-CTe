using HermesService.Domain.Entity;


namespace HermesService.Domain.Service.Base
{
    public abstract class BaseService
    {
        public IEntityRepository _BaseRepository;
        public BaseService(IEntityRepository repo)
        {
            _BaseRepository = repo;
        }
    }
}
