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

    public class GameVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event JumpEventHandler PlayJumpSound;
        public event JumpEventHandler PlayCrashSound;

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
                if (_width != value)
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

        private double _xBarrier1;
        public double XBarrier1
        {
            get
            {
                return _xBarrier1;
            }
            set
            {
                if (_xBarrier1 != value)
                {
                    _xBarrier1 = value;
                    RaisePropertyChanged(nameof(XBarrier1));
                    if (value < X && value > X - 2)
                    {
                        AugmentScore();
                    }
                    if (value == 754)
                    {
                        RaisePropertyChanged(nameof(HeightBarrier1));
                        RaisePropertyChanged(nameof(HeightBarrier1Low));
                    }
                }
            }
        }

        private double _xBarrier2;
        public double XBarrier2
        {
            get
            {
                return _xBarrier2;
            }
            set
            {
                if (_xBarrier2 != value)
                {
                    _xBarrier2 = value;
                    RaisePropertyChanged(nameof(XBarrier2));
                    if (value < X && value > X - 2)
                    {
                        AugmentScore();
                    }
                    if (value == 754)
                    {
                        RaisePropertyChanged(nameof(HeightBarrier2));
                        RaisePropertyChanged(nameof(HeightBarrier2Low));
                    }
                }
            }
        }

        private double _xBarrier3;
        public double XBarrier3
        {
            get
            {
                return _xBarrier3;
            }
            set
            {
                if (_xBarrier3 != value)
                {
                    _xBarrier3 = value;
                    RaisePropertyChanged(nameof(XBarrier3));
                    if (value < X && value > X - 2)
                    {
                        AugmentScore();
                    }
                    if (value == 754)
                    {
                        RaisePropertyChanged(nameof(HeightBarrier3));
                        RaisePropertyChanged(nameof(HeightBarrier3Low));
                    }
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

        private double _yGround = 499;

        public double YGround
        {
            get
            {
                return _yGround;
            }
        }

        public GameVM()
        {
            AugmentScore();
            Width = 50;
            Height = 50;
            X = 200;
            Y = 209.5;
            XBarrier1 = 754;
            XBarrier2 = 754;
            XBarrier3 = 754;
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
            Y = Y > 0 ? Y - 50 : Y;
            PlayJumpSound?.Invoke();
            if (_crashed)
            {
                _crashed = false;
                ResetScore();
            }
        }

        private bool _crashed = false;

        public void Fall()
        {
            Y = Y < YGround - Height ? Y + 5 : Y;
            if (Y >= (YGround - (Height + 1)) && !_crashed)
            {
                PlayCrashSound?.Invoke();
                _crashed = true;
            }
            var newXb1 = XBarrier1 > -1 ? XBarrier1 - 15 : 754;
            var newXb2 = XBarrier2 > -1 ? XBarrier2 - 10 : 754;
            var newXb3 = XBarrier3 > -1 ? XBarrier3 - 5 : 754;
            XBarrier1 = newXb1;
            XBarrier2 = newXb2;
            XBarrier3 = newXb3;
        }

        private void AugmentScore()
        {
            Score = _realScore.ToString("0000000");
            _realScore++;
        }

        private void ResetScore()
        {
            _realScore = 0;
            Score = _realScore.ToString("0000000");
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double HeightBarrier1
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }

        public double HeightBarrier1Low
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }

        public double HeightBarrier2
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }

        public double HeightBarrier2Low
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }
        public double HeightBarrier3
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }

        public double HeightBarrier3Low
        {
            get
            {
                return new Random().NextDouble() * 200;
            }
        }
    }
}
