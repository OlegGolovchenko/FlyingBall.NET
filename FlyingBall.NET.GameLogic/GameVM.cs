using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlyingBall.NET.GameLogic
{
    public delegate void JumpEventHandler();

    public class GameVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event JumpEventHandler PlayJumpSound;

        private int _realScore = 0;
        private string _score;

        public string Score
        {
            get
            {
                return _score;
            }
            private set
            {
                if (_score != value)
                {
                    _score = value;
                    RaisePropertyChanged(nameof(Score));
                }
            }
        }

        private double _width;
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if(_width != value)
                {
                    _width = value;
                    RaisePropertyChanged(nameof(Width));
                }
            }
        }

        private double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    RaisePropertyChanged(nameof(Height));
                }
            }
        }

        private double _x;
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    RaisePropertyChanged(nameof(X));
                }
            }
        }

        private double _y;
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    RaisePropertyChanged(nameof(Y));
                }
            }
        }

        public GameVM()
        {
            AugmentScore();
            Width = 50;
            Height = 50;
            X = 100;
            Y = 209.5;
        }

        public ICommand JumpCommand
        {
            get
            {
                return new DelegateCommand(Jump);
            }
        }

        private void Jump()
        {
            Y = Y - 20;
            PlayJumpSound?.Invoke();
        }

        private void AugmentScore()
        {
            Score = _realScore.ToString("0000000");
            _realScore++;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
