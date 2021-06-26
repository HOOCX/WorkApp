using JobManagement.API.Data.Context;
using JobManagement.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobManagement.API.Bussines
{
    public class User_Service
    {
        private JobManagementContext _context;

        public User_Service()
        {
            _context = new JobManagementContext();
        }

        public Users AddUser(Users data)
        {

            var result = _context.Users.Add(data);
            _context.SaveChanges();

            return result;

        }
        public bool UpdateUser(Users data)
        {
            var user = GetUserById(data.Id);
            user.Name = data.Name;
            user.UserName = data.UserName;
            user.Role = data.Role;
            user.Email = data.Email;

            _context.SaveChanges();

            return true;
        }

        public Users GetUserById(int Id)
        {
            var result = _context.Users.Where(x => x.Id == Id).FirstOrDefault();

            return result;
        }

        public List<Users> GetAllUser()
        {
            var result = _context.Users.ToList();
            return result;
        }

        public bool DeleteUserById(int id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public Users GetUsuarioByCredenciales(string username, string password)
        {
            var user = _context.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}