namespace Hero.Tests
{
    using NUnit.Framework;
    using Fakes;
  
    [TestFixture]
    public class Tests
    {
        [Test]
        public void HeroShouldGainExpIfTargetDies()
        {
            var weapon = new FakeWeapon();
            var target = new FakeTarget();
            var hero = new Hero("TestHero", weapon);

            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DefaultExperience));
        }
    }
}