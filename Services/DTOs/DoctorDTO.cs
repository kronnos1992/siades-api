namespace siades.Services.DTOs
{
    public class DoctorDTO
    {
        // doctor
        public string? DocNumber { get; set; }
        // contact
        public string? PhoneNumeber { get; set; }
        public string? HousePhoneNumber { get; set; }
        public string? EmailAdrress { get; set; }
        //address
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? NeighborHud { get; set; }
        //birth address
        public string? BirthStreet { get; set; }
        public string? BirthHouseNumber { get; set; }
        public string? BirthNeighborHud { get; set; }
        //person
        public string? FullName { get; set; }
        public string? IdentDocNumber { get; set; }
        public string? TypeIdentDoc { get; set; }
    }
}