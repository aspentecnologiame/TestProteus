
namespace MarcosCosta.Repository.Base
{
    public abstract class BaseRepository
    {
        public readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
