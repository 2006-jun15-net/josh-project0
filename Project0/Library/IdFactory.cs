using System;

namespace Project0
{
    internal static class IdFactory
    {
        private static int _productIDSeed = 0123456789;//save IDseed to begin seed where it was left between program runs
        /// <summary>
        /// Generate a unique ID when called. Seed should be persistant between runs of the program. 
        /// </summary>
        /// <returns></returns>
        public static string generateNewId()
        {
            string IdString = "";

            IdString = _productIDSeed.ToString();

            _productIDSeed++;

            return IdString;
        }
    }
}