namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Footer")]
    public partial class Footer
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Content { get; set; }

        public bool? Status { get; set; }
    }
}
