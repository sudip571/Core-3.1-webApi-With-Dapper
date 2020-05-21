using FD.DAL.Common;
using FD.DAL.Entities;
using FD.DAL.Repository.Reference;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FD.DAL.UnitOfWork
{
   public  class DapUnitOfWork : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public DapUnitOfWork(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString); 
            //_connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        #region Setting repository forEntities
        //declaration
        private RepositoryBase<CovidTest> _covidTestRepository = null;


        //Implementation
        public RepositoryBase<CovidTest> CovidTestRepository
        {
            get
            {
                return _covidTestRepository ?? (_covidTestRepository = new RepositoryBase<CovidTest>(_transaction));
            }
        }

        #endregion



        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        /// <summary>
        /// When we commit changes, we will be on a new transaction, so  to re-instantiate our repositories we should reset them.        
        /// </summary>
        private void ResetRepositories()
        {
            _covidTestRepository = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
      
    }
}
