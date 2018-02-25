using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using democsbackendService.DataObjects;
using democsbackendService.Models;

namespace democsbackendService.Controllers
{
    public class CustomerController : TableController<Customer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            democsbackendContext context = new democsbackendContext();
            DomainManager = new EntityDomainManager<Customer>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<Customer> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Customer> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Customer> PatchTodoItem(string id, Delta<Customer> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(Customer item)
        {
            Customer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}