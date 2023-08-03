namespace ApartmentMngSystem.Core.TokenOperations.Dto
{
    public class CheckUserResponseDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
