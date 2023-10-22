using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotivTest.Data;
using MotivTest.Models;
using MotivTest.Models.Decloration;
using System.Linq;
using System.Linq.Expressions;

namespace MotivTest.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RequestController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult RequestRegister()
        {
            var requests = RequestRegisterViewModel.GetProjection(_context.Requests);
            return View(requests);
        }

		public IActionResult EditRequest(int id)
		{
            var request = _context.Requests.Include(x => x.User).ThenInclude(x => x.Locality).ThenInclude(x => x.Region).ThenInclude(x => x.Country)
                .FirstOrDefault(x => x.Id == id);
			return View(request);
		}

        [HttpPost]
        public IActionResult EditRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("EditRequest", request);
            }

            _context.Requests.Update(request);
            _context.SaveChanges();
            return RedirectToAction("RequestRegister");
        }

        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View(new Request { User = new User { Locality = new Locality { Region = new Region { Country = new Country() } } } });
        }

        [HttpPost]
        public IActionResult CreateRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Create is failed");
                return View("CreateRequest", request);
            }
            _context.Requests.Add(request);
            _context.SaveChanges();
            return RedirectToAction("RequestRegister");
        }

        [HttpPost]
        public IActionResult Search(RequestSearchViewModel searchViewModel)
        {
            var requests = RequestRegisterViewModel.GetProjection(_context.Requests.Where(GetExpression(searchViewModel)));
            return View("RequestRegister", requests);
        }

        private Expression<Func<Request, bool>> GetExpression(RequestSearchViewModel searchViewModel)
        {
            Expression<Func<Request, bool>> expressionFunc = x => true;

            if (!string.IsNullOrEmpty(searchViewModel.Country))
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.User.Locality.Region.Country.Name.Contains(searchViewModel.Country);
                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (!string.IsNullOrEmpty(searchViewModel.Region))
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.User.Locality.Region.Name.Contains(searchViewModel.Region);

                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (!string.IsNullOrEmpty(searchViewModel.Locality))
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.User.Locality.Name.Contains(searchViewModel.Locality);

                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (!string.IsNullOrEmpty(searchViewModel.Number))
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.User.Number.Contains(searchViewModel.Number);
                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (!string.IsNullOrEmpty(searchViewModel.Reason))
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.Reason.Contains(searchViewModel.Reason);
                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (searchViewModel.Department != null)
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.DepartmentId == (int)searchViewModel.Department;
                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }
            if (searchViewModel.Date != null && searchViewModel.Date != DateTime.MinValue)
            {
                Expression<Func<Request, bool>> func =
                    doc => doc.Date == searchViewModel.Date;
                var funcInvoke = Expression.Invoke(func, expressionFunc.Parameters.Cast<Expression>());
                expressionFunc = Expression.Lambda<Func<Request, bool>>(Expression.AndAlso(expressionFunc.Body, funcInvoke), expressionFunc.Parameters);
            }

            return expressionFunc;
        }
    }
}
