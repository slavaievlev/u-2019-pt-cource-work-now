using System.Web.Http;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

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
        
        [HttpPut]
        public IHttpActionResult UpdateDoctor(DoctorBindingModel doctorBindingModel)
        {
            DoctorViewModel doctorViewModel = _doctorService.UpdateDoctor(doctorBindingModel);
            return Ok(new ResponseModel(doctorViewModel, "Данные доктора успешно обновлены"));
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);
            return Ok(new ResponseModel("Доктор успешно удален"));
        }
        
        [HttpGet]
        public IHttpActionResult GetDoctor(int id)
        {
            DoctorViewModel doctorViewModel = _doctorService.GetDoctor(id);
            return Ok(new ResponseModel(doctorViewModel));
        }
        
        [HttpGet]
        public IHttpActionResult GetDoctors()
        {
            var doctorViewModels = _doctorService.GetDoctors();
            return Ok(new ResponseModel(doctorViewModels));
        }
    }
}