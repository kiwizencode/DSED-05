using System;
using System.Collections.Generic;
using System.Text;
using GreyHoundApp.Data;

namespace GreyHoundApp.Data.PunterClass
{
    public abstract class PunterBaseClass : IDataClass
    {
        /// <summary>
        /// name of the punter object.
        /// </summary>
        public string Name { get => _Name; set => _Name = value; }
        private string _Name;
        /// <summary>
        /// unique class name that identify punter class
        /// </summary>
        public string ClassName { get => _ClassType; set { string temp = value; } }
        private string _ClassType = "Punter Class";
        /// <summary>
        /// return an unique ID for the punter object.
        /// </summary>
        /// <returns>return an integer</returns>
        public int GenerateID()
        {
            return PunterGeneratorClass.GenerateID();
        }

        public const int NOT_BETTING = 0;
        public const int NO_DOG_SELECTED = -1;
        /// <summary>
        /// The amount the punter have on hand
        /// </summary>
        public int Amount { get; set; } = 100;
        /// <summary>
        /// Age of the punter
        /// </summary>
        public int Age { get; set; } = 0;
        /// <summary>
        /// check whether the punter has no more money left ==> BUSTED !!
        /// </summary>
        public bool Busted { get => (Amount > 0 ? true : false); }
        /// <summary>
        /// How much money the punter has place on a particular dog
        /// </summary>
        public int Bet = NOT_BETTING;
        /// <summary>
        /// The ID of the dog that punter has placed bet on
        /// </summary>
        public int DogID = NO_DOG_SELECTED;
        public void WinGame()
        {
            Amount += Bet;
            ResetBet();
        }
        public void LoseGame()
        {
            Amount -= Bet;
            ResetBet();
        }
        public void ResetBet()
        {
            Bet = NOT_BETTING;
        }
    }
}
