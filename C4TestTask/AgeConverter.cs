using System;

namespace C4TestTask
{
    class AgeConverter
    {
      public static int? ReturnAge(string birthdate)
        {
            if (birthdate == null){return null;}

            DateTime today = DateTime.Today;
            DateTime birth = DateTime.Parse(birthdate);

            int age = today.Year - birth.Year;
            //если человек родился в високосном году
            if (birth > today.AddYears(-age)) age--;

            return age;
        }
    }
}
