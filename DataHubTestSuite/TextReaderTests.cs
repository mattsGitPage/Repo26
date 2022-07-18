using DataHub.ReaderFactory;
using NUnit.Framework;
using DataHub.ReaderFactory.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DataHubTestSuite
{
    [TestFixture]
    public class TextReaderTests
    {
        private  IReader _reader;
        private readonly string _testFilePath = @"C:\Users\Matthew\source\repos\DataHub'\InputFile.txt";

        [SetUp]
        public void Setup()
        {
            _reader = ReaderFactory.GetReader(ReaderType.TextReader);
        }

        [Test]
        public void Test_EnsureFilePathIsntEmpty()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(_testFilePath), "Please update filepath before testing.");
        }

        [Test]
        public void Test_EnsureFactoryReturnedReaderIsTextReader()
        {
            Assert.IsTrue(_reader is TextReader);
        }

        [Test]
        public void Test_EnsureReadFileCreatesLeadsModel()
        {
            var results = _reader.ReadFile(_testFilePath);
            Assert.IsTrue(results is List<LeadsModel>);
        }

        [Test]
        public void Test_EnsureOutputsMatchAsExpected()
        {
            var postModel = new LeadsModel { FirstName = "Matt", LastName = "Jost", PhoneNumber = "702-999-9999", Project = "landscaping", PropertyType = "Yard", StartDate = DateTime.Now };
            var result =_reader.ReadFile(_testFilePath).LastOrDefault();
            Assert.AreSame(postModel, result);
        }
    }
}