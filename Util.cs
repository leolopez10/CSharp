using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Collections.Generic;

namespace Catworx.BadgeMaker
{
    class Util
    {
        // add List parameter to method
        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }

        public static void MakeCSV(List<Employee> employees)
        {
            // In the method, check to see if a data folder exists, and if not, create it.
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            // Create a new file located at data/employees.csv.
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                // file.WriteLine("ID, Name, PhotoUrl");

                // Loop over employees
                for (int i = 0; i < employees.Count; i++)
                {
                    string template = "Employee ID: {0}\nName: {1}\nPhoto: {2}";

                    // Write each employee’s info as a comma-separated string to the CSV file.
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }

        public static void MakeBadges(List<Employee> employees)
        {
            // Layout Variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            int COMPANY_NAME_START_X = 0;
            int COMPANY_NAME_START_Y = 110;
            int COMPANY_NAME_WIDTH = 100;

            int PHOTO_START_X = 184;
            int PHOTO_START_Y = 215;
            int PHOTO_WIDTH = 302;
            int PHOTO_HEIGHT = 302;

            int EMPLOYEE_NAME_START_X = 0;
            int EMPLOYEE_NAME_START_Y = 560;
            int EMPLOYEE_NAME_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_NAME_HEIGHT = 100;

            int EMPLOYEE_ID_START_X = 0;
            int EMPLOYEE_ID_START_Y = 690;
            int EMPLOYEE_ID_WIDTH = BADGE_WIDTH;
            int EMPLOYEE_ID_HEIGHT = 100;

            // Create Image Test
            // Image newImage = Image.FromFile("badge.png");
            // newImage.Save("data/employeeBadge.png");

            // Create Photo for badge
            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoUrl()));

                    Image background = Image.FromFile("badge.png");
                    photo.Save("data/employeeBadge.png");
                }
            }
        }
    }
}