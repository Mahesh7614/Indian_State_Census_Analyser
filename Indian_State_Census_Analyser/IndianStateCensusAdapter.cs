
using Indian_State_Census_Analyser.DataDAO;
using Indian_State_Census_Analyser.DTO;

namespace Indian_State_Census_Analyser
{
    /// <summary>
    /// Inheriting GetCensusDataAdapter to use methods from it
    /// </summary>
    public class IndianStateCensusAdapter : GetCensusDataAdapter
    {
        string[] censusdata;
        Dictionary<string, CensusDTO> dataDict;
        /// <summary>
        /// Method for load data and add into dictionary
        /// Method for load data and add into dictionary
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="csvHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(string filePath, string csvHeaders)
        {
            try
            {
                dataDict = new Dictionary<string, CensusDTO>();
                censusdata = GetData(filePath, csvHeaders);
                foreach (string i in censusdata.Skip(1))
                {
                    if (!i.Contains(","))
                    {
                        throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                    }

                    string[] lines = i.Split(",");

                    if (filePath.Contains("CensusData.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new CensusDataDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                    if (filePath.Contains("StateCodes.csv"))
                    {
                        dataDict.Add(lines[1], new CensusDTO(new StateCodesDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                }
                return dataDict;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}
