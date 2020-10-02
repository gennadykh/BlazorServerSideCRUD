namespace SimpleSurvey
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //? using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            ////Survey_Questions = new HashSet<Survey_Questions>();
            ////SurveyResponses = new HashSet<SurveyResponse>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [Required]
        [StringLength(200)]
        public string QuestionType { get; set; }

        [Required]
        [StringLength(2000)]
        public string Options { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Survey_Questions> Survey_Questions { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}
