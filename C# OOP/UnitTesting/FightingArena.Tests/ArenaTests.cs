
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(arena.Warriors);

        }
        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }
        [Test]
        public void TestEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }
        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 1;
            Warrior warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, this.arena.Count);
        }
        [Test]
        public void TestIfEnrollIncreasesCount()
        {
            int expectedCount = 2;
            Warrior warrior = new Warrior("Pesho", 15, 100);
            this.arena.Enroll(warrior);
            Warrior warrior2 = new Warrior("GFadf", 15, 100);
            this.arena.Enroll(warrior2);
            Assert.AreEqual(expectedCount, this.arena.Count);
        }
        [Test]
        public void TestIfFightWorksCorrectly()
        {
            int expectedAttackerHP = 95;
            int expectedDefenderHP = 90;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 100);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
        [Test]

        public void TestAttackingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 100);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(()=> {
                this.arena.Fight(attacker.Name, defender.Name);
            });
        }
    }
}
