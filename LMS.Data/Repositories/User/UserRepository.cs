namespace LMS.Data.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<entities.User> _genericRepository;
        public UserRepository(IGenericRepository<entities.User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<entities.User> DeleteAsync(int id)
        {
            return await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<entities.User>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<entities.User> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<entities.User> InsertAsync(entities.User entity)
        {
            return await _genericRepository.InsertAsync(entity);
        }

        public async Task<entities.User> UpdateAsync(entities.User entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }
    }
}
