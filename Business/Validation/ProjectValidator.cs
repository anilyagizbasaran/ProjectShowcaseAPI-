using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Boş bırakmayın.")
            .When(x => string.IsNullOrWhiteSpace(x.Title))
            .MaximumLength(25).WithMessage("En fazla 25 karakter girilebilir.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(p => p.Technologies).NotEmpty().WithMessage("Kullandığınız teknolojileri girin!");


            //url control
            RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Resim URL'si boş olamaz.") 
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            .WithMessage("Geçerli bir resim URL'si girin.");

            RuleFor(x => x.GithubUrl)
            .NotEmpty().WithMessage("Github URL'si boş olamaz.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                         (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            .WithMessage("Geçerli bir URL girin.");


        }


    }
}
