namespace Hero.Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public const int DefaultExperience = 100; 
        public int GiveExperience() => 100;

        public bool IsDead() => true;

        public void TakeAttack(int damage)
        {
            
        }
       
    }
}
