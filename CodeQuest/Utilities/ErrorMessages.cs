using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Utilities
{
    public class ErrorMessages
    {
        public string CouldNotConvertToInt()
        {
            return "ERROR! Could not convert input to int.";
        }

        public string UserNameAlreadyExist()
        {
            return "ERROR! User name already exist.";
        }

        public string GuessNotValid()
        {
            return "ERROR! Guess is not valid.";
        }

        public string InvalidInput()
        {
            return "ERROR! Input is not valid.";
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
