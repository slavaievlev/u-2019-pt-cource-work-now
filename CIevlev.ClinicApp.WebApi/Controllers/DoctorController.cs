using System.Web.Http;
using CIevlev.ClinicApp.WebApi.Models;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.WebApi.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public IHttpActionResult CreateDoctor(DoctorBindingModel doctorBindingModel)
        {
            DoctorViewModel doctorViewModel = _doctorService.CreateDoctor(doctorBindingModel);
            return Ok(new ResponseModel(doctorViewModel));
        }
        
        [HttpGet]
        public IHttpActionResult UpdateDoctor(DoctorBindingModel doctorBindingModel)
        {
            DoctorViewModel doctorViewModel = _doctorService.UpdateDoctor(doctorBindingModel);
            return Ok(new ResponseModel(doctorViewModel, "Данные доктора успешно обновлены"));
        }
        
        [HttpGet]
        public IHttpActionResult DeleteDoctor(int doctorId)
        {
            _doctorService.DeleteDoctor(doctorId);
            return Ok(new ResponseModel("Доктор успешно удален"));
        }
        
        [HttpGet]
        public IHttpActionResult GetDoctor(int doctorId)
        {
            DoctorViewModel doctorViewModel = _doctorService.GetDoctor(doctorId);
            return Ok(new ResponseModel(doctorViewModel));
        }
    }
}