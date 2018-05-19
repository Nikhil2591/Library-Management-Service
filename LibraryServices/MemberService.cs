using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class MemberService : IMember
    {
        private LibraryContext _context;

        public MemberService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Member newMember)
        {
            _context.Add(newMember);
            _context.SaveChanges();
        }

        public Member Get(int id)
        {
                return GetAll()
                .FirstOrDefault(member => member.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members
                .Include(member => member.LibraryCard)
                .Include(member => member.HomeLibraryBranch);
        }

        public IEnumerable<Checkout> GetCheckout(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;           

            return _context.Checkouts
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;

            return _context.CheckoutHistories
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId)
                .OrderByDescending(co => co.CheckedOut);
        }

        public IEnumerable<Hold> GetHolds(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;

            return _context.Holds
                .Include(h => h.LibraryCard)
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryCard.Id == cardId)
                .OrderByDescending(h => h.HoldPlaced);
        }
    }

}
