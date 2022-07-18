using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataHub.ReaderFactory.Readers
{
    static class Validator
    {
        public static bool DoesFilePathExist(string fullPath)
        {
            return File.Exists(fullPath);
        }
    }
}
