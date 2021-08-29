using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TestTask_SysTech.Models;

namespace TestTask_SysTech.DataStorages
{
    internal static class XmlCardsStorage
    {
        private static string storagePath = "D:/Index.xml";
        private static List<Card> cards;
        internal static List<Card> GetData()
        {
            if (cards == null)
                cards = new List<Card>();
            if (File.Exists(storagePath))
            {
                XDocument xDoc = XDocument.Load(storagePath);
                UpdateData(xDoc);
            }
            return cards;
        }
        internal static List<string> UpdateData(XDocument xDoc)
        {
            List<string> err = new List<string>();
            List<Card> temp = new List<Card>();
            if (xDoc.Element("cards") != null)
            {
                foreach (XElement cardElement in xDoc.Element("cards").Elements("card"))
                {
                    try
                    {
                        XElement billsElement = cardElement.Element("bills");
                        XElement amountElement = cardElement.Element("amount");
                        if (billsElement != null && amountElement != null)
                        {
                            temp.Add(new Card(billsElement.Value, Decimal.Parse(amountElement.Value, CultureInfo.InvariantCulture)));
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        err.Add(ex.Message);
                    }
                }
            }
            else
            {
                err.Add("Указанный файл не содержит коллекции 'Cards'.");
            }
            if (!err.Any())
                cards = temp;
            return err;
        }
    }
}