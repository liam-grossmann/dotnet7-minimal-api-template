namespace MinimalApiTemplate.Domain;

/// <summary>
/// User domain
/// </summary>
public class User
{
    public int Id { get; set; }
    public Guid Code { get; set; }
    
    /// <summary>
    /// First nane
    /// </summary>
    public string Firstname { get; set; } = null!;
    
    /// <summary>
    /// Last name
    /// </summary>
    public string Lastname { get; set; } = null!;
    
    /// <summary>
    /// Email address
    /// </summary>
    public string EmailAddress { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
}