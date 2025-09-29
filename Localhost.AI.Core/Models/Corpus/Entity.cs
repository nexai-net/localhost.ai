namespace Localhost.AI.Core.Models.Corpus
{
    using Models;
    public class Entity : EntityBase
    {
        public string Name { get; set; }
        public List<string> AlternativeNames { get; set; }
        private string _Type { get; set; }
        public string Type
        {
            get { return _Type; }
            set
            {
                value = value.ToUpper().Trim();
                if (!(value == "PERSON" || value == "LOCATION" || value == "ORGANIZATION" || value == "DATE" || value == "TIME" || value == "MONEY" || value == "QUANTITY" || value == "PRODUCT" || value == "EVENT" || value =="APPLICATION" || value == "AGENT"))
                {
                    _Type = "OTHER_ENTITY";
                }
                else
                {
                    _Type = value;
                }
            }
        }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<string> RelatedEntities { get; set; }
        public int Joy { get; set; } = 0;
        public int Fear { get; set; } = 0;
        public int Anger { get; set; } = 0;
        public int Sadness { get; set; } = 0;
        public int Disgust { get; set; } = 0;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; } = DateTime.Now.AddYears(1000);

        public string? HowTo { get; set; }
        public string? WithWhat { get; set; }
        public string? WithoutWhat { get; set; }
        public string? Where { get; set; }
        public string? When { get; set; }
    }
}
