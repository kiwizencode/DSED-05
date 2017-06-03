using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public abstract class AbstractPunter : IData
    {
        public const int NOT_BETTING = 0;
        public const int NO_RACER_SELECTED = -1;

        public AbstractPunter()
        {
            ClassName = "Abstract Punter Class";
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public Enum Type { get; set; }
        /// <summary>
        /// Money that the punter have
        /// </summary>
        public int Money { get; set; }
        /// <summary>
        /// check whether the punter has no more money left ==> BUSTED !!
        /// </summary>
        public bool Busted { get => (Money > 0 ? true : false); }
        /// <summary>
        /// How much money the punter has place on a particular dog
        /// </summary>
        public int Bet = NOT_BETTING;
        /// <summary>
        /// The ID of the dog that punter has placed bet on
        /// </summary>
        public int RacerID = NO_RACER_SELECTED;

        public bool CheckType(Enum type)
        {
            return (CommonClass.Punter_Type)Type == (CommonClass.Punter_Type)type;
        }
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
    }
}
