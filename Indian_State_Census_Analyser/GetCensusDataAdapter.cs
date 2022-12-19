
namespace Indian_State_Census_Analyser
{
    public class GetCensusDataAdapter
    {
        /// <summary>
        /// Method to get csv data and validate
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="csvHeaders"></param>
        /// <returns></returns>
        public string[] GetData(string filePath, string csvHeaders)
        {
            try
            {
                string[] data;
                if (!Path.GetExtension(filePath).Equals(".csv"))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, "Invalid file extension");
                }
                if (!File.Exists(filePath))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.FILE_NOT_FOUND, "File not found");
                }
                data = File.ReadAllLines(filePath);
                if (!data[0].Equals(csvHeaders))
                {
                    throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_HEADER, "Invalid file headers");
                }
                return data;
            }
            catch (StateCensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
