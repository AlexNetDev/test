using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class TriangleByThreeSidesTests
    {
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void Ctor_CalledWithInvalidSideLength_ThrowsArgumentException(double side)
        {
            // Act
            Action actA = () => new TriangleByThreeSides(side, 1.0, 2.0);
            Action actB = () => new TriangleByThreeSides(1.0, side, 2.0);
            Action actC = () => new TriangleByThreeSides(1.0, 2.0, side);

            // Assert
            actA.Should().Throw<ArgumentException>()
                .WithMessage("Argument 'a' should be greater than '0'.");
            actB.Should().Throw<ArgumentException>()
                .WithMessage("Argument 'b' should be greater than '0'.");
            actC.Should().Throw<ArgumentException>()
                .WithMessage("Argument 'c' should be greater than '0'.");
        }

        [Test]
        public void Ctor_CalledWithInvalidSideLengths_ThrowsArgumentException()
        {
            // Act
            Action act = () => new TriangleByThreeSides(1.0, 2.0, 3.0);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("The sum of the lengths of any two sides of a triangle is greater than the length of the third side.");
        }

        [Test]
        public void Ctor_SetsProperties()
        {
            // Act
            TriangleByThreeSides sut = new TriangleByThreeSides(3.0, 4.0, 5.0);

            // Assert
            sut.A.Should().Be(3.0);
            sut.B.Should().Be(4.0);
            sut.C.Should().Be(5.0);
        }

        [Test]
        public void CalculateArea_ReturnsExpectedValue()
        {
            // Arrange
            TriangleByThreeSides sut = new TriangleByThreeSides(3.0, 4.0, 5.0);

            // Act
            double actual = sut.CalculateArea();

            // Assert
            double expected = 6.0;
            Tolerance.AreEqual(actual, expected).Should().BeTrue();
        }
    }
}
