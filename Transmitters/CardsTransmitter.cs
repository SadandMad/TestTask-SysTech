using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TestTask_SysTech.DataStorages;
using TestTask_SysTech.DTO;
using TestTask_SysTech.Models;

namespace TestTask_SysTech.Transmitters
{
    internal static class CardsTransmitter
    {
        private static List<Card> rawData;
        private static List<CardDTO> data;

        internal static List<CardDTO> GetData()
        {
            if (data == null)
                data = new List<CardDTO>();
            else
                data.Clear();
            rawData = XmlCardsStorage.GetData();
            foreach(Card c in rawData)
            {
                data.Add(new CardDTO(c.Bills, c.Amount));
            }
            return data;
        }
        internal static List<string> UpdateData(StreamReader sr)
        {
            XDocument xDoc = XDocument.Load(sr);
            List<string> err = XmlCardsStorage.UpdateData(xDoc);
            if (!err.Any())
                GetData();
            return err;
        }
    }
}