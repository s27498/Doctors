using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _patientService;

    public PatientController(PatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatient(int id)
    {
        if (!await _patientService.DoesPatientExist(id))
        {
            BadRequest("Patient with given id does not exist! ");
        }

        var result = await _patientService.GetPatient(id);

        return Ok(result);

    }
}