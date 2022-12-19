using IndianStateCensusAnalyzerProblemStatement;

namespace IndianStateCensusAnalyzerProblemTest
{
    public class Tests
    {
        public string stateCensusFilePath = @"C:\GetRepositry\indianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerProblemStatement\Files\StateCensusData.csv";
        public string stateCensusIncorrectFilePath = @"C:\GetRepositry\indianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerProblemStatement\Files\";
        public string typeIncorrectFilePath = @"C:\GetRepositry\indianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerProblemStatement\Files\Demo.txt";
        public string delimeterFilePath = @"C:\GetRepositry\indianStateCensusAnalyzerProblem\IndianStateCensusAnalyzerProblemStatement\Files\CSVStateCensusDelimeter.csv";

        [Test]
        public void GivenStateCensusData_WhenAnalyzed_ShouldReturnNoOfRecordsMatches()
        {
            IndianCensusAnalyzer analyzerProblem = new IndianCensusAnalyzer();
            CSVStateCensus cSVState = new CSVStateCensus();
            Assert.AreEqual(cSVState.ReadStateCensusData(stateCensusFilePath), analyzerProblem.ReadStateCensusData(stateCensusFilePath));
        }
        [Test]
        public void GivenStateCencusDataFileIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            IndianCensusAnalyzer analyzer = new IndianCensusAnalyzer();
            try
            {
                int records = analyzer.ReadStateCensusData(stateCensusIncorrectFilePath);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect file path");
            }

        }
        [Test]
        public void GivenStateCensusDataFileTypeIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            IndianCensusAnalyzer analyzer = new IndianCensusAnalyzer();
            try
            {
                int records = analyzer.ReadStateCensusData(typeIncorrectFilePath);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Type Incorrect");
            }
        }

        [Test]
        public void GivenStateCencusDataFileDelimeterIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            IndianCensusAnalyzer analyzer = new IndianCensusAnalyzer();
            try
            {
                int records = analyzer.ReadStateCensusData(delimeterFilePath);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Delimeter");
            }
        }

        [Test]
        public void GivenStateCencusDataFileHeaderIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            IndianCensusAnalyzer indianCensusAnalyzer = new IndianCensusAnalyzer();
            try
            {
                bool records = indianCensusAnalyzer.ReadStateCencusData(delimeterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.IsTrue(records);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }
    }
}