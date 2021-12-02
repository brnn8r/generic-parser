using GenericParser;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace generic_parser_tests
{
    [TestFixture]
    public class Tests
    {

        public class TestCase<T>
        {
            public object O { get; }
            public T ExpectedValue { get; }
  
            public T DefaultValue { get; set; }            

            public TestCase(object o, T expectedValue = default, T defaultValue = default)
            {
                this.O = o;                
                DefaultValue = defaultValue;

                if (EqualityComparer<T>.Default.Equals(expectedValue, default))
                {
                    ExpectedValue = DefaultValue;
                }
                else
                {
                    ExpectedValue = expectedValue;
                }
            }

            public override string ToString()
            {
                return $"TestCase(o:{O}, d:{DefaultValue})";
            }
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
            int testInt = test.O.ConvertTo(test.DefaultValue);

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
            int? testInt = test.O.ConvertTo(test.DefaultValue);

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