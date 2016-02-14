using MyMedicalGuide.Data.Common.Models;

namespace MyMedicalGuide.Data.Models
{
    public class CustomAppointment 
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

    }
}
