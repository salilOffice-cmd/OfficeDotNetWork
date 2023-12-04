using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.PersonCQ.Queries
{
    public class GetPersons : IRequest<List<Person>>
    { }

    public class GetPersonsHandler : IRequestHandler<GetPersons, List<Person>>
    {
        private readonly IApplicationDbContext _ApplicationDbContext;
        public GetPersonsHandler(IApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public async Task<List<Person>> Handle(GetPersons request, CancellationToken cancellationToken)
        {
            // data access logic 
            return await _ApplicationDbContext.Person.ToListAsync();
        }
    }
}
