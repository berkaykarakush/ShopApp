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
