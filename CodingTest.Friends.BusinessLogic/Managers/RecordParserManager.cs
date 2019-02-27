using CodingTest.Friends.BusinessLogic.Exceptions;
using CodingTest.Friends.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Friends.BusinessLogic.Managers
{
    public class RecordParserManager
    {
        private const string _PIPE = " | ";
        private const string _COMMA = ", ";

        public static Friend ParseRecordFromString(string rawRecord)
        {
            if (rawRecord.Split(new string[] { _PIPE, _COMMA, " " }, StringSplitOptions.RemoveEmptyEntries).Count() != 5)
                throw new InvalidRecordFormatException(
                    InvalidRecordFormatException.BuildErrorMessage(rawRecord));

            if (rawRecord.Contains(_PIPE))
                return ParseRecordByPipe(rawRecord);

            if (rawRecord.Contains(_COMMA))
                return ParseRecordByComma(rawRecord);

            return ParseRecordBySpace(rawRecord);
        }

        private static Friend ParseRecordByPipe(string rawRecord)
        {
            return ParseRecordsByArray(rawRecord.Split(new string[] { _PIPE }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static Friend ParseRecordByComma(string rawRecord)
        {
            return ParseRecordsByArray(rawRecord.Split(new string[] { _COMMA }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static Friend ParseRecordBySpace(string rawRecord)
        {
            return ParseRecordsByArray(rawRecord.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static Friend ParseRecordsByArray(string[] rawRecordArray)
        {
            if (rawRecordArray.Count() != 5)
                throw new InvalidPropertiesCountException(
                    InvalidPropertiesCountException.BuildErrorMessage(rawRecordArray, "ParseRecordsByArray"));

            Friend result = new Friend();

            result.lastName = rawRecordArray[0];
            result.firstName = rawRecordArray[1];
            result.gender = rawRecordArray[2];
            result.favoriteColor = rawRecordArray[3];

            DateTime dateOfBirth;
            if (!DateTime.TryParse(rawRecordArray[4], out dateOfBirth))
                throw new InvalidDateOfBirthException(rawRecordArray[3]);
            result.dateOfBirth = dateOfBirth;

            return result;
        }
    }
}
