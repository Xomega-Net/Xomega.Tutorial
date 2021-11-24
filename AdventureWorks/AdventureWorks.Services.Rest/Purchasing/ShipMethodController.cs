//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Web API Controllers" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    ///<summary>
    /// Shipping company lookup table.
    ///</summary>
    public partial class ShipMethodController : BaseController
    {
        private readonly IShipMethodService svc;

        public ShipMethodController(ErrorList errorList, ErrorParser errorParser, IShipMethodService service)
            : base(errorList, errorParser)
        {
            svc = service;
        }

        ///<summary>
        /// Reads a list of Ship Method objects based on the specified criteria.
        ///</summary>
        [Route("ship-method")]
        [HttpGet]
        public async Task<ActionResult> ReadListAsync(CancellationToken token = default)
        {
            ActionResult response;
            try
            {
                if (ModelState.IsValid)
                {
                    Output<ICollection<ShipMethod_ReadListOutput>> output = await svc.ReadListAsync(token);
                    response = StatusCode((int)output.HttpStatus, output);
                    return response;
                }
                else
                {
                    currentErrors.AddModelErrors(ModelState);
                }
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            response = StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
            return response;
        }
    }
}