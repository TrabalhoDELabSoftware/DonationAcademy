namespace DonationAcademy.Services
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAync();
        Task SeedUsersAync();
    }
}
