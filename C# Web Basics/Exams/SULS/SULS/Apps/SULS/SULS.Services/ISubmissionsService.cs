using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(Submission submission);

        IEnumerable<Submission> GetAll();

        void Delete(string id);

        Submission GetById(string id);
    }
}
