using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SingleDDD.Core.Domain.Entities
{
    public class User
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DeactivationDate { get; set; }

        internal void SetData(string email, string password)
        {
            ValidateData(email, password);

            Email = email;
            Password = password;
            RegistrationDate = DateTime.Now;
        }

        private void ValidateData(string email, string password)
        {
            ValidateEmail(email);
            ValidatePassword(password);
        }

        private void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new Exception("Invalid password!");

            if (!Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$"))
                throw new Exception("Invalid password!");
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Invalid email!");

            if (!Regex.IsMatch(email, @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b"))
                throw new Exception("Invalid email!");
        }

        internal void Activate()
        {
            DeactivationDate = null;
        }

        internal void Deactivate()
        {
            DeactivationDate = DateTime.Now;
        }

        internal void UpdateData(string email, string password)
        {
            ValidateData(email, password);

            Email = email;
            Password = password;
        }
    }
}
