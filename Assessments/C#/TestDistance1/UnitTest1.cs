using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment4;

namespace TestDistance_MSTest
{
    [TestClass]
    public class DistanceTest
    {
        [TestMethod]
        public void Add_TwoDistanceObjects_ReturnsCorrectSum()
        {
         
            Distance d1 = new Distance { Kilometer = 20 };
            Distance d2 = new Distance { Kilometer = 30 };

            Distance result = Distance.Add(d1, d2);

            Assert.AreEqual(50, result.Kilometer);
        }

        [TestMethod]
        public void Add_Distance_WithParameters()
        {
            Distance d1 = new Distance { Kilometer = 10 };
            Distance d2 = new Distance { Kilometer = 40 };

            Distance result = Distance.Add(d1, d2);

            Assert.AreEqual(50, result.Kilometer);
        }
    }
}

