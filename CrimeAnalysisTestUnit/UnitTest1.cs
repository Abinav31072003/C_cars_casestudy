using NUnit.Framework;
using CARS.Dao;
using CARS.Entities;
namespace CrimeAnalysisTestUnit
{
    [TestFixture]
    public class CrimeAnalysisSystemTests
    {
        private CrimeAnalysisServiceImpl crimeAnalysisServiceImpl;

        [SetUp]
        public void Setup()
        {
            // Initialize your service implementation class here or use a mocking framework
            crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
        }

        [Test]
        public void TestIncidentCreation()
        {
            // Arrange
             Incidents incidents = new Incidents();
            {
                // Set up attributes for testing incident creation
                incidents.IncidentType = "Robbery";
                incidents.IncidentDate = DateTime.Now;
                incidents.Location = "Test Location";
                incidents.Description = "Test Incident";
                incidents.Status = "Open";
                incidents.VictimID = 1;
                incidents.SuspectID = 1;
                // Set up Victim and Suspect if needed
            };

            // Act
            bool isIncidentCreated = crimeAnalysisServiceImpl.testcreateIncident(incidents);

            // Assert
            Assert.IsTrue(isIncidentCreated, "Incident should be created successfully");
            // Optionally, you can add more assertions to check attributes accuracy
        }

        [Test]
        public void TestIncidentStatusUpdate()
        {
            // Arrange
            int incidentId = 123; // Assuming a valid incident ID
            string newStatus = "Closed"; // New status for the incident

            // Act
            bool isStatusUpdated = crimeAnalysisServiceImpl.testupdateIncident(incidentId, newStatus);

            // Assert
            Assert.IsTrue(isStatusUpdated, "Incident status should be updated successfully");
            // Optionally, you can add more assertions to check if invalid status updates are handled appropriately
        }
    }
}