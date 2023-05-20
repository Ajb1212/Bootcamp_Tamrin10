namespace Tamrin9
{
    class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ICollection<T> _entities;
        public Repository(ICollection<T> entities) => _entities = entities;

        public void Delete(T entity) => _entities.Remove(entity);

        public T Get(int id) => _entities.Single(entity => entity.Id == id);

        public IEnumerable<T> GetAll() => _entities;

        public void Insert(T entity) => _entities.Add(entity);

        public void Update(T entity)
        {
            Delete(entity);
            Insert(entity);
        }
    }
}