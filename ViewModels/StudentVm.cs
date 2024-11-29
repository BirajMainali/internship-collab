namespace ProductApp.ViewModels;

public class StudentVm
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
}