using System.Web.Http;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.WebApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;
        private readonly IMailService _mailService;

        public ReportController(IReportService reportService, IMailService mailService)
        {
            _reportService = reportService;
            _mailService = mailService;
        }
        
        [HttpPost]
        public IHttpActionResult SendPatientInvoices(PatientInvoicesBindingModel patientInvoicesBindingModel)
        {
            var pathToFile = _reportService.GetPatientInvoicesAsPhysicalPath(new PatientInvoicesBindingModel
            {
                DocumentType = patientInvoicesBindingModel.DocumentType,
                EndDate = patientInvoicesBindingModel.EndDate,
                PatientId = patientInvoicesBindingModel.PatientId,
                StartDate = patientInvoicesBindingModel.StartDate
            });
            
            _mailService.SendMessageToPatient(patientInvoicesBindingModel.PatientId, "", pathToFile);

            return Ok(new ResponseModel("Отчет отправлен успешно!"));
        }

        [HttpGet]
        public IHttpActionResult GetPatientInvoices(PatientInvoicesBindingModel patientInvoicesBindingModel)
        {
            var bytes = _reportService.GetPatientInvoicesAsByteArray(new PatientInvoicesBindingModel
            {
                DocumentType = patientInvoicesBindingModel.DocumentType,
                EndDate = patientInvoicesBindingModel.EndDate,
                PatientId = patientInvoicesBindingModel.PatientId,
                StartDate = patientInvoicesBindingModel.StartDate
            });

            return Ok(new ResponseModel(bytes, "Отчет сформирован успешно!"));
        }
    }
}