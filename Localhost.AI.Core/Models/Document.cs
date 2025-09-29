namespace Localhost.AI.Core.Models
{
    public class Document : EntityBase
    {
        public string Location { get; set; }
        public int Lenght { get; set; }
        public int BlocksCount { get; set; }
        public string Type { get; set; }
        public List<Block> Blocks { get; set; }

    }
    public class Block
    {

        public string Id { get; set; }
        public int Position { get; set; }
        public string Type { get; set; }

    }
}
