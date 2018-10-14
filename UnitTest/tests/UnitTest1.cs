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

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, 4, 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFalseIfTheDataNotValid()
        {


            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(1, 2, 3);
            Assert.AreNotEqual(expected, actual);


        }

        [TestMethod]
        public void IsFalseIfTheSideIsNegative()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, 4, -5);
            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void IsFalseIfTwoSideAreNegative()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, -4, -5);
            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        public void IsTrueIfTheSidesAreEquals()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(4, 4, 6);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsTrueIfSidesAreEquals()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(4, 4, 4);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsFalseIfTtheSideIsZero()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, 4, 0);
            Assert.AreNotEqual(expected, actual);


        }

        [TestMethod]
        public void IsFalseIfTwoSidesAreZero()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, 0, 0);
            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        public void IsFalseIfTtheSidesAreZero()
        {


            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(0, 0, 0);
            Assert.AreNotEqual(expected, actual);

        }



        [TestMethod]
        public void IsFalseIfTwoSidesEqualsToTheThird()
        {

            bool expected = true;

            Triangle result = new Triangle();

            int actual = result.Triangle(3, 7, 10);
            Assert.AreNotEqual(expected, actual);

        }

    }
}
