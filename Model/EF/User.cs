namespace Model.EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
      //  [Required(ErrorMessage = "{0} không được để trống")]
        public string UserName { get; set; }

        [StringLength(32)]
     //   [Required(ErrorMessage = "{0} không được để trống")]
        public string Password { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        [StringLength(50)]
     //   [Required(ErrorMessage = "{0} không được để trống")]
        public string Name { get; set; }

        [StringLength(50)]
     //   [Required(ErrorMessage = "{0} không được để trống")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
    //    [Required(ErrorMessage = "{0} không được để trống")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email khônghợp lệ!")]
        public string Email { get; set; }

        [StringLength(50)]
     //   [Required(ErrorMessage = "{0} không được để trống")]
        public string Phone { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}