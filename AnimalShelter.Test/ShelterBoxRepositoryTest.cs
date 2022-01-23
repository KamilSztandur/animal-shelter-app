using AnimalShelter.Core.Domain;
using AnimalShelter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShelterBoxTest
{
    public class ShelterBoxTestBase
    {
        public TestContext TestContext { get; set; }
        public ShelterBoxRepository Repository;
        public List<ShelterBox> MockedShelterBoxes { get; set; }

        public int NON_EXISTING_SHELTERBOX_ID { get; set; }
        public int NON_EXISTING_ANIMAL_ID { get; set; }

        [ClassInitialize()]
        public void ClassInitialize(TestContext tc)
        {
            this.TestContext = tc;

            TestContext.WriteLine("Initializing test classes and Repositories...");
            InitializeShelterBoxRepositoryWithMockedDataBase();
            InitializeAdditionalAttributes();
            TestContext.WriteLine("Done.");
        }

        [ClassCleanup()]
        public void ClassCleanup(TestContext tc)
        {
            tc.WriteLine("Cleaning test classes...");
            this.Repository = null;
            tc.WriteLine("Done.");

            this.TestContext = null;
        }

        private void InitializeShelterBoxRepositoryWithMockedDataBase()
        {
            var shelterBoxes = GetMockedShelterBoxesQuerable();
            var shelterBoxesTableMock = GetMockedShelterBoxTable(shelterBoxes);
            var shelterBoxesContextMock = GetMockedAppDbContext(shelterBoxesTableMock);

            var mockedShelterBoxesRepository = new ShelterBoxRepository(shelterBoxesContextMock);

            this.Repository = mockedShelterBoxesRepository;
        }

        private IQueryable<ShelterBox> GetMockedShelterBoxesQuerable()
        {
            var shelterBoxes = new List<ShelterBox>
            {
                GetMockedFirstShelterBox(),
                GetMockedSecondShelterBox(),
                GetMockedThirdShelterBox()
            };

            this.MockedShelterBoxes = shelterBoxes;

            return shelterBoxes.AsQueryable();
        }

        private DbSet<ShelterBox> GetMockedShelterBoxTable(IQueryable<ShelterBox> shelterBoxes)
        {
            var shelterBoxesMock = new Mock<DbSet<ShelterBox>>();
            shelterBoxesMock.As<IQueryable<ShelterBox>>().Setup(x => x.Provider).Returns(shelterBoxes.Provider);
            shelterBoxesMock.As<IQueryable<ShelterBox>>().Setup(x => x.Expression).Returns(shelterBoxes.Expression);
            shelterBoxesMock.As<IQueryable<ShelterBox>>().Setup(x => x.ElementType).Returns(shelterBoxes.ElementType);
            shelterBoxesMock.As<IQueryable<ShelterBox>>().Setup(x => x.GetEnumerator()).Returns(shelterBoxes.GetEnumerator());

            return shelterBoxesMock.Object;
        }

        private AppDbContext GetMockedAppDbContext(DbSet<ShelterBox> shelterBoxesTable)
        {
            var shelterBoxesContextMock = new Mock<AppDbContext>();
            shelterBoxesContextMock.Setup(x => x.ShelterBoxes).Returns(shelterBoxesTable);

            return shelterBoxesContextMock.Object;
        }


        protected void InitializeAdditionalAttributes()
        {
            NON_EXISTING_SHELTERBOX_ID = int.Parse(TestContext.Properties["NonExistingShelterBoxId"].ToString());
            NON_EXISTING_ANIMAL_ID = int.Parse(TestContext.Properties["NonExistingAnimalId"].ToString());
        }

        protected ShelterBox GetMockedFirstShelterBox()
        {
            Mock<ShelterBox> ShelterBox = new Mock<ShelterBox>();

            ShelterBox.SetupGet(e => e.Id).Returns(int.Parse(TestContext.Properties["FirstShelterBoxId"].ToString()));
            ShelterBox.SetupGet(e => e.Animal.Id).Returns(int.Parse(TestContext.Properties["FirstShelterBoxAnimalId"].ToString()));

            return ShelterBox.Object;
        }

        protected ShelterBox GetMockedSecondShelterBox()
        {
            Mock<ShelterBox> ShelterBox = new Mock<ShelterBox>();

            ShelterBox.SetupGet(e => e.Id).Returns(int.Parse(TestContext.Properties["SecondShelterBoxId"].ToString()));
            ShelterBox.SetupGet(e => e.Animal.Id).Returns(int.Parse(TestContext.Properties["SecondShelterBoxAnimalId"].ToString()));

            return ShelterBox.Object;
        }

        protected ShelterBox GetMockedThirdShelterBox()
        {
            Mock<ShelterBox> ShelterBox = new Mock<ShelterBox>();

            ShelterBox.SetupGet(e => e.Id).Returns(int.Parse(TestContext.Properties["ThirdShelterBoxId"].ToString()));
            ShelterBox.SetupGet(e => e.Animal.Id).Returns(int.Parse(TestContext.Properties["ThirdShelterBoxAnimalId"].ToString()));

            return ShelterBox.Object;
        }
    }

    [TestClass]
    public class ShelterBoxTest : ShelterBoxTestBase
    {
        [TestInitialize]
        public void TestInitiailize()
        {
            ClassInitialize(this.TestContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ClassCleanup(this.TestContext);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(5)]
        [Description("Should add passed ShelterBox to database when it's correct.")]
        public async void CreateCorrectShelterBox()
        {
            ShelterBox VALID_SHELTERBOX = new ShelterBox() { Animal = new Animal() { Id = 10 } };
            int result;

            result = await this.Repository.AddAsync(VALID_SHELTERBOX);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(3)]
        [Description("Should throw exception when it's incorrect.")]
        [ExpectedException(typeof(NullReferenceException))]
        public async void CreateNullShelterBox()
        {
            ShelterBox NULL_SHELTERBOX = null;
            int result;

            result = await this.Repository.AddAsync(NULL_SHELTERBOX);

            Assert.IsFalse(result == 1);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(5)]
        [Description("Should find correct shelterbox when passing correct ID value.")]
        public async void ReadExistingShelterBox()
        {
            ShelterBox FIRST_SHELTERBOX = this.MockedShelterBoxes[0];
            int FIRST_SHELTERBOX_ID = FIRST_SHELTERBOX.Id;
            ShelterBox result;

            result = await this.Repository.GetAsync(FIRST_SHELTERBOX_ID);

            Assert.AreEqual(FIRST_SHELTERBOX, result);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(2)]
        [Description("Should not throw exception when searching for non existing shelterbox ID and return default.")]
        public async void ReadNotExistingShelterBox()
        {
            ShelterBox result;

            result = await this.Repository.GetAsync(NON_EXISTING_SHELTERBOX_ID);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(4)]
        [Description("Should modify shelterbox in database when passing correct values.")]
        public async void UpdateExistingShelterBox()
        {
            ShelterBox VALID_SHELTERBOX = new ShelterBox();
            int ID_OF_UPDATED_SHELTERBOX = VALID_SHELTERBOX.Id;
            int result;

            result = await this.Repository.UpdateAsync(ID_OF_UPDATED_SHELTERBOX, VALID_SHELTERBOX);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(3)]
        [Description("Should throw exception when updating incorrect shelterbox.")]
        [ExpectedException(typeof(NullReferenceException))]
        public async void UpdateNotExistingShelterBox()
        {
            ShelterBox VALID_SHELTERBOX = new ShelterBox();
            int result;

            result = await this.Repository.UpdateAsync(NON_EXISTING_SHELTERBOX_ID, VALID_SHELTERBOX);

            Assert.IsFalse(result == 1);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(3)]
        [Description("Should delete shelterbox in database when passing correct values.")]
        public async void DeleteExistingShelterBox()
        {
            int FIRST_SHELTERBOX_ID = this.MockedShelterBoxes[0].Id;
            int result;

            result = await this.Repository.DelAsync(FIRST_SHELTERBOX_ID);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        [Owner("Kamil")]
        [Priority(3)]
        [Description("Should throw exception when deleting incorrect shelterbox.")]
        [ExpectedException(typeof(NullReferenceException))]
        public async void DeleteNotExistingShelterBox()
        {
            int result;

            result = await this.Repository.DelAsync(NON_EXISTING_SHELTERBOX_ID);

            Assert.IsFalse(result == 1);
        }
    }
}
