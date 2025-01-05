namespace Ezh.Tests
{

    public class Tests
    {
        private IColorTransformer _transformer;

        [SetUp]
        public void Setup()
        {
            _transformer = ColorTransformer.Instance;
        }

        [Test]
        public void Transform_AllAlreadyTargetColor_ReturnsZero()
        {
            int[] population = { 5, 0, 0 };
            int targetColor = 0;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Transform_NoWayToTransform_ReturnsMinusOne()
        {
            int[] population = { 0, 5, 0 };
            int targetColor = 0;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Transform_ValidTransformation_ReturnsCorrectMeetingCount()
        {
            int[] population = { 3, 3, 1 };
            int targetColor = 2;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Transform_ComplexPopulation_ReturnsCorrectMeetingCount()
        {
            int[] population = { 6, 6, 9 };
            int targetColor = 2;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Transform_SingleColorPopulation_ReturnsMinusOne()
        {
            int[] population = { 0, 0, 7 };
            int targetColor = 0;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Transform_ZeroPopulation_ReturnsZero()
        {
            int[] population = { 0, 0, 0 };
            int targetColor = 0;

            int result = _transformer.Transform(population, targetColor);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}