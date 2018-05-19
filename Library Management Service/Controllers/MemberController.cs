using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Management.Service.Model.Member;
using LibraryData;
using LibraryData.Models;
using LibraryServices;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_Service.Controllers
{
    public class MemberController : Controller
    {
        private IMember _member;

        public MemberController(IMember member)
        {
            _member = member;
        }

        public IActionResult Index()
        {
            var allMembers = _member.GetAll();

            var memberModels = allMembers.Select(m => new MemberDetailModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                LibraryCardId = m.LibraryCard.Id,
                OverdueFees = m.LibraryCard.Fees,
                HomeLibraryBranch = m.HomeLibraryBranch.Name
            }).ToList();

            var model = new MemberIndexModel()
            {
                Members = memberModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var member = _member.Get(id);

            var model = new MemberDetailModel
            {
                LastName = member.LastName,
                FirstName = member.FirstName,
                Address = member.Address,
                HomeLibraryBranch = member.HomeLibraryBranch.Name,
                MemberSince = member.LibraryCard.Created,
                OverdueFees = member.LibraryCard.Fees,
                LibraryCardId = member.LibraryCard.Id,
                Telephone = member.PhoneNumber,
                AssetsCheckedOut = _member.GetCheckout(id).ToList() ?? new List<Checkout>(),
                CheckoutHistory = _member.GetCheckoutHistory(id),
                Holds = _member.GetHolds(id)
            };

        return View(model);
        }
    }
}