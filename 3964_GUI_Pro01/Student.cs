using Microsoft.Win32;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace _3964_GUI_Pro01
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public double GPA { get; set; }
        public byte[] Image { get; set; }

        public Student()
        {
        }

        
        
    }
}