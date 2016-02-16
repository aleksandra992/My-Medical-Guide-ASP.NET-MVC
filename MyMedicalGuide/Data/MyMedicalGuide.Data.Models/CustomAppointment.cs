using MyMedicalGuide.Data.Common.Models;

namespace MyMedicalGuide.Data.Models
{
    public class CustomAppointment : BaseModel<int>
    {
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

    }
}
