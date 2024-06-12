using Microsoft.VisualBasic;

namespace WebApplication1.Models.DTOs;

public class InsertDTO
{
    public PatientDTO PatientDto { get; set; }
    public IEnumerable<MedicamentDTO>  MedicamentDto { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}


public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}
public partial class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}