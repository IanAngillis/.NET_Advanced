using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using NUnit.Framework;

namespace BankTests
{
    [TestFixture]
    class SavingsAccountTests
    {
        private SavingsAccount sut;

        [SetUp]
        public void beforeEachTest()
        {
            sut = new SavingsAccount("Ian", 0.05);
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

        [Test]
        public void SavingAccountShouldAddInterestCorrectly()
        {
            sut.AddInterests();

            Assert.That(sut.Balance, Is.EqualTo(105));
        }
    }
}
