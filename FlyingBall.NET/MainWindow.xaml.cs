using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace FlyingBall.NET
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer _player;

        public MainWindow()
        {
            InitializeComponent();
            _player = new SoundPlayer("bounce.wav");
            _player.Load();
            GameViewModel.PlayJumpSound += GameVM_PlayJumpSound;
        }

        private void GameVM_PlayJumpSound()
        {
            _player.Play();
        }
    }
}
