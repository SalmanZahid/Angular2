using Glossary.BLL.DTOs;
using Glossary.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Glossary.WEBAPI.Controllers
{
    public class GlossaryController : BaseApiController
    {
        private readonly GlossaryItemService service = new GlossaryItemService();

        /// <summary>
        /// EndPoint for list of glossary terms
        /// </summary>
        /// <returns>Status and IEnumerable<GlossaryTermDTO></returns>
        public IHttpActionResult Get()
        {
            IEnumerable<GlossaryTermDTO> list = service.GetAll();
            return Ok(new { status = ResponseStatusCode.SUCCESS, data = list });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            GlossaryTermDTO entity = service.FindById(id);

            if (entity.Id > 0)
            {
                return Ok(new { status = ResponseStatusCode.SUCCESS, entity = entity });
            }

            return NotFound();
        }

        /// <summary>
        /// EndPoint to Add New Term
        /// </summary>
        /// <param name="glossaryTermDTO"></param>
        /// <returns>status</returns>
        public IHttpActionResult Post(GlossaryTermDTO glossaryTermDTO)
        {
            if (ModelState.IsValid)
            {
                service.Add(glossaryTermDTO);
                return Ok(new { status = ResponseStatusCode.SUCCESS, entity = glossaryTermDTO });
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// EndPoint to update term
        /// </summary>
        /// <param name="glossaryTermDTO"></param>
        /// <returns>status</returns>
        public IHttpActionResult Put([FromUri] GlossaryTermDTO glossaryTermDTO)
        {
            service.Update(glossaryTermDTO);
            return Ok(new { status = ResponseStatusCode.SUCCESS });
        }

        /// <summary>
        /// EndPoint to delete term
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status</returns>
        public IHttpActionResult Delete(int id)
        {
            if (service.Delete(id) == true)
            {
                return Ok(new { status = ResponseStatusCode.SUCCESS });
            }

            return Ok(new { status = ResponseStatusCode.ERROR });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
