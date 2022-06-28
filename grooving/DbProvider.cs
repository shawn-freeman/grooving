﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grooving
{
    public class DbProvider
    {
        private string _dbFile;
        public DbProvider(string dbFile)
        {
            _dbFile = dbFile;
        }

        public List<Employee> GetEmployeeRecords()
        {
            var employees = new List<Employee>();
            using (FileStream fs = File.OpenRead(_dbFile))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        var employee = new Employee();
                        employee.Id = Convert.ToInt32(values[0]);
                        employee.Name = values[1];
                        employee.JobTitle = values[2];

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public void Insert(string name, string title)
        {
            var lastLine = File.ReadLines(_dbFile).LastOrDefault().Split(',');

            using (FileStream fs = File.OpenWrite(_dbFile))
            {
                fs.Seek(0, SeekOrigin.End);
                using (var sr = new StreamWriter(fs))
                {
                    var newEmployeeRecord = new Employee()
                    {
                        Id = Convert.ToInt32(lastLine[0]) + 1,
                        Name = name,
                        JobTitle = title
                    };

                    sr.WriteLine($"\r{newEmployeeRecord.Id},{newEmployeeRecord.Name},{newEmployeeRecord.JobTitle}");

                    Console.WriteLine("done");
                }
            }            
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
