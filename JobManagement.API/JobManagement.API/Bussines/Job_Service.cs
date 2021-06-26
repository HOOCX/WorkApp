using JobManagement.API.Data.Context;
using JobManagement.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.API.Bussines
{
    public class Job_Service
    {
        private JobManagementContext _context;

        public Job_Service()
        {
            _context = new JobManagementContext();
        }

        public Jobs AddJob(Jobs data)
        {

            var result = _context.Jobs.Add(data);
            _context.SaveChanges();

            return result;

        }
        public bool UpdateJob(Jobs data)
        {
            var job = GetJobById(data.Id);
            job.Name = data.Name;
            job.Description = data.Description;
            job.User_Id = data.User_Id;
            job.Photo = data.Photo;
            job.State = data.State;
      
            _context.SaveChanges();

            return true;
        }

        public Jobs GetJobById(int Id)
        {
            var result = _context.Jobs.Where(x => x.Id == Id).FirstOrDefault();

            return result;
        }

        public List<Jobs> GetAllBobs()
        {
            var result = _context.Jobs.ToList();
            return result;
        }

        public bool DeleteJobById(int id)
        {
            var job = GetJobById(id);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return true;
        }

    }
}