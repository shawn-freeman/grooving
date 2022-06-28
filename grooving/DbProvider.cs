using System;
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

                    sr.Write($"\r{newEmployeeRecord.Id},{newEmployeeRecord.Name},{newEmployeeRecord.JobTitle}");
                }
            }            
        }

        public void Update(int id, string name, string title)
        {
            var lines = File.ReadLines(_dbFile).ToList();

            var lineToModify = lines.Skip(1).FirstOrDefault(l => {
                var lineId = Convert.ToInt32(l.Split(',')[0]);
                return lineId == id;
            });

            using (FileStream fs = File.Create(_dbFile))
            {
                using (var sr = new StreamWriter(fs))
                {
                    sr.Write(lines[0]);
                    foreach (var line in lines.Skip(1))
                    {
                        var lineValList = line.Split(',');

                        var employee = new Employee()
                        {
                            Id = Convert.ToInt32(lineValList[0]),
                            Name = lineValList[1],
                            JobTitle = lineValList[2]
                        };

                        if(employee.Id == id)
                        {
                            employee.Name = name;
                            employee.JobTitle = title;
                        }
                        sr.Write($"\r{employee.Id},{employee.Name},{employee.JobTitle}");
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var lines = File.ReadLines(_dbFile).ToList();

            var newLines = lines.Skip(1).Where(l => {
                var lineId = Convert.ToInt32(l.Split(',').FirstOrDefault());
                if (lineId != id) return true;
                return false;
            }).ToList();

            using (FileStream fs = File.Create(_dbFile))
            {
                using (var sr = new StreamWriter(fs))
                {
                    sr.Write(lines[0]);
                    foreach (var line in newLines)
                    {
                        sr.Write($"\r{line}");
                    }
                }
            }
        }
    }
}
