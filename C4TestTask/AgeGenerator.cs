using System;

namespace C4TestTask
{
    class AgeGenerator
    {
        // вычесляенм возраст сотрудника
      public static int ReturnAge(string birthdate)
        {
            DateTime today = DateTime.Today;
            DateTime birth = DateTime.Parse(birthdate);

            int age = today.Year - birth.Year;
            //если человек родился в високосном году
            if (birth > today.AddYears(-age)) age--;

            return age;
        }
    }
}
