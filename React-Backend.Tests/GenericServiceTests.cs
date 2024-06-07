using Application.IServices;
using Application.Services;
using Infrastructure;
using Moq;
using Moq.EntityFrameworkCore;

namespace React_Backend.Tests
{
    public class GenericServiceTests
    {
        private Mock<ApplicationDbContext> _contextMock;
        private IGenericService<TestEntity> _service;
        private List<TestEntity> _testData;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<ApplicationDbContext>();
            _testData = new List<TestEntity>
            {
                new TestEntity { Id = 1, Name = "Test 1" },
                new TestEntity { Id = 2, Name = "Test 2" }
            };

            _contextMock.Setup(c => c.Set<TestEntity>()).ReturnsDbSet(_testData);
            _service = new GenericService<TestEntity>(_contextMock.Object);
        }

        [Test]
        public async Task Get_ReturnsPaginatedResponse()
        {
            // Act
            var result = await _service.Get(1, 5);

            // Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, result.Total);
            Assert.AreEqual(2, result.Body.Count());
        }

        [Test]
        public async Task GetById_ReturnsEntity()
        {
            // Act
            _contextMock.Setup(b => b.Set<TestEntity>().FindAsync(1)).ReturnsAsync(_testData[0]);
            var result = await _service.GetById(1);
            // Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(_testData[0], result.Body);
        }

        [Test]
        public async Task Insert_AddsEntity()
        {
            // Arrange
            var newEntity = new TestEntity { Id = 3, Name = "Test 3" };

            // Act
            var result = await _service.Insert(newEntity);

            // Assert
            _contextMock.Verify(c => c.Set<TestEntity>().AddAsync(newEntity, default), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(200, result.StatusCode);
        }

        //[Test]
        //public async Task Update_ModifiesEntity()
        //{
        //    // Arrange
        //    var updatedEntity = _testData[0];
        //    updatedEntity.Name = "Updated Name";
        //    _contextMock.Setup(b => b.Entry(updatedEntity).State).Verifiable();

        //    // Act
        //    var result = await _service.Update(updatedEntity);

        //    // Assert
        //    _contextMock.Verify(c => c.Set<TestEntity>().Attach(updatedEntity), Times.Once);
        //    _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        //    Assert.AreEqual(200, result.StatusCode);
        //}

        [Test]
        public async Task Delete_RemovesEntity()
        {
            // Arrange
            var entityToDelete = _testData[0];
            _contextMock.Setup(b => b.Set<TestEntity>().FindAsync(1)).ReturnsAsync(entityToDelete);

            // Act
            var result = await _service.Delete(entityToDelete);

            // Assert
            _contextMock.Verify(c => c.Set<TestEntity>().Remove(entityToDelete), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task Delete_ById_RemovesEntity()
        {
            // Arrange
            var entityToDelete = _testData[0];
            _contextMock.Setup(b => b.Set<TestEntity>().FindAsync(1)).ReturnsAsync(entityToDelete);
            // Act
            var result = await _service.Delete(1);

            // Assert
            _contextMock.Verify(c => c.Set<TestEntity>().Remove(entityToDelete), Times.Once);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task DeleteRange_RemovesEntities()
        {
            // Arrange
            var ids = _testData.Select(e => (object)e.Id).ToList();
            _contextMock.Setup(b => b.Set<TestEntity>().FindAsync(1)).ReturnsAsync(_testData[0]);
            _contextMock.Setup(b => b.Set<TestEntity>().FindAsync(2)).ReturnsAsync(_testData[1]);

            // Act
            var result = await _service.DeleteRange(ids);

            // Assert
            foreach (var entity in _testData)
            {
                _contextMock.Verify(c => c.Set<TestEntity>().Remove(entity), Times.Once);
            }
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Exactly(_testData.Count));
            Assert.AreEqual(200, result.StatusCode);
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
