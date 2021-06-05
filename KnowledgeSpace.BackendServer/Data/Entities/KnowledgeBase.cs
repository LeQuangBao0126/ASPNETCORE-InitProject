﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeSpace.BackendServer.Data.Entities
{
    [Table("KnowledgeBase")]
    public class KnowledgeBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        public int CategoryId { get; set; }

        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string SeoAlias { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Environment { get; set; }

        [MaxLength(500)]
        public string Problem { get; set; }

        public string StepToReproduce { get; set; }

        [MaxLength(500)]
        public string ErrorMessage { get; set; }

        [MaxLength(500)]
        public string Workaround { get; set; }

        public string Note { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string OwnerUserId { get; set; }

        public string Labels { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? NumberOfComments { get; set; }

        public int? NumberOfVotes { get; set; }

        public int? NumberOfReports { get; set; }


    }
}
