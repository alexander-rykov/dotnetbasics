// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {

        private DataSource dataSource = new DataSource();

        [Category("Restriction Operators")]
        [Title("Where - Task 1")]
        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        public void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
              from num in numbers
              where num < 5
              select num;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 2")]
        [Description("This sample return return all presented in market products")]
        public void Linq2()
        {
            var products =
              from p in dataSource.Products
              where p.UnitsInStock > 0
              select p;

            this.WriteResult(products);
        }

        [Category("Restriction Operators")]
        [Title("Task Linq001")]
        [Description(
          "This sample return a list of all customers whose total turnover (sum of all orders) exceeds a certain value")]
        public void Linq001()
        {
            const decimal x = 10000;

            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq002A")]
        [Description(
          "This sample return a list of suppliers who are in the same country and the same city for each client")]
        public void Linq002A()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq002B")]
        [Description(
          "This sample return a list of suppliers who are in the same country and the same city for each client")]
        public void Linq002B()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq003")]
        [Description(
          "This sample return a list of customers who have orders that total value exceeds value X")]
        public void Linq003()
        {
            const decimal x = 5000;

            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq004")]
        [Description(
          "This sample return a list of customer list indicating the beginning of a month of the year they became clients")]
        public void Linq004()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq005")]
        [Description(
          "This sample return a list of customer list indicating the beginning of a month of the year they became clients sorted by year, month, turnover")]
        public void Linq005()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq006")]
        [Description(
          "The customers who have specified a non-digital code or full region or in the phone area code Unknown")]
        public void Linq006()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq007")]
        [Description(
          "Group all products by category, in - on the availability of stock within the last group of sort by cost")]
        public void Linq007()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq008")]
        [Description(
          "Group the items by groups of \"cheap\", \"average price\", \"expensive\"")]
        public void Linq008()
        {
            var firstVal = 40M;
            var secondVal = 100M;

            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq009")]
        [Description(
          "Calculate the average profitability of each city")]
        public void Linq009()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq010")]
        [Description(
          "Make an annual average customer activity by month, by year statistics for the years and months")]
        public void Linq010()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq010")]
        [Description(
          "Make an annual average customer activity by month, by year statistics for the years and months")]
        public void Linq010B()
        {
            // TODO make LINQ query here
        }

        [Category("Restriction Operators")]
        [Title("Task Linq010")]
        [Description(
          "Make an annual average customer activity by month, by year statistics for the years and months")]
        public void Linq010C()
        {
            // TODO make LINQ query here
        }


        private void WriteResult(IEnumerable objects)
        {
            foreach (var p in objects)
            {
                ObjectDumper.Write(p);
            }
        }
    }
}
