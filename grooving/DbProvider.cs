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

        public void Output()
        {
            Console.WriteLine();
            using (FileStream fs = File.OpenRead(_dbFile))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine();
        }

        public void Insert()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
