using Abp.Domain.Uow;

namespace JobMarket.Data
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {

        private readonly ApplicationDbContext _context = context;

        public string Id => throw new NotImplementedException();

        public IUnitOfWork Outer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnitOfWorkOptions Options => throw new NotImplementedException();

        public IReadOnlyList<DataFilterConfiguration> Filters => throw new NotImplementedException();

        public IReadOnlyList<AuditFieldConfiguration> AuditFieldConfiguration => throw new NotImplementedException();

        public Dictionary<string, object> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsDisposed => throw new NotImplementedException();

        public event EventHandler Completed;
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
        public event EventHandler Disposed;

        public void Begin(UnitOfWorkOptions options)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public IDisposable DisableAuditing(params string[] fieldNames)
        {
            throw new NotImplementedException();
        }

        public IDisposable DisableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDisposable EnableAuditing(params string[] fieldNames)
        {
            throw new NotImplementedException();
        }

        public IDisposable EnableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        public int? GetTenantId()
        {
            throw new NotImplementedException();
        }

        public bool IsFilterEnabled(string filterName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Save()
        {
            return _context.SaveChanges();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IDisposable SetFilterParameter(string filterName, string parameterName, object value)
        {
            throw new NotImplementedException();
        }

        public IDisposable SetTenantId(int? tenantId)
        {
            throw new NotImplementedException();
        }

        public IDisposable SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable)
        {
            throw new NotImplementedException();
        }
    }
}
