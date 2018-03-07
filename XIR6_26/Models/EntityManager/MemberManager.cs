using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XIR6_26.Models.DB;
using XIR6_26.Models.ViewModel;

namespace XIR6_26.Models.EntityManager
{
    public class MemberManager
    {
        public void AddMember(MemberView mv)
        {
            using (GoGoDBEntities db = new GoGoDBEntities())
            {
                Member mm = new Member();
                mm.nama = mv.nama;
                mm.telepon = mv.telepon;
                mm.saldo = mv.saldo;
                db.Members.Add(mm);
                db.SaveChanges();
            }
        }
        public void UpdateMember(MemberView mv)
        {
            using (GoGoDBEntities db = new GoGoDBEntities())
            {
                Member mm = db.Members.Find(mv.id_member);
                mm.nama = mv.nama;
                mm.telepon = mv.telepon;
                mm.saldo = mv.saldo;
                //db.Members.Add(mm);
                db.SaveChanges();
            }
        }
        public void DeleteMember(int memberID)
        {
            using (GoGoDBEntities db = new GoGoDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mm = db.Members.Where(o => o.id_member == memberID);
                        if (mm.Any())
                        {
                            db.Members.Remove(mm.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
        public List<MemberView> GetMemberData()
        {
            using (GoGoDBEntities db = new GoGoDBEntities())
            {
                var member = db.Members.Select(o => new MemberView
                {
                    id_member = o.id_member,
                    nama = o.nama,
                    telepon = o.telepon,
                    saldo = o.saldo
                }).ToList();

                return member;
            }
        }
    }
}