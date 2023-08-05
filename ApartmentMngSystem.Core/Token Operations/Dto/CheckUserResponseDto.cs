namespace ApartmentMngSystem.Core.TokenOperations.Dto
{
    public class CheckUserResponseDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? IdentityNumber { get; set; } = null!;
        public string? PlateNumber { get; set; } = null!;
    }
}
