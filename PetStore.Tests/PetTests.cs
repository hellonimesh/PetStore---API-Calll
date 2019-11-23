using NUnit.Framework;
using PetStore.Client;

namespace PetStore.Tests
{
    public class PetTests
    {

        PetStoreAPIClient petStoreAPIClient;

        [SetUp]
        public void Setup()
        {
             petStoreAPIClient = new PetStoreAPIClient();
        }

        [Test]
        public void Assert_Available_Pets_With_Doggie_Name_Count()
        { 
          int petCount = petStoreAPIClient.GetPetCount("available", "doggie").Result;
            System.Console.WriteLine($"The number of pets available are =  {petCount}");
            Assert.NotZero(petCount);
        }

        [TearDown]
        public void TearDown()
        {
            petStoreAPIClient = null;
        }
    }
}