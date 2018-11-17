using System;

namespace console
{
    public class Calculator //Internal: Enkel klassen in deze solution/project gaan de klassen zien
    {
        public Calculator()
        {
        }

        public  int Add(int v1, int v2)
        {

            if(v1 < 0 || v2 < 0)
            {
                throw new ArgumentException();
            }

            return v1 + v2;
        }
    }
}