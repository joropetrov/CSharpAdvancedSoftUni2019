namespace Hero.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetDummies()
        {
            this.aliveDummy = new Dummy(100, 200);
            this.deadDummy = new Dummy(0, 200);
        }

        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            //Act
            this.aliveDummy.TakeAttack(30);

            //Assert
            Assert.That(aliveDummy.Health, Is.EqualTo(70));
        }

        [Test]
        public void DummmyThrowsExceptionIfAttackedWithoutHealth()
        {
            Assert.That(() => deadDummy.TakeAttack(50),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DummySgouldGiveExperienceIfDead()
        {
            var experience = deadDummy.GiveExperience();

            Assert.That(experience, Is.EqualTo(200));
        }

        [Test]
        public void DummySgouldNOTgiveExperienceIfAlive()
        {
            Assert.That(() => aliveDummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
