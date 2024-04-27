namespace backend;
/// <summary>
/// A class that defines the properties of the User entity.
/// </summary>
public class User
{
    /// <summary>
    /// The Id of the User.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the User.
    /// </summary>
    public required string Name { get; set; }
}