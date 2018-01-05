using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MongoDB.Driver;

namespace MongoDB_ReadTest
{
    class Tests
    {
        Stopwatch stopwatch = new Stopwatch();

        public string ReadAllTest(IMongoCollection<Measurement> collection)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
            stopwatch.Reset();
            stopwatch.Start();

            var filt = Builders<Measurement>.Filter.Where(m => m.speed != null);
            long amountFound = collection.Find(filt).Count();

            stopwatch.Stop();

            return "ReadAll found: " + amountFound + "\n" + "In: " + stopwatch.Elapsed.ToString();
        }
        public string ReadAllIndexedTest(IMongoCollection<Measurement> collection)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
            stopwatch.Reset();
            stopwatch.Start();

            var filt = Builders<Measurement>.Filter.Where(m => m.speed != null);
            long amountFound = collection.Find(filt).Count();

            stopwatch.Stop();

            return "\n" + "ReadAllIndexed found: " + amountFound + "\n" + "In: " + stopwatch.Elapsed.ToString();
        }
        public string ReadPartTest(DateTime from, DateTime to, IMongoCollection<Measurement> collection)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
            stopwatch.Reset();
            stopwatch.Start();

            var filt = Builders<Measurement>.Filter.Where(m => m.dateTime > from.ToUniversalTime()
            && m.dateTime < to.ToUniversalTime());
            long amountFound = collection.Find(filt).Count();

            stopwatch.Stop();

            return "ReadPart found: " + amountFound + "\n" + "In: " + stopwatch.Elapsed.ToString();
        }
        public string ReadPartIndexedTest(DateTime from, DateTime to, IMongoCollection<Measurement> collection)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
            stopwatch.Reset();
            stopwatch.Start();

            var filt = Builders<Measurement>.Filter.Where(m => m.dateTime > from.ToUniversalTime() && m.dateTime < to.ToUniversalTime());
            long amountFound = collection.Find(filt).Count();

            stopwatch.Stop();

            return "ReadPartIndexed found: " + amountFound + "\n" + "In: " + stopwatch.Elapsed.ToString();
        }
    }
}
