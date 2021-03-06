//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Current version number of the AdventureWorks 2016 sample database. 
    ///</summary>
    public partial class AwBuildVersion
    {
        public AwBuildVersion()
        {
        }

        #region Properties

        public byte SystemInformationId  { get; set; }

        ///<summary>
        /// Version number of the database in 9.yy.mm.dd.00 format.
        ///</summary>
        public string DatabaseVersion  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime VersionDate  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion
    }
}