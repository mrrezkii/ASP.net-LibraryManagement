using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XIR6_26.Models.ViewModel
{
    public class MemberView
    {
        [Key]
        public int id_member { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Nama")]
        public string nama { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Telepon")]
        public string telepon { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Saldo")]
        public int saldo { get; set; }
    }
    public class MemberDataView
    {
        public IEnumerable<MemberView> MemberProfile { get; set; }
        public int? SelectedMember { get; set; }
    }
}