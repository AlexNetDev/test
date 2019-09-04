using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class CircleByRadiusTests
    {
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void Ctor_CalledWithInvalidRadius_ThrowsArgumentException(double radius)
        {
            // Act
            Action act = () => new CircleByRadius(radius);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Argument 'radius' should be greater than '0'.");
        }

        [Test]
        public void Ctor_CalledWithValidRadius_DoesNotThrowArgumentException()
        {
            // Arrange
            double radius = .1;

            // Act
            Action act = () => new CircleByRadius(radius);

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void Ctor_SetsRadius()
        {
            // Arrange
            double radius = .1;

            // Act
            CircleByRadius sut = new CircleByRadius(radius);

            // Assert
            sut.Radius.Should().Be(radius);
        }

        [TestCase(1.0, 3.14159265358)]
        [TestCase(2.0, 12.5663706143)]
        public void CalculateArea_ReturnsExpectedValue(double radius, double expected)
        {
            // Arrange
            CircleByRadius sut = new CircleByRadius(radius);

            // Act
            double actual = sut.CalculateArea();

            // Assert
            Tolerance.AreEqual(actual, expected).Should().BeTrue();
        }
    }
}
