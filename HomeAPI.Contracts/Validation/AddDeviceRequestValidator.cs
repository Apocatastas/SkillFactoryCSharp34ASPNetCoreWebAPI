using FluentValidation;
using HomeAPI.Contracts.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Contracts.Validation
{
    public class AddDeviceRequestValidator : AbstractValidator<AddDeviceRequest>
    {
        string[] _validLocations;

        public AddDeviceRequestValidator()
        {
            _validLocations = new[]
            {
           "Kitchen",
           "Bathroom",
           "Livingroom",
           "Toilet"
       };

            RuleFor(x => x.Name).NotEmpty(); 
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.CurrentVolts).NotEmpty().InclusiveBetween(120, 220); 
            RuleFor(x => x.GasUsage).NotNull();
            RuleFor(x => x.Location).NotEmpty().Must(BeSupported).WithMessage($"Please choose one of the following locations: {string.Join(", ", _validLocations)}");
        }

        private bool BeSupported(string location)
        {
            return _validLocations.Any(e => e == location);
        }
    }
}
