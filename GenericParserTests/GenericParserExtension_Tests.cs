using GenericParser;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GenericParserTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test_string_to_datetimeoffset()
        {
            DateTimeOffset testoffset = "2/12/2021".ConvertTo<DateTimeOffset>();

            Assert.That(testoffset, Is.EqualTo(new DateTimeOffset(new DateTime(2021,12,2,0,0,0, DateTimeKind.Local))));

            DateTimeOffset testoffset2 = "2021-12-02T02:36:17+0000".ConvertTo<DateTimeOffset>();

            Assert.That(testoffset2, Is.EqualTo(new DateTimeOffset(2021, 12, 2, 2, 36, 17, 0, TimeSpan.Zero)));
        }

        [Test]
        public void Test_string_to_datetime()
        {
            DateTime testoffset = "2/12/2021".ConvertTo<DateTime>();

            Assert.That(testoffset, Is.EqualTo(new DateTime(2021, 12, 2, 0, 0, 0)));
        }

        public static IEnumerable<TestCase<int>> GetIntTestCases()
        {            
            yield return new TestCase<int>("123", expectedValue: 123);
            yield return new TestCase<int>(null) { DefaultValue = -1 };
            yield return new TestCase<int>("steve") { DefaultValue = -2 };
        } 

        [TestCaseSource(nameof(GetIntTestCases))]
        public void Test_non_int_to_int(TestCase<int> test)
        {
            int testInt = test.TestValue.ConvertTo(test.DefaultValue);

            Assert.That(testInt, Is.EqualTo(test.ExpectedValue).Or.EqualTo(test.DefaultValue));
        }

        [Test]
        public void Test_int_to_int()
        {
            int testInt = 1.ConvertTo();

            Assert.That(testInt, Is.EqualTo(1));
        }

        public static IEnumerable<TestCase<int?>> GetNullableIntTestCases()
        {
            yield return new TestCase<int?>("123", expectedValue: 123);
            yield return new TestCase<int?>(null) { DefaultValue = -1 };
            yield return new TestCase<int?>("steve") { DefaultValue = -2 };
        }

        [TestCaseSource(nameof(GetNullableIntTestCases))]
        public void Test_non_int_to_nullable_int(TestCase<int?> test)
        {
            int? testInt = test.TestValue.ConvertTo(test.DefaultValue);

            Assert.That(testInt, Is.EqualTo(test.ExpectedValue).Or.EqualTo(test.DefaultValue));
        }

        [Test]
        public void Test_nullable_int_to_nullable_int()
        {
            int? testInt = 1.ConvertTo();

            Assert.That(testInt, Is.EqualTo(1));
        }
    }
}