using Dapper;
using FD.DAL.Entities;
using FD.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.DAL.Repository.Reference
{
    public class CovidTestRepository : ICovidTestRepository
    {

        public List<CovidTest> GetAll(string connectionString)
        {
            try
            {
                using (var unitOfWork = new DapUnitOfWork(connectionString))
                {
                    var sqlQuery = CovidTestQuery.GET_ALL;                   
                    var result = unitOfWork.CovidTestRepository.GetAll(sqlQuery, null);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public CovidTest GetById(string connectionString,int id)
        {
            try
            {
                using (var unitOfWork = new DapUnitOfWork(connectionString))
                {
                    var sqlQuery = CovidTestQuery.GET_BY_ID;
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id", id);
                    var result = unitOfWork.CovidTestRepository.GetSingle(sqlQuery, parameter);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public void Add(string connectionString, CovidTest model)
        {
            try
            {
                using (var unitOfWork = new DapUnitOfWork(connectionString))
                {
                    var sqlQuery = CovidTestQuery.INSERT;
                    var result = unitOfWork.CovidTestRepository.Add(sqlQuery, model);
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }
        public void Update(string connectionString, CovidTest model)
        {
            try
            {
                using (var unitOfWork = new DapUnitOfWork(connectionString))
                {
                    var sqlQuery = CovidTestQuery.UPDATE;
                    var result = unitOfWork.CovidTestRepository.Update(sqlQuery, model);
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public void Delete(string connectionString, int Id)
        {
            try
            {
                using (var unitOfWork = new DapUnitOfWork(connectionString))
                {
                    var sqlQuery = CovidTestQuery.DELETE;
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id", Id);
                    var result = unitOfWork.CovidTestRepository.Delete(sqlQuery, parameter);
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
