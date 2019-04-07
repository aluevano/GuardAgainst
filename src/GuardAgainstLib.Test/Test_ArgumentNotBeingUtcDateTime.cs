﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentNotBeingUtcDateTime : TestBase
    {
        public Test_ArgumentNotBeingUtcDateTime(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentValueIsLocal_ShouldThrowArgumentException()
        {
            var myArgument = DateTime.Now;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentNotBeingUtcDateTime(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentValueIsUnspecified_ShouldThrowArgumentException()
        {
            var myArgument = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentNotBeingUtcDateTime(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentValueIsUtc_ShouldNotBeSlow()
        {
            var myArgument = DateTime.UtcNow;

            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentNotBeingUtcDateTime(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentValueIsUtc_ShouldNotThrow()
        {
            var myArgument = DateTime.UtcNow;

            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentNotBeingUtcDateTime(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }
    }
}
