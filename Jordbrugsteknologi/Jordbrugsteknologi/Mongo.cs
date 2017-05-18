using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Jordbrugsteknologi
{
    class Mongo
    {
        MongoClient client;
        IMongoCollection<Field> collection;
        public Mongo()
        {
            MongoClient client = new MongoClient("mongodb://85.27.195.63:27017");
            IMongoDatabase database = client.GetDatabase("agriculture");

            try
            {
                collection = database.GetCollection<Field>("fields");
            }
            catch (Exception)
            {
                database.CreateCollection("fields");
                collection = database.GetCollection<Field>("fields");
            }
        }
        public void CreateCompleteField(Field Thisfield)
        {
            collection.InsertOne(Thisfield);
        }

        public void CreateRowInField(Row row, string field)
        {
            Field FoundField = ReadCompleteField(field);

            var filter = Builders<Field>.Filter.Eq("_id", field);
            var update = Builders<Field>.Update.AddToSet("rows", row);
            collection.UpdateOne(filter, update);
        }

        public Field ReadCompleteField(string FieldName)
        {
            var filter = Builders<Field>.Filter.Eq("_id", FieldName);
            return collection.Find(filter).FirstOrDefault();
        }

        public Row ReadRowInField(int RowNumber, string FieldName)
        {
            Field FoundField = ReadCompleteField(FieldName);
            Row Result = null;

            foreach (Row item in FoundField.rows)
            {
                if (item.Number == RowNumber)
                {
                    Result = item;
                    break;
                }
            }
            return Result;
        }
    }
}
