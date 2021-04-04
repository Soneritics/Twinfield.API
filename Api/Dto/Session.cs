namespace Api.Dto
{
    /// <summary>
    /// Session object, used to authorize between services.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the cluster URI.
        /// </summary>
        /// <value>
        /// The cluster URI.
        /// </value>
        public string ClusterUri { get; set; }
    }
}
