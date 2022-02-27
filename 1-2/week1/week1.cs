using System;
using System.Collections.Generic;
using System.Globalization;


namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("No: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Birth Date (dd/mm/YYYY): ");
            string date = Console.ReadLine();
            Console.Write("Lessons count: ");
            int lessonsCount = Convert.ToInt32(Console.ReadLine());
            while (lessonsCount < 9){
            Console.Write("Lessons count: ");
            lessonsCount = Convert.ToInt32(Console.ReadLine());
            }
            
            List<Lesson> lessons = new List<Lesson>();
            int lastDigit = (no % 10);
            double midtermRate;
            if (name.Length > surname.Length)
            {
                midtermRate = 0.3;
            }
            else if (name.Length < surname.Length)
            {
                midtermRate = 0.6;
            }
            else
            {
                if (lastDigit % 2 == 0)
                {
                    midtermRate = 0.35;
                }
                else
                {
                    midtermRate = 0.25;
                }
            }
            double finalRate = 1.0 - midtermRate;

            for (int i = 0; i < lessonsCount; i++) 
            {
                Console.Write($"{i+1}. Lesson Title: ");
                string lessonTitle = Console.ReadLine();
                Console.Write($"{i+1}. Lesson Midterm: ");
                int lessonMidterm = Convert.ToInt32(Console.ReadLine());
                Console.Write($"{i+1}. Lesson Final: ");
                int lessonFinal = Convert.ToInt32(Console.ReadLine());
                int lessonAverage = Convert.ToInt32(lessonMidterm * midtermRate + lessonFinal * finalRate);
                lessons.Add(new Lesson {title = lessonTitle, midterm = lessonMidterm, final = lessonFinal, average = lessonAverage});

            }
            

            DateTime birthday = DateTime.ParseExact(date, "dd/MM/yyyy", new CultureInfo("tr-TR"));
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (today.Month < birthday.Month || (today.Month == birthday.Month && today.Day < birthday.Day)) age--;

            Console.WriteLine($"Dear {name} {surname}, you are {age} years old.");
            foreach(Lesson lesson in lessons)
            {
                Console.WriteLine($"Lesson Title: {lesson.title}, Midterm Grade: {lesson.midterm}, Final Grade: {lesson.final}, Average Grade: {lesson.average} ");
            }

        }

        internal class Lesson
        {
        public string title { get; set; }
        public int midterm { get; set; }
        public int final { get; set; }
        public int average { get; set; }
        }
}
}
