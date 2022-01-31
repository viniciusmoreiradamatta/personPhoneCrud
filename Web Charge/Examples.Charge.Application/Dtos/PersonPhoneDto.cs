namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public string Id { get; set; }
        public string IdPerson { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }

        public PhoneNumberTypeDto PhoneNumberType { get; set; }
    }
}