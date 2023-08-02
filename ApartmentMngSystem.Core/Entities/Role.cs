namespace ApartmentMngSystem.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        public List<User>? Users { get; set; }
    }
}
