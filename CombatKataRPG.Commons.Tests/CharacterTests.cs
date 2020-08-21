using System;
using System.Collections.Generic;
using CombatKataRPG.Commons.Models;
using Xunit;

namespace CombatKataRPG.Commons.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void Character_ShoudStartWhithOneHundredLifePoints()
        {
            var characther = new Character("Character 1");
            Assert.Equal(1000, characther.LifePoints);
        }

        [Fact]
        public void Character_ShoudStartLevelOne()
        {
            var characther = new Character("Character 1");
            Assert.Equal(1, characther.Level);
        }

        [Fact]
        public void Character_ShoudStartAlive()
        {
            var characther = new Character("Character 1");
            Assert.Equal(true, characther.IsAlive);
        }

        [Fact]
        public void Character_ShoudHaveARange()
        {
            var characther = new Character("Character 1");
            Assert.NotNull(characther.MaxRange);
        }

        [Theory]
        [InlineData(50, 51)]
        [InlineData(50, 49)]
        [InlineData(0, 1)]
        [InlineData(1000, 500)]
        public void Character_IsDeadIfTheHitsIsGratterThanHisLife(long currentLifePoints, long currentDamage)
        {
            var charactherAggressor = new Character("Aggressor");
            var charactherReceiver = new Character("Receiver");
            charactherReceiver.LifePoints = currentLifePoints;

            var characters = new List<Character>();
            characters.Add(charactherReceiver);
            
            charactherAggressor.DealDamage(characters, currentDamage);

            if(currentDamage > currentLifePoints)
                Assert.Equal(false, charactherReceiver.IsAlive);
            else
                Assert.Equal(true, charactherReceiver.IsAlive);
        }

        [Theory]
        [InlineData(39, 38)]
        public void Character_ShouldGrantDealsDamage(long currentLifePoints, long currentDamage)
        {
            var charactherAggressor = new Character("Aggressor");
            var charactherReceiver = new Character("Receiver");
            charactherReceiver.LifePoints = currentLifePoints;

            var characters = new List<Character>();
            characters.Add(charactherReceiver);

            charactherAggressor.DealDamage(characters, currentDamage);
            Assert.Equal(1, charactherReceiver.LifePoints);
        }

        [Theory]
        [InlineData(40, 10, 7)]
        [InlineData(40, 10, 2)]
        public void Character_ShouldGrantDealsHalfDamageOnHigherLevels(long currentLifePoints, long currentDamage, int receiverLevel)
        {
            var charactherAggressor = new Character("Aggressor");
            var charactherReceiver = new Character("Receiver");
            charactherReceiver.LifePoints = currentLifePoints;
            charactherReceiver.Level = receiverLevel;

            var characters = new List<Character>();
            characters.Add(charactherReceiver);

            charactherAggressor.DealDamage(characters, currentDamage);

            if(charactherReceiver.Level > charactherAggressor.Level + 5)
                Assert.Equal(charactherReceiver.LifePoints, currentLifePoints - (currentDamage / 2));
            else if(charactherReceiver.Level > charactherAggressor.Level - 5)
                Assert.Equal(charactherReceiver.LifePoints, currentLifePoints - (currentDamage * 2));
            else
                Assert.Equal(charactherReceiver.LifePoints, currentLifePoints - currentDamage);
            
        }
        
        [Theory]
        [InlineData(39, 38)]
        public void Character_ShouldNotDealDamageItself(long currentLifePoints, long currentDamage)
        {
            var charactherAggressor = new Character("Aggressor");
            charactherAggressor.LifePoints = currentLifePoints;

            var characters = new List<Character>();
            characters.Add(charactherAggressor);
            
            charactherAggressor.DealDamage(characters, currentDamage);
            Assert.Equal(currentLifePoints, charactherAggressor.LifePoints);
        }
        
        [Theory]
        [InlineData(500, 900)]
        [InlineData(1000, 1)]
        [InlineData(0, 10001)]
        public void Character_NotHealGreatterThanMax(long currentLifePoints, long currentHealing)
        {
            var charactherReceiver = new Character("Receiver");
            charactherReceiver.LifePoints = currentLifePoints;
            
            charactherReceiver.HealAmount(currentHealing);

            if((currentHealing + currentLifePoints) >= 1000 )
                Assert.Equal(1000, charactherReceiver.LifePoints);
            else
                Assert.Equal((currentHealing + currentLifePoints), charactherReceiver.LifePoints);
        }
    }
}
