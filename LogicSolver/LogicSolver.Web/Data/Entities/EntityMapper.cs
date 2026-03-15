namespace LogicSolver.Web.Data.Entities
{
    public class EntityMapper
    {
        public string EntityMainType { get; set; } = string.Empty;

        public string Entity02Type { get; set; } = string.Empty;

        public string Entity03Type { get; set; } = string.Empty;

        public string Entity04Type { get; set; } = string.Empty;

        public EntityMapper(string entityMainType, string entity02Type, string entity03Type, string entity04Type)
        {
            EntityMainType = entityMainType;
            Entity02Type = entity02Type;
            Entity03Type = entity03Type;
            Entity04Type = entity04Type;
        }
    }
}
