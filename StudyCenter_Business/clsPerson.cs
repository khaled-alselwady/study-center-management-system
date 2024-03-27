using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 };

        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public enGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string FullName => (ThirdName != null) ? string.Concat(FirstName, " ", SecondName, " ", ThirdName, " ", LastName)
                                                      : string.Concat(FirstName, " ", SecondName, " ", LastName);
        public string GenderName => Gender.ToString();

        public clsPerson()
        {
            PersonID = null;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = null;
            LastName = string.Empty;
            Gender = enGender.Male;
            DateOfBirth = DateTime.Now;
            PhoneNumber = string.Empty;
            Email = null;
            Address = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int? personID, string firstName, string secondName, string thirdName,
            string lastName, enGender gender, DateTime dateOfBirth, string phoneNumber,
            string email, string address)
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

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(FirstName, SecondName, ThirdName,
                LastName, (byte)Gender, DateOfBirth, PhoneNumber, Email, Address);

            return (PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, FirstName, SecondName, ThirdName,
                LastName, (byte)Gender, DateOfBirth, PhoneNumber, Email, Address);
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

            bool isFound = clsPersonData.GetPersonInfoByID(personID, ref firstName, ref secondName,
                ref thirdName, ref lastName, ref gender, ref dateOfBirth, ref phoneNumber,
                ref email, ref address);

            return (isFound) ? (new clsPerson(personID, firstName, secondName, thirdName, lastName,
                               (enGender)gender, dateOfBirth, phoneNumber, email, address))
                             : null;
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