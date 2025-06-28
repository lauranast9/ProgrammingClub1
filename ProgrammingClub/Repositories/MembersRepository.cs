using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public MembersRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.IdMember == id);
        }

        public async Task AddMemberAsync(Member member)
        {
            if (member == null || member.IdMember == Guid.Empty)
                return;

            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Members.AnyAsync(m => m.Username == username);
        }

        public async Task<Member?> UpdateMemberAsync(Member member)
        {
            if (member.IdMember == Guid.Empty)
                return null;

            var existingMember = await _context.Members.FindAsync(member.IdMember);
            if (existingMember == null)
                return null;

            existingMember.Username = member.Username;
            existingMember.Password = member.Password;
            existingMember.Name = member.Name;
            existingMember.Title = member.Title;
            existingMember.Resume = member.Resume;
            existingMember.Description = member.Description;

            await _context.SaveChangesAsync();
            return existingMember;
        }

        public async Task<bool> MemberExistAsync(Guid id)
        {
            return await _context.Members.AnyAsync(m => m.IdMember == id);
        }

        public async Task<Member> UpdateMemberPartiallyAsync(Member member)
        {
            Member memberFromDb = await GetMemberByIdAsync(member.IdMember);

            if (memberFromDb == null)
            {
                return null;
            }

            UpdateIfNullOrEmpty(member.Username, value => memberFromDb.Username = value);
            UpdateIfNullOrEmpty(member.Password, value => memberFromDb.Password = value);
            UpdateIfNullOrEmpty(member.Name, value => memberFromDb.Name = value);
            UpdateIfNullOrEmpty(member.Title, value => memberFromDb.Title = value);
            UpdateIfNullOrEmpty(member.Description, value => memberFromDb.Description = value);
            UpdateIfNullOrEmpty(member.Resume, value => memberFromDb.Resume = value);

            _context.Update(memberFromDb);
            await _context.SaveChangesAsync();
            return memberFromDb;
        }

        public async Task<bool> DeleteMemberAsync(Guid id)
        {
            if (!await MemberExistAsync(id))
            {
                return false;
            }

            _context.Members.Remove(new Member { IdMember = id });
            await _context.SaveChangesAsync();
            return true;
        }

        private void UpdateIfNullOrEmpty(string newValue, Action<string> setter)
        {
            if (!string.IsNullOrEmpty(newValue))
            {
                setter(newValue);
            }
        }
    }
}