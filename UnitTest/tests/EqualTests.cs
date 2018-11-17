using System;
using Xunit;
using lab_xUnit;

namespace lab_xUnit
{
    public class EqualTests
    {
        public class TriangleTest
        {

            [Fact]
            public void IsTrueIfTheDataValid()
            {
                bool expected = true;
                bool actual = Triangle.IsTriangle(3, 4, 5);
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public void IsTrueIfTheSidesAreEquals()
        {
            bool expected = true;
            bool actual = Triangle.IsTriangle(4, 4, 6);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsTrueIfSidesAreEquals()
        {
            bool expected = true;
            bool actual = Triangle.IsTriangle(4, 4, 4);
            Assert.Equal(expected, actual);
        }

    }
}

