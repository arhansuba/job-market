namespace JobMarket.Data
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
