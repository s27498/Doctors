using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class PrescriptionService
{
    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task InsertPrescription(InsertDTO insertDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {

                var Prescription = new Prescription()
                {
                    IdPatient = insertDto.PatientDto.IdPatient,
                    Date = insertDto.Date,
                    DueDate = insertDto.DueDate,
                    
                };
                
                await _context.Prescriptions.AddAsync(Prescription);
                await _context.SaveChangesAsync();

                foreach (var Medicament in insertDto.MedicamentDto)
                {
                    var Prescription_Medicament = new Prescription_Medicament()
                    {
                        IdMedicament = Medicament.IdMedicament,
                        Dose = Medicament.Dose,
                        Details = Medicament.Description
                    };
                  await _context.PrescriptionMedicaments.AddAsync(Prescription_Medicament);
                }
                
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<bool> DoesPatientExist(InsertDTO insertDto)
    {
        var possiblePatient = await _context
            .Patients
            .FindAsync(insertDto.PatientDto.IdPatient);

        if (possiblePatient == null)
        {
            return false;
        }

        return true;
    }

    public async Task InsertPatient(InsertDTO insertDto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var Patient = new Patient()
            {
                IdPatient = insertDto.PatientDto.IdPatient,
                Birthdate = insertDto.PatientDto.Birthdate,
                FirstName = insertDto.PatientDto.FirstName,
                LastName = insertDto.PatientDto.LastName
            };
            await _context.Patients.AddAsync(Patient);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<bool> DoesMedicamentExist(InsertDTO insertDto)
    {
        foreach (var Medicament in insertDto.MedicamentDto)
        {
            var possibleMedicament = await _context
                .Medicaments
                .FindAsync(Medicament.IdMedicament);
            if (possibleMedicament == null)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> CheckQuantity(InsertDTO insertDto)
    {
        if (insertDto.MedicamentDto.ToArray().Length > 10)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> CheckDate(InsertDTO insertDto)
    {
        if (insertDto.DueDate >= insertDto.Date)
        {
            return true;
        }

        return false;
    }

}