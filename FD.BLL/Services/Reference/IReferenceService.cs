using FD.BLL.Models.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Services.Reference
{
    public interface IReferenceService
    {
        List<CovidTestModel> GetAll();
        void Delete(int id);
        CovidTestModel GetById(int Id);
        void Add(CovidTestModel model);
        void Update(CovidTestModel model);
    }
}
