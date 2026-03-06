namespace LogicSolver.Web.Data.Entities
{
    public class EntityMapper
    {
        public EntityMain EntityMain { get; set; }

        public EntityMapper(string entityMainTitle, string entity01Title)
        {
            EntityMain = new EntityMain
            {
                Title = entityMainTitle
            };
        }
    }
}
