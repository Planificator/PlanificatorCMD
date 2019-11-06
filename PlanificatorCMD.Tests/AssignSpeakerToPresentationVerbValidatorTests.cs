using Xunit;
using Moq;
using PlanificatorCMD.Validators;

namespace PlanificatorCMD.Tests
{
    public class AssignSpeakerToPresentationVerbValidatorTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(9, 10)]
        [InlineData(20, 20)]
        public void IsValid_ReturnsTrue_WithValidIndexAndCount(int index, int totalCount)
        {
            var expected = true;

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();
            var actual = sut.IsValid(index, totalCount);

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(-1, 1)]
        [InlineData(-1, 0)]
        [InlineData(20, 19)]
        [InlineData(-3, 0)]
        [InlineData(-10, -5)]
        public void IsValid_ReturnsFalse_WithInvalidIndexAndCount(int index, int totalCount)
        {
            var expected = false;

            AssignSpeakerToPresentationVerbValidator sut = new AssignSpeakerToPresentationVerbValidator();
            var actual = sut.IsValid(index, totalCount);

            Assert.Equal(actual, expected);
        }
    }
}
