using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlyingBall.NET
{
    public class GameVM:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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


        public GameVM()
        {
            AugmentScore();
        }

        public ICommand AugmentScoreCommand
        {
            get
            {
                return new DelegateCommand(AugmentScore);
            }
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
