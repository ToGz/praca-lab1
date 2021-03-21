using System;

namespace lab3.Models.dto
{
    public class BookDto
    {
        private DateTime _datePublished;

        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string DatePublished { 
            get { return _datePublished.ToShortDateString(); } 
            set { _datePublished = DateTime.Parse(value); } 
        }
    }
}
