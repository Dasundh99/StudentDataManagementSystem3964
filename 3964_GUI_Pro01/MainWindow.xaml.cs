using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace _3964_GUI_Pro01
{
    
    public partial class MainWindow : Window
    {
        private byte[] imageData;
        private string imagePath;

        public List<Student> DatabaseStudents { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SelectedStudent()
        {
            using (DataContext context = new DataContext())
            {
                Student selectedStudent = StudentList.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    fnTextBox.Text = selectedStudent.FirstName;
                    lnTextName.Text=selectedStudent.LastName;
                    dobTextBox.Text = selectedStudent.DOB;
                    gpaTextBox.Text = selectedStudent.GPA.ToString();
                    ImagePathTextBox.Text = Convert.ToBase64String(selectedStudent.Image);
                    
                }
                else
                {
                    MessageBox.Show("Select a Student", "Error!");
                }
            }
        }

        public void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == true)
            {
                string imagePath = dialog.FileName;

                
                
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, (int)fs.Length);
                }
                MessageBox.Show("Image successfully uploaded!", "Success");

                ImagePathTextBox.Text = imagePath;
            }
            else
            {
                MessageBox.Show("Select An Image", "Alert!");
            }
        }

        

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var firstName = fnTextBox.Text;
                var lastName = lnTextName.Text;
                var dob = dobTextBox.Text;
                var gpaText = gpaTextBox.Text;
                var image = ImagePathTextBox.Text;

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(dob) && !string.IsNullOrEmpty(gpaText) && !string.IsNullOrWhiteSpace(image))
                {
                    if (double.TryParse(gpaText, out double gpa))
                    {
                        context.Students.Add(new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DOB = dob,
                            GPA = gpa,
                            Image = imageData
                        });
                        context.SaveChanges();
                        MessageBox.Show("You have successfully created a new entry", "DONE!");

                        fnTextBox.Text = string.Empty;
                        lnTextName.Text = string.Empty;
                        dobTextBox.Text = string.Empty;
                        gpaTextBox.Text = string.Empty;
                        ImagePathTextBox.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Invalid GPA value. Please enter a value < 4.00", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Enter relevant data", "Alert!");
                }
            }
        }


        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseStudents = context.Students.ToList();
                StudentList.ItemsSource = DatabaseStudents;
            }
        }

        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Student selectedStudent = StudentList.SelectedItem as Student;
                var firstName = fnTextBox.Text;
                var lastName = lnTextName.Text;
                var dob = dobTextBox.Text;
                var gpa = gpaTextBox.Text;
                var image = ImagePathTextBox.Text;

                if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(dob) && !string.IsNullOrWhiteSpace(gpa) && !string.IsNullOrWhiteSpace(image))
                {

                    if(selectedStudent != null)
                    {
                        Student student = context.Students.Find(selectedStudent.Id);
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.DOB = dob;
                        student.GPA = Convert.ToDouble(gpa);
                        student.Image = imageData;
                        context.SaveChanges();

                        MessageBox.Show("You have successfully updated the selected Student", "DONE!");

                        fnTextBox.Text = string.Empty;
                        lnTextName.Text = string.Empty;
                        dobTextBox.Text = string.Empty;
                        gpaTextBox.Text = string.Empty;
                        ImagePathTextBox.Text = string.Empty;
                    }
                   
                    else
                    {
                        MessageBox.Show("Select a Student", "ERROR!");
                    }


                }
                else if (selectedStudent == null)
                {
                    MessageBox.Show("Select a Student", "ERROR!");
                }
                else
                {
                    MessageBox.Show("Enter relevant data", "ERROR!");
                }
            }
        }




        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Student selectedStudent = StudentList.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    Student student = context.Students.Find(selectedStudent.Id);
                    context.Remove(student);
                    context.SaveChanges();
                    MessageBox.Show("You have successfully deleted the selected student", "DONE!");

                    fnTextBox.Text = string.Empty;
                    lnTextName.Text = string.Empty;
                    dobTextBox.Text = string.Empty;
                    gpaTextBox.Text = string.Empty;
                    ImagePathTextBox.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("Select a Student", "ERROR!");
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List list = new List();
            this.Visibility = Visibility.Hidden;
            list.Show();

            Read();
        }

        private void DeleteButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            SelectedStudent();
        }
    }

    
}

