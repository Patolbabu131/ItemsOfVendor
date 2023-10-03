using ItemsOfVendor.Data;
using ItemsOfVendor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ItemsOfVendor.Controllers
{
    public class VendorController : Controller
    {
      
        private readonly ApplicationDbContext _db;
        public VendorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult GetData(JqueryDatatableParam param)
        {
            var vendors = _db.Vendors.ToList();

            //Searching
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                vendors = vendors.Where(x => x.VId.ToString().Contains(param.sSearch.ToLower())
                                              || x.VName.ToString().Contains(param.sSearch.ToLower())
                                              || x.VCode.ToString().Contains(param.sSearch.ToLower())
                                              || x.CName.ToString().Contains(param.sSearch.ToLower())
                                              || x.VContact_No.ToString().Contains(param.sSearch.ToLower())).ToList();
            }
            //Sorting
            if (param.iSortCol_0 == 0)
            {
                vendors = param.sSortDir_0 == "asc" ? vendors.OrderBy(c => c.VId).ToList() : vendors.OrderByDescending(c => c.VId).ToList();
            }
            else if (param.iSortCol_0 == 1)
            {
                vendors = param.sSortDir_0 == "asc" ? vendors.OrderBy(c => c.VName).ToList() : vendors.OrderByDescending(c => c.VName).ToList();
            }
            else if (param.iSortCol_0 == 2)
            {
                vendors = param.sSortDir_0 == "asc" ? vendors.OrderBy(c => c.VCode).ToList() : vendors.OrderByDescending(c => c.VCode).ToList();
            }
            else if (param.iSortCol_0 == 3)
            {
                vendors = param.sSortDir_0 == "asc" ? vendors.OrderBy(c => c.CName).ToList() : vendors.OrderByDescending(c => c.CName).ToList();
            }
            else if (param.iSortCol_0 == 4)
            {
                vendors = param.sSortDir_0 == "asc" ? vendors.OrderBy(c => c.VContact_No).ToList() : vendors.OrderByDescending(c => c.VContact_No).ToList();
            }

            //TotalRecords
            var displayResult = vendors.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalRecords = vendors.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            });
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveOrder(Vendor vendor, Item[] itemss)
            {
        
                var VId = Guid.NewGuid();
                Vendor model = new Vendor();
                model.VId = VId;
                model.VName = vendor.VName;
                model.VCode = vendor.VCode;
                model.CName = vendor.CName;
                model.VContact_No = vendor.VContact_No;
                _db.Vendors.Add(model);
                foreach (var value in itemss)
                {   
                    var iid = Guid.NewGuid();
                    Item O = new Item();
                    O.IId = iid;
                    O.IName = value.IName;
                    O.ICode = value.ICode;
                    O.IPrice = value.IPrice;
                    O.VId = iid;
                    _db.Items.Add(O);
                }
                _db.SaveChanges();

            return RedirectToAction("Index", "VendorController");
        }
    }
}
