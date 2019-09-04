using FluentAssertions;
using InterviewTasks.Antal.Shapes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test.InterviewTasks.Antal.Shapes
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void SkipAt_CalledWithNull_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<int> collection = null;

            // Act
            Action act = () => collection.SkipAt(-1);

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .WithMessage("*Argument 'collection' can not be 'null'.");
        }

        [Test]
        public void SkipAt_CalledWithNotNull_DoesNotThrowArgumentNullException()
        {
            // Arrange
            IEnumerable<int> collection = new int[0];

            // Act
            Action act = () => collection.SkipAt(-1);

            // Assert
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Test]
        public void SkipAt_ReturnsExpectedValue()
        {
            // Arrange
            IEnumerable<int> collection = new[] { 1, 2, 3 };

            // Act
            IEnumerable<int> actual = collection.SkipAt(1);

            // Assert
            IEnumerable<int> expected = new[] { 1, 3 };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
