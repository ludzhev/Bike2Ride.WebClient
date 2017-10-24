using System.Web.Mvc;

using Bike2Ride.Data.Contracts;

using Bytes2you.Validation;

namespace Bike2Ride.WebClient.Infrastructure.ActionFilters
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IEFUnitOfWork unitOfWork;

        public SaveChangesFilter(IEFUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, "Save changes unitOfWork").IsNull().Throw();

            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.unitOfWork.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
