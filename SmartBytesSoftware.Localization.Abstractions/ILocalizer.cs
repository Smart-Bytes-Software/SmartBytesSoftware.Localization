namespace SmartBytesSoftware.Localization.Abstractions
{
    public interface ILocalizer
    {    
        /// <summary>
         /// Gets the string resource with the given name.
         /// </summary>
         /// <param name="name">The name of the string resource.</param>
        string this[string name] { get; }
    }
}
