using System;
using Doughnut.Provider;
using Doughnut.Provider.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doughnut.Controllers
{
    [Route("api/[controller]")]
    public class DecisionTreeController : Controller
    {
        protected JsonSerializerSettings JsonSettings { get; }
        private readonly IDecisionTreeProvider _provider;
        public DecisionTreeController(IDecisionTreeProvider provider)
        {
            _provider = provider;
            JsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        /// POST: api/DecisionTree
        /// </summary>
        /// <returns>Return the answer.</returns>
        [HttpPost("ClientRequest")]
        public IActionResult ClientRequest([FromBody]ClientViewModel model)
        {
            try
            {
                // Or we can return a StatusCodeResult(500) which is a generic HTTP Status 500 (Server Error) as an another way
                // if the client payload is invalid.
                if (model == null) return new BadRequestResult();

                //In the real scenarios, I would use async-await, but there is no need here
                var theAnswer = _provider.GetTheAnswer(model);

                return Json(new ResultDTO { Result = theAnswer }, JsonSettings);
            }
            catch (Exception ex)
            {
                //Logging
                throw ex;
            }
        }
    }
}
