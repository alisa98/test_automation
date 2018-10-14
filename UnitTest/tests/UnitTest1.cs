using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void IsTrueIfTheDataValid()
        {
                Assert.AreEqual(Triangle.IsTriangle(3,4,5));
        }

        [TestMethod]
        public void IsFalseIfTheDataNotValid()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(1,2,3));

        }

        [TestMethod]
        public void IsFalseIfTheSideIsNegative()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(3, 4, -5 ));

        }

        [TestMethod]
        public void IsFalseIfTwoSideAreNegative()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(3, -4, -5));

        }


        [TestMethod]
        public void IsTrueIfTheSidesAreEquals()
        {
            Assert.AreEqual(Triangle.IsTriangle(4, 4, 6));
        }

        [TestMethod]
        public void IsTrueIfSidesAreEquals()
        {
            Assert.AreEqual(Triangle.IsTriangle(4, 4, 4));
        }

        [TestMethod]
        public void IsFalseIfTtheSideIsZero()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(3, 4, 0));
        }

        [TestMethod]
        public void IsFalseIfTwoSidesAreZero()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(3, 0, 0));
        }


        [TestMethod]
        public void IsFalseIfTtheSidesAreZero()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(0, 0, 0));
        }
      


        [TestMethod]
        public void IsFalseIfTwoSidesEqualsToTheThird()
        {
            Assert.AreNotEqual(Triangle.IsTriangle(3, 7, 10));
        }



    }
}
