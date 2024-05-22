using System;
using System.ComponentModel;
Note note = new Note();
do
{
    Console.Clear();
    Console.WriteLine("Выберите действие:\n" +
        "1 - Добавление нового сотрудника в список\n" +
        "2 - Удаление сотрудника по фамилии\n" +
        "3 - Поиск сотрудника по имени или должности\n" +
       
        "4 - Выход");
    note.Print();
    Console.Write("Введите действие:");
    int n;
    int.TryParse(Console.ReadLine(), out n);
    switch (n)
    {
        case 1:
            {
                Console.Write("Введите имя сотрудника:");
                string name = Console.ReadLine()!;
                Console.WriteLine("Введите фамилию сотрудника: ");
                string surname = Console.ReadLine()!;
                Console.Write("Введите должность:");
                string job = Console.ReadLine()!;
                Employee employee = new Employee(name,surname,job);
                note.Add(employee);
            }
            break;
        case 2:
            {

                Console.WriteLine("Введите фамилию сотрудника:");
                string surname = Console.ReadLine()!;
                Employee employee = note.FindByName(surname);
                note.Remove(employee);
            }
            break;
       
        case 3:
            {
                Console.WriteLine("Выберите способ:\n" +
                   "1 - по имени\n" +
                   "2 - по должности: ");
                int m;
                int.TryParse(Console.ReadLine(), out m);
                switch (m)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите имя сотрудника:");
                            string name = Console.ReadLine()!;
                            Employee employee = note.FindByName(name);
                            Console.WriteLine(employee.getName() + " " + employee.getJob());
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Введите должность сотрудника:");
                            string job = Console.ReadLine()!;
                            Employee employee = note.FindByJob(job);
                            Console.WriteLine(employee.getName() + " " + employee.getJob());
                            Console.ReadKey();
                        }
                        break;
                }
            }
            break;
    }

    if (n == 4) break;
}
while (true);
class Note
{
    private List<Employee> employee;
    public Note()
    {
        employee = new List<Employee>();
    }
    public void Add(Employee contact) => employee.Add(contact);
    public void Remove(Employee contact) => employee.Remove(contact);
    public void Remove(int n) => employee.RemoveAt(n - 1);
    public Employee FindByName(string name)
    {
        foreach (Employee i in employee)
        {
            if (i.getName() == name)
            {
                return i;
            }
        }
        return null!;
    }
    public Employee FindByJob(string job) => employee.FirstOrDefault(p => p.getJob() == job)!;
    public void Print()
    {
        int i = 0;
        foreach (Employee item in employee)
        {
            Console.WriteLine(++i + "." + item.getName() + ", " + item.getJob());
        }
    }
}
class Employee
{
    private string name;
    private string surname;
    private string job;
    public Employee(string name, string surname,string job)
    {
        this.name = name;
        this.job = job;
        this.surname = surname;
    }
    public string getName() => name;
    public string getJob() => job;
    public string getSurname() => surname;
}