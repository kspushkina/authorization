using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Авторизация
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string CorrectUsername = "username";
        private const string CorrectPassword = "password";
        private int attemptCount = 0; // Счетчик попыток

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (attemptCount >= 3) // Проверка на превышение количества попыток
            {
                MessageBox.Show("Вы исчерпали все попытки входа. Приложение будет закрыто.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown(); // Закрытие приложения
                return;
            }

            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == CorrectUsername && password == CorrectPassword)
            {
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Здесь можно добавить логику для перехода на другую форму или окно
            }
            else
            {
                attemptCount++; // Увеличиваем счетчик попыток
                MessageBox.Show($"Неверный логин или пароль. Осталось попыток: {3 - attemptCount}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                if (attemptCount >= 3) // Проверяем, если это была последняя попытка
                {
                    MessageBox.Show("Вы исчерпали все попытки входа. Приложение будет закрыто.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown(); // Закрытие приложения
                }
            }
        }
    }
}

