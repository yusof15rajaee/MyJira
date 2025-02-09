namespace Project.Contracts.Dtos;
public class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}
