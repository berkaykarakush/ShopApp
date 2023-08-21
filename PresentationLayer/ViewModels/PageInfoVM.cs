namespace PresentationLayer.ViewModels
{ 
    public class PageInfoVM
    {
        public PageInfoVM()
        {
            TotalItems = 0;
            ItemsPerPage = 0;
            CurrentPage = 0;
        }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string? CurrentCategory { get; set; }
        public int TotalPages()
        {
            try
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

    }
}
