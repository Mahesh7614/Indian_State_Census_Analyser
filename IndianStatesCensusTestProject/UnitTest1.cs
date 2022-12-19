using Indian_State_Census_Analyser.DTO;
using Indian_State_Census_Analyser;

namespace IndianStatesCensusTestProject
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusFilePath = @"C:\Users\Mahesh\OneDrive\Desktop\Assignments\RFP .Net Assignment\Indian_State_Census_Analyser\Indian_State_Census_Analyser\CsvFiles\CensusData.csv";
        string wrongExtensionFilePath = @"C:\Users\Mahesh\OneDrive\Desktop\Assignments\RFP .Net Assignment\Indian_State_Census_Analyser\Indian_State_Census_Analyser\CsvFiles\CSVAdapterFactory.cs";
        string wrongFilePath = @"C:\Users\Mahesh\OneDrive\Desktop\Assignments\RFP .Net Assignment\CensusData.csv";
        string wrongheadersFilePath = @"C:\Users\Mahesh\OneDrive\Desktop\Assignments\RFP .Net Assignment\Indian_State_Census_Analyser\Indian_State_Census_Analyser\CsvFiles\WrongHeaders.csv";
        string wrongDelimitersFilePath = @"C:\Users\Mahesh\OneDrive\Desktop\Assignments\RFP .Net Assignment\Indian_State_Census_Analyser\Indian_State_Census_Analyser\CsvFiles\WrongDelimiter.csv";
        CSVAdapterFactory csvAdapter = default;
        Dictionary<string, CensusDTO> allStateRecords;
        [TestInitialize]
        public void Setup()
        {
            allStateRecords = new Dictionary<string, CensusDTO>();
            csvAdapter = new CSVAdapterFactory();
        }
        /// <summary>
        /// Uc1 - Tc-1.1 - Test for number of records matches
        /// </summary>
        [TestMethod]
        public void TestNumberOfRecordMatches()
        {
            allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,Area,Density");
            int expected = 5, actual = allStateRecords.Count;
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        ///  Uc1 - Tc-1.2 - Test for Wrong File Extension
        /// </summary>
        [TestMethod]
        public void TestForWrongFileExtension()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongExtensionFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file extension";

                Assert.AreEqual(expected, ex.Message);
            }

        }
        /// <summary>
        /// Uc1 - Tc-1.3 - Test for File not found exception
        /// </summary>
        [TestMethod]
        public void TestForFileNotFound()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "File not found";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Uc1 - Tc-1.4 - Test for wrong headers exception
        /// </summary>
        [TestMethod]
        public void TestForWrongHeaders()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongheadersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid file headers";

                Assert.AreEqual(ex.Message, expected);
            }

        }
        /// <summary>
        /// Test For Wrong Delimiters
        /// </summary>
        [TestMethod]
        public void TestForWrongDelimiters()
        {
            try
            {
                allStateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimitersFilePath, "State,Population,Area,Density");


            }
            catch (StateCensusAnalyserException ex)
            {
                string expected = "Invalid Delimiter";

                Assert.AreEqual(ex.Message, expected);
            }

        }
    }
}