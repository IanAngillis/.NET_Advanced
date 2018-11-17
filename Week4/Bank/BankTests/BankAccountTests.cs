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
    class BankAccountTests
    {
        private CheckingAccount sut;

        [SetUp]
        public void BeforeEachTest()
        {
            sut = new CheckingAccount("Ian", 0.05);
        }

        [Test]
        public void AccountShouldAddInterestCorrectly()
        {
            sut.AddInterests();

            Assert.That(sut.Balance, Is.EqualTo(105));
        }

        [Test]
        public void ShouldDepositCorrectly()
        {
            sut.Deposit(10);

            Assert.That(sut.Balance, Is.EqualTo(110));
        }

        [Test]
        public void ShouldNotDepositWhenAmountIsNegative()
        {
            double expectedBalance = sut.Balance;
            sut.Deposit(-10);

            Assert.That(sut.Balance, Is.EqualTo(expectedBalance));
        }
    }

}
