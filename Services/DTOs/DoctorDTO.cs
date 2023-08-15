namespace siades.Services.DTOs
{
    public class DoctorDTO
    {
        // doctor
        public string? DoctorNumber { get; set; }
        // contact
        public string? PhoneNumber { get; set; }
        public string? HousePhoneNumber { get; set; }
        public string? EmailAdrress { get; set; }
        //address
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? NeighborHud { get; set; }
        //person
        public string? FullName { get; set; }
        public string? IdNumber { get; set; }
        public string? TypeDocId { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceOfBirth { get; set; }
    }
}