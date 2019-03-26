using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        //PROPERTIES
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadTestStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students.Add(new Student { FirstName = "John", LastName = "Doe" });
            students.Add(new Student { FirstName = "Linda", LastName = "Liukas" });
            students.Add(new Student { FirstName = "Lorppa", LastName = "Huuli" });
            students.Add(new Student { FirstName = "Lala", LastName = "Lolo" });
            Students = students;
        }
    }
}
