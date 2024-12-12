namespace WebApplication1.Entities;

public class AppUser
{
    public int Id { get; set; }//By convention it is regarded as PK.
    public required string UserName { get; set; }
    
}

