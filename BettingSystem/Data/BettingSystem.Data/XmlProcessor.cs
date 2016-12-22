namespace BettingSystem.Data
{
    using System.IO;
    using System.Linq;
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
        }

        public void UpdateDataBase(SportsCollection collection)
        {
            BetsDbContext context = new BetsDbContext();
            string test = collection.Sports.First().Name;

            Models.Sport testSport = new Models.Sport()
            {
                Name = test
            };

            context.SaveChanges();

            using (StreamWriter wr = new StreamWriter("Log.txt", true))
            {
                wr.WriteLine("count: {0}", context.Sports.Count());
            }

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
