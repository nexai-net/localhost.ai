namespace Localhost.AI.Core.Models
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public EntityBase(string? id)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                this.Id = id;
            }
            Init();
        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        private void Init()
        {

        }
    }

}
