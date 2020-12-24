using CQRS.ProductAPI.MediatR.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.ProductAPI.Validation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("is not empty");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("is not empty");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("is not empty");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("is not empty");
        }
    }
}
