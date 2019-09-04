using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class TriangleByThreeSidesExtensionsTests
    {
        [Test]
        public void IsRectangular_CalledWithNull_ThrowsArgumentNullException()
        {
            // Arrange
            TriangleByThreeSides sut = null;

            // Act
            Action act = () => sut.IsRectangular();

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("*Argument 'triangle' can not be 'null'.");
        }

        [Test]
        public void IsRectangular_WithRectangularTriangle_ReturnsTrue()
        {
            // Arrange
            TriangleByThreeSides sut = new TriangleByThreeSides(3.0, 4.0, 5.0);

            // Act
            bool actual = sut.IsRectangular();

            // Assert
            actual.Should().BeTrue();
        }

        [Test]
        public void IsRectangular_WithNonRectangularTriangle_ReturnsFalse()
        {
            // Arrange
            TriangleByThreeSides sut = new TriangleByThreeSides(3.0, 4.0, 6.0);

            // Act
            bool actual = sut.IsRectangular();

            // Assert
            actual.Should().BeFalse();
        }
    }
}
