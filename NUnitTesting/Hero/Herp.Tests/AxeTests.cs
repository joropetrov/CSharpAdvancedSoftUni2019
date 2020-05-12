namespace Hero.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private Dummy target;
        private const int AttackPoints = 10;

        [SetUp]
        public void SetDummy() => this.target = new Dummy(100, 500);

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //Assert
            var axe = new Axe(AttackPoints, 5);
            
            //Act
            axe.Attack(target);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
        }

        [Test]
        
        public void AxeShouldThrowExceptionIfAttackIsMadeWithBrokenWeapon()
        {
            Assert.Throws<InvalidOperationException >(() =>
            {
                //Assert
                var axe = new Axe(AttackPoints, 0);
               
                //Act
                axe.Attack(target);
            }, "Axe is broken");
        }
    }
}
