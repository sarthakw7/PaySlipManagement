using PaySlipManagement.DAL.Interfaces;
using PaySlipManagement.DAL.DapperServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using PaySlipManagement.Common.Models;

namespace PaySlipManagement.DAL.Implementations
{
    public class UserDALRepo : IUserDALRepo
    {
        DapperServices<Users>  _userRepository;

        public UserDALRepo()
        {
            _userRepository = new DapperServices<Users>();
        }
        
        public async  Task<IEnumerable<Users>> GetAllAsync()
        {
            var result = await _userRepository.ReadAllAsync(new Users() { Id = null, Emp_Code= null, Password= null, Email= null });
            
            return result;
        }

        public async Task<Users> GetByIdAsync(Users user)
        {
            return await _userRepository.ReadGetByIdAsync(user);
        }
         
        public async  Task<bool> Create(Users user)
        {
            if(user != null) 
            {
                var employeeExists = await _userRepository.CheckEmployeeExistsAsync(user.Emp_Code);
                if (!employeeExists)
                {
                    return false;
                }

                await  _userRepository.CreateAsync(user);
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Users user)
        {
            if(user!=null)
            {
                await _userRepository.DeleteAsync(user);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Users user)
        {
            if(user != null)
            {
                var employeeExists = await _userRepository.CheckEmployeeExistsAsync(user.Emp_Code);
                if (!employeeExists)
                {
                    return false;
                }

                await _userRepository.UpdateAsync(user);
                return true;
            }

             return false;
        }

        public async Task<Users> GetByEmailAsync(string Email, string password)
        {
            var user = await _userRepository.ValidateAsync(new Users() { Email = Email, Password = password });
            return user;
        }
        public async Task<Users> UserValidateUserCredentials(Users user)
        {
            var data = await GetByEmailAsync(user.Email, user.Password);
            return data;
        }

        //public class AuthenticationService
        //{
        //    private readonly string _connectionString;

        //    public AuthenticationService(string connectionString)
        //    {
        //        _connectionString = connectionString;
        //    }

        //    private IDbConnection Connection => new SqlConnection(_connectionString);

        //    public bool Authenticate(string email, string password)
        //    {
        //        using (IDbConnection dbConnection = Connection)
        //        {
        //            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password";
        //            int count = dbConnection.QuerySingle<int>(query, new { Email = email, Password = password });

        //            return count == 1;
        //        }
        //    }

        //    public string GetUserRole(string email)
        //    {
        //        using (IDbConnection dbConnection = Connection)
        //        {
        //            string query = @"SELECT R.Role
        //                     FROM Users U
        //                     INNER JOIN UserRoles UR ON U.Emp_Code = UR.Emp_Code
        //                     INNER JOIN Roles R ON UR.RoleId = R.Id
        //                     WHERE U.Email = @Email";

        //            return dbConnection.QueryFirstOrDefault<string>(query, new { Email = email });
        //        }
        //    }
        //}


    }
}
