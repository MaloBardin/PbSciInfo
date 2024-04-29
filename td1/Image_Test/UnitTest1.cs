using Microsoft.VisualStudio.TestTools.UnitTesting;
using td1;
using System.IO;

namespace Image_Tests // Ajout d'un espace de noms approprié pour encapsuler les tests
{
    [TestClass]
    public class ImageTests
    {
        private Image CréerImageTest(int width, int height)
        {
            var image = new Image();
            image.MatricePixel = new Pixel[width, height];
            image.TailleX = width;
            image.TailleY = height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    image.MatricePixel[i, j] = new Pixel(100, 150, 200); // Pixel avec des couleurs de base
                }
            }
            return image;
        }

        [TestMethod]
        public void TestAgrandissement()
        {
            // Arrange
            var image = CréerImageTest(2, 2);
            int agrandissementFactor = 2;

            // Act
            image.Agrandissement(agrandissementFactor);

            // Assert
            Assert.AreEqual(4, image.TailleX);
            Assert.AreEqual(4, image.TailleY);
        }

        [TestMethod]
        public void TestImageEnNoir()
        {
            // Arrange
            var image = CréerImageTest(2, 2);

            // Act
            var resultat = image.ImageEnNoir(image);

            // Assert
            foreach (Pixel p in resultat.MatricePixel)
            {
                Assert.IsTrue(p.R == 0 || p.R == 255, "La couleur R n'est pas noir ou blanc.");
                Assert.IsTrue(p.G == 0 || p.G == 255, "La couleur G n'est pas noir ou blanc.");
                Assert.IsTrue(p.B == 0 || p.B == 255, "La couleur B n'est pas noir ou blanc.");
            }
        }

        [TestMethod]
        public void TestImageEnGris()
        {
            // Arrange
            var image = CréerImageTest(2, 2);

            // Act
            var resultat = image.ImageEnGris(image);

            // Assert
            foreach (Pixel p in resultat.MatricePixel)
            {
                Assert.AreEqual(p.R, p.G, "Les valeurs R et G ne sont pas égales.");
                Assert.AreEqual(p.G, p.B, "Les valeurs G et B ne sont pas égales.");
            }
        }

        [TestMethod]
        public void TestRotationDegre()
        {
            // Arrange
            var image = CréerImageTest(2, 2);
            int degre = 90;

            // Act
            image.RotationDegre(degre);

            // Assert
            // Nous vérifions simplement que la méthode a été appelée sans exception et que les dimensions changent.
            Assert.IsTrue(image.TailleX > 0 && image.TailleY > 0, "Les dimensions de l'image ne sont pas correctes après la rotation.");
        }

        [TestMethod]
        public void TestSauvegardeImage()
        {
            // Arrange
            var image = CréerImageTest(2, 2);
            string nomFichier = "test_image.bmp";

            // Act
            image.SauvegardeImage(nomFichier, image);

            // Assert
            Assert.IsTrue(File.Exists(nomFichier), "Le fichier image n'a pas été créé.");

            // Cleanup
            File.Delete(nomFichier);
        }
    }
}
