using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CMSApplication.DTOs.RequestModel;
using CMSApplication.Interfaces.Services;

namespace CMSApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("CreateAppointment/{donorId}/{requestId}")]
        public async Task<IActionResult> CreateAppointment([FromForm] CreateAppointmentRequestModel model, [FromRoute]int donorId, [FromRoute]int requestId)
        {
            var appoint = await _appointmentService.CreateAppointment(model, donorId, requestId);
            if(appoint.Success == false)
            {
                return BadRequest(appoint);
            }
            return Ok(appoint);
        }

        [HttpPut("ApproveAppointment/{id}")]
        public async Task<IActionResult> ApproveAppointment([FromRoute] int id)
        {
            var appoint = await _appointmentService.ApproveAppointment(id);
            if (appoint.Success == false)
            {
                return BadRequest(appoint);
            }
            return Ok(appoint);
        }

        [HttpPut("UpdateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment([FromForm]UpdateAppointmentRequestModel model, [FromRoute]int id)
        {
            var update = await _appointmentService.UpdateAppointment(model, id);
            if(update.Success == false)
            {
                return BadRequest(update);
            }
            return Ok(update);
        }


        [HttpGet("GetByCharityHomeId/{id}")]
        public async Task<IActionResult> GetByCharityHomeId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetByCharityHomeId(id);
            if (appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetApprovedByDonorId/{id}")]
        public async Task<IActionResult> GetApprovedByDonorId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetApprovedByDonorId(id);
            if(appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetUnapprovedByDonorId/{id}")]
        public async Task<IActionResult> GetUnaccomplishedByDonorId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetUnapprovedByDonorId(id);
            if (appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetApprovedByCharityHomeId/{id}")]
        public async Task<IActionResult> GetApprovedByCharityHomeId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetApprovedByCharityHomeId(id);
            if(appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetUnapprovedByCharityHomeId/{id}")]
        public async Task<IActionResult> GetUnapprovedByCharityHomeId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetUnapprovedByCharityHomeId(id);
            if (appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetById(id);
            if (appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetByDonorId/{id}")]
        public async Task<IActionResult> GetByDonorId([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetByDonorId(id);
            if (appointments.Success == false)
            {
                return BadRequest(appointments);
            }
            return Ok(appointments);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var appointment = await _appointmentService.GetAll();
            if(appointment.Success == false)
            {
                return BadRequest(appointment);
            }
            return Ok(appointment);
        }
    }
}
