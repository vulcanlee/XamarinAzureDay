using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using XamarinAzureDayService.DataObjects;
using XamarinAzureDayService.Models;

namespace XamarinAzureDayService.Controllers
{
    public class BusinessTripExpenseController : TableController<BusinessTripExpense>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            XamarinAzureDayContext context = new XamarinAzureDayContext();
            DomainManager = new EntityDomainManager<BusinessTripExpense>(context, Request);
        }

        // GET tables/BusinessTripExpense
        public IQueryable<BusinessTripExpense> GetAllBusinessTripExpense()
        {
            return Query(); 
        }

        // GET tables/BusinessTripExpense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<BusinessTripExpense> GetBusinessTripExpense(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/BusinessTripExpense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<BusinessTripExpense> PatchBusinessTripExpense(string id, Delta<BusinessTripExpense> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/BusinessTripExpense
        public async Task<IHttpActionResult> PostBusinessTripExpense(BusinessTripExpense item)
        {
            BusinessTripExpense current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/BusinessTripExpense/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBusinessTripExpense(string id)
        {
             return DeleteAsync(id);
        }
    }
}
