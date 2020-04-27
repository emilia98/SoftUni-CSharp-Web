using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(Problem problem);

        void DeleteById(string id);

        Problem GetById(string id);

        IEnumerable<Problem> GetAll();
    }
}
