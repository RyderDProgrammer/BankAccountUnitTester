﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountUnitTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountUnitTester.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;
        [TestInitialize]
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod]
        //[TestCategory("Deposit")]
        //[Priority(1)]
        [DataRow(10000)]
        [DataRow(10001)]
        [DataRow(10000.01)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        //[TestCategory("Deposit")]
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(.01)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            //AAA - Arrange Act Assert

            //Arrange - Creating variables/object
            const double startBalance = 0;

            //Act - Execute method under test
            acc.Deposit(initialDeposit);

            //Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod()]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            //Arrange
            const double initialBal = 0;
            const double depositAmt = 10.55;

            //Act
            double newBalance = acc.Deposit(depositAmt);

            //Assert
            const double expectedBalance = initialBal + depositAmt;
            Assert.AreEqual(expectedBalance, newBalance);

        }

        //Test - for multiple deposits
        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            //Arrange
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;

            //Act
            double intermediateBalance = acc.Deposit(deposit1);
            double finalBalance = acc.Deposit(deposit2);

            //Assert
            Assert.AreEqual(deposit1, intermediateBalance);
            Assert.AreEqual(expectedBalance, finalBalance);
        }
        //Test - for negative deposits
        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            //Arrange
            double negativeDep = -5;

            //Assert and acting here
            Assert.ThrowsException<ArgumentException>
            (
                () => acc.Deposit(negativeDep)
            );
        }

        [TestMethod]
        [DataRow(100,50)]
        [DataRow(100,100)]
        [DataRow(9.99,9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {
            //double initialBalance = 0;
            //An account created with the default constructor has a 0 balance
            Account myAccount = new Account();
            double withdrawAmount = 1;
            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            double negativeWith = -5;

            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(negativeWith));
        }
    }
}