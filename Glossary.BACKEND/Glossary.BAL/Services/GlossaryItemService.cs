using Glossary.BLL.DTOs;
using System.Collections.Generic;
using Glossary.Business.Interfaces;
using Glossary.DAL.Repository;
using Glossary.Common.Entities;
using Glossary.BLL.Mapper;

namespace Glossary.BLL.Services
{
    public sealed class GlossaryItemService : BaseMapper<GlossaryTerm, GlossaryTermDTO>, IBaseService<GlossaryTermDTO>
    {
        private GlossaryTermRepository glossaryRepository = new GlossaryTermRepository();

        /// <summary>
        /// Get all glossary terms
        /// </summary>
        /// <returns>IEnumerable<GlossaryTermDTO></returns>
        public IEnumerable<GlossaryTermDTO> GetAll()
        {
            var glossaryTerms = glossaryRepository.GetAll();
            List<GlossaryTermDTO> glossaryTermsDTOList = new List<GlossaryTermDTO>();
            foreach (GlossaryTerm glossaryTerm in glossaryTerms)
            {
                glossaryTermsDTOList.Add(GetMappedToDTO(glossaryTerm));
            }

            return glossaryTermsDTOList;
        }

        /// <summary>
        /// Get glossary term by Id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>GlossaryTermDTO</returns>
        public GlossaryTermDTO FindById(int id)
        {
            GlossaryTerm entity = glossaryRepository.FindById(id);
            GlossaryTermDTO glossaryTermDTO = GetMappedToDTO(entity);
            return glossaryTermDTO;
        }

        /// <summary>
        /// Add new term in data store
        /// </summary>
        /// <param name="entity">GlossaryTermDTO</param>
        public void Add(GlossaryTermDTO entity)
        {
            GlossaryTerm glossartTerm = GetMappedToModel(entity);
            glossaryRepository.Add(glossartTerm);
            entity.Id = glossartTerm.Id;
        }

        /// <summary>
        /// Remove term from data store
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Boolean</returns>
        public bool Delete(int id)
        {
            bool removed = glossaryRepository.Delete(id);
            return removed;
        }

        /// <summary>
        /// Update term in data store
        /// </summary>
        /// <param name="entity"></param>
        public void Update(GlossaryTermDTO entity)
        {
            GlossaryTerm glossartTerm = GetMappedToModel(entity);
            glossaryRepository.Update(glossartTerm);
        }
    }

}
