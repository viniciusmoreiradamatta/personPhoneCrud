using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<PersonPhoneRequest> Phones { get; set; }
    }
}