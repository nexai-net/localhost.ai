namespace Localhost.AI.Core.Models
{
    public class Paragraph : EntityBase
    {
        public string text { get; set; }
        public int lenght { get; set; }
        public int wordsCount { get; set; }
        public List<IncludedIn> includedIns { get; set; }
        public List<MetaData> MetaDatas { get; set; }

    }


    public class IncludedIn
    {
        public string documentLocation { get; set; }
        public string documentId { get; set; }
        public int position { get; set; }
    }
}
