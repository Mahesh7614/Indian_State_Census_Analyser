
using Indian_State_Census_Analyser.DTO;

namespace Indian_State_Census_Analyser
{
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Method to load csv data from File
        /// </summary>
        /// <param name="country"></param>
        /// <param name="path"></param>
        /// <param name="csvHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string path, string csvHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianStateCensusAdapter().LoadCensusData(path, csvHeaders);
                    default:
                        throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY, "No such country present");
                }
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
