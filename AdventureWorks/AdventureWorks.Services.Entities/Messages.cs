using System;
using System.Resources;

namespace AdventureWorks.Services.Entities
{
    /// <summary>
    /// Message codes, as well as a resource manager to get a (localized) message text for those.
    /// </summary>
    public static class Messages
    {
        private static readonly Lazy<ResourceManager> resourceManager =
            new Lazy<ResourceManager>(() => new ResourceManager("AdventureWorks.Services.Entities.Resources", typeof(Messages).Assembly));

        /// <summary>
        /// Resource manager for the current messages.
        /// </summary>
        public static ResourceManager ResourceManager
        {
            get { return resourceManager.Value; }
        }

        /// <summary>
        /// {0} with id {1} already exists.
        /// Where {0}=Entity Type, {1}=Entity ID
        /// </summary>
        public const string EntityExistsWithKey = "EntityExistsWithKey";

        /// <summary>
        /// {0} with id ({1}) already exists.
        /// Where {0}=Entity Type, {1}=Entity Keys
        /// </summary>
        public const string EntityExistsWithKeys = "EntityExistsWithKeys";

        /// <summary>
        /// {0} with id {1} not found.
        /// Where {0}=Entity Type, {1}=Entity ID
        /// </summary>
        public const string EntityNotFoundByKey = "EntityNotFoundByKey";

        /// <summary>
        /// {0} with id ({1}) not found.
        /// Where {0}=Entity Type, {1}=Entity Keys
        /// </summary>
        public const string EntityNotFoundByKeys = "EntityNotFoundByKeys";

        /// <summary>
        /// Invalid value {0} for parameter {1}. Cannot find the corresponding {2} object.
        /// Where {0}=Value, {1}=Parameter Name, {2}=Reference Entity Type
        /// </summary>
        public const string InvalidForeignKey = "InvalidForeignKey";

        /// <summary>
        /// Invalid values ({0}) for parameters ({1}). Cannot find the corresponding {2} object.
        /// Where {0}=Values, {1}=Parameter Names, {2}=Reference Entity Type
        /// </summary>
        public const string InvalidForeignKeys = "InvalidForeignKeys";

        /// <summary>
        /// Payment information is required for order {0}.
        /// Where {0}=Order ID
        /// </summary>
        public const string PaymentRequired = "PaymentRequired";
    }
}
