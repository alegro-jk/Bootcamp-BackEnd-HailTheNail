using System.Data.SqlClient;
using CmsModel;

public class CmsDatabase
{
    private static string? DB_CONNECTION_STRING;

    static CmsDatabase()
    {
        DB_CONNECTION_STRING = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    }

    public static void CreateAdminTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsUsers' and xtype='U')
                // CREATE TABLE CmsUsers (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // FirstName VARCHAR(255),
                // LastName VARCHAR(255),
                // Branch VARCHAR(255),
                // Position VARCHAR(255),
                // Type VARCHAR(255),
                // Username VARCHAR(255),
                // Password VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsSessions' and xtype='U')
                // CREATE TABLE CmsSessions (
                // id VARCHAR(255) NOT NULL PRIMARY KEY,
                // Username VARCHAR(255),
                // Type VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsStaffs' and xtype='U')
                // CREATE TABLE CmsStaffs (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Name VARCHAR(255),
                // Age VARCHAR(255),
                // Branch VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsPromos' and xtype='U')
                // CREATE TABLE CmsPromos (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Name VARCHAR(255),
                // Period VARCHAR(255),
                // Branch VARCHAR(255),
                // Status VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsBranches' and xtype='U')
                // CREATE TABLE CmsBranches (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Branch VARCHAR(255),
                // Address VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsGuests' and xtype='U')
                // CREATE TABLE CmsGuests (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // FirstName VARCHAR(255),
                // LastName VARCHAR(255),
                // AvailServices VARCHAR(255),
                // AvailProducts VARCHAR(255),
                // PreferredBranch VARCHAR(255),
                // DateOfVisit VARCHAR(255),
                // TimeOfVisit VARCHAR(255),
                // Totalamount INT
                // )";
                // command.ExecuteNonQuery();

            }
        }
    }

    public static void CreateEmployeeTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsServices' and xtype='U')
                // CREATE TABLE CmsServices (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Name VARCHAR(255),
                // Price INT
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsProducts' and xtype='U')
                // CREATE TABLE CmsProducts (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Name VARCHAR(255),
                // Price INT
                // )";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CmsWhatsNew' and xtype='U')
                // CREATE TABLE CmsWhatsNew (
                // id INT NOT NULL IDENTITY PRIMARY KEY,
                // Name VARCHAR(255),
                // Period VARCHAR(255),
                // Status VARCHAR(255)
                // )";
                // command.ExecuteNonQuery();
            }
        }
    }

    public static void DropAdminTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                // command.CommandText = "DROP TABLE IF EXISTS CmsUsers;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsSessions;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsStaffs;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsPromos;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsBranches;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsGuests;";
                // command.ExecuteNonQuery();
            }
        }
    }

    public static void DropEmployeeTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                // command.CommandText = "DROP TABLE IF EXISTS CmsServices;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsProducts;";
                // command.ExecuteNonQuery();
                // command.CommandText = "DROP TABLE IF EXISTS CmsWhatsNew;";
                // command.ExecuteNonQuery();
            }
        }
    }

    public static void AddUser(UserModel user)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsUsers (FirstName, LastName, Branch, Position, Type, Username, Password) VALUES (@FirstName, @LastName, @Branch, @Position, @Type, @Username, @Password);";
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Branch", user.Branch);
                command.Parameters.AddWithValue("@Position", user.Position);
                command.Parameters.AddWithValue("@Type", user.Type);
                command.Parameters.AddWithValue("@Username", user.Username);
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                command.Parameters.AddWithValue("@Password", hashPassword);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void AddStaff(StaffModel staff)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsStaffs (Name, Age, Branch) VALUES (@Name, @Age, @Branch);";
                command.Parameters.AddWithValue("@Name", staff.Name);
                command.Parameters.AddWithValue("@Age", staff.Age);
                command.Parameters.AddWithValue("@Branch", staff.Branch);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void AddPromo(PromoModel promo)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsPromos (Name, Period, Branch, Status) VALUES (@Name, @Period, @Branch, @Status);";
                command.Parameters.AddWithValue("@Name", promo.Name);
                command.Parameters.AddWithValue("@Period", promo.Period);
                command.Parameters.AddWithValue("@Branch", promo.Branch);
                command.Parameters.AddWithValue("@Status", promo.Status);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void AddBranch(BranchModel branch)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsBranches (Branch, Address) VALUES (@Branch, @Address);";
                command.Parameters.AddWithValue("@Branch", branch.Branch);
                command.Parameters.AddWithValue("@Address", branch.Address);
                command.ExecuteNonQuery();
            }
        }
    }

    // public static void AddGuest(GuestModel guest)
    // {
    //     using(var db = new SqlConnection(DB_CONNECTION_STRING))
    //     {
    //         db.Open();
    //         using(var command = db.CreateCommand())
    //         {
    //             command.CommandText = "INSERT INTO CmsGuests (FirstName, LastName, AvailServices, AvailProducts, PreferredBranch, DateOfVisit, TimeOfVisit, Totalamount) VALUES (@FirstName, @LastName, @AvailServices, @AvailProducts, @PreferredBranch, @DateOfVisit, @TimeOfVisit, @Totalamount);";
    //             command.Parameters.AddWithValue("@FirstName", guest.FirstName);
    //             command.Parameters.AddWithValue("@LastName", guest.LastName);
    //             command.Parameters.AddWithValue("@AvailServices", guest.AvailServices);
    //             command.Parameters.AddWithValue("@AvailProducts", guest.AvailProducts);
    //             command.Parameters.AddWithValue("@PreferredBranch", guest.PreferredBranch);
    //             command.Parameters.AddWithValue("@DateOfVisit", guest.DateOfVisit);
    //             command.Parameters.AddWithValue("@TimeOfVisit", guest.TimeOfVisit);
    //             command.Parameters.AddWithValue("@Totalamount", guest.Totalamount);
    //             command.ExecuteNonQuery();
    //         }
    //     }
    // }

    public static void AddService(ServiceModel service)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsServices (Name, Price) VALUES (@Name, @Price);";
                command.Parameters.AddWithValue("@Name", service.Name);
                command.Parameters.AddWithValue("@Price", service.Price);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void AddProducts(ProductModel product)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsProducts (Name, Price) VALUES (@Name, @Price);";
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void AddWhatsNew(WhatsNewModel wnew)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsWhatsNew (Name, Period, Status) VALUES (@Name, @Period, @Status);";
                command.Parameters.AddWithValue("@Name", wnew.Name);
                command.Parameters.AddWithValue("@Period", wnew.Period);
                command.Parameters.AddWithValue("@Status", wnew.Status);
                command.ExecuteNonQuery();
            }
        }
    }

    public static List<UserModel> GetUsers(string user)
    {
        var userlist = new List<UserModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsUsers WHERE Username = '{user}';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    userlist.Add(new UserModel {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Branch = reader.GetString(3),
                        Position = reader.GetString(4),
                        Type = reader.GetString(5),
                        Username = reader.GetString(6),
                        Password = reader.GetString(7)
                    });
                }
            }
        }
        return userlist;
    }

    public static List<StaffModel> GetStaffs()
    {
        var stafflist = new List<StaffModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsStaffs;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    stafflist.Add(new StaffModel {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetString(2),
                        Branch = reader.GetString(3)
                    });
                }
            }
        }
        return stafflist;
    }

    public static List<PromoModel> GetPromos()
    {
        var promolist = new List<PromoModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsPromos;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    promolist.Add(new PromoModel {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Period = reader.GetString(2),
                        Branch = reader.GetString(3),
                        Status = reader.GetString(4)
                    });
                }
            }
        }
        return promolist;
    }

    public static List<BranchModel> GetBranches()
    {
        var branchlist = new List<BranchModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsBranches;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    branchlist.Add(new BranchModel {
                        Id = reader.GetInt32(0),
                        Branch = reader.GetString(1),
                        Address = reader.GetString(2)
                    });
                }
            }
        }
        return branchlist;
    }

    // public static List<GuestModel> GetGuests()
    // {
    //     var guestlist = new List<GuestModel>();
    //     using(var db = new SqlConnection(DB_CONNECTION_STRING))
    //     {
    //         db.Open();
    //         using(var command = db.CreateCommand())
    //         {
    //             command.CommandText = $"SELECT FirstName, LastName, AvailServices, AvailProducts, PreferredBranch, DateOfVisit, TimeOfVisit, Totalamount FROM WebBooking;";
    //             var reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 guestlist.Add(new GuestModel {
    //                     Id = reader.GetInt32(0),
    //                     FirstName = reader.GetString(1),
    //                     LastName = reader.GetString(2),
    //                     AvailServices = reader.GetString(3),
    //                     AvailProducts = reader.GetString(4),
    //                     PreferredBranch = reader.GetString(5),
    //                     DateOfVisit = reader.GetString(6),
    //                     TimeOfVisit = reader.GetString(7),
    //                     Totalamount = reader.GetInt32(8)
    //                 });
    //             }
    //         }
    //     }
    //     return guestlist;
    // }

    // public static void InsertGuestData(GuestModel guest)
    // {
    //     using(var db = new SqlConnection(DB_CONNECTION_STRING))
    //     {
    //         db.Open();
    //         using(var command = db.CreateCommand())
    //         {
    //             command.CommandText = @"SELECT FirstName, LastName, AvailServices, AvailProducts, PreferredBranch, DateOfVisit, TimeOfVisit, Totalamount FROM WebBooking;
    //             INSERT INTO CmsGuests (FirstName, LastName, AvailServices, AvailProducts, PreferredBranch, DateOfVisit, TimeOfVisit, Totalamount) VALUES (@FirstName, @LastName, @AvailServices, @AvailProducts, @PreferredBranch, @DateOfVisit, @TimeOfVisit, @Totalamount);";
    //             command.Parameters.AddWithValue("@FirstName", guest.FirstName);
    //             command.Parameters.AddWithValue("@LastName", guest.LastName);
    //             command.Parameters.AddWithValue("@AvailServices", guest.AvailServices);
    //             command.Parameters.AddWithValue("@AvailProducts", guest.AvailProducts);
    //             command.Parameters.AddWithValue("@PreferredBranch", guest.PreferredBranch);
    //             command.Parameters.AddWithValue("@DateOfVisit", guest.DateOfVisit);
    //             command.Parameters.AddWithValue("@TimeOfVisit", guest.TimeOfVisit);
    //             command.Parameters.AddWithValue("@Totalamount", guest.Totalamount);
    //             command.ExecuteNonQuery();
    //         }
    //     }
    // }

    public static List<ServiceModel> GetServices()
    {
        var servicelist = new List<ServiceModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsServices;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    servicelist.Add(new ServiceModel {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }
            }
        }
        return servicelist;
    }

    public static List<ProductModel> GetProducts()
    {
        var productlist = new List<ProductModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsProducts;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    productlist.Add(new ProductModel {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }
            }
        }
        return productlist;
    }

    public static List<WhatsNewModel> GetArticles()
    {
        var articlelist = new List<WhatsNewModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsWhatsNew;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    articlelist.Add(new WhatsNewModel {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Period = reader.GetString(2),
                        Status = reader.GetString(3),
                    });
                }
            }
        }
        return articlelist;
    }

    public static UserModel GetUserById(int Id, string user)
    {
        var userModel = new UserModel();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsUsers WHERE Id= '{Id}' and Username = '{user}';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    userModel.Id = reader.GetInt32(0);
                    userModel.FirstName = reader.GetString(1);
                    userModel.LastName = reader.GetString(2);
                    userModel.Branch = reader.GetString(3);
                    userModel.Position = reader.GetString(4);
                    userModel.Type = reader.GetString(5);
                    userModel.Username = reader.GetString(6);
                    userModel.Password = reader.GetString(7);
                }
            }
        }
        return userModel;
    }

    public static void DeleteUser(int Id)
    {
        var userModel = new UserModel();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsUsers WHERE Id = '{Id}';";
                var reader = command.ExecuteReader();
            }
        }
    }

    public static void AddSession(SessionModel session)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "INSERT INTO CmsSessions (Id, Username, Type) VALUES (@Id, @Username, @Type)";
                command.Parameters.AddWithValue("@Id", session.Id); 
                command.Parameters.AddWithValue("@Username", session.Username);
                command.Parameters.AddWithValue("@Type", session.Type);
                command.ExecuteNonQuery();
            }
        }
    }

    public static SessionModel GetSessionById(string Id)
    {
        var sessionModel = new SessionModel();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM CmsSessions WHERE Id = '{Id}';";
                var reader = command.ExecuteReader();
                if(reader.HasRows == true)
                {
                    while(reader.Read())
                    {
                        sessionModel.Id = reader.GetString(0);
                        sessionModel.Username = reader.GetString(1);
                        sessionModel.Type = reader.GetString(2);
                    }
                    return sessionModel;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public static SessionModel AddSessionForUser(string Username, string Type)
    {
        var randomId = Guid.NewGuid().ToString();
        var sessionModel = new SessionModel();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                sessionModel.Id = randomId;
                sessionModel.Username = Username;
                sessionModel.Type = Type;
                AddSession(sessionModel);
            }
        }
        return sessionModel;
    }

    public static SessionModel? AddSessionWithCredentials(string Username, string Password)
    {
        var login = false;
        var sessionModel = new SessionModel();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"SELECT Username, Password, Type FROM CmsUsers WHERE Username= '{Username}';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    login = BCrypt.Net.BCrypt.Verify(Password, reader.GetString(1));
                    sessionModel.Type = reader.GetString(2);
                }
            }
            if(login) {
                sessionModel = AddSessionForUser(Username, sessionModel.Type);
                return sessionModel;
            }
        }
        return null;
    }

    public static void DeleteSession(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsSessions where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteBranch(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsBranches where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteStaff(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsStaffs where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeletePromo(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsPromos where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteService(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsServices where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteProduct(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsProducts where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteArticle(string Id)
    {
        using (var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = $"DELETE FROM CmsWhatsNew where Id = '{Id}';";
                command.ExecuteNonQuery();
            }
        }
    }

    public static bool DoesUserOwnContact(string UserId, string Username)
    {
        var verification = false;
        if(UserId != Username)
        {
            return verification;
        }
        else
        {
            verification = true;
        }
        return verification;
    }

    public static List<BookingModel> GetBookingData()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    // FOR BRANCHES
    public static List<BookingModel> GetSilangData()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredBranch='Silang';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetGentriData()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredBranch='Gentri';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetNasugbuData()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredBranch='Nasugbu';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    // FOR SILANG STAFFS
    public static List<BookingModel> GetBookingIm()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Im Nayeon%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingYoo()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Yoo Jeongyeon%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingHirai()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Hirai Momo%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    // FOR GENTRI STAFFS
    public static List<BookingModel> GetBookingMinatozaki()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Minatozaki Sana%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingPark()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Park Jihyo%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingMyoui()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Myoui Mina%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    // FOR NASUGBU STAFFS
    public static List<BookingModel> GetBookingKim()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Kim Dahyun%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingSon()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Son Chaeyoung%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }

    public static List<BookingModel> GetBookingChou()
    {
        var bookingData = new List<BookingModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBooking WHERE PreferredTechnician LIKE '%Chou Tzuyu%';";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    bookingData.Add(new BookingModel {
                        Id = reader.GetInt32(0), 
                        FirstName = reader.GetString(1), 
                        LastName = reader.GetString(2), 
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        MethodOfContact = reader.GetString(5),
                        AvailServices = reader.GetString(6),
                        AvailProducts = reader.GetString(7),
                        PreferredBranch = reader.GetString(8),
                        PreferredTechnician = reader.GetString(9),
                        DateOfVisit = reader.GetString(10),
                        TimeOfVisit = reader.GetString(11),
                        GuestNumber = reader.GetInt32(12),
                        Request = reader.GetString(13),
                        Orderdate = reader.GetString(14),
                        Totalamount = reader.GetInt32(15)
                    });
                }
            }
        }
        return bookingData;
    }
}