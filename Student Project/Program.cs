using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Project info: Find the student exam verdict (pass/fail) and print the status, grade and total marks when failed.

//Student is the class name
namespace Student_Project
{
    // This is Sudheer's class!
    class Student
    {
        static void Main()
        {
            int studentId, numberOfStudents, numberOfSubjects;        // Integer variable Declaration
            string studentName;     //string  variable Declaration
            var studentMarks = new List<int>();  // Array Declaration with size 6

            //Getting the input from the user about number of students info and storing into integer "a".
            Console.WriteLine("How many students information you want?");
            numberOfStudents = int.Parse(Console.ReadLine());    // Integer Conversion

            //Looping through and getting the students info such as ID for all the studens
            for (int i = 0; i < numberOfStudents; i++)         // FOR loop
            {
                Console.WriteLine("---------Enter the student {0} information----------", i + 1);

                Console.WriteLine("Enter Student id:");
                string input_id = Console.ReadLine();

                // If user enters string accidentally , it won't break if we use TryParse.
                while (!Int32.TryParse(input_id, out studentId))
                {
                    Console.WriteLine("Invalid student id-- please input an integer number.");
                    input_id = Console.ReadLine();
                }

                Console.WriteLine("Enter Student Name:");
                studentName = Console.ReadLine();

                Console.WriteLine("Enter Student 6 subjects Marks:");


                int numberOfSubjects = 0;

                //While loop to find out the marks entered by the user is less than 100
                while (numberOfSubjects < studentMarks.Count)// While loop
                {
                    Console.WriteLine("Subject{0} :", numberOfSubjects + 1);
                    studentMarks[numberOfSubjects] = int.Parse(Console.ReadLine());
                    //If user enters more than 100 then reprompt the user to enter less than 100
                    if (studentMarks[numberOfSubjects] > 100)// If Statement
                    {
                        Console.WriteLine(" marks should be less then 100..... Enter again");
                        studentMarks[numberOfSubjects] = int.Parse(Console.ReadLine());
                    }
                    numberOfSubjects++; //post increment operator
                }
                //We have marks, now we are finding whether student passed or failed....            
                // Creating a object ("st") and calling the method with that object.             
                string r1;
                Student st = new Student();   // Object creation
                r1 = st.result(studentMarks[0], studentMarks[1], studentMarks[2], studentMarks[3], studentMarks[4], studentMarks[5]); // Method Calling
                if (r1 == "PASS")
                {
                    Console.WriteLine("Student Passed");

                    //finding the total and  percentage
                    int tot = 0;
                    float percentage;
                    string grade;
                    //total: 
                    foreach (int n in studentMarks)  // for each loop
                    {
                        tot += n;       // Assignmeent operator "tot = tot+n"
                    }
                    Console.WriteLine("Total Marks:  {0}", tot);

                    //percentage
                    percentage = tot / 6;  // Binary Operator
                    Console.WriteLine("Percentage: {0}", percentage);

                    //Multiple If Statements to assess the grade.

                    if (tot > 499 && tot <= 600)
                    {
                        grade = "A";

                    }

                    else if (tot > 399 && tot <= 499)
                    {
                        grade = "B";
                    }

                    else if (tot > 299 && tot <= 399)
                    {
                        grade = "C";
                    }

                    else if (tot > 199 && tot <= 299)
                    {
                        grade = "D";
                    }

                    else
                    {
                        grade = "E";
                    }
                    //Printing the grade here.
                    Console.WriteLine("Grade :   {0}", grade);

                    // Switch statement with string Type to PRINT the status.

                    switch (grade)
                    {

                        case "A":
                            Console.WriteLine("Status : Excellent");
                            break;
                        case "B":
                            Console.WriteLine("Status : Very Good");
                            break;
                        case "C":
                            Console.WriteLine("Status : Good");
                            break;
                        case "D":
                            Console.WriteLine("Status : Not Bad");
                            break;
                        case "E":
                            Console.WriteLine("Status : Bad");
                            break;
                    }

                }

                else
                {
                    Console.WriteLine("Student Failed");
                    //Since user failed printing the total for their info
                    //Finding the total of all the marks entered by the user. 

                    int tot = 0;

                    foreach (int n in studentMarks)  // for each loop
                    {
                        tot += n;       // Assignmeent operator
                    }
                    Console.WriteLine("Total Marks: {0} ", tot);

                }

            }

            Console.ReadLine();
        }

        int MakeMyPromptIntoAnInteger(string prompt)
        {

            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            int output;

            // If user enters string accidentally , it won't break if we use TryParse.
            while (!Int32.TryParse(input, out output))
            {
                Console.WriteLine("Invalid input, want to try an integer instead? Try again!");
                input = Console.ReadLine();
            }

            return output;

        }

        //Creating the method and returning the results 
        //student failes even if one subject has less than 35
        string result(int a, int b, int c, int d, int e, int f)    // method Definition
        {
            string res;

            if (a >= 35 && b >= 35 && c >= 35 && d >= 35 && e >= 35 && f >= 35)    // If....else statement
            {
                res = "PASS";
            }
            else
            {
                res = "FAIL";
            }
            return res;
        }

    }
}