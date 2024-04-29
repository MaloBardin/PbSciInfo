using td1;
namespace PIXEL_Test
{
    [TestClass]
    public class PixelTests
    {
        [TestMethod]
        public void TestPixelCreation()
        {
            // Arrange
            byte bleu = 50;
            byte vert = 100;
            byte rouge = 150;

            // Act
            Pixel pixel = new Pixel(bleu, vert, rouge);

            // Assert
            Assert.AreEqual(rouge, pixel.R);
            Assert.AreEqual(vert, pixel.G);
            Assert.AreEqual(bleu, pixel.B);
        }

        [TestMethod]
        public void TestPixelInitialisationProprietes()
        {
            // Arrange
            byte initbleu = 50;
            byte initvert = 100;
            byte initrouge = 150;
            Pixel pixel = new Pixel(initbleu, initvert, initrouge);

            // Act
            pixel.R = 200;
            pixel.G = 250;
            pixel.B = 300;  // Note that this will wrap around since byte max value is 255

            // Assert
            Assert.AreEqual(200, pixel.R);
            Assert.AreEqual(250, pixel.G);
            Assert.AreEqual(44, pixel.B);  // 300 % 256 = 44
        }

        [TestMethod]
        public void TestPixelToString()
        {
            // Arrange
            Pixel pixel = new Pixel(255, 0, 128);

            // Act
            string result = pixel.toString();

            // Assert
            Assert.AreEqual("R128 G0 B255", result);
        }
    }
}
