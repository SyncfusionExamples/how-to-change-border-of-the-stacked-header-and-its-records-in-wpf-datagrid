using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SfDataGridDemo {
    internal class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model> employeelist;
        private ObservableCollection<string> employeesList = new ObservableCollection<string>();

        public ObservableCollection<string> EmployeeList
        {
            get { return employeesList; }
            set
            {
                employeesList = value;
                RaisePropertyChanged("EmployeeList");
            }
        }
        public ViewModel()
        {

            employeelist = new ObservableCollection<Model>();
            //employeesList.Add("one");
            //employeesList.Add("Two");
            //employeesList.Add("Three");
            //employeesList.Add("Four");
            //employeesList.Add("Five");
            //employeesList.Add("Six");
            //employeesList.Add("Seven");
            //employeesList.Add("Eight");
            //employeesList.Add("Nine");
            //employeesList.Add("Ten");
            for (int i = 0; i < 50; i++)
            {

                employeelist.Add(new Model
                {
                    EmployeeID = 101,
                    EmployeeName = "Jacobs",
                    EmployeeAge = 25,
                    EmployeeSalary = 20000
                });
                
                employeelist.Add(new Model
                {
                    EmployeeID = 102,
                    EmployeeName = "Edison",
                    EmployeeAge = 32,
                    EmployeeSalary = 21000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 103,
                    EmployeeName = "Markswille",
                    EmployeeAge = 45,
                    EmployeeSalary = 22000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 104,
                    EmployeeName = "Antony",
                    EmployeeAge = 26,
                    EmployeeSalary = 23000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 105,
                    EmployeeName = "Bergius",
                    EmployeeAge = 29,
                    EmployeeSalary = 24000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 106,
                    EmployeeName = "Thomas",
                    EmployeeAge = 38,
                    EmployeeSalary = 25000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 107,
                    EmployeeName = "Martin",
                    EmployeeAge = 32,
                    EmployeeSalary = 35000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 108,
                    EmployeeName = "Christopher",
                    EmployeeAge = 32,
                    EmployeeSalary = 34000
                });
                employeelist.Add(new Model
                {
                    EmployeeID = 109,
                    EmployeeName = "Bradman Toy",
                    EmployeeAge = 38,
                    EmployeeSalary = 35000
                });
            }
            //employeesList.Add("one");
            //employeesList.Add("Two");
            //employeesList.Add("Three");
            //employeesList.Add("Four");
            //employeesList.Add("Five");
            //employeesList.Add("Six");
            //employeesList.Add("Seven");
            //employeesList.Add("Eight");
            //employeesList.Add("Nine");
            //employeesList.Add("Ten");
            GetEmployeeNames();
        }

        public ObservableCollection<Model> EmployeeDetails 
        {
            get { return employeelist; }
            set { value = employeelist; }
        }

        public void GetEmployeeNames()
        {
            foreach (var item in employeelist)
                employeesList.Add(item.EmployeeName);
        }
        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}