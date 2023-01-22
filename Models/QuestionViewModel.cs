using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testest.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel() { }
        public Question question { get; set; }
        public ICollection<Test> tests { get; set; }
    }
}