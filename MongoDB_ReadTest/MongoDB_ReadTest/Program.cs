using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MongoDB_ReadTest
{
    class Program
    {
        Tests tests = new Tests();
        IMongoCollection<Measurement> MeasurementCollection;
        List<Measurement> measurements = new List<Measurement>();
        int insertAmount = 500000; //Set to determine the size of the test set.

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            Connect();
            //ReadFile();
            //Insert();
            Console.WriteLine(tests.ReadAllTest(MeasurementCollection));
            Console.WriteLine(tests.ReadPartTest(new DateTime(2017, 4, 30, 1, 00, 00), new DateTime(2017, 5, 12, 22, 45, 00), MeasurementCollection));
            Console.ReadKey();
            Console.WriteLine(tests.ReadAllIndexedTest(MeasurementCollection));
            Console.WriteLine(tests.ReadPartIndexedTest(new DateTime(2017, 4, 30, 1, 00, 00), new DateTime(2017, 5, 12, 22, 45, 00), MeasurementCollection));
            Console.ReadKey();
        }
        public void ReadFile()
        {
            
            var Lines = File.ReadLines(@"C:\Users\simgl\Desktop\Test Data\Rismarksvej km 4,203 [FMA].txt").Select(a => a.Split('\t'));

            int areaCode = 4205461; //Put the station areacode here!

            int counter = 0;
            foreach (var item in Lines)
            {
                if (counter != 0)
                {
                    measurements.Add(new Measurement(DateTime.Parse(item[0]), int.Parse(item[1]), int.Parse(item[2]), int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]), int.Parse(item[6]), int.Parse(item[7]), int.Parse(item[8]), areaCode)); //check efter x antal og hvis for stor skriv til db og clear liste, kunne være en læsning.
                }
                counter++;
                if (counter > insertAmount)
                {
                    break;
                }
            }
        }
        public void Insert()
        {
            int count = 0;
            foreach (var item in measurements)
            {
                count++;
                MeasurementCollection.InsertOne(item);
                Console.WriteLine(count);
            }
        }
        public void Connect() //Burde sættes som constructor i den classe det bruges i
        {
            string connectionString = "mongodb://localhost:27017";

            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("Trafik_DB"); // is made if not already there

            MeasurementCollection = database.GetCollection<Measurement>("Measurements"); // same as the database
        }


    }
}
