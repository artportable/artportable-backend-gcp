using System;

namespace Artportable.API.DTOs
{
    public class UserWithSubscriptionDTO
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber {get; set;}

    public DateTime Created { get; set; }
    public int Subscription_Id {get; set;}
    
    public int Product_Id {get; set;}                  
    
    public string CustomerId {get; set;}           
    
     public DateTime? ExpirationDate { get; set; }
    public int User_Id{get; set;}
    public SubscriptionDTO Subscription { get; set; }
    public string SubscriptionStatus { get; set; } 
    public string ProductPlan {get; set;}
}

public class SubscriptionDTO
{
    public int Subscription_Id { get; set; }
    public int Product_Id { get; set; }
    public string CustomerId { get; set; }
    public DateTime? ExpirationDate { get; set; }
}

public class CustomerDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public string Phone {get; set;}

 
    }

}
