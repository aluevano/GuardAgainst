﻿using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingLessThanMinimum : TestBase
    {
        public TestArgumentBeingLessThanMinimum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = "B";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B", nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrowException()
        {
            var myArgument= default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B", nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenMinimumValueIsNull_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, null, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }
    }
}
