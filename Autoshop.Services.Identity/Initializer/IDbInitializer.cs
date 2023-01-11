using System.Security.Claims;
using Autoshop.Services.Identity.DbContexts;
using Autoshop.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Autoshop.Services.Identity.Initializer;

public interface IDbInitializer
{
    public void Initialize();
}

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext dbContext;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;


    public DbInitializer(
        ApplicationDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    
    public void Initialize()
    {
        if (roleManager.FindByNameAsync(SD.Admin).Result == null)
        {
            roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
        }
        else
        {
            return;
        }

        var admin = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin@email.com",
            Email = "admin@email.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "ROman",
            LastName = "admin"
        };

        userManager.CreateAsync(admin, "admin_Admin_*1").GetAwaiter().GetResult();

        userManager.AddToRoleAsync(admin, SD.Admin).GetAwaiter().GetResult();

        var adminResult = userManager.AddClaimsAsync(admin, new Claim[]
        {
            new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
            new Claim(JwtClaimTypes.GivenName, $"{admin.FirstName}"),
            new Claim(JwtClaimTypes.FamilyName, $"{admin.LastName}"),
            new Claim(JwtClaimTypes.Role, SD.Admin)
        }).Result;
        
        var customer = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "customer@email.com",
            Email = "customer@email.com",
            EmailConfirmed = true,
            PhoneNumber = "111111111111",
            FirstName = "ROman",
            LastName = "customer"
        };

        userManager.CreateAsync(customer, "customer_Customer_*1").GetAwaiter().GetResult();

        userManager.AddToRoleAsync(customer, SD.Customer).GetAwaiter().GetResult();

        var customerResult = userManager.AddClaimsAsync(customer, new Claim[]
        {
            new Claim(JwtClaimTypes.Name, $"{customer.FirstName} {customer.LastName}"),
            new Claim(JwtClaimTypes.GivenName, $"{customer.FirstName}"),
            new Claim(JwtClaimTypes.FamilyName, $"{customer.LastName}"),
            new Claim(JwtClaimTypes.Role, SD.Customer)
        }).Result;
    }
}