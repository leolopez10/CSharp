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

            // Graphics objects
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            int FONT_SIZE = 32;
            Font font = new Font("Arial", FONT_SIZE);
            Font monoFont = new Font("Courier New", FONT_SIZE);

            SolidBrush brush = new SolidBrush(Color.Black);

            // Create Photo for badge
            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoUrl()));

                    Image background = Image.FromFile("badge.png");
                    Image badge = new Bitmap(BADGE_HEIGHT, BADGE_HEIGHT);

                    Graphics graphic = Graphics.FromImage(badge);
                    graphic.DrawImage(background, new Rectangle(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                    graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));
                    graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));


                    // Company Name
                    graphic.DrawString(
                        employees[i].GetCompanyName(),
                        font,
                        new SolidBrush(Color.White),
                        new Rectangle(
                            COMPANY_NAME_START_X,
                            COMPANY_NAME_START_Y,
                            BADGE_WIDTH,
                            COMPANY_NAME_WIDTH
                        ),
                        format
                        );

                    // Employee Name
                    graphic.DrawString(
                        employees[i].GetFullName(),
                        font,
                        brush,
                        new Rectangle(
                            EMPLOYEE_NAME_START_X,
                            EMPLOYEE_NAME_START_Y,
                            BADGE_WIDTH,
                            EMPLOYEE_NAME_HEIGHT
                        ),
                        format
                        );

                    // Employee ID
                    graphic.DrawString(
                        employees[i].GetId().ToString(),
                        monoFont,
                        brush,
                        new Rectangle(
                            EMPLOYEE_ID_START_X,
                            EMPLOYEE_ID_START_Y,
                            EMPLOYEE_ID_WIDTH,
                            EMPLOYEE_ID_HEIGHT
                        ),
                        format
                        );

                    // photo.Save("data/employeeBadge.png");
                    // badge.Save($"data/employeeBadge.png");
                    string fileName = $"data/{employees[i].GetId()}_Badge.png";
                    badge.Save(fileName);


                }
            }
        }
    }
}