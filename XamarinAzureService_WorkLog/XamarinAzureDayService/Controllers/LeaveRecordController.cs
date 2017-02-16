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
    public class LeaveRecordController : TableController<LeaveRecord>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            XamarinAzureDayContext context = new XamarinAzureDayContext();
            DomainManager = new EntityDomainManager<LeaveRecord>(context, Request);
        }

        // GET tables/LeaveRecord
        public IQueryable<LeaveRecord> GetAllLeaveRecord()
        {
            return Query(); 
        }

        // GET tables/LeaveRecord/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<LeaveRecord> GetLeaveRecord(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/LeaveRecord/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<LeaveRecord> PatchLeaveRecord(string id, Delta<LeaveRecord> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/LeaveRecord
        public async Task<IHttpActionResult> PostLeaveRecord(LeaveRecord item)
        {
            LeaveRecord current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/LeaveRecord/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteLeaveRecord(string id)
        {
             return DeleteAsync(id);
        }
    }
}
