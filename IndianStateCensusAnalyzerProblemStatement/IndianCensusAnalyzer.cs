using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using IndianStateCensusAnalyzerProblemStatement;

namespace IndianStateCensusAnalyzerProblemStatement
{
    public class IndianCensusAnalyzer
    {
        public int ReadStateCensusData(string filePath)
        {
            if (!File.Exists(filePath))
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "Incorrect file path");
            if (!filePath.EndsWith(".csv"))
                throw new StateCensusException(StateCensusException.ExceptionType.TYPE_INCORRECT, "Type Incorrect");
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusException(StateCensusException.ExceptionType.DELIMETER, "Incorrect Delimeter");
            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StateCensusDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count() - 1;
            }
        }
        public bool ReadStateCencusData(string filePath, string actualHeader)
        {
            var read = File.ReadAllLines(filePath);
            string headern = read[0];
            if (headern.Equals(actualHeader))
                return true;
            else
                throw new StateCensusException(StateCensusException.ExceptionType.HEADER_INCORRECT, "Incorrect Header");
        }
        public int ReadStateCodeData(string filePath1)
        {
            if (!File.Exists(filePath1))
                throw new StateCodeException(StateCodeException.ExceptionType.FILE_INCORRECT, "Incorrect file path");
            if (!filePath1.EndsWith(".csv"))
                throw new StateCodeException(StateCodeException.ExceptionType.TYPE_INCORRECT, "Type Incorrect");
            var read = File.ReadAllLines(filePath1);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCodeException(StateCodeException.ExceptionType.DELIMETER, "Incorrect Delimeter");
            using (var reader = new StreamReader(filePath1))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StateCodeDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count() - 1;
            }
        }
        public bool ReadStateCodeData(string filePath1, string actualHeader)
        {
            var read = File.ReadAllLines(filePath1);
            string headern = read[0];
            if (headern.Equals(actualHeader))
                return true;
            else
                throw new StateCodeException(StateCodeException.ExceptionType.HEADER_INCORRECT, "Incorrect Header");
        }
    }
}
