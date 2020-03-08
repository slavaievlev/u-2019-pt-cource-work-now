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
        
        [HttpPut]
        public IHttpActionResult UnblockPatient(int id)
        {
            _patientService.UnblockPatient(id);
            return Ok(new ResponseModel("Пациент успешно разблокирован! :)"));
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
        
        [HttpPost]
        public IHttpActionResult SendPatientInvoicesToEmail(PatientInvoicesReportDto patientInvoicesReportDto)
        {
            _patientService.SendInvoicesToEmail(new PatientInvoicesReportDto
            {
                DocumentType = patientInvoicesReportDto.DocumentType,
                EndDate = patientInvoicesReportDto.EndDate,
                PatientId = patientInvoicesReportDto.PatientId,
                StartDate = patientInvoicesReportDto.StartDate
            });

            return Ok(new ResponseModel("Отчет отправлен успешно!"));
        }
        
        [HttpGet]
        public IHttpActionResult GetAllInvoices(int id)
        {
            var invoices = _patientService.GetAllInvoices(id);
            return Ok(new ResponseModel(invoices, "Получение счетов пациента прошло успешно!"));
        }
    }
}