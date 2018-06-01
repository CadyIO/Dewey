using Dewey.Types;
using Xunit;

namespace Dewey.Test
{
    public class DecimalExtensionsTest
    {
        [Fact]
        public void NumberToCurrencyText() => Assert.Equal("Ten Dollars and No Cents", 10m.NumberToCurrencyText());

        [Fact]
        public void IsBefore()
        {
            Assert.True(5.IsBefore(10));
            Assert.False(10.IsBefore(5));
        }

        [Fact]
        public void IsAfter()
        {
            Assert.True(10.IsAfter(5));
            Assert.False(5.IsAfter(10));
        }

        [Fact]
        public void AddDecimal()
        {
            // Add two decimals.
            Assert.Equal(10m, 5m.Add(5m));

            // Chain add decimals.
            Assert.Equal(15m, 5m.Add(5m).Add(5m));
        }
    }
}
