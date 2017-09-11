using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeWork_PlotGraph.Models
{
    public class ValidationClass //костыль
    {
        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)|(-\d+)", ErrorMessage = "Uncorrect value")]
        public double A { get; set; }

        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)|(-\d+)", ErrorMessage = "Uncorrect value")]
        public double B { get; set; }

        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)|(-\d+)", ErrorMessage = "Uncorrect value")]
        public double C { get; set; }

        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)", ErrorMessage = "Uncorrect value")]
        public double Step { get; set; }

        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)|(-\d+)", ErrorMessage = "Uncorrect value")]
        public double RangeFrom { get; set; }

        [Required]
        [RegularExpression(@"(\d,\d*)|(\d+)|(-\d+)", ErrorMessage = "Uncorrect value")]
        public double RangeTo { get; set; }

        public ValidationClass()
        {
        }

        public ValidationClass(List<string> st)
        {
            A = Double.Parse(st[0]);
            B = Double.Parse(st[1]);
            C = Double.Parse(st[2]);
            Step = Double.Parse(st[3]);
            RangeFrom = Double.Parse(st[4]);
            RangeTo = Double.Parse(st[5]);
        }
    }
}