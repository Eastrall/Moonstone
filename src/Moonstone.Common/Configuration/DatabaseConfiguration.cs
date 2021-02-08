namespace Moonstone.Common.Configuration
{
    /// <summary>
    /// Provides a data structure for configuring the Moonstone database access.
    /// </summary>
    public class DatabaseConfiguration
    {
        /// <summary>
        /// Gets or sets the database remote host.
        /// </summary>
        public string Host { get; set; } = null!;

        /// <summary>
        /// Gets or sets the database remote listening port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the database server username.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the database server password for the specified username.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets the database name on the server.
        /// </summary>
        public string Database { get; set; } = null!;
    }
}
