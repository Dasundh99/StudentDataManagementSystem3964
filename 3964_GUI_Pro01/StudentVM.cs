using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _3964_GUI_Pro01
{
    partial class StudentVM: ObservableObject
    {
        private Student student;

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dob;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public byte[] image;

        public StudentVM(Student s)
        {
            student = s;

            firstname = student.FirstName;
            lastname = student.LastName;
            dob = student.DOB;
            gpa = student.GPA;
            image = student.Image;
        }

    }
}
