namespace ShipperWebsite.Models.ShipperAdmin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAdmin")]
    public partial class UserAdmin
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password_ { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
