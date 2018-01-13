using HiperStreamInvoice.Core;
using Xunit;

namespace HiperStreamInvoice.Tests
{
    public class UnitTests
    {
        private readonly IInvoice _invoice;
        public UnitTests()
        {
            _invoice = new Invoice();
        }

        [Fact]
        public void TestQutd()
        {
           int regsLidos = _invoice.Process(@"..\..\..\..\HiperStreamInvoice.Core\Baseficticia.txt");

            Assert.Equal(5000, regsLidos);
        }
    }
}
