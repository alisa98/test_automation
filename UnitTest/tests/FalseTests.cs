using System;
using Xunit;

namespace FalseTests
{
    public class FalseTest
    {
        [Fact]
        public void IsFalseIfTheDataNotValid()
        {
            Assert.False(Triangle.IsTriangle(1, 2, 3));
        }

        [Fact]
        public void IsFalseIfTheSideIsNegative()
        {
            Assert.False(Triangle.IsTriangle(3, 4, -5));
        }

        [Fact]
        public void IsFalseIfTwoSideAreNegative()
        {
            Assert.False(Triangle.IsTriangle(3, -4, -5));
        }

        [Fact]
        public void IsFalseIfTtheSideIsZero()
        {
            Assert.False(Triangle.IsTriangle(3, 4, 0));
        }

        [Fact]
        public void IsFalseIfTwoSidesAreZero()
        {
            Assert.False(Triangle.IsTriangle(3, 0, 0));
        }

        [Fact]
        public void IsFalseIfTtheSidesAreZero()
        {
            Assert.False(Triangle.IsTriangle(0, 0, 0));
        }

        [Fact]
        public void IsFalseIfTwoSidesEqualsToTheThird()
        {
            Assert.False(Triangle.IsTriangle(3, 7, 10));
        }

    }
}
