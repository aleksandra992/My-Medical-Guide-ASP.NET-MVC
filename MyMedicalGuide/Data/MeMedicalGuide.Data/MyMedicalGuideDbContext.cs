namespace MeMedicalGuide.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyMedicalGuide.Data.Models;

    public class MyMedicalGuideDbContext : IdentityDbContext<User>
    {
        public MyMedicalGuideDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MyMedicalGuideDbContext Create()
        {
            return new MyMedicalGuideDbContext();
        }
    }
}
