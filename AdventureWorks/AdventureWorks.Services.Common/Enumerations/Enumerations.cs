//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Enumeration Constants" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

namespace AdventureWorks.Services.Common.Enumerations
{
    #region Operators
    ///<summary>
    /// A list of operators to be used with filter criteria.
    ///</summary>
    public class Operators
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "operators";

        ///<summary>
        /// Additional attributes for enumeration 'operators'.
        ///</summary>
        public class Attributes
        {
            ///<summary>
            /// Defines the sort order of the operators with respect to other operators.
            ///</summary>
            public const string SortOrder = "sort order";
            ///<summary>
            /// The number of additional data properties that the operator needs.
            /// 0 (default) means it needs no additional values, 1 means it needs a value and 2 is for ranges that need both ends.
            ///</summary>
            public const string AddlProps = "addl props";
            ///<summary>
            /// 1 if the additional property can be multi-valued, 0 otherwise.
            ///</summary>
            public const string Multival = "multival";
            ///<summary>
            /// Fully qualified type of the additional property, which this operator applies to.
            /// It will also apply to all subclasses of this type. Multiple types can be specified.
            ///</summary>
            public const string Type = "type";
            ///<summary>
            /// Fully qualified type of the additional property, which this operator does not apply to.
            /// It won't also apply to all subclasses of this type. Multiple exclude types can be specified.
            /// Exclude types should be generally more concrete than include types.
            ///</summary>
            public const string ExcludeType = "exclude type";
            ///<summary>
            /// 1 for null checks, otherwise 0 (default).
            ///</summary>
            public const string NullCheck = "null check";
        }

        ///<summary>
        /// Checks if the target value is blank.
        ///</summary>
        public const string IsNull = "NL";
        ///<summary>
        /// Checks if the target value is not blank.
        ///</summary>
        public const string IsNotNull = "NNL";
        ///<summary>
        /// Checks if the target value is equal to the specified value.
        ///</summary>
        public const string IsEqualTo = "EQ";
        ///<summary>
        /// Checks if the target value is not equal to the specified value.
        ///</summary>
        public const string IsNotEqualTo = "NEQ";
        ///<summary>
        /// Checks if the target value is one of the values listed.
        ///</summary>
        public const string IsOneOf = "In";
        ///<summary>
        /// Checks if the target value is none of the values listed.
        ///</summary>
        public const string IsNoneOf = "NIn";
        ///<summary>
        /// Checks if the target value is less than the specified values.
        ///</summary>
        public const string IsLessThan = "LT";
        ///<summary>
        /// Checks if the target value is less than or equal to the specified values.
        ///</summary>
        public const string IsLessThanOrEqualTo = "LE";
        ///<summary>
        /// Checks if the target value is greater than the specified values.
        ///</summary>
        public const string IsGreaterThan = "GT";
        ///<summary>
        /// Checks if the target value is greater than or equal to the specified values.
        ///</summary>
        public const string IsGreaterThanOrEqualTo = "GE";
        ///<summary>
        /// Checks if the target date/time is today.
        ///</summary>
        public const string Today = "[bod,eod)";
        ///<summary>
        /// Checks if the target date/time is this week.
        ///</summary>
        public const string ThisWeek = "[bow,eow)";
        ///<summary>
        /// Checks if the target date/time is this month.
        ///</summary>
        public const string ThisMonth = "[boM,eoM)";
        ///<summary>
        /// Checks if the target date/time is this year.
        ///</summary>
        public const string ThisYear = "[boy,eoy)";
        ///<summary>
        /// Checks if the target date/time is within the last 30 days from today.
        ///</summary>
        public const string Last30Days = "[bod-30d,ct]";
        ///<summary>
        /// Checks if the target date/time is earlier than the specified date/time.
        ///</summary>
        public const string IsEarlierThan = "Earlier";
        ///<summary>
        /// Checks if the target date/time is later than the specified date/time.
        ///</summary>
        public const string IsLaterThan = "Later";
        ///<summary>
        /// Checks if the target value contains the specified string.
        ///</summary>
        public const string Contains = "CN";
        ///<summary>
        /// Checks if the target value does not contain the specified string.
        ///</summary>
        public const string DoesNotContain = "NCN";
        ///<summary>
        /// Checks if the target value starts with the specified string.
        ///</summary>
        public const string StartsWith = "SW";
        ///<summary>
        /// Checks if the target value does not starts with the specified string.
        ///</summary>
        public const string DoesNotStartWith = "NSW";
        ///<summary>
        /// Checks if the target value is between the specified values.
        ///</summary>
        public const string IsBetween = "BW";
        ///<summary>
        /// Checks if the target value is not between the specified values.
        ///</summary>
        public const string IsNotBetween = "NBW";
    }
    #endregion

    #region Product
    ///<summary>
    /// Cached enumeration returned by the IProductService.ReadListAsync operation.
    ///  
    ///</summary>
    public class Product
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "product";

        ///<summary>
        /// Additional attributes for enumeration 'product'.
        ///</summary>
        public class Attributes
        {
            public const string ProductSubcategoryId = "product subcategory id";
            public const string ProductModelId = "product model id";
        }

    }
    #endregion

    #region SalesOrderStatus
    public class SalesOrderStatus
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "sales order status";

        public const string InProcess = "1";
        public const string Approved = "2";
        public const string Backordered = "3";
        public const string Rejected = "4";
        public const string Shipped = "5";
        public const string Cancelled = "6";
    }
    #endregion

    #region SalesPerson
    ///<summary>
    /// Cached enumeration returned by the ISalesPersonService.ReadListAsync operation.
    ///  
    ///</summary>
    public class SalesPerson
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "sales person";

        ///<summary>
        /// Additional attributes for enumeration 'sales person'.
        ///</summary>
        public class Attributes
        {
            public const string TerritoryId = "territory id";
        }

    }
    #endregion

    #region SalesTerritory
    ///<summary>
    /// Cached enumeration returned by the ISalesTerritoryService.ReadListAsync operation.
    ///  
    ///</summary>
    public class SalesTerritory
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "sales territory";

        ///<summary>
        /// Additional attributes for enumeration 'sales territory'.
        ///</summary>
        public class Attributes
        {
            public const string CountryRegionCode = "country region code";
            public const string Group = "group";
        }

    }
    #endregion

    #region SalesTerritoryGroup
    public class SalesTerritoryGroup
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "sales territory group";

        public const string NorthAmerica = "North America";
        public const string Europe = "Europe";
        public const string Pacific = "Pacific";
    }
    #endregion

    #region SpecialOffer
    ///<summary>
    /// Cached enumeration returned by the ISpecialOfferService.ReadListAsync operation.
    ///  
    ///</summary>
    public class SpecialOffer
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "special offer";

        ///<summary>
        /// Additional attributes for enumeration 'special offer'.
        ///</summary>
        public class Attributes
        {
            public const string Category = "category";
        }

    }
    #endregion

    #region Yesno
    public class Yesno
    {
        ///<summary>
        /// Enumeration name used for storing it in a lookup cache.
        ///</summary>
        public const string EnumName = "yesno";

        public const string Yes = "true";
        public const string No = "false";
    }
    #endregion

}
