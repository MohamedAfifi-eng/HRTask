namespace HRTask.Services
{
    public interface IDataService<T>
    {
        public T? Find(int Id);
        public IEnumerable<T> GetAll();
        public T Create(T Entity);
        public T Update(T Entity);
        public Boolean Delete(T Entity);

    }
}
