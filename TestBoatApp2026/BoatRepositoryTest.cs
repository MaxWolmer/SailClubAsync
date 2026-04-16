using SailClubLibrary.Exceptions;
using SailClubLibrary.Models;
using SailClubLibrary.Services;

namespace TestBoatApp2026
{
    [TestClass]
    public sealed class BoatRepositoryTest
    {
        [TestMethod]
        public void AddBoatTest()
        {
            //Arrange
            BoatRepository bRepo = new BoatRepository();

            //Act
            int beforeCount = bRepo.Count;
            bRepo.AddBoat(new Boat(5, BoatType.LASERJOLLE, "IC4", "233243DK", "No", 0.3, 1.2, 4, "2006"));
            int afterCount = bRepo.Count;

            //Assert
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        [ExpectedException(typeof(BoatSailnumberExistsException))]
        public void AddExistBoatTest_BoatSailnumberExistsException()
        {
            //Arrange
            BoatRepository bRepo = new BoatRepository();
            bRepo.AddBoat(new Boat(5, BoatType.LASERJOLLE, "IC4", "23343DK", "No", 0.3, 1.2, 4, "2006"));

            //Act
            bRepo.AddBoat(new Boat(6, BoatType.LYNÆS, "IC5", "233243DK", "No", 0.5, 0.3, 4, "2006"));

            //Assert
        }
    }
}
