using NUnit.Framework;
using PetStore.Client;

namespace PetStore.Tests
{
    public class PetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Assert_Available_Pets_With_Doggie_Name_Count()
        {
            PetStoreAPIClient petStoreAPIClient = new PetStoreAPIClient();
            int petCount = petStoreAPIClient.GetPetCount("available", "doggie").Result;
            Assert.NotZero(petCount);
        }
    }
}