using td1;

namespace Image_Tests // Ajout d'un espace de noms approprié pour encapsuler les tests
{
    [TestClass]
    public class ImageTests
    {
        private Image CréerImageTest(int largeur, int longueur)
        {
            var image = new Image();
            image.MatricePixel = new Pixel[largeur, longueur];
            image.TailleX = largeur;
            image.TailleY = longueur;
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < longueur; j++)
                {
                    image.MatricePixel[i, j] = new Pixel(200, 150, 100); // Pixel avec des couleurs de base
                }
            }
            return image;
        }

        [TestMethod]
        public void TestAgrandissement()
        {
            // Arrange
            var image = CréerImageTest(2, 2);
            int agrand = 2;

            // Act
            image.Agrandissement(agrand);

            // Assert
            Assert.AreEqual(4, image.TailleX);
            Assert.AreEqual(4, image.TailleY);
            for (int i = 0; i < image.TailleX; i++)
            {
                for (int j = 0; j < image.TailleY; j++)
                {
                    Assert.AreEqual(100, image.MatricePixel[i, j].R);
                    Assert.AreEqual(150, image.MatricePixel[i, j].G);
                    Assert.AreEqual(200, image.MatricePixel[i, j].B);
                }
            }
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
                Assert.IsTrue(p.R == 0 || p.R == 255); //La couleur R est noir ou blanc
                Assert.IsTrue(p.G == 0 || p.G == 255); //La couleur G est noir ou blanc
                Assert.IsTrue(p.B == 0 || p.B == 255); //La couleur B est noir ou blanc
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
                Assert.AreEqual(p.R, p.G); // R et G sont égaux
                Assert.AreEqual(p.G, p.B); // G et B sont égaux
            }
        }

        [TestMethod]
        public void TestRotationDegree()
        {
            // Arrange
            var image = CréerImageTest(2, 2);
            int degree = 90;

            // Act
            image.RotationDegre(degree);

            // Assert
            Assert.IsTrue(image.TailleX > 0 && image.TailleY > 0);
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
            Assert.IsFalse(File.Exists(nomFichier), "Le fichier image n'a pas été créé.");

            // Cleanup
            File.Delete(nomFichier);
        }
    }
}
