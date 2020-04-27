using SULS.Data;
using SULS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext dbContext;

        public ProblemsService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Problem problem)
        {
            this.dbContext.Problems.Add(problem);
            this.dbContext.SaveChanges();
        }

        public void DeleteById(string id)
        {
            var problem = this.GetById(id);

            if (problem == null)
            {
                return;
            }

            this.dbContext.Problems.Remove(problem);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<Problem> GetAll()
        {
            return this.dbContext.Problems.ToArray();
        }

        public Problem GetById(string id)
        {
            return this.dbContext.Problems.FirstOrDefault(p => p.Id == id);
        }
    }
}
