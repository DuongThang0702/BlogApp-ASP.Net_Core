namespace Core.Dtos.user
{
    public class GetUserDto : BaseDto
    {
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
