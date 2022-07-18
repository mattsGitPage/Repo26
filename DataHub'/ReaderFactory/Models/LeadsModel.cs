using System;
using System.ComponentModel;

namespace DataHub.ReaderFactory.Models
{
    [Serializable]
    public class LeadsModel
    {
        public int InputNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PropertyType { get; set; }
        public string Project { get; set; }
        public DateTime StartDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}", FirstName, LastName, PropertyType , Project, StartDate.ToString("M/d/yyyy"), string.Format("{0: #: (###)-###-####}" , PhoneNumber));
        }
    }

    public enum ReaderType
    {
        [Description("Reader for parsing json files.")]
        JsonReader,
        [Description("Reader for parsing text files.")]
        TextReader,
        [Description("Reader for parsing CSV files.")]
        CSVReader,
        [Description("Reader for parsin XMLReader.")]
        XMLReader,
    }
}
