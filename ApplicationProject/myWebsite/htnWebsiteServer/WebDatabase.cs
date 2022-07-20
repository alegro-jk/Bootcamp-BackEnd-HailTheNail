using System.Data.SqlClient;

public class WebDatabase
{
    private static string? DB_CONNECTION_STRING;

    static WebDatabase()
    {
        DB_CONNECTION_STRING = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    }

    public static void CreateWebTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebBooking' and xtype='U')
                // CREATE TABLE WebBooking (
                //     id INT NOT NULL IDENTITY PRIMARY KEY,
                //     FirstName VARCHAR(255),
                //     LastName VARCHAR(255),
                //     Email VARCHAR(255),
                //     PhoneNumber VARCHAR(255),
                //     MethodOfContact VARCHAR(255),
                //     AvailServices VARCHAR(255),
                //     AvailProducts VARCHAR(255),
                //     PreferredBranch VARCHAR(255),
                //     PreferredTechnician VARCHAR(255),
                //     DateOfVisit VARCHAR(255),
                //     TimeOfVisit VARCHAR(255),
                //     GuestNumber INT,
                //     Request VARCHAR(255),
                //     Orderdate VARCHAR(255),
                //     Totalamount INT
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebServices' and xtype='U')
                // CREATE TABLE WebServices (
                //     id INT NOT NULL IDENTITY PRIMARY KEY,
                //     Name VARCHAR(255),
                //     Description VARCHAR(255),
                //     Price INT
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebProducts' and xtype='U')
                // CREATE TABLE WebProducts (
                //     id INT NOT NULL IDENTITY PRIMARY KEY,
                //     Name VARCHAR(255),
                //     Image VARBINARY(max),
                //     Price INT
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebStaffs' and xtype='U')
                // CREATE TABLE WebStaffs (
                //     StaffNames VARCHAR(255),
                //     StaffBranches VARCHAR(255),
                //     StaffDescriptions VARCHAR(255),
                //     StaffImages VARCHAR(255)
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebServices' and xtype='U')
                // CREATE TABLE WebServices (
                //     Name VARCHAR(255),
                //     Details VARCHAR(255),
                //     Price INT
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebProducts' and xtype='U')
                // CREATE TABLE WebProducts (
                //     Name VARCHAR(255),
                //     Image VARCHAR(255),
                //     Price INT
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebPromos' and xtype='U')
                // CREATE TABLE WebPromos (
                //     Name VARCHAR(255),
                //     Period VARCHAR(255),
                //     Image VARCHAR(255)
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebArticles' and xtype='U')
                // CREATE TABLE WebArticles (
                //     SiteUrl VARCHAR(255),
                //     Image VARCHAR(255),
                //     ImageSource VARCHAR(255)
                //     );";
                // command.ExecuteNonQuery();

                // command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebBranches' and xtype='U')
                // CREATE TABLE WebBranches (
                //     Branch VARCHAR(255),
                //     Address VARCHAR(255),
                //     Contact VARCHAR(255),
                //     Operation VARCHAR(255),
                //     Map VARCHAR(MAX)
                //     );";
                // command.ExecuteNonQuery();

