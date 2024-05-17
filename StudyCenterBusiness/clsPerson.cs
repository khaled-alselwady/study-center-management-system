using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
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

        public string FullName => string.Concat(FirstName, " ", SecondName, " ", ThirdName ?? "", " ", LastName);
        public string GenderName => Gender.ToString();

        public bool IsUser => clsUser.Exist(PersonID, clsUser.enFindBy.PersonID);
        public bool IsStudent => clsStudent.IsStudent(PersonID);
        public bool IsTeacher => clsTeacher.IsTeacher(PersonID);

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

        private bool _Validate()
        {
            if (Mode == enMode.Update && !PersonID.HasValue)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(SecondName) || string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }

            if (DateOfBirth.Date > DateTime.Now.Date)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                return false;
            }

            return true;
        }

        private bool _Add()
        {
            PersonID = clsPersonData.Add(FirstName, SecondName, ThirdName,
                LastName, (byte)Gender, DateOfBirth, PhoneNumber, Email, Address);

            return (PersonID.HasValue);
        }

        private bool _Update()
        {
            return clsPersonData.Update(PersonID.Value, FirstName, SecondName, ThirdName,
                LastName, (byte)Gender, DateOfBirth, PhoneNumber, Email, Address);
        }

        public bool Save()
        {
            if (!_Validate())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
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

            bool isFound = clsPersonData.GetInfoByID(personID, ref firstName, ref secondName,
                ref thirdName, ref lastName, ref gender, ref dateOfBirth, ref phoneNumber,
                ref email, ref address);

            return (isFound) ? (new clsPerson(personID, firstName, secondName, thirdName, lastName,
                               (enGender)gender, dateOfBirth, phoneNumber, email, address))
                             : null;
        }

        public static bool Delete(int? personID) => clsPersonData.Delete(personID);

        public static bool Exists(int? personID) => clsPersonData.Exists(personID);

        public static DataTable All() => clsPersonData.All();
    }
}