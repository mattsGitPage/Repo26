using DataHub.ReaderFactory.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataHub
{
    
    public class APIGeneric<T>
    {
      
        #region API 
        public bool PostLead(T model, string filePath)
        {
            bool success = false;
            try
            {
                using (StreamWriter writetext = File.AppendText(filePath))
                {
                    writetext.WriteLine(model.ToString());
                }

                success = true;
            }
            catch(Exception e)
            {
                // Log exception
                success = false;
            }

            return success;
        }

        public List<LeadsModel> GetLeadsSortedByProperty(string filePath)
        {
            return ReaderFactory.ReaderFactory.GetReader(ReaderType.TextReader).ReadFile(filePath).OrderBy(o => o.PropertyType).ToList();
        }

        public List<LeadsModel> GetLeadsSortedByStartDate(string filePath)
        {
            return ReaderFactory.ReaderFactory.GetReader(ReaderType.TextReader).ReadFile(filePath).OrderBy(o => o.StartDate).ToList();
        }

        public List<LeadsModel> GetDuplicatedLeads(string filePath)
        {
            var results = ReaderFactory.ReaderFactory.GetReader(ReaderType.TextReader).ReadFile(filePath).ToList();
            var duplicatePhoneNumbers = results
                                          .GroupBy(g => g.PhoneNumber)
                                          .Where(w => w.Count() > 1)
                                          .Select(s => s.Key)
                                          .ToList();

            return results.Where(w => duplicatePhoneNumbers.Any(a=> a == w.PhoneNumber)).ToList();
        }

        #endregion
    }
}
