using System;
using System.Collections.Generic;
using System.Text;

namespace GOSTechnology.Core.Archives.Domain.ViewModels
{
    public class ResultViewModel
    {
        public Boolean IsSuccess { get; set; }
        public String[] Messages { get; set; }
        public Object Data { get; set; }        
    }
}
