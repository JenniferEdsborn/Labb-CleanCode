using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Utilities
{
    public class ErrorMessages
    {
        public string CouldNotConvertToInt(string userGuess)
        {
            return "ERROR! Could not convert input to int.";
        }

        public string UserNameAlreadyExist(string userName)
        {
            return "ERROR! User name already exist.";
        }



        //public string ErrorCode;
        //public string Description;
        //public string Solution;

        //public override string ToString()
        //{
        //    return $"Error {ErrorCode}: {Description}\nSolution: {Solution}";
        //}

        //public void UserNameAlreadyExist()
        //{
        //    ToString();
        //}
    }
}
