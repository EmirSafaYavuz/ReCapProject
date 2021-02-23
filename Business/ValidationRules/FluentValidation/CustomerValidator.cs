﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.CompanyName).NotEmpty();
            RuleFor(cu => cu.CompanyName).MinimumLength(2).WithMessage(Messages.CompanyNameLengthInvalid);
        }
    }
}
