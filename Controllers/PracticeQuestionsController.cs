using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Web;

namespace GenieWeb.Controllers
{
    public class PracticeQuestionsController : Controller
    {
        private static Dictionary<string, List<QuestionModel>> _questionSets = new Dictionary<string, List<QuestionModel>>
        {
            { "CSharpAsynchronousQues", new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Create an asynchronous method that fetches data from a web API using HttpClient.",
        Explanation = "This demonstrates how to use async and await for making non-blocking web requests.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program {
    static async Task FetchDataAsync() {
        using HttpClient client = new HttpClient();
        string result = await client.GetStringAsync(""https://api.example.com/data"");
        Console.WriteLine(result);
    }
    static async Task Main() {
        await FetchDataAsync();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Write an asynchronous method that reads a file and prints its contents without blocking the main thread.",
        Explanation = "Demonstrates async file I/O operations.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.IO;
using System.Threading.Tasks;
class Program {
    static async Task ReadFileAsync(string filePath) {
        string content = await File.ReadAllTextAsync(filePath);
        Console.WriteLine(content);
    }
    static async Task Main() {
        await ReadFileAsync(""sample.txt"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 3,
        Question = "3. Implement an async method that simulates a long-running task using Task.Delay().",
        Explanation = "Shows how Task.Delay() is used to mimic asynchronous operations.",
        MaxTime = "8 minutes",
        Answer = @"using System;
using System.Threading.Tasks;
class Program {
    static async Task SimulateLongTask() {
        Console.WriteLine(""Task started..."");
        await Task.Delay(5000);
        Console.WriteLine(""Task completed after 5 seconds."");
    }
    static async Task Main() {
        await SimulateLongTask();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 4,
        Question = "4. Implement a method that runs two async tasks in parallel and waits for both to complete.",
        Explanation = "Demonstrates Task.WhenAll() for concurrent execution.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Threading.Tasks;
class Program {
    static async Task Task1() {
        await Task.Delay(3000);
        Console.WriteLine(""Task 1 completed."");
    }
    static async Task Task2() {
        await Task.Delay(2000);
        Console.WriteLine(""Task 2 completed."");
    }
    static async Task Main() {
        await Task.WhenAll(Task1(), Task2());
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 5,
        Question = "5. Demonstrate exception handling in an async method using try-catch.",
        Explanation = "Shows how exceptions can be handled in asynchronous operations.",
        MaxTime = "8 minutes",
        Answer = @"using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program {
    static async Task FetchDataWithHandlingAsync() {
        try {
            using HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(""https://invalid-url.com"");
            Console.WriteLine(result);
        } catch (HttpRequestException e) {
            Console.WriteLine(""Request failed: {e.Message}"");
        }
    }
    static async Task Main() {
        await FetchDataWithHandlingAsync();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 6,
        Question = "6. Use Task.Run to run a CPU-bound task asynchronously.",
        Explanation = "Demonstrates how to offload CPU-bound work to background threads.",
        MaxTime = "8 minutes",
        Answer = @"using System;
using System.Threading.Tasks;
class Program {
    static async Task<int> ComputeAsync() {
        return await Task.Run(() => {
            int sum = 0;
            for (int i = 0; i < 1000000; i++) sum += i;
            return sum;
        });
    }
    static async Task Main() {
        int result = await ComputeAsync();
        Console.WriteLine(""Computed sum: {result}"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 7,
        Question = "7. Implement an async method that processes multiple tasks using Task.WhenAny().",
        Explanation = "Shows how to handle the first completed task in a group.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Threading.Tasks;
class Program {
    static async Task Main() {
        Task task1 = Task.Delay(3000).ContinueWith(_ => Console.WriteLine(""Task 1 done""));
        Task task2 = Task.Delay(2000).ContinueWith(_ => Console.WriteLine(""Task 2 done""));
        await Task.WhenAny(task1, task2);
    }
}" ,
        ShowAnswer = false
    },
new QuestionModel {
        Id = 8,
        Question = "8. Implement an async method that uses ConfigureAwait(false) to avoid deadlocks in UI applications.",
        Explanation = "Demonstrates how ConfigureAwait(false) helps prevent deadlocks when using async in UI applications.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program {
    static async Task<string> FetchDataAsync() {
        using HttpClient client = new HttpClient();
        return await client.GetStringAsync(""https://api.example.com/data"").ConfigureAwait(false);
    }
    static async Task Main() {
        string data = await FetchDataAsync();
        Console.WriteLine(data);
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 9,
        Question = "9. Demonstrate how to use SemaphoreSlim to limit concurrent async operations.",
        Explanation = "Shows how SemaphoreSlim can be used to limit the number of concurrent tasks.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
class Program {
    static SemaphoreSlim semaphore = new SemaphoreSlim(2);
    static async Task ProcessTask(int id) {
        await semaphore.WaitAsync();
        try {
            Console.WriteLine(""Task {id} started."");
            await Task.Delay(3000);
            Console.WriteLine(""Task {id} completed."");
        } finally {
            semaphore.Release();
        }
    }
    static async Task Main() {
        List<Task> tasks = new List<Task>();
        for (int i = 1; i <= 5; i++) {
            tasks.Add(ProcessTask(i));
        }
        await Task.WhenAll(tasks);
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 10,
        Question = "10. Write an async method that returns a value using Task<T> and demonstrate its usage.",
        Explanation = "Shows how to use Task<T> to return values from asynchronous methods.",
        MaxTime = "8 minutes",
        Answer = @"using System;
using System.Threading.Tasks;
class Program {
    static async Task<int> GetDataAsync() {
        await Task.Delay(2000);
        return 42;
    }
    static async Task Main() {
        int result = await GetDataAsync();
        Console.WriteLine(""The answer is {result}"");
    }
}" ,
        ShowAnswer = false
    }
 }
        },
            { "InheritancePracticeQues",new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Create a simple base class `Animal` with a method `Speak()`. Derive a `Dog` class that overrides it.",
        Explanation = "This introduces basic inheritance. The `Dog` class will override the `Speak()` method of the `Animal` class.",
        MaxTime = "5 minutes",
        Answer = @"
using System;
class Animal {
    public virtual void Speak() {
        Console.WriteLine(""Animals make sounds"");
    }
}
class Dog : Animal {
    public override void Speak() {
        Console.WriteLine(""Dog barks"");
    }
}
class Program {
    static void Main() {
        Animal a = new Dog();
        a.Speak();
    }
}",
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Create a `Person` class with a method `GetDetails()`. Derive a `Student` class that overrides it.",
        Explanation = "You'll learn how a derived class (`Student`) can provide a different implementation of a method inherited from the base class (`Person`).",
        MaxTime = "8 minutes",
        Answer = @"
using System;
class Person {
    public virtual void GetDetails() {
        Console.WriteLine(""This is a person."");
    }
}
class Student : Person {
    public override void GetDetails() {
        Console.WriteLine(""This is a student."");
    }
}
class Program {
    static void Main() {
        Person p = new Student();
        p.GetDetails();
    }
}",
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 3,
        Question = "3. Implement an `Employee` base class with a method `CalculateSalary()`. Create a `Manager` class that adds a bonus to salary.",
        Explanation = "This question introduces method overriding and the use of `base` to call the parent class method while adding additional logic.",
        MaxTime = "10 minutes",
        Answer = @"
using System;
class Employee {
    public virtual double CalculateSalary() {
        return 40000;
    }
}
class Manager : Employee {
    public override double CalculateSalary() {
        return base.CalculateSalary() + 10000;
    }
}
class Program {
    static void Main() {
        Employee emp = new Manager();
        Console.WriteLine($""Salary: {emp.CalculateSalary()}"");
    }
}",
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 4,
        Question = "4. Create a `Vehicle` class with `StartEngine()`. Extend it to `Car` and `Motorcycle` with different behaviors.",
        Explanation = "This demonstrates how multiple classes can inherit from the same parent and implement methods differently.",
        MaxTime = "12 minutes",
        Answer = @"
using System;
class Vehicle {
    public virtual void StartEngine() {
        Console.WriteLine(""Vehicle engine starting"");
    }
}
class Car : Vehicle {
    public override void StartEngine() {
        Console.WriteLine(""Car engine roaring!"");
    }
}
class Motorcycle : Vehicle {
    public override void StartEngine() {
        Console.WriteLine(""Motorcycle engine revving!"");
    }
}
class Program {
    static void Main() {
        Vehicle v1 = new Car();
        v1.StartEngine();
        
        Vehicle v2 = new Motorcycle();
        v2.StartEngine();
    }
}",
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 5,
        Question = "5. Implement a `BankAccount` class with `Deposit()` and `Withdraw()`. Extend it to `SavingsAccount` with interest calculation.",
        Explanation = "You'll implement a basic banking system where `SavingsAccount` adds extra functionality.",
        MaxTime = "15 minutes",
        Answer = @"
using System;
class BankAccount {
    protected double balance;
    public virtual void Deposit(double amount) {
        balance += amount;
        Console.WriteLine($""Deposited: {amount}"");
    }
}
class SavingsAccount : BankAccount {
    private double interestRate = 0.05;
    public override void Deposit(double amount) {
        balance += amount + (amount * interestRate);
        Console.WriteLine($""Deposited with interest: {amount * interestRate}"");
    }
}
class Program {
    static void Main() {
        SavingsAccount acc = new SavingsAccount();
        acc.Deposit(1000);
    }
}",
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 6,
        Question = "6. Implement `Shape` class with `CalculateArea()`. Extend to `Rectangle` and `Circle` with area calculations.",
        Explanation = "You'll learn how different classes can provide unique implementations for a common method.",
        MaxTime = "15 minutes",
        Answer = @"
using System;
class Shape {
    public virtual double CalculateArea() {
        return 0;
    }
}
class Rectangle : Shape {
    private double width, height;
    public Rectangle(double w, double h) {
        width = w;
        height = h;
    }
    public override double CalculateArea() {
        return width * height;
    }
}
class Circle : Shape {
    private double radius;
    public Circle(double r) {
        radius = r;
    }
    public override double CalculateArea() {
        return Math.PI * radius * radius;
    }
}
class Program {
    static void Main() {
        Shape rect = new Rectangle(5, 10);
        Console.WriteLine($""Rectangle Area: {rect.CalculateArea()}"");

        Shape circle = new Circle(7);
        Console.WriteLine($""Circle Area: {circle.CalculateArea()}"");
    }
}",
        ShowAnswer = false
    }
}
 },
            { "CSharpBasics", new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Reverse a string without using built-in functions.",
        Explanation = "This tests string manipulation and loop usage.",
        MaxTime = "5 minutes",
        Answer = @"using System;
class Program {
    static void Main() {
        string input = ""hello"";
        char[] reversed = new char[input.Length];
        for (int i = 0; i < input.Length; i++) {
            reversed[i] = input[input.Length - 1 - i];
        }
        Console.WriteLine(new string(reversed));
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Find the largest element in an integer array.",
        Explanation = "This tests array traversal and comparison logic.",
        MaxTime = "5 minutes",
        Answer = @"using System;
class Program {
    static void Main() {
        int[] numbers = {3, 8, 2, 5, 9, 1};
        int max = numbers[0];
        foreach(int num in numbers) {
            if (num > max) max = num;
        }
        Console.WriteLine(""Largest number: {max
    }"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel
    {
        Id = 3,
        Question = "3. Remove duplicates from a list using a HashSet.",
        Explanation = "Demonstrates how sets automatically handle duplicates.",
        MaxTime = "6 minutes",
        Answer = @"using System;
using System.Collections.Generic;
class Program {
    static void Main() {
        List<int> numbers = new List<int> {1, 2, 3, 2, 4, 1, 5};
        HashSet<int> uniqueNumbers = new HashSet<int>(numbers);
        Console.WriteLine(string.Join("", "", uniqueNumbers));
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel
    {
        Id = 4,
        Question = "4. Find the frequency of elements in an array using a Dictionary.",
        Explanation = "Demonstrates dictionary usage for counting occurrences.",
        MaxTime = "8 minutes",
        Answer = @"using System;
using System.Collections.Generic;
class Program {
    static void Main() {
        int[] arr = {1, 2, 3, 2, 1, 4, 2};
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in arr) {
            if (freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        }
        foreach (var item in freq) {
            Console.WriteLine(""{ item.Key }: {item.Value
    }"");
        }
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel
    {
        Id = 5,
        Question = "5. Check if a given string is a palindrome.",
        Explanation = "String reversal and comparison logic.",
        MaxTime = "7 minutes",
        Answer = @"using System;
class Program {
    static void Main() {
        string input = ""racecar"";
        bool isPalindrome = true;
        for (int i = 0; i < input.Length / 2; i++) {
            if (input[i] != input[input.Length - 1 - i]) {
            isPalindrome = false;
                break;
            }
    }
        Console.WriteLine(isPalindrome ? ""Palindrome"" : ""Not a palindrome"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel
    {
        Id = 6,
        Question = "6. Find the sum of all elements in an array.",
        Explanation = "Demonstrates array traversal and summation logic.",
        MaxTime = "5 minutes",
        Answer = @"using System;
class Program {
    static void Main() {
        int[] arr = {1, 2, 3, 4, 5};
        int sum = 0;
        foreach(int num in arr) sum += num;
        Console.WriteLine(""Sum: {sum
    }"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel
    {
        Id = 7,
        Question = "7. Merge two sorted arrays into a single sorted array.",
        Explanation = "Demonstrates merging and sorting techniques.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Linq;
class Program {
    static void Main() {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};
        int[] merged = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while (i < arr1.Length && j < arr2.Length) {
            if (arr1[i] < arr2[j]) {
                merged[k++] = arr1[i++];
            } else {
                merged[k++] = arr2[j++];
            }
        }
        while (i < arr1.Length) {
            merged[k++] = arr1[i++];
        }
        while (j < arr2.Length) {
            merged[k++] = arr2[j++];
        }
        Console.WriteLine(string.Join("", "", merged));
    }
}" ,
        ShowAnswer = false
    }
}
 },
            {
    "CSharpAdvancedQues",
    new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Create a base class `Employee` with a method `GetSalary()`. Derive `FullTimeEmployee` and `PartTimeEmployee` classes that override the method to calculate salaries differently.",
        Explanation = "This demonstrates polymorphism by allowing different employee types to implement their own salary calculation logic.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class Employee {
    public virtual double GetSalary() {
        return 0;
    }
}
class FullTimeEmployee : Employee {
    public override double GetSalary() {
        return 50000;
    }
}
class PartTimeEmployee : Employee {
    public override double GetSalary() {
        return 20000;
    }
}
class Program {
    static void Main() {
        Employee emp1 = new FullTimeEmployee();
        Console.WriteLine(""Full-Time Employee Salary: {emp1.GetSalary()}"");

        Employee emp2 = new PartTimeEmployee();
        Console.WriteLine(""Part-Time Employee Salary: {emp2.GetSalary()}"");
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Create a `Vehicle` class with a method `Drive()`. Derive `Car` and `Truck` classes that override the method to provide specific driving behaviors.",
        Explanation = "This demonstrates polymorphism by allowing different vehicle types to implement their own driving logic.",
        MaxTime = "8 minutes",
        Answer = @"using System;
class Vehicle {
    public virtual void Drive() {
        Console.WriteLine(""Driving a vehicle"");
    }
}
class Car : Vehicle {
    public override void Drive() {
        Console.WriteLine(""Driving a car"");
    }
}
class Truck : Vehicle {
    public override void Drive() {
        Console.WriteLine(""Driving a truck"");
    }
}
class Program {
    static void Main() {
        Vehicle v1 = new Car();
        v1.Drive();

        Vehicle v2 = new Truck();
        v2.Drive();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 3,
        Question = "3. Create a `Shape` class with a method `CalculatePerimeter()`. Derive `Rectangle` and `Triangle` classes that override the method to calculate their respective perimeters.",
        Explanation = "This demonstrates polymorphism by allowing different shapes to implement their own perimeter calculation logic.",
        MaxTime = "12 minutes",
        Answer = @"using System;
class Shape {
    public virtual double CalculatePerimeter() {
        return 0;
    }
}
class Rectangle : Shape {
    private double length, width;
    public Rectangle(double l, double w) {
        length = l;
        width = w;
    }
    public override double CalculatePerimeter() {
        return 2 * (length + width);
    }
}
class Triangle : Shape {
    private double a, b, c;
    public Triangle(double side1, double side2, double side3) {
        a = side1;
        b = side2;
        c = side3;
    }
    public override double CalculatePerimeter() {
        return a + b + c;
    }
}
class Program {
    static void Main() {
        Shape rect = new Rectangle(5, 10);
        Console.WriteLine(""Rectangle Perimeter: {rect.CalculatePerimeter()}"");

        Shape tri = new Triangle(3, 4, 5);
        Console.WriteLine(""Triangle Perimeter: {tri.CalculatePerimeter()}"");
    }
}" ,
        ShowAnswer = false
    },
     new QuestionModel {
        Id = 4,
        Question = "4. Create a `Person` class with a method `GetDetails()`. Derive `Teacher` and `Student` classes that override the method to provide specific details.",
        Explanation = "This demonstrates inheritance and polymorphism by allowing derived classes to provide their own implementation of a method.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class Person {
    public virtual void GetDetails() {
        Console.WriteLine(""This is a person."");
    }
}
class Teacher : Person {
    public override void GetDetails() {
        Console.WriteLine(""This is a teacher."");
    }
}
class Student : Person {
    public override void GetDetails() {
        Console.WriteLine(""This is a student."");
    }
}
class Program {
    static void Main() {
        Person p1 = new Teacher();
        p1.GetDetails();

        Person p2 = new Student();
        p2.GetDetails();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 5,
        Question = "5. Create a `BankAccount` class with methods `Deposit()` and `Withdraw()`. Derive `CheckingAccount` and `SavingsAccount` classes that override the methods to implement specific rules.",
        Explanation = "This demonstrates polymorphism by allowing different account types to implement their own deposit and withdrawal rules.",
        MaxTime = "15 minutes",
        Answer = @"using System;
class BankAccount {
    protected double balance;
    public virtual void Deposit(double amount) {
        balance += amount;
        Console.WriteLine(""Deposited: {amount}"");
    }
    public virtual void Withdraw(double amount) {
        balance -= amount;
        Console.WriteLine(""Withdrawn: {amount}"");
    }
}
class CheckingAccount : BankAccount {
    public override void Withdraw(double amount) {
        if (balance - amount < 0) {
            Console.WriteLine(""Insufficient funds"");
        } else {
            base.Withdraw(amount);
        }
    }
}
class SavingsAccount : BankAccount {
    private double interestRate = 0.05;
    public override void Deposit(double amount) {
        balance += amount + (amount * interestRate);
        Console.WriteLine(""Deposited with interest: {amount * interestRate}"");
    }
}
class Program {
    static void Main() {
        BankAccount acc1 = new CheckingAccount();
        acc1.Deposit(500);
        acc1.Withdraw(600);

        BankAccount acc2 = new SavingsAccount();
        acc2.Deposit(1000);
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 6,
        Question = "6. Create a `Device` class with a method `TurnOn()`. Derive `Laptop` and `Smartphone` classes that override the method to provide specific behaviors.",
        Explanation = "This demonstrates polymorphism by allowing different devices to implement their own start-up logic.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class Device {
    public virtual void TurnOn() {
        Console.WriteLine(""Device is turning on"");
    }
}
class Laptop : Device {
    public override void TurnOn() {
        Console.WriteLine(""Laptop is booting up"");
    }
}
class Smartphone : Device {
    public override void TurnOn() {
        Console.WriteLine(""Smartphone is starting"");
    }
}
class Program {
    static void Main() {
        Device d1 = new Laptop();
        d1.TurnOn();

        Device d2 = new Smartphone();
        d2.TurnOn();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 7,
        Question = "7. Create a `Game` class with a method `Start()`. Derive `Chess` and `Football` classes that override the method to provide specific game start logic.",
        Explanation = "This demonstrates polymorphism by allowing different games to implement their own start logic.",
        MaxTime = "8 minutes",
        Answer = @"using System;
class Game {
    public virtual void Start() {
        Console.WriteLine(""Starting a game"");
    }
}
class Chess : Game {
    public override void Start() {
        Console.WriteLine(""Starting a chess game"");
    }
}
class Football : Game {
    public override void Start() {
        Console.WriteLine(""Starting a football game"");
    }
}
class Program {
    static void Main() {
        Game g1 = new Chess();
        g1.Start();

        Game g2 = new Football();
        g2.Start();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 8,
        Question = "8. Create a `Tool` class with a method `Use()`. Derive `Hammer` and `Screwdriver` classes that override the method to provide specific usage logic.",
        Explanation = "This demonstrates polymorphism by allowing different tools to implement their own usage logic.",
        MaxTime = "6 minutes",
        Answer = @"using System;
class Tool {
    public virtual void Use() {
        Console.WriteLine(""Using a tool"");
    }
}
class Hammer : Tool {
    public override void Use() {
        Console.WriteLine(""Using a hammer"");
    }
}
class Screwdriver : Tool {
    public override void Use() {
        Console.WriteLine(""Using a screwdriver"");
    }
}
class Program {
    static void Main() {
        Tool t1 = new Hammer();
        t1.Use();

        Tool t2 = new Screwdriver();
        t2.Use();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 9,
        Question = "9. Create a `MusicalInstrument` class with a method `Play()`. Derive `Piano` and `Guitar` classes that override the method to provide specific playing behaviors.",
        Explanation = "This demonstrates polymorphism by allowing different musical instruments to implement their own playing logic.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class MusicalInstrument {
    public virtual void Play() {
        Console.WriteLine(""Playing an instrument"");
    }
}
class Piano : MusicalInstrument {
    public override void Play() {
        Console.WriteLine(""Playing the piano"");
    }
}
class Guitar : MusicalInstrument {
    public override void Play() {
        Console.WriteLine(""Playing the guitar"");
    }
}
class Program {
    static void Main() {
        MusicalInstrument mi1 = new Piano();
        mi1.Play();

        MusicalInstrument mi2 = new Guitar();
        mi2.Play();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 10,
        Question = "10. Implement a `Food` class with a method `Cook()`. Extend it to `Pizza` and `Pasta` with different cooking methods.",
        Explanation = "This demonstrates polymorphism by allowing different food types to implement their own cooking logic.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class Food {
    public virtual void Cook() {
        Console.WriteLine(""Cooking food"");
    }
}
class Pizza : Food {
    public override void Cook() {
        Console.WriteLine(""Cooking pizza"");
    }
}
class Pasta : Food {
    public override void Cook() {
        Console.WriteLine(""Cooking pasta"");
    }
}
class Program {
    static void Main() {
        Food f1 = new Pizza();
        f1.Cook();

        Food f2 = new Pasta();
        f2.Cook();
    }
}" ,
        ShowAnswer = false
    }
}

     },
            {
    "CSharpPolymorphism",new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Create a base class `Shape` with a method `Draw()`. Derive `Circle` and `Square` classes that override the `Draw()` method.",
        Explanation = "This demonstrates polymorphism by allowing different shapes to implement their own version of the `Draw()` method.",
        MaxTime = "5 minutes",
        Answer = @"using System;
class Shape {
    public virtual void Draw() {
        Console.WriteLine(""Drawing a shape"");
    }
}
class Circle : Shape {
    public override void Draw() {
        Console.WriteLine(""Drawing a circle"");
    }
}
class Square : Shape {
    public override void Draw() {
        Console.WriteLine(""Drawing a square"");
    }
}
class Program {
    static void Main() {
        Shape s1 = new Circle();
        s1.Draw();

        Shape s2 = new Square();
        s2.Draw();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Implement a `Payment` class with a method `ProcessPayment()`. Extend it to `CreditCardPayment` and `PayPalPayment` with different implementations.",
        Explanation = "This shows how different payment methods can have unique implementations of the same method.",
        MaxTime = "8 minutes",
        Answer = @"using System;
class Payment {
    public virtual void ProcessPayment() {
        Console.WriteLine(""Processing payment"");
    }
}
class CreditCardPayment : Payment {
    public override void ProcessPayment() {
        Console.WriteLine(""Processing credit card payment"");
    }
}
class PayPalPayment : Payment {
    public override void ProcessPayment() {
        Console.WriteLine(""Processing PayPal payment"");
    }
}
class Program {
    static void Main() {
        Payment p1 = new CreditCardPayment();
        p1.ProcessPayment();

        Payment p2 = new PayPalPayment();
        p2.ProcessPayment();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 3,
        Question = "3. Create a `Media` class with a method `Play()`. Derive `Audio` and `Video` classes that override the `Play()` method.",
        Explanation = "This demonstrates polymorphism by allowing different media types to implement their own playback behavior.",
        MaxTime = "7 minutes",
        Answer = @"using System;
class Media {
    public virtual void Play() {
        Console.WriteLine(""Playing media"");
    }
}
class Audio : Media {
    public override void Play() {
        Console.WriteLine(""Playing audio"");
    }
}
class Video : Media {
    public override void Play() {
        Console.WriteLine(""Playing video"");
    }
}
class Program {
    static void Main() {
        Media m1 = new Audio();
        m1.Play();

        Media m2 = new Video();
        m2.Play();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 4,
        Question = "4. Create a `Notification` class with a method `Send()`. Derive `EmailNotification` and `SMSNotification` classes that override the method.",
        Explanation = "This demonstrates how different notification types can override the same method to provide specific functionality.",
        MaxTime = "6 minutes",
        Answer = @"using System;
class Notification {
    public virtual void Send() {
        Console.WriteLine(""Sending notification"");
    }
}
class EmailNotification : Notification {
    public override void Send() {
        Console.WriteLine(""Sending email notification"");
    }
}
class SMSNotification : Notification {
    public override void Send() {
        Console.WriteLine(""Sending SMS notification"");
    }
}
class Program {
    static void Main() {
        Notification n1 = new EmailNotification();
        n1.Send();

        Notification n2 = new SMSNotification();
        n2.Send();
    }
}" ,
        ShowAnswer = false
    },
     new QuestionModel {
        Id = 5,
        Question = "5. Create a `Document` class with a method `Print()`. Derive `WordDocument` and `PDFDocument` classes that override the `Print()` method.",
        Explanation = "This demonstrates how different document types can implement their own printing logic.",
        MaxTime = "7 minutes",
        Answer = @"using System;
class Document {
    public virtual void Print() {
        Console.WriteLine(""Printing document"");
    }
}
class WordDocument : Document {
    public override void Print() {
        Console.WriteLine(""Printing Word document"");
    }
}
class PDFDocument : Document {
    public override void Print() {
        Console.WriteLine(""Printing PDF document"");
    }
}
class Program {
    static void Main() {
        Document d1 = new WordDocument();
        d1.Print();

        Document d2 = new PDFDocument();
        d2.Print();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 6,
        Question = "6. Implement a `Transport` class with a method `Move()`. Extend it to `Car` and `Bicycle` with different behaviors.",
        Explanation = "This demonstrates polymorphism by allowing different transport modes to implement their own movement logic.",
        MaxTime = "8 minutes",
        Answer = @"using System;
class Transport {
    public virtual void Move() {
        Console.WriteLine(""Transport is moving"");
    }
}
class Car : Transport {
    public override void Move() {
        Console.WriteLine(""Car is driving"");
    }
}
class Bicycle : Transport {
    public override void Move() {
        Console.WriteLine(""Bicycle is pedaling"");
    }
}
class Program {
    static void Main() {
        Transport t1 = new Car();
        t1.Move();

        Transport t2 = new Bicycle();
        t2.Move();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 7,
        Question = "7. Create a `GameCharacter` class with a method `Attack()`. Derive `Warrior` and `Mage` classes that override the `Attack()` method.",
        Explanation = "This demonstrates how different character types in a game can have unique attack behaviors.",
        MaxTime = "10 minutes",
        Answer = @"using System;
class GameCharacter {
    public virtual void Attack() {
        Console.WriteLine(""Character is attacking"");
    }
}
class Warrior : GameCharacter {
    public override void Attack() {
        Console.WriteLine(""Warrior is slashing"");
    }
}
class Mage : GameCharacter {
    public override void Attack() {
        Console.WriteLine(""Mage is casting a spell"");
    }
}
class Program {
    static void Main() {
        GameCharacter c1 = new Warrior();
        c1.Attack();

        GameCharacter c2 = new Mage();
        c2.Attack();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 8,
        Question = "8. Implement a `Device` class with a method `Shutdown()`. Extend it to `Laptop` and `Desktop` with different shutdown behaviors.",
        Explanation = "This demonstrates polymorphism by allowing different devices to implement their own shutdown logic.",
        MaxTime = "7 minutes",
        Answer = @"using System;
class Device {
    public virtual void Shutdown() {
        Console.WriteLine(""Device is shutting down"");
    }
}
class Laptop : Device {
    public override void Shutdown() {
        Console.WriteLine(""Laptop is shutting down"");
    }
}
class Desktop : Device {
    public override void Shutdown() {
        Console.WriteLine(""Desktop is shutting down"");
    }
}
class Program {
    static void Main() {
        Device d1 = new Laptop();
        d1.Shutdown();

        Device d2 = new Desktop();
        d2.Shutdown();
    }
}" ,
        ShowAnswer = false
    }
}
    },
            {
    "ProgrammingQuestions", new List<QuestionModel> {
    new QuestionModel {
        Id = 1,
        Question = "1. Find Items: Implement methods to look up items by sold count, get min/max sold items, and sort items by sold count.",
        Explanation = "Builds sorted dictionary operations for lookup, min/max selection, and ascending sorting.",
        MaxTime = "12 minutes",
        Answer = @"using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();

    public static SortedDictionary<string, long> FindItemDetails(long soldCount) {
        var result = new SortedDictionary<string, long>();
        foreach (var item in itemDetails) {
            if (item.Value == soldCount) {
                result[item.Key] = item.Value;
            }
        }
        return result;
    }

    public static List<string> FindMinandMaxSoldItems() {
        var result = new List<string>();
        if (itemDetails.Count == 0) {
            return result;
        }

        long min = itemDetails.Values.Min();
        long max = itemDetails.Values.Max();
        result.Add(itemDetails.First(kv => kv.Value == min).Key);
        result.Add(itemDetails.First(kv => kv.Value == max).Key);
        return result;
    }

    public static Dictionary<string, long> SortByCount() {
        return itemDetails.OrderBy(kv => kv.Value)
            .ToDictionary(kv => kv.Key, kv => kv.Value);
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 2,
        Question = "2. Calculate Numbers: Add numbers, compute GPA, and return a grade for the GPA.",
        Explanation = "Uses a list to calculate GPA and map the GPA to a letter grade.",
        MaxTime = "10 minutes",
        Answer = @"using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static List<int> NumberList = new List<int>();

    public static void AddNumbers(int numbers) {
        NumberList.Add(numbers);
    }

    public static double GetGPAScored() {
        if (NumberList.Count == 0) {
            return -1;
        }

        double total = NumberList.Sum(n => n * 3);
        return total / (NumberList.Count * 3.0);
    }

    public static char GetGradeScored(double gpa) {
        if (gpa < 5 || gpa > 10) {
            return '\0';
        }
        if (gpa == 10) return 'S';
        if (gpa >= 9) return 'A';
        if (gpa >= 8) return 'B';
        if (gpa >= 7) return 'C';
        if (gpa >= 6) return 'D';
        return 'E';
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 3,
        Question = "3. Movie Stock: Add movies, filter by genre, and sort by ratings.",
        Explanation = "Parses a comma-separated string into a Movie object and returns sorted or filtered lists.",
        MaxTime = "12 minutes",
        Answer = @"using System;
using System.Collections.Generic;
using System.Linq;

class Movie {
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Ratings { get; set; }
}

class Program {
    public static List<Movie> MovieList = new List<Movie>();

    public static void AddMovie(string movieDetails) {
        var parts = movieDetails.Split(',');
        MovieList.Add(new Movie {
            Title = parts[0].Trim(),
            Artist = parts[1].Trim(),
            Genre = parts[2].Trim(),
            Ratings = int.Parse(parts[3].Trim())
        });
    }

    public static List<Movie> ViewMoviesByGenre(string genre) {
        return MovieList.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static List<Movie> ViewMoviesByRatings() {
        return MovieList.OrderBy(m => m.Ratings).ToList();
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 4,
        Question = "4. Yoga Meditation: Store member details, compute BMI, and calculate the membership fee.",
        Explanation = "Tracks yoga members, computes BMI, and returns a fee based on goal and BMI.",
        MaxTime = "15 minutes",
        Answer = @"using System;
using System.Collections;

class MeditationCenter {
    public int MemberId { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string Goal { get; set; }
    public double BMI { get; set; }
}

class Program {
    public static ArrayList memberList = new ArrayList();

    public void AddYogaMember(int memberId, int age, double weight, double height, string goal) {
        memberList.Add(new MeditationCenter {
            MemberId = memberId,
            Age = age,
            Weight = weight,
            Height = height,
            Goal = goal
        });
    }

    public double CalculateBMI(int memberId) {
        foreach (MeditationCenter member in memberList) {
            if (member.MemberId == memberId) {
                double bmi = member.Weight / (member.Height * member.Height);
                member.BMI = Math.Floor(bmi * 100) / 100;
                return member.BMI;
            }
        }
        return 0;
    }

    public int CalculateYogaFee(int memberId) {
        foreach (MeditationCenter member in memberList) {
            if (member.MemberId == memberId) {
                double bmi = member.BMI;
                if (member.Goal == ""Weight Loss"") {
                    if (bmi >= 35) return 3000;
                    if (bmi >= 30) return 2500;
                    if (bmi >= 25) return 2000;
                }
                if (member.Goal == ""Weight Gain"") {
                    return 2500;
                }
            }
        }
        return 0;
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 5,
        Question = "5. Ecommerce Application: Create a payment method that throws an exception when the wallet balance is insufficient.",
        Explanation = "Uses a custom exception to enforce wallet balance validation.",
        MaxTime = "12 minutes",
        Answer = @"using System;

class EcommerceShop {
    public string UserName { get; set; }
    public double WalletBalance { get; set; }
    public double TotalPurchaseAmount { get; set; }
}

class InsufficientWalletBalanceException : Exception {
    public InsufficientWalletBalanceException(string message) : base(message) { }
}

class Program {
    public EcommerceShop MakePayment(string name, double balance, double amount) {
        if (balance < amount) {
            throw new InsufficientWalletBalanceException(""Insufficient balance in your digital wallet"");
        }

        return new EcommerceShop {
            UserName = name,
            WalletBalance = balance,
            TotalPurchaseAmount = amount
        };
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 6,
        Question = "6. User Authentication: Validate passwords and throw a mismatch exception when they differ.",
        Explanation = "Creates a User model and validates the password confirmation with a custom exception.",
        MaxTime = "12 minutes",
        Answer = @"using System;

class User {
    public string Name { get; set; }
    public string Password { get; set; }
    public string ConfirmationPassword { get; set; }
}

class PasswordMismatchException : Exception {
    public PasswordMismatchException(string message) : base(message) { }
}

class Program {
    public User ValidatePassword(string name, string password, string confirmationPassword) {
        if (!string.Equals(password, confirmationPassword, StringComparison.Ordinal)) {
            throw new PasswordMismatchException(""Password entered does not match"");
        }

        return new User {
            Name = name,
            Password = password,
            ConfirmationPassword = confirmationPassword
        };
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 7,
        Question = "7. Construction Estimate: Validate construction area and throw an exception when it exceeds site area.",
        Explanation = "Returns EstimateDetails when valid, otherwise throws a ConstructionEstimateException.",
        MaxTime = "10 minutes",
        Answer = @"using System;

class EstimateDetails {
    public float ConstructionArea { get; set; }
    public float SiteArea { get; set; }
}

class ConstructionEstimateException : Exception {
    public ConstructionEstimateException(string message) : base(message) { }
}

class Program {
    public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea) {
        if (constructionArea > siteArea) {
            throw new ConstructionEstimateException(""Sorry your Construction Estimate is not approved"");
        }

        return new EstimateDetails {
            ConstructionArea = constructionArea,
            SiteArea = siteArea
        };
    }
}" ,
        ShowAnswer = false
    },
    new QuestionModel {
        Id = 8,
        Question = "8. User Verification: Validate phone number length and throw an exception on invalid input.",
        Explanation = "Ensures the phone number length is 10 before returning the User object.",
        MaxTime = "8 minutes",
        Answer = @"using System;

class User {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

class InvalidPhoneNumberException : Exception {
    public InvalidPhoneNumberException(string message) : base(message) { }
}

class Program {
    public User ValidatePhoneNumber(string name, string phoneNumber) {
        if (phoneNumber?.Length != 10) {
            throw new InvalidPhoneNumberException(""Invalid phone number"");
        }

        return new User {
            Name = name,
            PhoneNumber = phoneNumber
        };
    }
}" ,
        ShowAnswer = false
    }
}
    }
            };


        public IActionResult InheritancePracticeQues()
        {
            return LoadPracticePage("InheritancePracticeQues");
        }

        public IActionResult CSharpBasics()
        {
            return LoadPracticePage("CSharpBasics");
        }

        public IActionResult CSharpAdvancedQues()
        {
            return LoadPracticePage("CSharpAdvancedQues");
        }

        public IActionResult CSharpPolymorphism()
        {
            return LoadPracticePage("CSharpPolymorphism");
        }

        public IActionResult CSharpAsynchronousQues()
        {
            return LoadPracticePage("CSharpAsynchronousQues");
        }

        public IActionResult ProgrammingQuestions()
        {
            return LoadPracticePage("ProgrammingQuestions");
        }

        public IActionResult CSharpStringToNumberQuestions()
        {
            return LoadProgramQuestionsPage("CSharpStringToNumberQuestions");
        }

        public IActionResult CSharpStringToNumberAnswers()
        {
            return LoadProgramQuestionsPage("CSharpStringToNumberAnswers");
        }

        public IActionResult CSharpChar52Questions()
        {
            return LoadProgramQuestionsPage("CSharpChar52Questions");
        }

        public IActionResult CSharpStringBuilder36Questions()
        {
            return LoadProgramQuestionsPage("CSharpStringBuilder36Questions");
        }

        public IActionResult CSharpString64Questions()
        {
            return LoadProgramQuestionsPage("CSharpString64Questions");
        }

        public IActionResult CSharpStringCharStringBuilder25Questions()
        {
            return LoadProgramQuestionsPage("CSharpStringCharStringBuilder25Questions");
        }

        public IActionResult CSharpDictionaryM1Mock20Questions()
        {
            return LoadProgramQuestionsPage("CSharpDictionaryM1Mock20Questions");
        }

        private IActionResult LoadPracticePage(string pageName)
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = pageName;
            ViewBag.Questions = _questionSets.ContainsKey(pageName) ? _questionSets[pageName] : new List<QuestionModel>();
            return View(pageName);
        }

        private IActionResult LoadProgramQuestionsPage(string pageName)
        {
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = pageName;
            return View(pageName);
        }

        [HttpPost]
        public IActionResult ToggleAnswer(string pageName, string questionsJson, int questionId)
        {
            // Ensure questionsJson is not null before deserializing
            if (string.IsNullOrEmpty(questionsJson))
            {
                return BadRequest("Invalid data received.");
            }

            // Deserialize the questions from the form input
            string decodedJson = HttpUtility.HtmlDecode(questionsJson);
            var questions = JsonConvert.DeserializeObject<List<QuestionModel>>(decodedJson);

            // Ensure questions list is not null before proceeding
            if (questions == null)
            {
                return BadRequest("Failed to deserialize questions.");
            }

            // Find and toggle the selected question
            var question = questions.FirstOrDefault(q => q.Id == questionId);
            if (question != null)
            {
                question.ShowAnswer = !question.ShowAnswer;
            }

            // Store the updated questions back in ViewBag
            ViewData["ActiveMenu"] = "PracticeQuestions";
            ViewData["ActivePage"] = pageName;
            ViewBag.Questions = questions;  // Assign the modified list back to ViewBag

            return View(pageName);
        }




    }


    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Explanation { get; set; }
        public string MaxTime { get; set; }
        public string Answer { get; set; }
        public bool ShowAnswer { get; set; }
    }
}
