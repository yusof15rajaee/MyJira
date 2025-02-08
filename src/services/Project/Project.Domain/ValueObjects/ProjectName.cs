namespace Project.Domain.ValueObjects;

public class ProjectName
{
    public string Value { get;}

    public ProjectName(string value)
    {
        if(string.IsNullOrWhiteSpace(value))throw new ArgumentNullException(nameof(value));

        this.Value = value;
    }
}
