using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DSED05_App.Common;
using DSED05_App.Data.Punter;

namespace DSED05_App.WPF.Model
{
    public class PunterModel
    {
        public Image Image { get; private set;}

        private AbstractPunter _Punter;

        public string Name { get => _Punter.Name; set { _Punter.Name = value; } }
        public int Money { get => _Punter.Money; private set { _Punter.Money = value; } }

        public const int NOT_BETTING = 0;
        public const int NO_RACER_SELECTED = -1;

        /// <summary>
        /// The ID of the racer that punter has placed bet on
        /// </summary>
        public int RacerID = NO_RACER_SELECTED;     

        /// <summary>
        /// How much money the punter has place on a particular dog
        /// </summary>
        public int Bet = NOT_BETTING;

        public PunterModel(CommonClass.Punter_Type type, Image image)
        {
            _Punter = PunterGenerator.FactoryMethod(type);
            Image = image;
        }

        /// <summary>
        /// check whether the punter has no more money left ==> BUSTED !!
        /// </summary>
        public bool Busted { get => (Money > 0 ? true : false); }

        /// <summary>
        /// When punter win a game, add bet amount to Money and reset bet amount.
        /// </summary>
        public void WinGame()
        {
            Money += Bet;
            ResetBet();
        }
        /// <summary>
        /// When punter win a game, add bet amount to Money and reset bet amount.
        /// </summary>
        public void LoseGame()
        {
            Money -= Bet;
            ResetBet();
        }
        /// <summary>
        /// Reset bet amount.
        /// </summary>
        public void ResetBet()
        {
            Bet = NOT_BETTING;
        }

        public void Reset()
        {
            _Punter.Reset();
        }
    }
}
