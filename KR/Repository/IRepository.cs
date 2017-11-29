namespace Repository
{
    using Common;

    public interface IRepository
    {
        void Add(Product product);

        void Delete(Product product);
    }
}