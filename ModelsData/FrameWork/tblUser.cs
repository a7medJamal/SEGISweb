namespace ModelsData.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUser
    {
        [Key]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PWD { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string UserType { get; set; }
    }
}
