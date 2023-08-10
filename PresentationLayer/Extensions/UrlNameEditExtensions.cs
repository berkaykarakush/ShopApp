using System.Collections;

namespace PresentationLayer.Extensions
{
    public static class UrlNameEditExtensions
    {
        /// <summary>
        /// This method saves the received name value by deleting the spaces and replacing them with a - sign.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string UrlNameEdit(string name)
        {
            string[] names;
            string newName = "";
            if (!string.IsNullOrEmpty(name))
            {
                if (name.Contains(' '))
                {
                    names = name.Split(' ');
                    newName = names[0];
                    for (int i = 1; i < names.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(names[i]))
                        {
                            newName += $"-{names[i]}";
                        }
                    }
                    name = newName;
                }
            }
            return name.ToLower();
        }
    }
}
