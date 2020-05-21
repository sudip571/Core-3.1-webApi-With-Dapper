using FD.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.DAL.Repository.Reference
{
   public  interface ICovidTestRepository
    {
        List<CovidTest> GetAll(string connectionString);
        CovidTest GetById(string connectionString, int id);
        void Add(string connectionString, CovidTest model);
        void Update(string connectionString, CovidTest model);
        void Delete(string connectionString, int Id);
    }
}
