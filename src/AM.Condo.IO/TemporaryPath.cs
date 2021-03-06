namespace AM.Condo.IO
{
    using System;
    using System.IO;

    using static System.FormattableString;

    /// <summary>
    /// Represents a temporary path used for testing purposes.
    /// </summary>
    public class TemporaryPath : IPathManager, IDisposable
    {
        #region Fields
        private readonly IPathManager path;

        private bool disposed;
        #endregion

        #region Constructors and Finalizers
        /// <summary>
        /// Initializes a new instance of the <see cref="TemporaryPath"/> class.
        /// </summary>
        public TemporaryPath()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemporaryPath"/> class.
        /// </summary>
        /// <param name="prefix">
        /// The prefix of the temporary path.
        /// </param>
        public TemporaryPath(string prefix)
        {
            // determine if the prefix is set
            if (string.IsNullOrEmpty(prefix))
            {
                // set a default prefix
                prefix = "condo";
            }

            // create the temporary path
            var path = Path.Combine(Path.GetTempPath(), Invariant($"{prefix}"), Path.GetRandomFileName());

            // create the directory for the path
            Directory.CreateDirectory(path);

            // create the path manager
            this.path = new PathManager(path);
        }
        #endregion

        #region Properties
        /// <inheritdoc/>
        public string FullPath => this.path.FullPath;
        #endregion

        #region Methods
        /// <inheritdoc/>
        public string Combine(string path)
        {
            return this.path.Combine(path);
        }

        /// <inheritdoc/>
        public bool Exists()
        {
            return this.path.Exists();
        }

        /// <inheritdoc/>
        public string Create(string relativePath)
        {
            return this.path.Create(relativePath);
        }

        /// <inheritdoc/>
        public string Save(string relativePath, string contents)
        {
            return this.path.Save(relativePath, contents);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// A value indicating whether or not dispose was called manually.
        /// </param>
        protected void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                // throw an object disposed exception
                throw new ObjectDisposedException(nameof(TemporaryPath));
            }

            // set the disposed flag
            this.disposed = true;

            try
            {
                // delete the directory
                Directory.Delete(this.path.FullPath, recursive: true);
            }
            catch
            {
                // swallow exceptions on dispose
            }

            // dispose of the underlying path
            this.path.Dispose();
        }
        #endregion
    }
}