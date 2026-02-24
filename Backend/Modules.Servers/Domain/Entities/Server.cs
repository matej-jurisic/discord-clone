namespace Modules.Servers.Domain.Entities
{
    public class Server
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        private Server() { }

        public static Server Create(long id, string name, string description) => new()
        {
            Id = id,
            Name = name,
            Description = description
        };
    }
}
