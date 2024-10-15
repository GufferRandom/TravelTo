using TravelTo.Models;

namespace TravelTo.Data
{
    public class SeedingData
    {
        public static void Seed(ApplicationDataContext context)
        {
            context.Companies.AddRange(
            new Company { Company_Id = 1, owner = "gela", description = "saswauli kompania romelic arasdros iarsebs", Name = "TBCKVADRO", img_name = "tbc_image.png" },
            new Company { Company_Id = 2, owner = "NEKA", description = "raxdeba sh", Name = "liberti", img_name = "liberti_img.png" },
            new Company { Company_Id = 3, owner = "NAK", description = "imedia", Name = "bog", img_name = "bog_image.png" },
            new Company { Company_Id = 4, owner = "bark", description = "iarsebs", Name = "kripto", img_name = "credit_bank.png" }
        );

            context.Turebis.AddRange(
        new Turebi { id = 1, Name = "Antarqtida", Description = "aq iyo batoni wyali romelmac wyali dalia", Price = 5.99, image_name = "31394_1.jpg", Company_Id = 1 },
        new Turebi { id = 2, Name = "Tbilisi", Description = "tbilo tibifli", Price = 15.99, image_name = "59564_1.jpg", Company_Id = 3 },
        new Turebi { id = 3, Name = "Parizi", Description = "parizelta dedaqali", Price = 6.99, image_name = "59564_1.jpg", Company_Id = 2 },
        new Turebi { id = 4, Name = "Los-Angeles, CA", Description = "მაგარიი პონტიიი", Price = 15555, image_name = "ee2aa1e4-37d6-41e1-a3b5-ee7d35f0202d.jfif", Company_Id = 4 },
        new Turebi { id = 5, Name = "Italy", Description = "მაგარიი პონტიიი", Price = 12341, image_name = "bffe2b9f-956c-41a5-a72e-12b08c899a45.jfif", Company_Id = 1 },
        new Turebi { id = 6, Name = "Brazil", Description = "მაგარიი პონტიიი", Price = 15111, image_name = "b373e51c-0ba1-4f3b-887d-3499cb200d3c.jpg", Company_Id = 2 },
        new Turebi { id = 7, Name = "Denmark", Description = "მაგარიი პონტიიი", Price = 19000, image_name = "f521cee9-6c84-4a02-8f75-9800f0002a53.jfif", Company_Id = 4 },
        new Turebi { id = 8, Name = "Spain", Description = "მაგარიი პონტიიი", Price = 23000, image_name = "6d4ea991-f9a5-4ec6-8550-0e4e02e5ab4c.jfif", Company_Id = 3 }
    );

            context.SaveChanges();
        }

    }
}
