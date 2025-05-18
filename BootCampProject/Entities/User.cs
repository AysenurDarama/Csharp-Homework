using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class User
{
    public int Id { get; set; }                   
    public string Username { get; set; }          
    public string FirstName { get; set; }          
    public string LastName { get; set; }          
    public DateTime DateOfBirth { get; set; }     
    public string NationalIdentity { get; set; }  
    public string Email { get; set; }              
    public string Password { get; set; }
    public UserType UserType { get; set; }

}
public enum UserType
{
    Applicant = 1,
    Instructor = 2,
    Employee = 3
}