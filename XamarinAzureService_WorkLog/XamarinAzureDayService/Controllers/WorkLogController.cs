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
    [Authorize]
    public class WorkLogController : TableController<WorkLog>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            XamarinAzureDayContext context = new XamarinAzureDayContext();
            DomainManager = new EntityDomainManager<WorkLog>(context, Request);
        }

        // GET tables/WorkLog
        public IQueryable<WorkLog> GetAllWorkLog()
        {
            return Query(); 
        }

        // GET tables/WorkLog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<WorkLog> GetWorkLog(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/WorkLog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<WorkLog> PatchWorkLog(string id, Delta<WorkLog> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/WorkLog
        public async Task<IHttpActionResult> PostWorkLog(WorkLog item)
        {
            WorkLog current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/WorkLog/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteWorkLog(string id)
        {
             return DeleteAsync(id);
        }
    }
}
