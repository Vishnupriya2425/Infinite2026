using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static mvc.Models.DbContext;
using Microsoft.EntityFrameworkCore;

namespace mvc.Models
{

    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }

    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var c = await _context.Contacts.FindAsync(id);
            if (c != null)
            {
                _context.Contacts.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}