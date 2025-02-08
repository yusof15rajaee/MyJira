namespace Project.Domain.ValueObjects;

public class ProjectDescription
{
    public string Value { get; }

    public ProjectDescription(string value)
    {
        if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

        this.Value = value;
    }
}
