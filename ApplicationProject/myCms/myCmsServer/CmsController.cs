using Microsoft.AspNetCore.Mvc;
using CmsModel;

public class AdminController : Controller
{
    [Route("/cms-configure")]
    public IActionResult CmsConfigure([FromBody] ConfigureActionModel param, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            var config = param.Action;
            if(config == "CreateAdminTables") {
                CmsDatabase.CreateAdminTables();
                return Ok("Admin User Tables created");
            }
            else if(config == "CreateEmployeeTables") {
                CmsDatabase.CreateEmployeeTables();
                return Ok("Employee User Tables created");
            }
            else if(config == "DropAdminTables") {
                CmsDatabase.DropAdminTables();
                return Ok("Admin User Tables deleted");
            }
            else if(config == "DropEmployeeTables") {
                CmsDatabase.DropEmployeeTables();
                return Ok("Employee User Tables deleted");
            }
            else {
                return Ok("Please choose from 'CreateAdminTables', 'CreateEmployeeTables', 'DropAdminTables' and 'DropEmployeeTables' only");
            }
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/users")]
    public IActionResult AddUser([FromBody] UserModel user, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddUser(user);
            return Ok("User details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/staffs")]
    public IActionResult AddStaff([FromBody] StaffModel staff, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddStaff(staff);
            return Ok("Staff details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/promos")]
    public IActionResult AddPromo([FromBody] PromoModel promo, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddPromo(promo);
            return Ok("Promo details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    // [HttpPost]
    // [Route("/branches")]
    // public IActionResult AddBranches([FromBody] BranchModel branch, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    // {
    //     var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
    //     if(ApiKey == AdminApiKey) {
    //         CmsDatabase.AddBranch(branch);
    //         return Ok("Branch details added!");
    //     }
    //     else {
    //        return Unauthorized(); 
    //     }
    // }

    [HttpPost]
    [Route("/branches")]
    public IActionResult AddBranches([FromBody] BranchModel branch, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddBranch(branch);
            return Ok("Branch details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/services")]
    public IActionResult AddServices([FromBody] ServiceModel service, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddService(service);
            return Ok("Service details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/products")]
    public IActionResult AddProducts([FromBody] ProductModel product, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddProducts(product);
            return Ok("Product details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/whatsnew")]
    public IActionResult AddArticles([FromBody] WhatsNewModel wnew, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.AddWhatsNew(wnew);
            return Ok("Article details added!");
        }
        else {
           return Unauthorized(); 
        }
    }

    [HttpPost]
    [Route("/sessions")]
    public IActionResult? AddSessions([FromBody] UserCredentialsModel session)
    {
        if(session.Username != null && session.Password != null) {
            var sessions = CmsDatabase.AddSessionWithCredentials(session.Username, session.Password);
            if(sessions != null) {
                // CmsDatabase.AddSession(sessions);
                return Json(sessions);
            }
            else 
            {
                return Unauthorized(); 
            }
        }
        else
        {
            return Ok("Please input username, password and type.");
        }
    }

    [HttpGet]
    [Route("/users")]
    public IActionResult AllUsers([FromHeader(Name = "X-SessionID")] string SessionID)
    {
        var sessionID = CmsDatabase.GetSessionById(SessionID);
        if(sessionID.Username != null) {
            List<UserModel> users = CmsDatabase.GetUsers(sessionID.Username);
            if(sessionID != null) {
                return Json(users);
            }
            else {
                return Unauthorized(); 
            }
        }
        return Unauthorized(); 
    }

    [HttpGet]
    [Route("/staffs")]
    public IActionResult AllStaffs()
    {
            var staffs = CmsDatabase.GetStaffs();
            return Json(staffs);
    }

    [HttpGet]
    [Route("/promos")]
    public IActionResult AllPromos()
    {
            var promos = CmsDatabase.GetPromos();
            return Json(promos);
    }

    [HttpGet]
    [Route("/branches")]
    public IActionResult AllBranches()
    {
            var branches = CmsDatabase.GetBranches();
            return Json(branches);
    }

    [HttpGet]
    [Route("/guests")]
    public IActionResult AllGuests(GuestModel guests)
    {
            // CmsDatabase.InsertGuestData(guests);
            return Json(guests);
    }

    [HttpGet]
    [Route("/services")]
    public IActionResult AllServices()
    {
            var services = CmsDatabase.GetServices();
            return Json(services);
    }

    [HttpGet]
    [Route("/products")]
    public IActionResult AllProducts()
    {
            var products = CmsDatabase.GetProducts();
            return Json(products);
    }

    [HttpGet]
    [Route("/whatsnew")]
    public IActionResult AllArticles()
    {
            var wnew = CmsDatabase.GetArticles();
            return Json(wnew);
    }

    [HttpGet]
    [Route("/users/{id}")]
    public IActionResult UserIndex(int Id, [FromHeader(Name = "X-SessionID")] string SessionID)
    {
        var sessionID = CmsDatabase.GetSessionById(SessionID);
        if(sessionID != null) {
            if(sessionID.Username != null) {
                var users = CmsDatabase.GetUserById(Id, sessionID.Username);
                return Json(users);
            }
            else 
            {
                return Unauthorized(); 
            }
        }
        else {
            return Unauthorized(); 
        }
    }

    [HttpDelete]
    [Route("/users/{id}")]
    public IActionResult DeleteUser(int Id, [FromHeader(Name = "X-SessionID")] string SessionID)
    {
        var sessionID = CmsDatabase.GetSessionById(SessionID);
        if(sessionID.Username != null) {
            var users = CmsDatabase.GetUserById(Id, sessionID.Username);
            if(sessionID.Username != null && users.Username != null) {
                var verify = CmsDatabase.DoesUserOwnContact(sessionID.Username, users.Username);
                if(sessionID.Id != null) {
                    CmsDatabase.DeleteUser(Id);
                    return Ok("User details deleted!");
                }
                if(!verify) 
                {
                    return Unauthorized(); 
                }
                return Unauthorized(); 
            }
        }
        return Unauthorized(); 
    }

    [HttpDelete]
    [Route("/sessions/{id}")]
    public IActionResult DeleteSession(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteSession(Id);
            return Ok("Session details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/branches/{id}")]
    public IActionResult DeleteBranch(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteBranch(Id);
            return Ok("Branch details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/staffs/{id}")]
    public IActionResult DeleteStaff(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteStaff(Id);
            return Ok("Staff details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/promos/{id}")]
    public IActionResult DeletePromo(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeletePromo(Id);
            return Ok("Promo details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/whatsnew/{id}")]
    public IActionResult DeleteArticle(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteArticle(Id);
            return Ok("Article details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/services/{id}")]
    public IActionResult DeleteService(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteService(Id);
            return Ok("Service details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("/products/{id}")]
    public IActionResult DeleteProduct(string Id, [FromHeader(Name = "X-ApiKey")] string ApiKey)
    {
        var AdminApiKey = Environment.GetEnvironmentVariable("ADMIN_API_KEY");
        if(ApiKey == AdminApiKey) {
            CmsDatabase.DeleteProduct(Id);
            return Ok("Product details deleted!");
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpGet]
    [Route("/summary")]
    public IActionResult onViewAllBookingInfo()
    {
        var booklist = CmsDatabase.GetBookingData();
        return Json(booklist);
    }

    // FOR BRANCHES
    [HttpGet]
    [Route("/summary/silang")]
    public IActionResult onViewAllSilangInfo()
    {
        var booklist = CmsDatabase.GetSilangData();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/gentri")]
    public IActionResult onViewAllGentriInfo()
    {
        var booklist = CmsDatabase.GetGentriData();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/nasugbu")]
    public IActionResult onViewAllNasugbuInfo()
    {
        var booklist = CmsDatabase.GetNasugbuData();
        return Json(booklist);
    }

    // FOR SILANG STAFFS
    [HttpGet]
    [Route("/summary/silang/im")]
    public IActionResult onViewAllIm()
    {
        var booklist = CmsDatabase.GetBookingIm();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/silang/yoo")]
    public IActionResult onViewAllYoo()
    {
        var booklist = CmsDatabase.GetBookingYoo();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/silang/hirai")]
    public IActionResult onViewAllHirai()
    {
        var booklist = CmsDatabase.GetBookingHirai();
        return Json(booklist);
    }

    // FOR GENTRI STAFFS
    [HttpGet]
    [Route("/summary/gentri/minatozaki")]
    public IActionResult onViewAllMinatozaki()
    {
        var booklist = CmsDatabase.GetBookingMinatozaki();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/gentri/park")]
    public IActionResult onViewAllPark()
    {
        var booklist = CmsDatabase.GetBookingPark();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/gentri/myoui")]
    public IActionResult onViewAllMyoui()
    {
        var booklist = CmsDatabase.GetBookingMyoui();
        return Json(booklist);
    }

    // FOR SILANG STAFFS
    [HttpGet]
    [Route("/summary/nasugbu/kim")]
    public IActionResult onViewAllKim()
    {
        var booklist = CmsDatabase.GetBookingKim();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/nasugbu/son")]
    public IActionResult onViewAllSon()
    {
        var booklist = CmsDatabase.GetBookingSon();
        return Json(booklist);
    }

    [HttpGet]
    [Route("/summary/nasugbu/chou")]
    public IActionResult onViewAllChou()
    {
        var booklist = CmsDatabase.GetBookingChou();
        return Json(booklist);
    }
}
