using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class PatientService
{
    private readonly ApplicationContext _context;

    public PatientService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<GetDTO> GetPatient(int id)
    {

        var patient = await _context.Patients
            .Where(a => a.IdPatient == id)
            .Select(a => new GetDTO()
            {
                IdPatient = a.IdPatient,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Birthdate = a.Birthdate,
                
                PrescriptionDtos = a.Prescriptions
                    .OrderBy(pre => pre.DueDate)
                    .Select(pre => new PrescriptionDTO()
                    {
                        IdPrescription = pre.IdPrescription,
                        Date = pre.Date,
                        
                        MedicamentDto = pre.PrescriptionMedicaments
                            .Select(med => new NewMedicamentDTO()
                            {
                                IdMedicament = med.IdMedicament,
                                Name = med.Medicament.Name,
                                Dose = med.Dose,
                                Description = med.Details
                            }).ToList(),
                        DoctorDto = new DoctorDTO()
                        {
                            IdDoctor = pre.Doctor.IdDoctor,
                            FirstName = pre.Doctor.FirstName
                        }
                    }).ToList()
                
            }).FirstOrDefaultAsync();
        return patient;
    }

    public async Task<bool> DoesPatientExist(int id)
    {
        var possiblePatient = await _context
            .Patients
            .FindAsync(id);
        if (possiblePatient == null)
        {
            return false;
        }

        return true;
    }
}