                command.CommandText = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='WebOptions' and xtype='U')
                CREATE TABLE WebOptions (
                    Products VARCHAR(255),
                    Services VARCHAR(255),
                    Branch VARCHAR(255),
                    Staff VARCHAR(255),
                    StaffBranch VARCHAR(255)
                    );";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void DropWebTables()
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = 
                    @"DROP TABLE IF EXISTS WebBranches;";
                command.ExecuteNonQuery();
            }
        }
    }

    public static void InsertBookingData(BookingModel model)
    {
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = @"INSERT INTO WebBooking (FirstName, LastName, Email, PhoneNumber, MethodOfContact, AvailServices, AvailProducts, PreferredBranch, PreferredTechnician, DateOfVisit, TimeOfVisit, GuestNumber, Request, Orderdate, Totalamount)
                VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @MethodOfContact, @AvailServices, @AvailProducts, @PreferredBranch, @PreferredTechnician, @DateOfVisit, @TimeOfVisit, @GuestNumber, @Request, @Orderdate, @Totalamount
                )";
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@MethodOfContact", model.MethodOfContact);
                command.Parameters.AddWithValue("@AvailServices",  model.AvailServices);
                command.Parameters.AddWithValue("@AvailProducts", model.AvailProducts);
                command.Parameters.AddWithValue("@PreferredBranch", model.PreferredBranch);
                command.Parameters.AddWithValue("@PreferredTechnician", model.PreferredTechnician);
                command.Parameters.AddWithValue("@DateOfVisit", model.DateOfVisit);
                command.Parameters.AddWithValue("@TimeOfVisit", model.TimeOfVisit);
                command.Parameters.AddWithValue("@GuestNumber", model.GuestNumber);
                command.Parameters.AddWithValue("@Request", model.Request);
                command.Parameters.AddWithValue("@Orderdate", model.Orderdate);
                command.Parameters.AddWithValue("@Totalamount", model.Totalamount);
                command.ExecuteNonQuery();
            }
        }
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

    public static List<StaffModel> GetAllStaffInfo()
    {
        var stafflist = new List<StaffModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebStaffs;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    stafflist.Add(new StaffModel {
                        StaffNames = reader.GetString(0),
                        StaffBranches = reader.GetString(1), 
                        StaffDescriptions = reader.GetString(2), 
                        StaffImages = reader.GetString(3)});
                }
            }
        }
        return stafflist;
    }

    public static List<ServiceModel> GetAllServiceInfo()
    {
        var servicelist = new List<ServiceModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebServices;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    servicelist.Add(new ServiceModel {
                        Name = reader.GetString(0),
                        Details = reader.GetString(1), 
                        Price = reader.GetInt32(2)});
                }
            }
        }
        return servicelist;
    }

    public static List<ProductModel> GetAllProductInfo()
    {
        var prodlist = new List<ProductModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebProducts;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    prodlist.Add(new ProductModel {
                        Name = reader.GetString(0),
                        Image = reader.GetString(1), 
                        Price = reader.GetInt32(2)});
                }
            }
        }
        return prodlist;
    }

    public static List<PromoModel> GetAllPromoInfo()
    {
        var promolist = new List<PromoModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebPromos;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    promolist.Add(new PromoModel {
                        Name = reader.GetString(0),
                        Period = reader.GetString(1), 
                        Image = reader.GetString(2)});
                }
            }
        }
        return promolist;
    }

    public static List<WhatsNewModel> GetAllArticleInfo()
    {
        var wnew = new List<WhatsNewModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebArticles;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    wnew.Add(new WhatsNewModel {
                        SiteUrl = reader.GetString(0),
                        Image = reader.GetString(1), 
                        ImageSource = reader.GetString(2)});
                }
            }
        }
        return wnew;
    }

    public static List<BranchModel> GetAllBranchInfo()
    {
        var branch = new List<BranchModel>();
        using(var db = new SqlConnection(DB_CONNECTION_STRING))
        {
            db.Open();
            using(var command = db.CreateCommand())
            {
                command.CommandText = "SELECT * FROM WebBranches;";
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    branch.Add(new BranchModel {
                        Branch = reader.GetString(0),
                        Address = reader.GetString(1), 
                        Contact = reader.GetString(2),
                        Operation = reader.GetString(3),
                        Map = reader.GetString(4)
                        });
                }
            }
        }
        return branch;
    }

    // public static OptionModel GetOptions()
    // {
    //     using(var db = new SqlConnection(DB_CONNECTION_STRING))
    //     {
    //         db.Open();
    //         using(var command = db.CreateCommand())
    //         {
    //             OptionModel model = new OptionModel();

    //             List<string> products = new List<string>();
    //             command.CommandText = "SELECT Name FROM WebProducts";
    //             var reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 products.Add(reader.GetString(0));
    //             }
    //             model.Products = products;
    //             reader.Close();

    //             List<string> services = new List<string>();
    //             command.CommandText = "SELECT Name FROM WebServices";
    //             reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 services.Add(reader.GetString(0));
    //             }
    //             model.Services = services;
    //             reader.Close();

    //             List<string> branch = new List<string>();
    //             command.CommandText = "SELECT Branch FROM WebBranches";
    //             reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 branch.Add(reader.GetString(0));
    //             }
    //             model.Branch = branch;
    //             reader.Close();

    //             List<string> staff = new List<string>();
    //             command.CommandText = "SELECT Name FROM WebStaffs";
    //             reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 staff.Add(reader.GetString(0));
    //             }
    //             model.Staff = staff;
    //             reader.Close();

    //             List<string> staffbranch = new List<string>();
    //             command.CommandText = "SELECT StaffBranches FROM WebStaffs";
    //             reader = command.ExecuteReader();
    //             while(reader.Read())
    //             {
    //                 staffbranch.Add(reader.GetString(0));
    //             }
    //             model.StaffBranch = staffbranch;
    //             reader.Close();

    //             return model;
    //         }
    //     }
    // }

}