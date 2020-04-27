using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext dbContext;

        public SubmissionsService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Submission submission)
        {
            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.GetById(id);

            if (submission == null)
            {
                return;
            }

            this.dbContext.Submissions.Remove(submission);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<Submission> GetAll()
        {
            return this.dbContext.Submissions.ToArray();
        }

        public Submission GetById(string id)
        {
            var submission = this.dbContext.Submissions.FirstOrDefault(s => s.Id == id);
            return submission;
        }
    }
}
