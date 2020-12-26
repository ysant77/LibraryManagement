﻿using FluentValidation;
using LibraryManagement.Core.Commands;

namespace LibraryManagement.Core.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(book => book.Name).NotEmpty().NotNull().Matches("^[a-zA-Z0-9]*$").WithMessage($"Attribute Name is invalid");
            RuleFor(book => book.Category).NotEmpty().NotNull().Matches("^[a-zA-Z0-9]*$").WithMessage($"Attribute Category is invalid");
            RuleFor(book => book.Author).NotEmpty().NotNull().Matches("^[a-zA-Z0-9]*$").WithMessage($"Attribute Author is invalid");
            RuleFor(book => book.Price).NotEmpty().NotNull().GreaterThan(0).WithMessage($"Price should be a positive number");
        }
    }
}
