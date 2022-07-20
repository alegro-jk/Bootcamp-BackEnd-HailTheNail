namespace CmsModel;
public class GuestModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    // public string? PhoneNumber { get; set; }
    public string? AvailServices {get;set;}
    public string? AvailProducts {get;set;}
    public string? PreferredBranch {get;set;}
    public string? DateOfVisit {get;set;}
    public string? TimeOfVisit {get;set;}
    // public string? Orderdate {get;set;}
    public int Totalamount {get;set;}
}