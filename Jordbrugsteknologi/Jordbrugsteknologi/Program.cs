using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jordbrugsteknologi
{
    class Program
    {
        Mongo mongo = new Mongo();
        Field resultField;
        Row resultRow;
        Stopwatch timer;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }
        public void Run()
        {
            timer = new Stopwatch();

            //Make the field
            Field field = new Field("Marken2", 2017);

            //Make the different types of weed
            Weed Crabgrass = new Weed(field.Name, "Crabgrass");
            Weed Quackgrass = new Weed(field.Name, "Quackgrass");
            Weed MoringGlory = new Weed(field.Name, "Moring Glory");
            Weed Pigweed = new Weed(field.Name, "Pigweed");

            //Make the different types of herbicide
            Herbicide Simazine = new Herbicide(field.Name, 5.25, "Simazine");
            Herbicide Terbuthylazine = new Herbicide(field.Name, 42, "Terbuthylazine");
            Herbicide Versatil = new Herbicide(field.Name, 2.55, "Versatil");

            //Make the different types of crop
            Crop Wheat = new Crop(field.Name, "Wheat");

            //Make the number of rows in the field
            Row row1 = new Row(field.Name, 1, Crabgrass, Wheat, Simazine);
            Row row2 = new Row(field.Name, 2, Crabgrass, Wheat, Terbuthylazine);
            Row row3 = new Row(field.Name, 3, Crabgrass, Wheat, Versatil);
            Row row4 = new Row(field.Name, 4, Quackgrass, Wheat, Simazine);
            Row row5 = new Row(field.Name, 5, Quackgrass, Wheat, Terbuthylazine);
            Row row6 = new Row(field.Name, 6, Quackgrass, Wheat, Versatil);
            Row row7 = new Row(field.Name, 7, MoringGlory, Wheat, Simazine);
            Row row8 = new Row(field.Name, 8, MoringGlory, Wheat, Terbuthylazine);
            Row row9 = new Row(field.Name, 9, MoringGlory, Wheat, Versatil);
            Row row10 = new Row(field.Name, 10, Pigweed, Wheat, Simazine);
            Row row11 = new Row(field.Name, 11, Pigweed, Wheat, Terbuthylazine);
            Row row12 = new Row(field.Name, 12, Pigweed, Wheat, Versatil);

            //Add all the rows to the list in the field
            field.rows.Add(row1);
            field.rows.Add(row2);
            field.rows.Add(row3);
            field.rows.Add(row4);
            field.rows.Add(row5);
            field.rows.Add(row6);
            field.rows.Add(row7);
            field.rows.Add(row8);
            field.rows.Add(row9);
            field.rows.Add(row10);
            field.rows.Add(row11);
            field.rows.Add(row12);

            timer.Start();
            //mongo.CreateCompleteField(field);

            //Row row13 = new Row(field.Name, 13, Quackgrass, Wheat, Versatil);
            //mongo.CreateRowInField(row13, field.Name);

            //resultRow = mongo.ReadRowInField(row5.Number, field.Name);

            //resultField = mongo.ReadCompleteField(field.Name);

            //Console.ReadKey();

            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            Console.ReadKey();
        }
    }
}
