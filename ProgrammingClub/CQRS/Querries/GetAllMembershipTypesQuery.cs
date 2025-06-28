using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Querries
{
    //noi in controller vom chema query ul, vine mediatr si cauta handler ul care implementeaza query ul, si se apeleaza metoda handle 
    //vreau sa obtin toate tipurile de membership din baza de data
    public class GetAllMembershipTypesQuery : IRequest<IEnumerable<MembershipType>>
    {



    }
}
