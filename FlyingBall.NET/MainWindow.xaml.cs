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
using System.Windows.Threading;

namespace FlyingBall.NET
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer _player;
        private SoundPlayer _crashPlayer;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _player = new SoundPlayer("bounce.wav");
            _crashPlayer = new SoundPlayer("hit.wav");
            _player.Load();
            _crashPlayer.Load();
            GameViewModel.PlayJumpSound += GameVM_PlayJumpSound;
            GameViewModel.PlayCrashSound += GameViewModel_PlayCrashSound;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(16.7);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void GameViewModel_PlayCrashSound()
        {
            _crashPlayer.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GameViewModel.Fall();
        }

        private void GameVM_PlayJumpSound()
        {
            _player.Play();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
        }
    }
}
