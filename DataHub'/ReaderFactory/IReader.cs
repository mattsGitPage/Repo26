using DataHub.ReaderFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHub.ReaderFactory
{
    public interface IReader
    {
        List<LeadsModel> ReadFile(string filePath);
    }
}
