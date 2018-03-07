using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XIR6_26.Models.ViewModel
{
    public class BisView
    {
        [Key]
        public int id_bis { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "MemberID")]
        public int memberID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Dari")]
        public string dari { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Ke")]
        public string ke { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Tarif")]
        public int tarif { get; set; }
    }
    public class BisDataView
    {
        public IEnumerable<BisView> BisProfile { get; set; }
        public int? SelectedBis { get; set; }
    }
}