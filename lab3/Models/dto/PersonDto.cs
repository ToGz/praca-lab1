using System;

namespace lab3.Models.dto
{
    public class PersonDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public bool IsAwesome { get; set; }
    }
}
