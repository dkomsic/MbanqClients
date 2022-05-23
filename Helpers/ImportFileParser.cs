using MbanqClients.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace MbanqClients.Helpers
{
    public class ImportFileParser
    {
        public List<Osobe> Parse(string filename)
        {
            List<Osobe> items = new List<Osobe>();
            using (TextFieldParser csvParser = new TextFieldParser(filename))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Osobe item = new Osobe();
                    try
                    {
                        item.ID = Convert.ToInt32(fields[0]);
                        item.OIB = Convert.ToInt32(fields[1]);
                        item.Ime = fields[2];
                        item.Prezime = fields[3];
                        item.Mjesto = fields[4];
                        item.Adresa = fields[5];
                        item.Telefon = Convert.ToInt32(fields[6]);
                        item.Mail = fields[7];
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    items.Add(item);
                }
            }
            return items;
        }

    }
}

