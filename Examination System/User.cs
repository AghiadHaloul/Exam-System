using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examination_System
{
    public abstract class User
    {
        protected string ID;
        protected string firstName;
        protected string lastName;
        protected string userName;
        protected string password;
        protected string email;
        public User()
        {
            ID = firstName = lastName = userName = password = email = "";
        }
        public User(string id, string first, string last, string user, string pass,
            string em)
        {
            ID = id;
            firstName = first;
            lastName = last;
            userName = user;
            password = pass;
            email = em;
        }
        public string getID() { return ID; }
        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public string getFullName() { return firstName + " " + lastName; }
        public string getUserName() { return userName; }
        public string getPassword() { return password; }
        public string getEmail() { return email; }
        abstract public string getDepartment();
        abstract public string getYear();

    }

    public class teacher : User
    {
        private string department;

        public teacher()
            : base()
        {
            department = "";
        }
        public teacher(string id, string first, string last, string user, string pass,
            string email, string department)
            : base(id, first, last, user, pass, email)
        {
            this.department = department;
            Teacher t = new Teacher();
            t.ID = this.ID;
            t.First_Name = this.firstName;
            t.Last_Name = this.lastName;
            t.Username = this.userName;
            t.Password = this.password;
            t.Email = this.email;
            t.Department = this.department;
            Form2.EF.Teachers.Add(t);
            Form2.EF.SaveChanges();
        }
        public bool checkTeacherSignIn(string User, string Pass)
        {
            foreach (var Teachers in Form2.EF.Teachers)
            {
                if (Teachers.Username == User && Teachers.Password == Pass)
                {
                    ID = Teachers.ID;
                    firstName = Teachers.First_Name;
                    lastName = Teachers.Last_Name;
                    userName = Teachers.Username;
                    password = Teachers.Password;
                    email = Teachers.Email;
                    department = Teachers.Department;
                    return true;
                }
            }
            return false;
        }
        public bool checkTeacherSignUp(string User)
        {
            foreach (var Teachers in Form2.EF.Teachers)
            {
                if (Teachers.Username == User)
                {
                    return true;
                }
            }
            return false;
        }
        public void generateReport() { }
        override public string getDepartment() { return department; }
        override public string getYear() { return "No year"; }
    }
    public class student : User
    {
        private string year;
        public student()
            : base()
        {
            year = "";
            
        }

        public student(string id, string first, string last, string username, string password,
            string email, string year)
            : base(id, first, last, username, password, email)
        {
            this.year = year;
            Student s = new Student();
            s.ID = this.ID;
            s.First_Name = this.firstName;
            s.Last_Name = this.lastName;
            s.Username = this.userName;
            s.Password = this.password;
            s.Email = this.email;
            s.Year = this.year;
            Form2.EF.Students.Add(s);
            Form2.EF.SaveChanges();
        }
        public bool checkStudentSignIn(string User, string Pass)
        {
            foreach (var Students in Form2.EF.Students)
            {
                if (Students.Username == User && Students.Password == Pass)
                {
                    ID = Students.ID;
                    firstName = Students.First_Name;
                    lastName = Students.Last_Name;
                    userName = Students.Username;
                    password = Students.Password;
                    email = Students.Email;
                    year = Students.Year;
                    return true;
                }
            }
            return false;
        }
        public bool checkStudentSignUp(string User)
        {
            foreach (var Students in Form2.EF.Students)
            {
                if (Students.Username == User)
                {
                    return true;
                }
            }
            return false;
        }
        override public string getYear() { return year; }
        override public string getDepartment() { return "No Department"; }

    }
}

