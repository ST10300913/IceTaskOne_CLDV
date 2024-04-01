using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IceTaskOne.Models; 

public class Boots
    {
    public int Id { get; set; } //primary key always needed.
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
}

