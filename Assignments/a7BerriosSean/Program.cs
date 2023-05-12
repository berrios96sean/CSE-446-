using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Course
{
    public string Subject { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string CourseId { get; set; }
    public string Location { get; set; }
    public string Instructor { get; set; }

    public Course(string subject, string code, string title, string courseId, string location, string instructor)
    {
        Subject = subject;
        Code = code;
        Title = title;
        CourseId = courseId;
        Location = location;
        Instructor = instructor;
    }
}

class Instructor
{
    public string Name { get; set; }
    public string Office { get; set; }
    public string Email { get; set; }


    public Instructor(string name, string office, string email)
    {
        Name = name;
        Office = office;
        Email = email;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "..\\..\\Courses.csv";
        string[] lines = File.ReadAllLines(filePath);

        string filePath2 = "..\\..\\Instructors.csv";
        string[] lines2 = File.ReadAllLines(filePath2);

        Course[] courses = new Course[lines.Length - 1];
        Instructor[] instructors = new Instructor[lines2.Length - 1];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');

            string subject = fields[0].Trim();
            string code = fields[1].Trim();
            string title = fields[2].Trim();
            string courseId = fields[3].Trim();
            string instructor = fields[4].Trim();
            string location = fields[7].Trim();

            courses[i - 1] = new Course(subject, code, title, courseId, location, instructor);
        }

        for (int i = 1; i < lines2.Length; i++)
        {
            string[] fields = lines2[i].Split(',');

            string name = fields[0].Trim();
            string office = fields[1].Trim();
            string email = fields[2].Trim();

            instructors[i - 1] = new Instructor(name,office,email);
        }

        Console.WriteLine("**********************************************");
        Console.WriteLine("Please Select operation to perform: ");
        Console.WriteLine("1: 1.2.a List IEE 300+ Courses ");
        Console.WriteLine("2: 1.2.b Deliver Courses in Groups and Subgroups ");
        Console.WriteLine("3: 1.5   Get emails for Instructors for all 200 Level Courses ");
        Console.WriteLine("4: 2.1.a Retrieve list of CPI courses level 200 or higher ");
        Console.WriteLine("5: 2.1.b Deliver courses in groups at two levels ");
        Console.WriteLine("Q: To Exit ");
        String input = Console.ReadLine();
        while (true)
        {
            if (input == "q" || input == "Q")
            {
                Console.WriteLine("Exiting Application....");
                break; 
            }

            if (input == 1.ToString())
            {
                Console.WriteLine("Printing IEE 300+ Courses");
                Console.WriteLine("**********************************************");
                IEnumerable<Course> myQuery =
                    from c in courses
                    where (c.Subject == "IEE" && int.Parse(c.Code) >= 300)
                    orderby c.Title
                    select c;

                foreach (Course item in myQuery)
                {
                    Console.WriteLine("Title = {0}, Instructor = {1}", item.Title, item.Instructor);
                }
            }

            if (input == 2.ToString())
            {
                var groupedCourses = courses.GroupBy(c => c.Subject)
                                            .Select(g => new
                                            {
                                                Subject = g.Key,
                                                Courses = g.GroupBy(c => c.Code)
                                                           .Where(g2 => g2.Count() >= 2)
                                                           .Select(g2 => new
                                                           {
                                                               Code = g2.Key,
                                                               Courses = g2.Select(c => new { Title = c.Title, Instructor = c.Instructor })
                                                                          .ToList()
                                                           })
                                                           .ToList()
                                            })
                                            .ToList();

                foreach (var group in groupedCourses)
                {
                    Console.WriteLine($"Subject: {group.Subject}");
                    foreach (var subgroup in group.Courses)
                    {
                        Console.WriteLine($"    Code: {subgroup.Code}");
                        foreach (var course in subgroup.Courses)
                        {
                            Console.WriteLine($"        Course Title: {course.Title}, Instructor: {course.Instructor}");
                        }
                    }
                }


            }

            if (input == 3.ToString())
            {
                var result = from c in courses
                             join i in instructors on c.Instructor equals i.Name into ci
                             from x in ci.DefaultIfEmpty()
                             where int.Parse(c.Code) >= 200 && int.Parse(c.Code) < 300
                             orderby c.Code
                             select new { Subject = $"{c.Subject} {c.Code}", Email = x?.Email ?? "" };

                foreach (var item in result)
                {
                    Console.WriteLine($"Subject: {item.Subject}, Instructor Email: {item.Email}");
                }

            }

            if (input == 4.ToString())
            {
                var cpiCourses =
                    from c in courses
                    join i in instructors on c.Instructor equals i.Name
                    where c.Subject == "CPI" && int.Parse(c.Code) >= 200
                    orderby i.Name
                    select new XElement("Course",
                        new XElement("Title", c.Title),
                        new XElement("Instructor", i.Name)
                    );

                foreach (var course in cpiCourses)
                {
                    Console.WriteLine(course);
                }

            }

            if (input == 5.ToString())
            {
                var groupedCourses = courses.GroupBy(c => c.Subject)
                                            .Select(g => new
                                            {
                                                Subject = g.Key,
                                                Courses = g.GroupBy(c => c.Code)
                                                           .Where(g2 => g2.Count() >= 2)
                                                           .Select(g2 => new
                                                           {
                                                               Code = g2.Key,
                                                               Courses = g2.Select(c => new { Title = c.Title, Instructor = c.Instructor })
                                                                          .ToList()
                                                           })
                                                           .ToList()
                                            })
                                            .ToList();

                foreach (var group in groupedCourses)
                {
                    Console.WriteLine($"Subject: {group.Subject}");
                    foreach (var subgroup in group.Courses)
                    {
                        Console.WriteLine($"    Code: {subgroup.Code}");
                        foreach (var course in subgroup.Courses)
                        {
                            Console.WriteLine($"        Course Title: {course.Title}, Instructor: {course.Instructor}");
                        }
                    }
                }
            }


            if (input == 6.ToString())
            {

            }

            Console.WriteLine("**********************************************");
            Console.WriteLine("Please Select operation to perform: ");
            Console.WriteLine("1: List IEE 300+ Courses ");
            Console.WriteLine("2: Deliver Courses in Groups and Subgroups ");
            Console.WriteLine("3: Get emails for Instructors for all 200 Level Courses ");
            Console.WriteLine("4: 2.1.a Retrieve list of CPI courses level 200 or higher ");
            Console.WriteLine("5: 2.1.b Deliver courses in groups at two levels ");
            Console.WriteLine("Q: To Exit ");
            input = Console.ReadLine();
        }


    }
}
