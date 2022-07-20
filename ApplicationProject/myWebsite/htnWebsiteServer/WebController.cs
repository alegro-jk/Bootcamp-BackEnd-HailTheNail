using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

public class WebController : Controller
{
    [Route("/web-configure")]
    public IActionResult WebConfigure([FromBody] ConfigureActionModel param, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var CorrectApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == CorrectApiKey) {

            var config = param.Action;
            if(config == "CreateWebTables") {
                WebDatabase.CreateWebTables();
                return Ok("Web Tables created");
            }
            else if(config == "DropWebTables") {
                WebDatabase.DropWebTables();
                return Ok("Web Tables deleted");
            }
            else {
                return Ok("Please choose from 'CreateWebTables' and 'DropWebTables' only" );
            }
        }
        else {
           return Unauthorized(); 
        }
    }

    [Route("/home")]
    public IActionResult onViewHomePage()
    {
        return View("/Views/htn.cshtml");
    }

    [Route("/aboutUs1")]
    public IActionResult onViewAboutUs1()
    {
        return View("/Views/aboutUs1.cshtml");
    }

    [HttpGet]
    [Route("/aboutUs2")]
    public IActionResult onViewAboutUs2()
    {
        var opts = WebDatabase.GetAllStaffInfo();
        return View("/Views/aboutUs2.cshtml", opts);
    }

    [Route("/services1")]
    public IActionResult onViewServices1()
    {
        var serv = WebDatabase.GetAllServiceInfo();
        return View("/Views/services1.cshtml", serv);
    }

    // [Route("/services2")]
    // public IActionResult onViewServices2()
    // {
    //     return View("/Views/services2.cshtml");
    // }

    // [Route("/services3")]
    // public IActionResult onViewServices3()
    // {
    //     return View("/Views/services3.cshtml");
    // }

    // [Route("/services4")]
    // public IActionResult onViewServices4()
    // {
    //     return View("/Views/services4.cshtml");
    // }

    // [Route("/services5")]
    // public IActionResult onViewServices5()
    // {
    //     return View("/Views/services5.cshtml");
    // }

    [Route("/htn-products")]
    public IActionResult onViewProducts()
    {
        var prod = WebDatabase.GetAllProductInfo();
        return View("/Views/products.cshtml", prod);
    }

    [Route("/htn-locations")]
    public IActionResult onViewLocations()
    {
        var branch = WebDatabase.GetAllBranchInfo();
        return View("/Views/locations.cshtml", branch);
    }

    [Route("/htn-whatsNew")]
    public IActionResult onViewWhatsNew()
    {
        var wnew = WebDatabase.GetAllArticleInfo();
        return View("/Views/whatsNew.cshtml", wnew);
    }

    [Route("/htn-promos")]
    public IActionResult onViewPromos()
    {
        var promo = WebDatabase.GetAllPromoInfo();
        return View("/Views/promos.cshtml", promo);
    }

    [HttpGet]
    [Route("/bookNow")]
    public IActionResult onViewBookingPage()
    {
        // OptionModel option = new OptionModel();
        // option = WebDatabase.GetOptions();
        // ViewBag.products = option.Products;
        // ViewBag.services = option.Services;
        // ViewBag.branch = option.Branch;
        // ViewBag.staff = option.Staff;
        // ViewBag.staffBranch = option.StaffBranch;
        // var prod = WebDatabase.GetAllProductInfo();

        return View("/Views/bookNow.cshtml");
    }

    [HttpPost]
    [Route("/bookingConfirmation")]
    public IActionResult onViewBookingConfirmation()
    {
        var FirstName = HttpContext.Request.Form["Firstname"];
        var LastName = HttpContext.Request.Form["Lastname"];
        var Email = HttpContext.Request.Form["Email"];
        var PhoneNumber = HttpContext.Request.Form["PhoneNumber"];
        var MethodOfContact = HttpContext.Request.Form["option"];
        string AvailServices = HttpContext.Request.Form["serv"];
        string AvailProducts = HttpContext.Request.Form["prods"];
        var PreferredBranch = HttpContext.Request.Form["branch"];
        var PreferredTechnician = HttpContext.Request.Form["staff"];
        var DateOfVisit = HttpContext.Request.Form["day_visit"];
        var TimeOfVisit = HttpContext.Request.Form["option1"];
        var GuestNumber = int.Parse(HttpContext.Request.Form["guest"]);
        var Request = HttpContext.Request.Form["request"];

        if(FirstName == "" || LastName == "" || Email == "" || PhoneNumber == "" 
        || MethodOfContact == "" || AvailServices == "" || AvailProducts == "" || TimeOfVisit == "" 
        || PreferredBranch == "" || PreferredTechnician == "" || DateOfVisit == "" || GuestNumber == 0 
        || Request == "")
        {
            return View("/Views/bookNow.cshtml");
        }
        else
        {
            var totalamount = 0;
            var totalservices = 0;
            var totalproducts = 0;

            if(AvailServices == "Manicure"){totalservices += 249 * GuestNumber;}
            if(AvailServices == "Pedicure"){totalservices += 349 * GuestNumber;}
            if(AvailServices == "Nail Art"){totalservices += 399 * GuestNumber;}
            if(AvailServices == "Cryotherapy"){totalservices += 2999 * GuestNumber;}
            if(AvailServices == "Chemical Peeling"){totalservices += 1499 * GuestNumber;}
            if(AvailServices == "None"){totalservices += 0;}           
            if(AvailServices.Contains(","))
            {
                string[] splitserv = AvailServices.Split(',');
                foreach(var serv in splitserv)
                {
                    if(serv == "Manicure"){totalservices += 249 * GuestNumber;}
                    if(serv == "Pedicure"){totalservices += 349 * GuestNumber;}
                    if(serv == "Nail Art"){totalservices += 399 * GuestNumber;}
                    if(serv == "Cryotherapy"){totalservices += 2999 * GuestNumber;}
                    if(serv == "Chemical Peeling"){totalservices += 1499 * GuestNumber;}
                    if(serv == "None"){totalservices += 0;}
                }
            }
            if(AvailProducts == "Nail Dryer"){totalproducts += 1499;}
            if(AvailProducts == "Nail Polish Set"){totalproducts += 499;}
            if(AvailProducts == "Manicure Kit"){totalproducts += 449;}
            if(AvailProducts == "None"){totalproducts += 0;}
            if(AvailProducts.Contains(","))
            {
                string[] splitprod = AvailProducts.Split(',');
                foreach(var prod in splitprod)
                {
                    if(prod == "Nail Dryer"){totalproducts += 1499;}
                    if(prod == "Nail Polish Set"){totalproducts += 499;}
                    if(prod == "Manicure Kit"){totalproducts += 449;}
                    if(prod == "None"){totalproducts += 0;}
                }
            }
 
            totalamount = totalproducts + totalservices;

            var model = new BookingModel();
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.Email = Email;
            model.PhoneNumber = PhoneNumber;
            model.MethodOfContact = MethodOfContact;
            model.AvailServices = AvailServices;
            model.AvailProducts = AvailProducts;
            model.PreferredBranch = PreferredBranch;
            model.PreferredTechnician = PreferredTechnician;
            model.DateOfVisit = DateOfVisit;
            model.TimeOfVisit = TimeOfVisit;
            model.GuestNumber = GuestNumber;
            model.Request = Request;
            model.Totalamount = totalamount;
            model.Orderdate = DateTime.Now.ToString("MM/dd/yyyy");
            WebDatabase.InsertBookingData(model);

            return View("/Views/bookingConfirmation.cshtml", model);
        }
    }

    [HttpGet]
    [Route("/summary")]
    public IActionResult onViewAllBookingInfo()
    {
        var booklist = WebDatabase.GetBookingData();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/silang")]
    public IActionResult onViewAllSilangInfo()
    {
        var booklist = WebDatabase.GetSilangData();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/gentri")]
    public IActionResult onViewAllGentriInfo()
    {
        var booklist = WebDatabase.GetGentriData();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/nasugbu")]
    public IActionResult onViewAllNasugbuInfo()
    {
        var booklist = WebDatabase.GetNasugbuData();
        return Json(booklist);
    }
}