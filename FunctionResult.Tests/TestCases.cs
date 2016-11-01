using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionResult.Tests.Classes;
using CestnoSoftware;

namespace FunctionResult.Tests
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public void Successful_Result()
        {
            var srv = new MyService();

            var addnums = srv.AddTwoNumbers(5, 5);

            Assert.IsTrue(addnums.WasSuccessful);
            Assert.IsTrue(addnums.ReturnValue == 10);
        }

        [TestMethod]
        public void Failed_Result()
        {
            var srv = new MyService();

            var dividenums = srv.DivideTwoNumbers(5, 0);

            Assert.IsFalse(dividenums.WasSuccessful);
            Assert.IsTrue(dividenums.Messages.Count == 1);
            Assert.IsTrue(dividenums.Messages[0].Message.StartsWith("Y can not be 0"));
        }

        [TestMethod]
        public void Failed_Result_Validation_Error()
        {
            var srv = new MyService();

            var addevennums = srv.AddTwoEvenNumbers(2, 5);

            Assert.IsFalse(addevennums.WasSuccessful);
            Assert.IsTrue(addevennums.Messages.Count == 1);
            Assert.IsTrue(addevennums.Messages[0].MessageType ==  FunctionResultMessageTypes.Validation);
            Assert.IsTrue(addevennums.Messages[0].FieldName == "Y");

        }
       
    }
}
