using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIR6_26.Models.EntityManager;
using XIR6_26.Models.ViewModel;

namespace XIR6_26.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(MemberView mv)
        {
            if(ModelState.IsValid)
            {
                MemberManager mm = new MemberManager();

                mm.AddMember(mv);

                return RedirectToAction("Welcome", "Home");
            }
            return View();
        }
        public ActionResult ManageMemberPartial(string status = "")
        {
            string loginName = User.Identity.Name;
            MemberManager mm = new MemberManager();
            MemberDataView mdv = new MemberDataView();
            mdv.MemberProfile = mm.GetMemberData();

            string message = string.Empty;
            if (status.Equals("update"))
                message = "Update Successful";
            else if (status.Equals("Delete"))
                message = "Delete Successful";

            ViewBag.Message = message;

            return PartialView(mdv);
        }
        public ActionResult UpdateMemberData(int memberID, string nama, string telepon, int saldo)
        {
            MemberView mv = new MemberView();
            mv.id_member = memberID;
            mv.nama = nama;
            mv.telepon = telepon;
            mv.saldo = saldo;

            MemberManager mm = new MemberManager();
            mm.UpdateMember(mv);

            return Json(new { success = true });
        }
        public ActionResult DeleteMember(int memberID)
        {
            MemberManager mm = new MemberManager();
            mm.DeleteMember(memberID);
            return Json(new { succes = true });
        }
        public ActionResult Perubahan()
        {
            return View();
        }
    }
}