﻿namespace EntityLayer
{
    public class ImageUrl
    {
        public ImageUrl()
        {
            Random random = new Random();
            Id = random.Next(111111111,999999999);
            Url = "";
        }
        public double Id { get; set; }
        public double ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
    }
}
