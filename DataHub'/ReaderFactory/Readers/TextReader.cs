using DataHub.ReaderFactory.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataHub.ReaderFactory
{
    public class TextReader : IReader
    {
        public List<LeadsModel> ReadFile(string filePath)
        {
            return ReadFileToList(filePath);
        }

        private List<LeadsModel> ReadFileToList(string filePath)
        {
            var results = new List<LeadsModel>();
            DateTime startDate;

            var fileContents = File.ReadAllLines(filePath);

            foreach(var input in fileContents
                                        .Select((row, index) => new { Value = row, Index = index }))
            {
                var tempRow = input.Value.Split("|");

                if (tempRow.Count() == 6
                        && DateTime.TryParse(tempRow[4], out startDate))
                {
                    results.Add(new LeadsModel
                    {
                        InputNumber = input.Index,
                        FirstName = tempRow[0],
                        LastName = tempRow[1],
                        PropertyType = tempRow[2],
                        Project = tempRow[3],
                        StartDate = startDate,
                        PhoneNumber = tempRow[5]
                    });
                }
                else 
                {
                    results.Add(new LeadsModel
                    {
                        InputNumber = input.Index,
                        FirstName = "FAILED",
                        LastName = "FAILED"
                    });
                }
            }

            return results;
        }
    }
}
