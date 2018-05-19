using System;
using LibraryData;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;

namespace LibraryData
{
    public interface ICheckout
    {
        void Add(Checkout newCheckout);

        IEnumerable<Checkout> GetAll();
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        Checkout GetByID(int checkoutId);
        Checkout GetLatestCheckout(int assetId);
        string GetCurrentCheckoutMember(int assetId);
        string GetCurrentHoldMemberName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        bool IsCheckedOut(int id);


        void CheckOutItem(int assetId, int LibraryCardId);
        void CheckInItem(int assetId);      
        void PlaceHold(int assetId, int libraryCardId);

        void MarkLost(int assetId);
        void MarkFound(int assetId);
    }
}
