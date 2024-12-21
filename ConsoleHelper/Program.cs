using System.Reflection.Metadata.Ecma335;
using Domain.Entities.Business;
using Domain.Entities.Securities;
using E_Association.Core.Domain.Enums;
using E_Association.Infrastructure.Presitence.Data;
using Microsoft.AspNetCore.Http;

class App
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Associations.AddRange(GenerateAssociations());
            context.Users.AddRange(GenerateUser());
            context.SaveChanges();
        }
    }

    public static List<Association> GenerateAssociations()
    {
        var subscriptions = new List<Association>
        {
            new Association { Name = "Subscription 1", MonthlyAmount = 100, Capacity = 51, Applicants = 2, TotalBalance = 1100, Collector = Guid.NewGuid(), Status = AssociationStatus.Active, StartAt = DateTime.Now.AddMonths(-1), EndAt = DateTime.Now.AddMonths(1) },
            new Association { Name = "Subscription 2", MonthlyAmount = 110, Capacity = 52, Applicants = 4, TotalBalance = 1200, Collector = Guid.NewGuid(), Status = AssociationStatus.Inactive, StartAt = DateTime.Now.AddMonths(-2), EndAt = DateTime.Now.AddMonths(2) },
            new Association { Name = "Subscription 3", MonthlyAmount = 120, Capacity = 53, Applicants = 6, TotalBalance = 1300, Collector = Guid.NewGuid(), Status = AssociationStatus.Pending, StartAt = DateTime.Now.AddMonths(-3), EndAt = DateTime.Now.AddMonths(3) },
            new Association { Name = "Subscription 4", MonthlyAmount = 130, Capacity = 54, Applicants = 8, TotalBalance = 1400, Collector = Guid.NewGuid(), Status = AssociationStatus.Active, StartAt = DateTime.Now.AddMonths(-4), EndAt = DateTime.Now.AddMonths(4) },
            new Association { Name = "Subscription 5", MonthlyAmount = 140, Capacity = 55, Applicants = 10, TotalBalance = 1500, Collector = Guid.NewGuid(), Status =AssociationStatus.Active, StartAt = DateTime.Now.AddMonths(-5), EndAt = DateTime.Now.AddMonths(5) },
            new Association { Name = "Subscription 6", MonthlyAmount = 150, Capacity = 56, Applicants = 12, TotalBalance = 1600, Collector = Guid.NewGuid(), Status =AssociationStatus.Inactive, StartAt = DateTime.Now.AddMonths(-6), EndAt = DateTime.Now.AddMonths(6) },
            new Association { Name = "Subscription 7", MonthlyAmount = 160, Capacity = 57, Applicants = 14, TotalBalance = 1700, Collector = Guid.NewGuid(), Status = AssociationStatus.Pending, StartAt = DateTime.Now.AddMonths(-7), EndAt = DateTime.Now.AddMonths(7) },
            new Association { Name = "Subscription 8", MonthlyAmount = 170, Capacity = 58, Applicants = 16, TotalBalance = 1800, Collector = Guid.NewGuid(), Status = AssociationStatus.Active, StartAt = DateTime.Now.AddMonths(-8), EndAt = DateTime.Now.AddMonths(8) },
            new Association { Name = "Subscription 9", MonthlyAmount = 180, Capacity = 59, Applicants = 18, TotalBalance = 1900, Collector = Guid.NewGuid(), Status = AssociationStatus.Active, StartAt = DateTime.Now.AddMonths(-9), EndAt = DateTime.Now.AddMonths(9) },
            new Association { Name = "Subscription 10", MonthlyAmount = 190, Capacity = 60, Applicants = 20, TotalBalance = 2000, Collector = Guid.NewGuid(), Status = AssociationStatus.Inactive, StartAt = DateTime.Now.AddMonths(-10), EndAt = DateTime.Now.AddMonths(10) }
        };
        return subscriptions;
    }

    public static List<ApplicationUser> GenerateUser()
    {
        return new List<ApplicationUser>
        {
            new ApplicationUser {Address = "Cairo" ,UserName = "AhmedSalah", Email = "user1@example.com",PasswordHash = "Ahmed123" , Balance = new Balance(){ CreatedAt = DateTime.Now ,Amount = 0 } },
            new ApplicationUser {Address = "Zagazig" ,UserName = "user2@example.com", Email = "user2@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance(){ CreatedAt = DateTime.Now ,Amount = 0 ,}},
            new ApplicationUser {Address = "Cairo" ,UserName = "user3@example.com", Email = "user3@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance(){ CreatedAt = DateTime.Now ,Amount = 0 ,}},
            new ApplicationUser {Address = "Mansoura" ,UserName = "user4@example.com", Email = "user4@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "Cairo" ,UserName = "user5@example.com", Email = "user5@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "Sudia" ,UserName = "user6@example.com", Email = "user6@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "Cairo" ,UserName = "user7@example.com", Email = "user7@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "Emirat" ,UserName = "user8@example.com", Email = "user8@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "US" ,UserName = "user9@example.com", Email = "user9@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }},
            new ApplicationUser {Address = "Cairo" ,UserName = "user10@example.com", Email = "user10@example.com" ,PasswordHash = "Ahmed123", Balance = new Balance() { CreatedAt = DateTime.Now, Amount = 0 }}
        };
    }
    public static List<Withdrawals> GenerateWithdrawals()
    {
        return new List<Withdrawals>()
        {
            new Withdrawals(){ Amount = 10},
        };
    }
   
}