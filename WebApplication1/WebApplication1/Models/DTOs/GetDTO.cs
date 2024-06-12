namespace WebApplication1.Models.DTOs;

public class GetDTO
{

    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public IEnumerable<PrescriptionDTO> PrescriptionDtos { get; set; }
    
}

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<NewMedicamentDTO> MedicamentDto { get; set; } 
    public DoctorDTO DoctorDto { get; set; }
}

public class NewMedicamentDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}