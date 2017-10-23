using Bike2Ride.Data.Contracts;

using Bytes2you.Validation;

namespace Bike2Ride.Data.UnitOfWork
{
    public class EfUnitOfWork : IEFUnitOfWork
    {
        private readonly MsSqlDbContext context;

        public EfUnitOfWork(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, "Unit of work dbcontext").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            if (!this.context.ChangeTracker.HasChanges())
            {
                return;
            }

            this.context.SaveChanges();
        }
    }
}
