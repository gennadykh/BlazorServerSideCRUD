namespace BlazorServerSideCRUD.Models.Survey
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //? using System.Data.Entity.Spatial;

    [Table("SurveyResponse")]
    public partial class SurveyResponse
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SurveyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string Response { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilledBy { get; set; }

        public virtual Question Question { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual User User { get; set; }
    }
}
