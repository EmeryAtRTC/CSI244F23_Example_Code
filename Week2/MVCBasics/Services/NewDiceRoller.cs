namespace MVCBasics.Services
{
    public class NewDiceRoller : IDiceRoller
    {
        public int RollDice()
        {
            //Just pretend with me that we make a cool new random number generator
            return Math.Abs((int)DateTime.Now.Ticks % 6) + 1;
        }
    }
}
