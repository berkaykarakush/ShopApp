namespace PresentationLayer.Models
{
    public class ManageModel
    {
        public List<UserAddressModel>? UserAddressModels { get; set; } = new List<UserAddressModel>();
        public UserAddressModel? UserAddressModel { get; set; }
        public UserDetailsModel? UserDetailsModel { get; set; }
        public ResetPasswordModel? ResetPasswordModel { get; set; }
    }
}
