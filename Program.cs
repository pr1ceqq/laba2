//Реалізуйте клас Працівник, який містить властивості: 
//ім 'я, прізвище, ставка за день роботи, кількість відпрацьованих днів. 
//Також клас повинен мати метод, який буде виводити зарплату працівника. 
//Зарплата - це добуток ставки на кількість відпрацьованих днів.
/*
 * Завдання 2
Створити у попередньому завданні два методи з використанням серіалізації та десеріалізації JSON. 
Метод 1. Зберігає створений об’єкт класу з Завдання 1 у JSON файл 
Метод 2. Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.
*/
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
// string jsonString = JsonSerializer.Serialize(employee);
// Employee? employee =
//JsonSerializer.Deserialize<Employee>(jsonstring);
Employee employee = new Employee();
employee.ZP();
var winpath = @"C:\Users\deadd\Desktop";
var filename = "emp.json";
var path = Path.Combine(winpath, filename);
tojson();
var nark = await fromjson();
nark.Print();
async void tojson()
{
    
    using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
    {
        string jsonString = JsonSerializer.Serialize(employee);

        byte[] buffer = Encoding.Default.GetBytes(jsonString);

        await fstream.WriteAsync(buffer, 0, buffer.Length);
        Console.WriteLine();
        Console.WriteLine("Текст записан в файл");
    }
}
 async Task<Employee> fromjson()
{
    var employee = new Employee();
    using (FileStream fs = File.OpenRead(path))
    {
         employee =
            await JsonSerializer.DeserializeAsync<Employee>(fs);
    }
    return employee;
}

class Employee
{
    public void ZP()
    {
        int zp = days * wage;
        Console.WriteLine(zp);
    }
    public void Print()
    {
        Console.WriteLine($"Имя: {name}"+ " "+ $" {surname}  Возраст: {age}; {wage}; {days}");
    }
    int age = 18;
    string name = "David";
    string surname = "Braun";
    int wage = 14;
    int days = 5;
    public int Age
    {

        set
        {
            if (value < 1 || value > 120)
                Console.WriteLine("Возраст должен быть в диапазоне от 1 до 120");
            else
                age = value;
        }
        get { return age; }
    }
    public string Name
    {
        set { name = value; }
        get { return name; }
    }
    public string Surname
    {
        set { surname = value; }
        get { return surname; }
    }
    public int Wage
    {
        set { wage = value; }
        get { return wage; }
    }
    public int Days
    {
        set { days = value; }
        get { return days; }
    }
   
}