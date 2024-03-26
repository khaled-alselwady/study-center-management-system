using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public clsPerson()
        {
            PersonID = null;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = null;
            LastName = string.Empty;
            Gender = 0;
            DateOfBirth = DateTime.Now;
            PhoneNumber = string.Empty;
            Email = null;
            Address = null;
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsPerson(int? personID, string firstName, string secondName, string thirdName, string lastName, byte gender, DateTime dateOfBirth, string phoneNumber, string email, string address, bool isActive)
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, PhoneNumber, Email, Address, IsActive);

            return (PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, PhoneNumber, Email, Address, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int? personID)
        {
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = null;
            string lastName = string.Empty;
            byte gender = 0;
            DateTime dateOfBirth = DateTime.Now;
            string phoneNumber = string.Empty;
            string email = null;
            string address = null;
            bool isActive = false;

            bool isFound = clsPersonData.GetPersonInfoByID(personID, ref firstName, ref secondName, ref thirdName, ref lastName, ref gender, ref dateOfBirth, ref phoneNumber, ref email, ref address, ref isActive);

            return (isFound) ? (new clsPerson(personID, firstName, secondName, thirdName, lastName, gender, dateOfBirth, phoneNumber, email, address, isActive)) : null;
        }

        public static bool DeletePerson(int? personID)
        {
            return clsPersonData.DeletePerson(personID);
        }

        public static bool DoesPersonExist(int? personID)
        {
            return clsPersonData.DoesPersonExist(personID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

    }

}