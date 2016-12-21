namespace BettingSystem.Data
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using XmlFeedModels;

    public class XmlProcessor
    {
        public void ProccessXmlToDatabase(string url)
        {
            XmlReader reader = this.Fetch(url);
            SportsCollection sports = this.Parse(reader);

            this.UpdateDataBase(sports);

            using (StreamWriter wr = new StreamWriter("Log.txt", true))
            {
                wr.WriteLine("fetched at: {0}", sports.CreateDate);
            }
        }

        public void UpdateDataBase(SportsCollection collection)
        {
        }

        private XmlReader Fetch(string url)
        {
            return new XmlTextReader(url);
        }

        private SportsCollection Parse(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SportsCollection));

            SportsCollection sports;

            using (reader)
            {
                sports = (SportsCollection)serializer.Deserialize(reader);
            }

            return sports;
        }
    }
}
