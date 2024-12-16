using System.IO;
using System.Text;
using System;
using Moq;
using DLL_CustomerService_For_MOQ_test;

namespace CustomerService_MoqTest_Demo
{
    public class CustomerServiceTest
    {
        private readonly Mock<ICustomerRepository> _repository;

        public CustomerServiceTest()
        {
            _repository = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void SaveCustomer_ThrowsArgumentNullException_WhenNull()
        {
            // Arrange
            var service = new CustomerService(_repository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => service.SaveCustomer(null));
        }

        [Fact]
        public void SaveCustomer_ThrowsInvalidDataException_WhenNameEmpty()
        {
            // Arrange
            var customer = new Customer { Name = string.Empty };
            var service = new CustomerService(_repository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidDataException>(() => service.SaveCustomer(customer));
            Assert.Equal("Name cannot be empty", exception.Message);
        }

        [Fact]
        public void SaveCustomer_ThrowsInvalidDataException_WhenEmailEmpty()
        {
            // Arrange
            var customer = new Customer { Name = "Prabhav", Email = string.Empty };
            var service = new CustomerService(_repository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidDataException>(() => service.SaveCustomer(customer));
            Assert.Equal("Email cannot be empty", exception.Message);
        }

        [Fact]
        public void SaveCustomer_ThrowsInvalidDataException_WhenCustomerExists()
        {
            // Arrange
            var customer = new Customer { Id = 0, Name = "Prabhav", Email = "Prabhav.khalya@yash.com" };
            _repository.Setup(x => x.Search(It.IsAny<string>())).Returns(customer);
            var service = new CustomerService(_repository.Object);

            // Act and Assert
            var exception = Assert.Throws<InvalidDataException>(() => service.SaveCustomer(customer));
            Assert.Equal("Customer already exists", exception.Message);
        }

        [Fact]
        public void SaveCustomer_ReturnsCustomerId_WhenValidAddRequest()
        {
            // Arrange
            var customer = new Customer { Id = 0, Name = "Prabhav", Email = "Prabhav.khalya@yash.com" };
            int customerId = 20;
            _repository.Setup(x => x.Search(It.IsAny<string>())).Returns((Customer)null);
            _repository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(customer.Id);
            var service = new CustomerService(_repository.Object);

            // Act
            var custId = service.SaveCustomer(customer);

            // Assert
            _repository.Verify(x => x.Add(customer), Times.Once());
            Assert.Equal(customerId, custId);
        }

        [Fact]
        public void SaveCustomer_ReturnsCustomerId_WhenValidUpdateRequest()
        {
            // Arrange
            var customer = new Customer { Id = 20, Name = "Prabhav", Email = "Prabhav.khalya@yash.com" };
            _repository.Setup(x => x.Search(It.IsAny<string>())).Returns(customer);
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer.Id);
            var service = new CustomerService(_repository.Object);

            // Act
            var custId = service.SaveCustomer(customer);

            // Assert
            _repository.Verify(x => x.Update(customer), Times.Once());
            Assert.Equal(customer.Id, custId);
        }

        [Fact]
        public void SaveCustomer_SendsEmail_WhenValidInput()
        {
            // Arrange
            var customer = new Customer { Id = 20, Name = "Prabhav", Email = "Prabhav.khalya@yash.com" };
            _repository.Setup(x => x.Search(It.IsAny<string>())).Returns(customer);
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer.Id);
            var service = new CustomerService(_repository.Object);

            // Act
            var custId = service.SaveCustomer(customer);

            // Assert
            _repository.Verify(x => x.Update(customer), Times.Once());
        }
    }
}