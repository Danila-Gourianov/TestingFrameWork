using ATLabProject.Services;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ATLabProject.Tests
{
    [AllureNUnit]
    [AllureFeature("API tests")]
    public class ApiTests
    {
        [Test]
        public void PetShouldBeAdded()
        {
            var petService = new PetStoreService();
            var petName = "Charlie";
            var addedPetId = petService.Add(petName).Result.id;
            var actualPetName = petService.FindById(addedPetId).Result.name;

            Assert.AreEqual(petName, actualPetName);
        }

        [Test]
        public void UserShouldBeAdded()
        {
            var userService = new UserStoreService();
            var userName = "TomSoyer";
            var addedUserId = userService.Add(userName).Result.Id;
            var actualUserName = userService.FindByUserName(userName).Result.username;

            Assert.That(actualUserName, Is.EqualTo(userName));
        }
    }
}