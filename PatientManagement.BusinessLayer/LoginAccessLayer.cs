using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PatientManagement.Data;
using PatientManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.BusinessLayer
{
    public static class LoginAccessLayer
    {
        public static ApplicationDbContext? context;
        public static bool IsLoggedIn = false;
        public static string? username;
        public static int? userId;

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="user">The user trying to login.</param>
        /// <returns></returns>
        public static bool Login(LoginDto user)
        {
            try
            {
                //Check if username exists
                if (context.Set<Login>().Where(x => x.Username == user.Username).SingleOrDefault() != null)
                {
                    //Hash input
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        string? password = context.Set<Login>().Where(x => x.Username == user.Username).SingleOrDefault()?.Password;

                        //Check if password is correct
                        if (VerifyHash(sha256Hash, user.Password, password))
                        {
                            IsLoggedIn = true;
                            username = user.Username;
                            userId = GetLoginId(username);
                            return true;
                        }
                        else throw new Exception("Wrong Password.");
                    }
                }
                else throw new Exception("Username does not exist.");
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return false;
            }
        }

        /// <summary>
        /// Gets and returns patientId.
        /// </summary>
        /// <param name="name">String[] name.</param>
        /// <returns></returns>
        public static int GetPersonId(string[] name)
        {
            try
            {
                return context.Set<Person>().Where(x => x.FirstName.ToLower() == name[0].ToLower() && x.LastName.ToLower() == name[1].ToLower()).Single().Id;
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return -1;
            }
        }

        /// <summary>
        /// Get the Id of the logged in user.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetLoginId(string name)
        {
            try
            {
                return context.Set<Login>().Where(x => x.Username.ToLower() == name.ToLower()).Single().Id;
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
                return -1;
            }
        }


        /// <summary>
        /// Hashing.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm used.</param>
        /// <param name="input">String to be hashed.</param>
        /// <returns></returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the newHash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Verify a hash.
        /// </summary>
        /// <param name="hashAlgorithm">The algorithm used.</param>
        /// <param name="input">The unhashed string to be compared.</param>
        /// <param name="hash">The hashed string to be compared.</param>
        /// <returns></returns>
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        /// <summary>
        /// Sets ApplicationDbContext;
        /// </summary>
        /// <param name="dbcontext"></param>
        public static void SetContext(ApplicationDbContext dbcontext)
        {
            try
            {
                context = dbcontext;
                TreatmentAccessLayer.context = dbcontext;
            }
            catch (Exception e)
            {
                ErrorHandling.ErrorMsg(e);
            }
        }

    }

    #region Data Transfer Objects
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    #endregion
}
