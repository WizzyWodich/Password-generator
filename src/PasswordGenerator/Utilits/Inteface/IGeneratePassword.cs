namespace PasswordGenerator.Utilits.Inteface
{
    /// <summary>
    /// Интерфейс для класса GeneratePassword
    /// </summary>
    public interface IGeneratePassword
    {
        /// <summary>
        /// Метод, который будет генерировать пароль
        /// </summary>
        /// <param name="length"> Длина пароля </param>
        /// <returns> Сгенерированный пароль </returns>
        string Generate(byte length);
    }
}
