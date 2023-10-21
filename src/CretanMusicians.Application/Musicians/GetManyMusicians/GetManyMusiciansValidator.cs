using CretanMusicians.Domain.ValidationErrorsMessages;
using FluentValidation;

namespace CretanMusicians.Application.Musicians.GetManyMusicians;

public class GetManyMusiciansValidator : AbstractValidator<GetManyMusiciansQuery>
{
    public GetManyMusiciansValidator()
    {
        RuleFor(q => q.Params.Page)
            .GreaterThan(default(int))
            .WithMessage(GetManyMusiciansQueryErrors.EmptyPage);
        
        RuleFor(q => q.Params.ItemsPerPage)
            .GreaterThan(default(int))
            .WithMessage(GetManyMusiciansQueryErrors.EmptyItemsPerPage);
    }
}