namespace SimpleSurvey
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //? using System.Data.Entity.Spatial;

    public partial class Survey
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Survey()
        {
            ////Survey_Questions = new HashSet<Survey_Questions>();
            ////SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ExpiresOn { get; set; }

        public int CreatedBy { get; set; }

        public bool Publish { get; set; }

        ////[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ////public virtual ICollection<Survey_Questions> Survey_Questions { get; set; }

        ////[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ////public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }

        ////public virtual User User { get; set; }
    }
}
