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

            string editName = NameEditExtensions.NameEdit(name);
            if (!string.IsNullOrEmpty(editName))
            {
                if (editName.Contains(' '))
                {
                    names = editName.Split(' ');
                    newName = names[0];
                    for (int i = 1; i < names.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(names[i]))
                        {
                            newName += $"-{names[i]}";
                        }
                    }
                    editName = newName;
                }
            }
            return editName.ToLower();
        }
    }
}
