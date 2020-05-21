using AutoMapper;
using FD.BLL.JsonModels;
using FD.BLL.Models.Reference;
using FD.DAL.Entities;
using FD.DAL.Repository.Reference;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Services.Reference
{
    public class ReferenceService : IReferenceService
    {
        private readonly IMapper _mapper;
        private readonly ConnectionStrings _connectionStrings;
        private readonly ICovidTestRepository _covidTestRepository;
        public ReferenceService(IMapper mapper, ICovidTestRepository covidTestRepository, IOptions<ConnectionStrings> connectionStrings)
        {
            _mapper = mapper;
            _connectionStrings = connectionStrings.Value;
            _covidTestRepository = covidTestRepository;
        }

        public List<CovidTestModel> GetAll()
        {
            try
            {
               var result= _covidTestRepository.GetAll(_connectionStrings.Postgresql);
                return _mapper.Map<List<CovidTestModel>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CovidTestModel GetById( int Id)
        {
            try
            {
                var result = _covidTestRepository.GetById(_connectionStrings.Postgresql, Id);
                return _mapper.Map<CovidTestModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Add(CovidTestModel model)
        {
            try
            {
                var dbModel= _mapper.Map<CovidTest>(model);
                 _covidTestRepository.Add(_connectionStrings.Postgresql, dbModel);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void  Update(CovidTestModel model)
        {
            try
            {
                var dbModel = _mapper.Map<CovidTest>(model);
                _covidTestRepository.Update(_connectionStrings.Postgresql, dbModel);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void  Delete(int id)
        {
            try
            {
                 _covidTestRepository.Delete(_connectionStrings.Postgresql,id);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
