using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CleanQuote.Data.Entities;


namespace CleanQuote.Data.Repositories
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> GetQuotes();
    }

    public class QuoteRepository : IQuoteRepository
    {
        private const int EXPECTED_NUMBER_OF_VALUE = 8;

        protected readonly IEnumerable<Quote> _quotes;

        public QuoteRepository()
        {
            string fileName = "quotes.csv";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            _quotes = LoadQuoteFile(path);
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _quotes;
        }

        private IEnumerable<Quote> LoadQuoteFile(string path)
        {

            var reader = File.ReadAllLines(path);
            var records = new List<Quote>();

            try
            {
                for (int i = 1; i < reader.Length; i++)
                {
                    var line = reader[i];
                    var splitLine = line.Split(',');
                    if(splitLine.Length == EXPECTED_NUMBER_OF_VALUE)
                    {
                        var record = new Quote
                        {
                            Symbol = splitLine[0],
                            Name = splitLine[1],
                            MarketCap = decimal.Parse(splitLine[2]),
                            Price = decimal.Parse(splitLine[3]),
                            DailyChange = decimal.Parse(splitLine[4]),
                            DailyChangePercent = double.Parse(splitLine[5]),
                            Currency = splitLine[6],
                            Date = DateTime.Parse(splitLine[7])
                        };
                        records.Add(record);
                    }
                }

                return records;
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            catch(FormatException e)
            {
                Console.WriteLine($"The file data is the wrong format: '{e}'");
            }

            return records;
        }
    }
}
