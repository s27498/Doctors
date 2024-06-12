using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly PrescriptionService _prescriptionService;

    public PrescriptionController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertPrescription([FromBody] InsertDTO insertDto)
    {
        if (!await _prescriptionService.DoesMedicamentExist(insertDto))
        {
            return BadRequest("Wrong medicament provided");
        }

        if (!await _prescriptionService.CheckQuantity(insertDto))
        {
            return BadRequest("Cannot insert more than 10 medicaments");
        }

        if (!await _prescriptionService.CheckDate(insertDto))
        {
            return BadRequest("DueDate >= Date!");
        }
        if (!await _prescriptionService.DoesPatientExist((insertDto)))
        {
            await _prescriptionService.InsertPatient(insertDto);
        }

        await _prescriptionService.InsertPrescription(insertDto);
        return Ok("Prescription has been added!");
    }
}