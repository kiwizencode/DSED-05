using System;
using System.Collections.Generic;
using System.Text;
using GreyHoundApp.Data;

namespace GreyHoundApp.Data.DogClass
{
    public abstract class DogBaseClass : IDataClass
    {
        /// <summary>
        /// name of the dog object.
        /// </summary>
        public string Name { get => _Name; set => _Name = value ; }
        private string _Name;
        /// <summary>
        /// unique class name that identify dog class
        /// </summary>
        public string ClassName { get => _ClassType; set {string temp = value; } }
        private string _ClassType = "Dog Class";

        /// <summary>
        /// return a unique ID for the dog object.
        /// </summary>
        /// <returns>return an integer</returns>
        public int GenerateID()
        {
            return DogGeneratorClass.GenerateID();
        }
        
        protected const char NOT_DEFINED_TYPE = 'Z';
        protected const char S_TYPE = 'S';
        protected const char M_TYPE = 'M';
        protected const char L_TYPE = 'L';
        protected const char G_TYPE = 'G';
        /// <summary>
        /// dog's breed type
        /// </summary>
        public string Breed { get; protected set; } = string.Empty;
        public int Breed_Type = -1;
        /// <summary>
        /// number of steps the dog move each time
        /// </summary>
        public int Steps { get; protected set; } = 0;
        /// <summary>
        /// country origin of the dog
        /// </summary>
        public string Origin { get; protected set; } = string.Empty;
        /// <summary>
        /// dog's size, whethe is Small, Medium, Large, Giant
        /// </summary>
        public char Size { get; protected set; } = NOT_DEFINED_TYPE;
    }
}
