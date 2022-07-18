using DataHub.ReaderFactory.Models;
using System;

namespace DataHub.ReaderFactory
{
    public static class ReaderFactory
    {
        public static IReader GetReader(ReaderType readerNeeded)
        {
            IReader reader;
            switch (readerNeeded)
            {
                case ReaderType.CSVReader:
                    reader = new CSVReader();
                    break;
                case ReaderType.JsonReader:
                    reader = new JsonReader();
                    break;
                case ReaderType.TextReader:
                    reader = new TextReader();
                    break;
                case ReaderType.XMLReader:
                    reader = new XMLReader();
                    break;
                default:
                    throw new ArgumentException();
            }

            return reader;
        }

    }
}
