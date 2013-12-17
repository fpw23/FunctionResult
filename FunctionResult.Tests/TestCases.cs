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
            Assert.IsTrue(dividenums.OperationStatus == CestnoSoftware.FunctionResultOperationStatus.FailureExceptions);
        }

        [TestMethod]
        public void Failed_Result_Validation_Error()
        {
            var srv = new MyService();

            var addevennums = srv.AddTwoEvenNumbers(2, 5);

            if (!addevennums.WasSuccessful)
            {
                switch (addevennums.OperationStatus)
                {
                    case FunctionResultOperationStatus.FailureExceptions:
                        //Show error messages
                        break;

                    case FunctionResultOperationStatus.FailureValidtion:
                        //Apply validation errors messages to fields on page
                        break;

                    case FunctionResultOperationStatus.SuccessWarnings:
                        //Finish the operation but warn the user about the possible problem
                        break;

                }
            }

            Assert.IsFalse(addevennums.WasSuccessful);
            Assert.IsTrue(addevennums.OperationStatus == FunctionResultOperationStatus.FailureValidtion);

        }

        [TestMethod]
        public void Failed_Result_ThrowEx_NoCheck_WasSuccessful()
        {
            var srv = new MyService();

            var dividenums = srv.DivideTwoNumbers(5, 0);

            try
            {
                var myresult = dividenums.ReturnValue;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FunctionResultUncheckedException));
            }
        }
    }
}
