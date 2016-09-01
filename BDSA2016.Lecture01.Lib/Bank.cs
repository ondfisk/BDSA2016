namespace BDSA2016.Lecture01.Lib
{
    public class Bank
    {
        public int Balance { get; private set; }

        public Bank()
        {
        }

        public Bank(int amount)
        {
            Balance = amount;
        }

        public void Deposit(int amount)
        {
            checked
            {
                Balance += amount;
            }
        }
    }
}
