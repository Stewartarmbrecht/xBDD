namespace xBDD
{
    /// <summary>
    /// Wrapper class used to pass objects to steps.
    /// TODO: Explain Wrapper Class
    /// Not user why this is used.  Need to test and explain.null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Wrapper<T>
    {
        /// <summary>
        /// Gets or sets the object that is to be wrapped.
        /// </summary>
        /// <value>Object of type T</value>
        public T Object { get; set; }
    }
}
