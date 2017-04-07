using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tests.Models.BLL
{
    public static class DAL
    {
        

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
            bool isSuccessful = false;
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
    }
}