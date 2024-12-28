using PasswordGenerator.Utilits.Inteface;

namespace PasswordGenerator.Utilits
{
    /// <summary>
    /// Класс для генерации пароля, наследует интерфейс IGeneratePassword
    /// </summary>
    internal class GeneratePassword : IGeneratePassword
    {
        Random random = new Random();
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@";

        /// <summary>
        /// Метод генерации пароля
        /// </summary>
        /// <param name="length"> Длина пароля </param>
        /// <returns> Сгенерированный пароль </returns>
        public string Generate(byte length)  // Метод должен быть public
        {
            string generatedPassword = new string(Enumerable.Range(0, length)
                .Select(s => CHARS[random.Next(CHARS.Length)]).ToArray());

            return generatedPassword;
        }
    }
}
