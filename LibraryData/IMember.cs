using System;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;

namespace LibraryData
{
    public interface IMember
    {
        Member Get(int id);
        IEnumerable<Member> GetAll();
        void Add(Member newMember);

        IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId);
        IEnumerable<Hold> GetHolds(int memberId);
        IEnumerable<Checkout> GetCheckout(int memberId);
    }
}
