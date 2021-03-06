﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tests.Models.BLL
{
    public static class DAL
    {
        
        public static List<IncomeInfo> GetIncomeOptions()
                {
                     var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/IncomeOptions.xml");
                            IEnumerable<IncomeInfo> incomeTypes = XDocument.Load(path).Element("IncomeTypes")
                                                .Descendants("IncomeType")
                                                .Select(x => new IncomeInfo
                                                {
                                                    IncomeTitle = x.Element("Name").Value,
                                                    IncomeType = x.Element("Type").Value

                                                });
            return incomeTypes.ToList();
            }
        public static List<Student> GetAllStudents()
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/TestData.xml");
            IEnumerable<Student> students = XDocument.Load(path).Element("Students")
                      .Descendants("Student")
                      .Select(x => new Student
                      {
                          StudentName = x.Element("Name").Value,
                          StudentRoll = x.Element("RollNo").Value

                      });

            return students.ToList();
        }

        public static bool SaveStudent(Student s)
        {
            
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/TestData.xml");
            try
            {
                XDocument xDoc = XDocument.Load(path);

                xDoc.Element("Students").Add(new XElement("Student",
                    new XElement("Name", s.StudentName), 
                    new XElement("RollNo", s.StudentRoll)));
                          
                xDoc.Save(path);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public static bool SaveTask(ToDo t)
        {

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/ToDo.xml");
            try
            {
                XDocument xDoc = XDocument.Load(path);

                xDoc.Element("Tasks").Add(new XElement("Task",
                    new XElement("TaskDescription", t.TaskDescription),
                    new XElement("TaskNumber", t.TaskNumber)));

                xDoc.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static List<ToDo> GetAllTasks()
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/ToDo.xml");
            IEnumerable<ToDo> Tasks = XDocument.Load(path).Element("Tasks")
                      .Descendants("Task")
                      .Select(x => new ToDo
                      {
                          TaskDescription = x.Element("TaskDescription").Value,
                          TaskNumber = x.Element("TaskNumber").Value

                      });

            return Tasks.ToList();
        }
        public static bool SaveListOfStudents(IEnumerable<Student> sList)
        {

            var path = System.Web.HttpContext.Current.Server.MapPath("~/Resources/TestData.xml");

            try
            {
                XDocument xDoc = XDocument.Load(path);
                foreach (Student s in sList)
                {

                    xDoc.Element("Students").Add(new XElement("Student",
                        new XElement("Name", s.StudentName),
                        new XElement("RollNo", s.StudentRoll)));

                    xDoc.Save(path);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}