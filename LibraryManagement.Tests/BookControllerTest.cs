using LibraryManagement.Core.Commands;
using LibraryManagement.Core.Common.Exceptions;
using LibraryManagement.Core.Handlers.CommandHandlers;
using LibraryManagement.Core.Validators;
using LibraryManagement.Domain;
using LibraryManagement.Persistence;
using LibraryManagement.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace LibraryManagement.Tests
{
    public class BookControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private CreateBookCommand _createBookCommand;
        public BookControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _createBookCommand = new CreateBookCommand
            {
                Author = "Cormen",
                Category = "DSA",
                Name = "Introduction to Algorithms",
                Price = 100
            };
        }
        
        [Fact]
        public void CreateBook_Success_Result()
        {
            _mediator.Setup(obj => obj.Send(It.IsAny<CreateBookCommand>(), new CancellationToken()))
                     .ReturnsAsync(new Book());
            var bookController = new BooksController(_mediator.Object);
            var result = bookController.Create(_createBookCommand);
            Assert.IsType<CreatedResult>(result.Result);
        }
        [Fact]
        public void CreateBook_ValidationError_When_Author_IsEmpty()
        {
            _createBookCommand.Author = string.Empty;
            _mediator.Setup(obj => obj.Send(It.IsAny<CreateBookCommand>(), new CancellationToken()))
                     .ReturnsAsync(new Book());
            var bookController = new BooksController(_mediator.Object);
            Assert.ThrowsAsync<ValidationException>(() => bookController.Create(_createBookCommand));
        }
        [Fact]
        public void CreateBook_ValidationError_When_Name_IsEmpty()
        {
            _createBookCommand.Name = string.Empty;
            _mediator.Setup(obj => obj.Send(It.IsAny<CreateBookCommand>(), new CancellationToken()))
                     .ReturnsAsync(new Book());
            var bookController = new BooksController(_mediator.Object);
            Assert.ThrowsAsync<ValidationException>(() => bookController.Create(_createBookCommand));
        }
        [Fact]
        public void CreateBook_ValidationError_When_Category_IsEmpty()
        {
            _createBookCommand.Category = string.Empty;
            _mediator.Setup(obj => obj.Send(It.IsAny<CreateBookCommand>(), new CancellationToken()))
                     .ReturnsAsync(new Book());
            var bookController = new BooksController(_mediator.Object);
            Assert.ThrowsAsync<ValidationException>(() => bookController.Create(_createBookCommand));
        }
        [Fact]
        public void CreateBook_ValidationError_When_Price_IsEmptyOrNotPositive()
        {
            _createBookCommand.Price = 0;
            _mediator.Setup(obj => obj.Send(It.IsAny<CreateBookCommand>(), new CancellationToken()))
                     .ReturnsAsync(new Book());
            var bookController = new BooksController(_mediator.Object);
            Assert.ThrowsAsync<ValidationException>(() => bookController.Create(_createBookCommand));
        }
       

    }
}
