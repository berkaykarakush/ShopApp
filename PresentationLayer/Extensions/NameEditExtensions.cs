namespace PresentationLayer.Extensions
{
    public static class NameEditExtensions
    {
        /// <summary>
        /// This method ensures that the received name value is saved in an orderly state by deleting the spaces between
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NameEdit(string name)
        {
            string[] names;
            string newName = "";
            if (!string.IsNullOrEmpty(name))
            {
                
                if (name.Contains(' '))
                {
                    name = name.Replace("\"", "")
                    .Replace("!", " ")
                    .Replace("'", " ")
                    .Replace("^", " ")
                    .Replace("+", " ")
                    .Replace("%", " ")
                    .Replace("&", " ")
                    .Replace("/", " ")
                    .Replace("\\", " ")
                    .Replace("(", " ")
                    .Replace(")", " ")
                    .Replace("=", " ")
                    .Replace("?", " ")
                    .Replace("_", " ")
                    .Replace("-", " ")
                    .Replace("@", " ")
                    .Replace("€", " ")
                    .Replace("¨", " ")
                    .Replace("~", " ")
                    .Replace(",", " ")
                    .Replace(";", " ")
                    .Replace(":", " ")
                    .Replace(".", " ")
                    .Replace("<", " ")
                    .Replace("<", " ")
                    .Replace("<", " ")
                    .Replace(">", " ")
                    .Replace("|", " ")
                    .Replace("[", " ")
                    .Replace("]", " ")
                    .Replace("Ö", "o")
                    .Replace("ö", "o")
                    .Replace("Ü", "u")
                    .Replace("ü", "u")
                    .Replace("ı", "i")
                    .Replace("İ", "i")
                    .Replace("ğ", "g")
                    .Replace("Ğ", "g")
                    .Replace("æ", "")
                    .Replace("ß", "")
                    .Replace("â", "a")
                    .Replace("î", "i")
                    .Replace("ş", "s")
                    .Replace("Ş", "s")
                    .Replace("Ç", "c")
                    .Replace("ç", "c");
                    names = name.Split(' ');

                    newName = names[0];
                    for (int i = 1; i < names.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(names[i]))
                        {
                            newName += $" {names[i]}";
                        }
                    }
                    name = newName;
                }
            }
            return name.ToLower();
        }
    }
}
