using MediatR;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Querries
{
    public class GetMembershipTypeByIdQuery : IRequest<MembershipType>
    {
        public Guid IdMembershipType { get; set; }
        public GetMembershipTypeByIdQuery(Guid idMembershipType)
        {
            IdMembershipType = idMembershipType;
        }
    }
}
