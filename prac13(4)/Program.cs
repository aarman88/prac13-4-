using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {Patronymic}, {Gender}, Возраст: {Age}, Зарплата: {Salary:C}";
    }
}

class Program
{
    static void Main()
    {
        string filePath = "employees.txt";

        try
        {
            // Чтение данных из файла
            List<Employee> employees = ReadEmployeesFromFile(filePath);

            // Разделение сотрудников на две группы
            var under10000 = employees.Where(emp => emp.Salary < 10000).ToList();
            var aboveOrEqual10000 = employees.Where(emp => emp.Salary >= 10000).ToList();

            // Печать данных в указанном порядке
            PrintEmployees(under10000);
            PrintEmployees(aboveOrEqual10000);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static List<Employee> ReadEmployeesFromFile(string filePath)
    {
        List<Employee> employees = new List<Employee>();

        string[] lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            string[] data = line.Split(',').Select(item => item.Trim()).ToArray();

            Employee employee = new Employee
            {
                LastName = data[0],
                FirstName = data[1],
                Patronymic = data[2],
                Gender = data[3],
                Age = int.Parse(data[4]),
                Salary = double.Parse(data[5])
            };

            employees.Add(employee);
        }

        return employees;
    }

    static void PrintEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
