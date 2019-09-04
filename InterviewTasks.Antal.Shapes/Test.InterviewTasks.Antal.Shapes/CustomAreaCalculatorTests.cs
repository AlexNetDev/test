using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class CustomAreaCalculatorTests
    {
        [Test]
        public void Ctor_CalledWithNullFormula_ThrowsArgumentNullException()
        {
            // Arrange
            Func<IReadOnlyList<double>, double> formula = null;
            double[] arguments = new double[0];

            // Act
            Action act = () => new CustomAreaCalculator(formula, arguments);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("*Argument 'formula' can not be 'null'.");
        }

        [Test]
        public void Ctor_CalledWithNullArguments_ThrowsArgumentNullException()
        {
            // Arrange
            double formula(IReadOnlyList<double> args) => -1;
            double[] arguments = null;

            // Act
            Action act = () => new CustomAreaCalculator(formula, arguments);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("*Argument 'arguments' can not be 'null'.");
        }

        [Test]
        public void Ctor_CalledWithNotNullParameters_DoesNotThrowArgumentNullException()
        {
            // Arrange
            double formula(IReadOnlyList<double> args) => -1;
            double[] arguments = new double[0];

            // Act
            Action act = () => new CustomAreaCalculator(formula, arguments);

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void Ctor_SetsProperties()
        {
            // Arrange
            Func<IReadOnlyList<double>, double> formula = (args) => -1;
            double[] arguments = new double[] { 1.0, 2.0, 3.0 };

            // Act
            CustomAreaCalculator sut = new CustomAreaCalculator(formula, arguments);

            // Assert
            sut.Formula.Should().Be(formula);
            sut.Arguments.Should().BeEquivalentTo(arguments);
        }

        [Test]
        public void Arguments_AreNotAffectedAfterCreation()
        {
            // Arrange
            double formula(IReadOnlyList<double> args) => -1;
            double[] arguments = new double[] { 1.0, 2.0, 3.0 };
            CustomAreaCalculator sut = new CustomAreaCalculator(formula, arguments);

            // Act
            arguments[0] = 0.0;

            // Assert
            sut.Arguments[0].Should().Be(1.0);
        }

        [Test]
        public void CalculateArea_ReturnsExpectedValue()
        {
            // Arrange
            double formula(IReadOnlyList<double> args) => (args[0] + args[1]) * args[2];
            double[] arguments = new double[] { 1.0, 2.0, 3.0 };
            CustomAreaCalculator sut = new CustomAreaCalculator(formula, arguments);

            // Act
            double actual = sut.CalculateArea();

            // Assert
            double expected = 9.0;
            Tolerance.AreEqual(actual, expected).Should().BeTrue();
        }
    }
}
