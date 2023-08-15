using System;
using System.ComponentModel.DataAnnotations;

public record AddEmployeeDTO
{
    [Required]
    public string FirstName {get;set;}

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateOnly DOB { get; set; }


    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Phone]
    [Required]
    public string Phone { get; set; }

    
    public int DepartmentId { get; set; }
}