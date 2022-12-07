using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(3);
            RuleFor(c => c.Description).Must(StartWithD).WithMessage("Car's Descriptions must start with D");
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);


        }

        private bool StartWithD(string arg)
        {
            return arg.StartsWith("D");
        }
    }
}
