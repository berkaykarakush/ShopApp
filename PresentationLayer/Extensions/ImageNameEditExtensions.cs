﻿namespace PresentationLayer.Extensions
{
    public static class ImageNameEditExtensions
    {
        /// <summary>
        /// This static method renames incoming files and makes them seo compitable.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async static Task<string> ImageNameEdit(IFormFile file, string modelName)
        {
            string imageName = "";
            if (file != null)
            {
                //file-name.jpg
                string extension = Path.GetExtension(file.FileName);//.jpg | .png 
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);//file-name
                fileName = modelName; //new filename = new product name
                
                //file-name-1.jpg
                int counter = 1; 
                imageName = string.Format($"{fileName}-{counter}{extension}"); //iphone-14-1.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", imageName);

                while (File.Exists(path)) //if the filename already exist
                {
                    
                    
                    counter++;
                    imageName = string.Format($"{fileName}-{counter}{extension}"); //iphone-14-2.jpg
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", imageName);
                    if (!File.Exists(path)) //filename not exist, exit the loop
                        //iphone-14-3.jpg 
                        break;
                }

                //save the file
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return imageName;
        }
    }
}
