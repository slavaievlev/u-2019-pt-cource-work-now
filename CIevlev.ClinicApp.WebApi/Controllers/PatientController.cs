using System.Web.Http;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Dtos;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.WebApi.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientService _patientService;
        
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IHttpActionResult CreatePatient(PatientBindingModel patientBindingModel)
        {
            var patientViewModel = _patientService.CreatePatient(patientBindingModel);
            return Ok(new ResponseModel(patientViewModel, "Аккаунт успешно создан! :)"));
        }
        
        [HttpPut]
        public IHttpActionResult ChangeBonus(int id, ChangeBonusDto changeBonusDto)
        {
            _patientService.ChangeBonus(id, changeBonusDto.NewBonusQuantity);
            return Ok(new ResponseModel("Бонусный счет пациента изменен успешно! :)"));
        }

        [HttpPut]
        public IHttpActionResult BlockPatient(int id)
        {
            _patientService.BlockPatient(id);
            return Ok(new ResponseModel("Пациент успешно заблокирован! :)"));
        }
        
        [HttpGet]
        public IHttpActionResult GetPatient(int id)
        {
            var patientViewModel = _patientService.GetPatient(id);
            return Ok(new ResponseModel(patientViewModel));
        }
        
        [HttpGet]
        public IHttpActionResult GetPatients()
        {
            var patientViewModel = _patientService.GetPatients();
            return Ok(new ResponseModel(patientViewModel));
        }
    }
}