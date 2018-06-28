using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork___May_23.Data
{
    public class CandidatesRepository
    {
        public string _connectionString;
        public CandidatesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using (var context = new Classwork___May_23DataContext(_connectionString))
            {
                context.Candidates.InsertOnSubmit(candidate);
                context.SubmitChanges();
            }
        }

        public IEnumerable<Candidate> GetCandidates(Status status)
        {
            using (var context = new Classwork___May_23DataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == status).ToList();
            }
        }

        public Candidate GetCandidateById(int id)
        {
            using (var context = new Classwork___May_23DataContext(_connectionString))
            {
                return context.Candidates.FirstOrDefault(c => c.Id == id);
            }
        }

        public int GetCount(Status status)
        {
            using (var context = new Classwork___May_23DataContext(_connectionString))
            {
                return context.Candidates.Count(c => c.Status == status);
            }
        }

        public void UpdateStatus(int candidateId, Status status)
        {
            using (var context = new Classwork___May_23DataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = {0} WHERE Id = {1}", status, candidateId);
            }
        }
    }
}

