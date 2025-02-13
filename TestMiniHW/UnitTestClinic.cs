using System;
using System.IO;
using Xunit;
using miniHW_1_AslanyanDG.Services.Interfaces;
using miniHW_1_AslanyanDG.Services;
using miniHW_1_AslanyanDG.Models.Animals;
using miniHW_1_AslanyanDG.Models.Animals.Herboes;
using miniHW_1_AslanyanDG.Models.Animals.Predators;

namespace miniHW_1_AslanyanDG.Tests
{
    public class TestAnimal : Animal
    {
        public TestAnimal(string name, uint food, uint health, uint number) 
            : base(name, food, health, number)
        {
        }
    }

    public class VeterinaryClinicTests
    {
        [Fact]
        public void CheckAnimal_WithHealthAboveThreshold_ReturnsTrue()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            var healthyAnimal = new TestAnimal("Healthy Cat", 3, 7, 505);

            // Act
            bool result;
            using (var sw = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                try
                {
                    Console.SetOut(sw);
                    result = clinic.CheckAnimal(healthyAnimal);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                }
            }

            // Assert
            Assert.True(result, "Животное с уровнем здоровья 7 должно считаться здоровым (≥5)");
        }

        [Fact]
        public void CheckAnimal_WithHealthBelowThreshold_ReturnsFalse()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            var unhealthyAnimal = new TestAnimal("Weak Dog", 2, 3, 404);

            // Act
            bool result;
            using (var sw = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                try
                {
                    Console.SetOut(sw);
                    result = clinic.CheckAnimal(unhealthyAnimal);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                }
            }

            // Assert
            Assert.False(result, "Животное с уровнем здоровья 3 не должно считаться здоровым");
        }

        [Fact]
        public void CheckAnimal_Exactly5Health_ReturnsTrue()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            var borderlineAnimal = new TestAnimal("Borderline Horse", 5, 5, 101);

            // Act
            bool result;
            using (var sw = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                try
                {
                    Console.SetOut(sw);
                    result = clinic.CheckAnimal(borderlineAnimal);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                }
            }

            // Assert
            Assert.True(result, "Животное с ровно 5 здоровья тоже считается здоровым (≥5)");
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(10, true)]
        public void CheckAnimal_ReturnsExpected_WhenDifferentHealth(int health, bool expected)
        {
            var clinic = new VeterinaryClinic();
            var wolf = new Wolf("TestWolf", 3, (uint)health, 500);
            
            var result = clinic.CheckAnimal(wolf);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckAnimal_MonkeyWithHealth10_ReturnsTrue()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            var monkey = new Monkey("Strong monkey", 5, 10, 900, 5);
            
            // Act
            bool result;
            using (var sw = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                try
                {
                    Console.SetOut(sw);
                    result = clinic.CheckAnimal(monkey);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                }
            }

            // Assert
            Assert.True(result, "Животное с ровно 5 здоровья тоже считается здоровым (≥5)");
        }
        
        [Fact]
        public void CheckAnimal_WolfWithHealth0_ReturnsFalse()
        {
            // Arrange
            IVeterinaryClinic clinic = new VeterinaryClinic();
            var wolf = new Wolf("Strong wolf", 1, 0, 901);
            
            // Act
            bool result;
            using (var sw = new StringWriter())
            {
                var originalConsoleOut = Console.Out;
                try
                {
                    Console.SetOut(sw);
                    result = clinic.CheckAnimal(wolf);
                }
                finally
                {
                    Console.SetOut(originalConsoleOut);
                }
            }

            // Assert
            Assert.False(result, "Животное с уровнем здоровья 0 не здоровое");
        }
    }
}
