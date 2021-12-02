using System.Collections.Generic;

namespace GenericParserTests
{
    public class TestCase<T>
    {
        public object TestValue { get; }
        public T ExpectedValue { get; }
        public T DefaultValue { get; set; }

        public TestCase(object testValue, T expectedValue = default, T defaultValue = default)
        {
            this.TestValue = testValue;
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
            return $"TestCase(testValue:{TestValue}, expectedValue:{ExpectedValue}, DefaultValue:{DefaultValue})";
        }
    }
}
