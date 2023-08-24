namespace PresentationLayer.Models
{
    public class ManageModel
    {
        public ManageModel()
        {
            UserAddressModels = new List<UserAddressModel>();
            UserAddressModel = new UserAddressModel();
            UserDetailsModel = new UserDetailsModel();
            ResetPasswordModel = new ResetPasswordModel();
        }
        public List<UserAddressModel> UserAddressModels { get; set; }
        public UserAddressModel UserAddressModel { get; set; }
        public UserDetailsModel UserDetailsModel { get; set; }
        public ResetPasswordModel ResetPasswordModel { get; set; }
    }
}
