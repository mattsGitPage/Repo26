using DataHub.ReaderFactory.Models;
using DataHub.ReaderFactory.Readers;
using System;
using System.Linq;

namespace DataHub
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an absolute file path to read in an input file.");

            var filePath = Console.ReadLine();
            filePath = @"C:\Users\Matthew\source\repos\DataHub'\InputFile.txt";

            try
            {
                if (Validator.DoesFilePathExist(filePath))
                {
                    var reader = ReaderFactory.ReaderFactory.GetReader(ReaderFactory.Models.ReaderType.TextReader);
                    var result = reader.ReadFile(filePath);

                    Console.WriteLine("Sorted By Property Type:");
                    result.OrderBy(o => o.PropertyType).ToList().ForEach(i => Console.WriteLine(i.ToString()));
                    Console.WriteLine();

                    Console.WriteLine("Sorted By Start Date:");
                    result.OrderBy(o => o.StartDate).ToList().ForEach(i => Console.WriteLine(i.ToString()));
                    Console.WriteLine();

                    Console.WriteLine("Sorted By Last Name Descending:");
                    result.OrderByDescending(o => o.LastName).ToList().ForEach(i => Console.WriteLine(i.ToString()));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Not able to find the absolute file path provided.");
                }
            }
            catch(Exception e)
            {
                // Log exception.
                Console.Write("There was an issue processing your request.");
            }

            Console.WriteLine("Preparing to make API calls, press enter to continue.");
            Console.ReadLine();

            try
            {
                ProcessLocalNonExposedAPICalls(filePath);
            }
            catch(Exception e)
            {
                Console.Write("There was an issue processing your API request.");
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }


        private static void ProcessLocalNonExposedAPICalls(string filePath)
        {
            APIGeneric<LeadsModel> api = new APIGeneric<LeadsModel>();

            Console.WriteLine("Writing new leads model to file");
            var postModel = new LeadsModel { FirstName = "Matt", LastName = "Jost", PhoneNumber = "602-999-9999", Project = "landscaping", PropertyType = "Yard", StartDate = DateTime.Now };
            api.PostLead(postModel, filePath);
            Console.WriteLine();

            Console.WriteLine("Getting leads sorted by property type");
            api.GetLeadsSortedByProperty(filePath).ForEach(i => Console.WriteLine(i.ToString()));

            Console.WriteLine("Getting leads sorted by start date");
            api.GetLeadsSortedByStartDate(filePath).ForEach(i => Console.WriteLine(i.ToString()));

            Console.WriteLine("Getting duplicated leads.");
            api.GetDuplicatedLeads(filePath).ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}
