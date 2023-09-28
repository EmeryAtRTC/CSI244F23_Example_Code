namespace MVCBasics.Services
{
    public class DiceRoller : IDiceRoller
    {
        //field
        Random rand;
        //constructors assign values to the fields
        public DiceRoller()
        {
            rand = new Random();
        }

        public int RollDice()
        {
            return rand.Next(1, 7);
        }
    }
}
