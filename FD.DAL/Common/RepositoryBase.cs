using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FD.DAL.Common
{
    public class RepositoryBase<T> where T : class
    {
        #region Private properties
        private IDbTransaction _transaction;
        //private IDbConnection _connection { get { return _transaction.Connection; } }
        private IDbConnection _connection;
        #endregion

        public RepositoryBase(IDbTransaction transaction)
        {
            _transaction = transaction;
            _connection = _transaction.Connection;
        }
        public int Add(string sqlQuery,T entity)
        {
           return  _connection.ExecuteScalar<int>(sqlQuery, entity, _transaction);
          //  var addedEntity= _connection.ExecuteScalar<T>(sqlQuery, entity, _transaction);
            //_connection.ExecuteScalar<int>(@"INSERT INTO Employees(FirstName, LastName, JobTitle)  
            //                                   VALUES(@FirstName, @LastName, @JobTitle); 
            //                                   SELECT SCOPE_IDENTITY()",
            //                                       new
            //                                       {
            //                                           FirstName = entity.FirstName,
            //                                           LastName = entity.LastName,
            //                                           JobTitle = entity.JobTitle
            //                                       }, _transaction);
        }
        public int Update(string sqlQuery, T entity)
        {
            return _connection.Execute(sqlQuery, entity, _transaction);
            //_connection.Execute(@"UPDATE Employees  
            //                    SET FirstName = @FirstName,  
            //                        LastName = @LastName,  
            //                        JobTitle = @JobTitle  
            //                    WHERE EmployeeId = @EmployeeId",
            //                        new
            //                        {
            //                            FirstName = entity.FirstName,
            //                            LastName = entity.LastName,
            //                            JobTitle = entity.JobTitle,
            //                            EmployeeId = entity.EmployeeId
            //                        }, _transaction);
        }
        public int  Delete(string sqlQuery, DynamicParameters parameters)
        {
           return  _connection.Execute(sqlQuery, parameters, _transaction);
        }
        public T GetSingle(string sqlQuery, DynamicParameters parameters)
        {
            return _connection.Query<T>(sqlQuery, parameters, _transaction).FirstOrDefault();
        }
        public List<T> GetAll(string sqlQuery, DynamicParameters parameters)
        {
            return _connection.Query<T>(sqlQuery, parameters, _transaction).ToList();
        }
        public T GetSingleBySP(string storedProcedureName, DynamicParameters parameters)
        {
            return _connection.Query<T>(storedProcedureName, parameters, _transaction, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public List<T> GetAllBySP(string storedProcedureName, DynamicParameters parameters)
        {
            return _connection.Query<T>(storedProcedureName, parameters, _transaction, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
