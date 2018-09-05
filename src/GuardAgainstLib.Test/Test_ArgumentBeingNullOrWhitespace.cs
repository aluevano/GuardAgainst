using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrWhitespace
    {
        [Fact]
        public void WhenArgumentExpressionIsNotNullOrWhitespace_ShouldNotThrow()
        {
            var myArgument = " blah ";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(() => myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(() => myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentExpressionIsWhitespace_ShouldThrowArgumentException()
        {
            var myArgument = "  ";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(() => myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNullOrWhitespace_ShouldNotThrow()
        {
            var myArgument = " blah ";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
        {
            var myArgument = "  ";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}