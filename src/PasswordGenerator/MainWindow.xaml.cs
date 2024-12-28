using System.Windows;
using PasswordGenerator.Utilits;
using PasswordGenerator.Utilits.Message;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MessageApp messageApp = new MessageApp();
        static GeneratePassword generatePassword = new GeneratePassword();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// События сброса всех параментров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btResetOptions_Click(object sender, RoutedEventArgs e)
        {
            tbLengthPassword.Text = "Длина пароля";
            tbGeneratePassword.Text = "Сгенерированый пароль";
        }
        
        /// <summary>
        /// События фокусировки на поле для ввода длины пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLengthPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            tbLengthPassword.Text = string.Empty;
        }

        /// <summary>
        /// События когда нету фокуса на поле для ввода длины пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLengthPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbLengthPassword.Text == string.Empty)
            {
                tbLengthPassword.Text = "Длина пароля";
            }
        }

        /// <summary>
        /// События при нажатии на кнопку для генерации пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            string input = tbLengthPassword.Text;

            if (!byte.TryParse(input, out byte length))
            {
                messageApp.ShowMessage((message, icon) =>
                    MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, icon),
                    "Вы ввели символы или отрицательное значение", MessageBoxImage.Error
                );
            }
            else if (length == 0)
            {
                messageApp.ShowInfoMsg();
            }
            else if (length < 4 || length > 16)
            {
                messageApp.ShowMessage((message, icon) =>
                    MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, icon),
                    "Допустимая длина пароля от 4 до 16 символов", MessageBoxImage.Error
                );
            }
            else
            {
                tbGeneratePassword.Text = string.Empty;
                tbGeneratePassword.Text = generatePassword.Generate(length);
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку скопироывать - копирования пароля в буфер обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCopyToBuffer_Click(object sender, RoutedEventArgs e)
        {
            if (tbGeneratePassword.Text == "Сгенерированый пароль")
            {
                return;
            }
            else
            {
                Clipboard.SetText(tbGeneratePassword.Text);
            }
        }
    }
}
