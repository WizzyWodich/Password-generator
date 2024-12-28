using System.Windows;

namespace PasswordGenerator.Utilits.Message
{
    internal class MessageApp
    {
        /// <summary>
        /// Класс для отображения сообщений
        /// </summary>
        /// <param name="message"> Содержание сообщения </param>
        /// <param name="icon"> Иконка сообщения </param>
        public delegate void ShowMessageDelegate(string message, MessageBoxImage icon);

        /// <summary>
        /// Метод который бедет отображать предупреждаюшее сообщение
        /// </summary>
        public void ShowInfoMsg()
        {
            ShowMessageDelegate showMessage = (message, icon) => MessageBox.Show(message, "Информация", MessageBoxButton.OK, icon);
            showMessage("Пароль не может состоять из нуля символов.", MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод который бедет отображать сообщение об ошибке
        /// </summary>
        public void ShowErrorMsg()
        {
            ShowMessageDelegate showMessage = (message, icon) => MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, icon);
            showMessage("Пароль не может быть меньше нуля.", MessageBoxImage.Error);
        }

        /// <summary>
        /// Кастомный метод сообшения
        /// </summary>
        /// <param name="messageDelegate"> Созданый выше делегат </param>
        /// <param name="message"> Содержимое сообщения </param>
        /// <param name="icon"> Иконка сообщения </param>
        public void ShowMessage(ShowMessageDelegate messageDelegate, string message, MessageBoxImage icon)
        {
            messageDelegate(message, icon);
        }
    }
}
