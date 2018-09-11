namespace ModelsData.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUser
    {
        public long ID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PWD { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string UserType { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public bool? Status { get; set; }
    }
}
