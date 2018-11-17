using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace BankTests
{

    [TestFixture]
    class CheckingAccountTests
    {
        private CheckingAccount sut;

        [SetUp]
        public void beforeEachTest()
        {
            sut = new CheckingAccount("Ian", 0.05);
        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(10000)]
        public void shouldWitdrawCorrectlyWithPositiveInput(double withdrawValue)
        {
            double currentBalance = sut.Balance;
            double balanceAfterWithdraw = currentBalance - withdrawValue;

            sut.Withdraw(withdrawValue);

            Assert.That(sut.Balance, Is.EqualTo(balanceAfterWithdraw));
        }

        [Test]
        [TestCase(-10)]
        public void ShouldNotWithdrawANegativeInput(double withdrawValue)
        {
            double currentBalance = sut.Balance;

            sut.Withdraw(withdrawValue);

            Assert.That(sut.Balance, Is.EqualTo(currentBalance));
        }
    }
}
