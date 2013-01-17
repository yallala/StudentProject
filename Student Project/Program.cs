using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Project info: Find the student exam verdict (pass/fail) and print the status, grade and total marks when failed.

//Student is the class name
namespace Student_Project
{
    class Student
    {
        static void Main()
        {
            int studentId, numberOfStudents, numberOfSubjects;        // Integer variable Declaration
            string studentName;     //string  variable Declaration
            var studentMarks = new List<int>();  // Array Declaration with size 6

            Student st = new Student();   // Object creation

            //Getting the input from the user about number of students info and storing into integer.
            numberOfStudents = MakeMyPromptIntoAnInteger("How many students information you want?");

            //Looping through and getting the students info such as ID for all the studens
            for (int i = 0; i < numberOfStudents; i++)         // FOR loop
            {
                Console.WriteLine("---------Enter the student {0} information----------", i + 1);

                studentId = MakeMyPromptIntoAnInteger("Enter Student Id:");
                                
                Console.WriteLine("Enter Student Name:");
                studentName = Console.ReadLine();

                numberOfSubjects = 6;

                Console.WriteLine("Enter 6 subject marks for {0}...", studentName);

                //While loop to find out the marks entered by the user is less than 100
                while (studentMarks.Count < numberOfSubjects)// While loop
                {
                    Console.WriteLine("Subject {0}...", studentMarks.Count + 1);
                    studentMarks.Add(MakeMyMarksValid());
                }
                //We have marks, now we are finding whether student passed or failed....                      
                string r1;

                r1 = st.result(studentMarks[0], studentMarks[1], studentMarks[2], studentMarks[3], studentMarks[4], studentMarks[5]); // Method Calling
                if (r1 == "PASS")
                {
                    Console.WriteLine("{0} Passed", studentName);

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
                    Console.WriteLine("{0} Failed", studentName);
                    //Since user failed printing the total for their info
                    //Finding the total of all the marks entered by the user. 

                    int tot = 0;

                    foreach (int n in studentMarks)  // for each loop
                    {
                        tot += n;       // Assignmeent operator
                    }
                    Console.WriteLine("Total Marks: {0} ", tot);

                }

                // Clear out the list of student marks
                studentMarks.Clear();
            }

            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }

        static int MakeMyPromptIntoAnInteger(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            int output;

            // If user enters a string accidentally , it won't break if we use TryParse.
            while (!Int32.TryParse(input, out output))
            {
                Console.WriteLine("Invalid input, want to try an integer instead? Try again!");
                input = Console.ReadLine();
            }

            return output;
        }

        static int MakeMyMarksValid()
        {
            int validMark;

            validMark = MakeMyPromptIntoAnInteger("Enter Mark:");
            while (validMark > 100)
            {
                Console.WriteLine("Student marks must be less than 100");
                validMark = MakeMyPromptIntoAnInteger("Enter Mark:");
            }

            return validMark;
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
