using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.Tests
{
    [TestFixtureAttribute]
    public class CalculatorTest
    {
        [Test]
        public void Add_ShouldCorrectlyAddTwoNumbers()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            int result = sut.Add(1, 3);

            //Assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Add_ShouldThrowExceptionForNegativeArguments()
        {
            //Arrange
            var sut = new Calculator();

            //Act + Assert
            Assert.That(() => sut.Add(-1, -3), Throws.InstanceOf<ArgumentException>()); //Lambda expressies, delegates (derde type), anonieme functies
            
        }
    }
}
