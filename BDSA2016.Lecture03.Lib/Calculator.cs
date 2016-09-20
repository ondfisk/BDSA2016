namespace BDSA2016.Lecture03.Lib
{
    public class Calculator
    {
        public int CurrentValue { get; private set; }

        public Calculator()
        {
        }

        public Calculator(int startValue)
        {
            CurrentValue = startValue;
        }

        public int Add(int x)
        {
            checked
            {
                CurrentValue += x;
            }

            return CurrentValue;
        }

        public int Invert() => CurrentValue = -CurrentValue;
    }
}
