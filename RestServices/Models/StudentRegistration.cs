using System.Collections.Generic;
using System.Linq;

namespace RestServices.Models
{
    public class StudentRegistration
    {
        private static IList<Student> _studentList;

        private static StudentRegistration _studentRegistration;
        private StudentRegistration()
        {
            _studentList = new List<Student>();
        }
        public static StudentRegistration GetInstance()
        {
            if (_studentRegistration != null) return _studentRegistration;
            _studentRegistration = new StudentRegistration();
            return _studentRegistration;
        }
        public bool Add(Student student)
        {
            _studentList.Add(student);
            return true;
        }
        public bool Remove(string registrationNumber)
        {
            for (int i = 0; i < _studentList.Count; i++)
            {
                Student student = _studentList.ElementAt(i);
                if (student.RegistrationNumber.Equals(registrationNumber))
                {
                    _studentList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public IList<Student> GetAllStudents()
        {
            return _studentList;
        }
        public Student GetStudent(string registrationNumber)
        {
            return _studentList.Single(s => s.RegistrationNumber == registrationNumber);
        }
        public bool UpdateStudent(Student student)
        {
            for (int i = 0; i < _studentList.Count; i++)
            {
                Student studentUpdate = _studentList.ElementAt(i);
                if (studentUpdate.RegistrationNumber.Equals(student.RegistrationNumber))
                {
                    _studentList[i] = student; // update the student
                    return true;
                }
            }
            return false;
        }
    }
}