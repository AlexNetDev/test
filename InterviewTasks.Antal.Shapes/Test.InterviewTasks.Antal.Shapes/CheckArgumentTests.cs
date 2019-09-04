using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class CheckArgumentTests
    {
        [Test]
        public void NotNull_CalledWithNull_ThrowsArgumentNullException()
        {
            // Arrange
            object arg = null;

            // Act
            Action act = () => CheckArgument.NotNull(arg, nameof(arg));

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .WithMessage("*Argument 'arg' can not be 'null'.");
        }

        [Test]
        public void NotNull_CalledWithNotNull_DoesNotThrowArgumentNullException()
        {
            // Arrange
            object arg = new object();

            // Act
            Action act = () => CheckArgument.NotNull(arg, nameof(arg));

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void GreaterThanZero_CalledWithZeroOrLess_ThrowsArgumentException(double arg)
        {
            // Act
            Action act = () => CheckArgument.GreaterThanZero(arg, nameof(arg));

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Argument 'arg' should be greater than '0'.");
        }

        [Test]
        public void GreaterThanZero_CalledWithGreaterThanZero_DoesNotThrowArgumentException()
        {
            // Arrange
            double arg = .1;

            // Act
            Action act = () => CheckArgument.GreaterThanZero(arg, nameof(arg));

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
