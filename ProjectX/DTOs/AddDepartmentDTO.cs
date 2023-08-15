using System.ComponentModel.DataAnnotations;

public record AddDepartmentDTO
{
    [Required]
    public string Name { get; set; }
    
}