using System;
using System.Collections.Generic;
using System.Text;
using CGH_App.Common;

namespace CGH_App.Data.PunterClass
{
    public abstract class PunterBaseClass : IDataClass
    {
        public const int NOT_BETTING = 0;
        public const int NO_RACER_SELECTED = -1;
        /// <summary>
        /// A unqiue number for the Punter Class Object.
        /// </summary>
        public int ID { get => _PunterID; set { int temp = value; } }
        private int _PunterID;
        /// <summary>
        /// Name of the Punter Class Object.
        /// </summary>
        public string Name { get => _PunterName; set => _PunterName = value; }
        private string _PunterName;
        public string ClassName { get => _ClassName; set { string temp = value; } }
        protected string _ClassName = "Punter Base Class";
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
        protected PunterBaseClass()
        {
            _PunterID = CommonClass.GetID(CommonClass.ID_Class_Type.PunterClass);
        }
        public void WinGame()
        {
            Money += Bet;
            ResetBet();
        }
        public void LoseGame()
        {
            Money -= Bet;
            ResetBet();
        }
        public void ResetBet()
        {
            Bet = NOT_BETTING;
        }
    }
}
