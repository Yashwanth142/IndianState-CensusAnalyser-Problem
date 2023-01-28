using IndianStateCensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyzer;
using Assert = NUnit.Framework.Assert;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTests
    {
        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\WrongIndiaStateCensusData.csv";
        static string delimeterIndianCensusFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\WrongIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\IndiaStateCensusData.xlsx";

        static string indianStateCodeFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\IndiaStateCode.txt";
        static string delimeterIndianStateCodeFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\yashw\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Csv\WrongIndiaStateCode.csv";
        IndianStateCensusAnalyser.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //Use case - 1
        //Happy Test Case 1.1 : The records are checked
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            System.Console.WriteLine("Indian state records Count : " + totalRecord.Count);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.2 : To verify if the exception is raised.
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(37, totalRecord.Count);
        }

        //Sad Test Case 1.3 : If the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileTypeWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianCensusFileType, indianStateCensusHeaders);

            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.4 : If the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileDelimeterWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.5 : If the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileCsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(29, totalRecord.Count);
        }


        //Use case - 2
        //Happy Test Case 2.1 : The records are checked
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            System.Console.WriteLine("State Record Count : " + stateRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.2 : To verify if the exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, stateRecord.Count);
        }

        //Sad Test Case 2.3 : If the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCode_FileTypeWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.4 : If the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_DelimeterWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //Sad Test Case 2.5 : If the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianStateCodeFile_CsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            stateRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, wrongHeaderStateCodeFilePath);
            Assert.AreEqual(37, stateRecord.Count);
        }
    }
}
