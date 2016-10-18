using System;
using Dewey.Exceptions;
using Xunit;

namespace Dewey.Tests.Dewey
{
    public class ExceptionTests
    {
        [Fact]
        public void NotFoundExceptionTest()
        {
            try {
                throw new NotFoundException();
            } catch(Exception ex) {
                Assert.True(ex is NotFoundException);
            }
        }

        [Fact]
        public void UniqueExceptionTest()
        {
            try {
                throw new UniqueException();
            } catch (Exception ex) {
                Assert.True(ex is UniqueException);
            }
        }
    }
}
