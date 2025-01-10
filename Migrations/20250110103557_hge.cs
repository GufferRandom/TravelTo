using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class hge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "ეს სასტუმრო წარმოადგენს სამგზის ლუქსს და თანამედროვე მომსახურებას.", "თბილისი", "თბილისი გრანდ ჰოტელი", "tbilisi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "ამ სასტუმროში სტუმრები სარგებლობენ საოცარი სანაპიროს ხედებით.", "ბათუმი", "ბათუმი ბიჩ რეზორტი", "batumi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "სასტუმრო გთავაზობთ კომფორტულ პირობებს და შესანიშნავ სამზარეულოს.", "ქუთაისი", "ქუთაისი ბუტიკ ჰოტელი", "kutaisi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "სასტუმრო წარმოადგენს ისტორიულ და კულტურულ გარემოს.", "მცხეთა", "მცხეთა ჰერიტიჯ ინი", "mtskheta@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "ცენტრალური ადგილმდებარეობა, ახლოს სამრეწველო და კულტურული ატრაქციონებთან.", "ზუგდიდი", "ზუგდიდი პარკ ჰოტელი", "zugdidi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "მომსახურება მაღალი ხარისხის, მყუდრო ატმოსფერო და თანამედროვე ოთახები.", "გორი", "გორი ფორტეს ჰოტელი", "gori@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "თელავში მდებარე მყუდრო სასტუმრო, რომელიც გთავაზობთ შესანიშნავ მომსახურებას.", "თელავი", "თელავი უაინ ჰოტელი", "telavi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "სასტუმრო მაღალი ხარისხის მომსახურებითა და ლამაზი ხედებით.", "სიღნაღი", "სიღნაღი ჰილტოპ ჰოტელი", "signagi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "სასტუმრო მშვიდ გარემოში და სრულყოფილი მყუდროებით.", "რაჭა", "რაჭა რეზორტი", "racha@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "ვარძი ჰოტელი გთავაზობთ თანამედროვე ფასის ოპციებს და განსაცვიფრებელ გარემოს.", "ვარძი", "ვარძი რეზორტი", "vardzi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 1,
                column: "Description",
                value: "ანტარქტიდა დედამიწის ყველაზე სამხრეთული კონტინენტია, სადაც არ არსებობს მუდმივი მოსახლეობა, მხოლოდ მკვლევარები.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 2,
                column: "Description",
                value: "თბილისი საქართველოს დედაქალაქია, ცნობილია თავისი ისტორიული ძველი უბნებით და კულტურული მნიშვნელობით.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Description",
                value: "ქუთაისი საქართველოს ისტორიული ქალაქია, გალიას საკათედრო ტაძრითა და მსოფლიოს ერთ-ერთი ძველი უნივერსიტეტით.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "პარიზი საფრანგეთის დედაქალაქია, ცნობილია აიფელის კოშკით და ლუვრის მუზეუმით.", "Paris.jpg" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Description",
                value: "ბათუმი შავი ზღვის სანაპიროზე მდებარე ქალაქია, ცნობილი თავისი სანაპირო პარკებით და კურორტებით.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "მაიამი, აშშ-ის ფლორიდაში მდებარე ქალაქია, ცნობილი თავისი ფინანსური, კულტურული და სავაჭრო ცენტრის როლით.", "Miami.jpg" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "გორი ქალაქია საქართველოში, ცნობილია თავისი ისტორიული მნიშვნელობით და გორის ციხით.", "Gori.jpg" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "თელავი ქალაქია კახეთში, ცნობილი თავისი ღვინის კულტურით და ისტორიული ძეგლებით.", "Telavi.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "es sastumro mdebareobs dedamiwis mwervalze romelzedac iyo guini", "RobotiqsiHotel", "Robotiqsi Grand Hotel", "gmail@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Es sastumro mdebareobs msoflios yvelaze civ wertislhi wesit esaaa", "AntarqtidaHotel", "Antarqtida Luxury Suites", "antarqtida@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Tbilisi tbilisi tbilisi uni uni uni btu ilia japan tsu.", "TbilisiHotel", "Tbilisi City Hotel", "tbilisi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Kutaisi kutaisi kutaisi ratqmaunda kutasisi rogorc yoveltvbis kutaisi.", "KutaisiHotel", "Kutaisi Boutique Hotel", "kutaisi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Batumi bautmi bautmi zfgva zgva zgva meti meti meti.", "BatumiHotel", "Batumi Beach Resort", "batumi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Mtskheta es xom mcxetaa mcxetaa azrze ar var ra davwero amaze.", "MtskhetaHotel", "Mtskheta Heritage Inn", "mtskheta@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Zugdidi es xom zugdidia yvelaze didi farti romelic daixarja", "ZugdidiHotel", "Zugdidi Park Hotel", "zugdidi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Gori gori gori amis meti ra unda vtqva es xom goria gorta shoris.", "GoriHotel", "Gori Fortress Hotel", "gori@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Telavi telavi telavi azrze ar var ra davwero amashi mara telaviaMountains.", "TelaviHotel", "Telavi Wine Hotel", "telavi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Lokacia", "Name", "gmail" },
                values: new object[] { "Signagi signagi signagi es xom signagia azrze ar var ra davwero amazec amitomac signagi signagia.", "SignagiHotel", "Signagi Hilltop Hotel", "signagi@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 1,
                column: "Description",
                value: "ანტარქტიდა — დედამიწის ყველაზე მაღალი კონტინენტია, რომლის ზედაპირის საშუალო სიმაღლე ზღვის დონიდან შეადგენს 2000 მეტრზე მეტს, ხოლო კონტინენტის ცენტრში აღწევს 4000 მეტრს.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 2,
                column: "Description",
                value: "თბილისი კავკასიის რეგიონის მნიშვნელოვანი ინდუსტრიული, სოციალური და კულტურული ცენტრია და ბოლო დროს ერთ-ერთი უმნიშვნელოვანესი სატრანსპორტო კვანძი ხდება გლობალური ენერგომატარებლებისა და სავაჭრო პროექტებისთვის (იხ. ბაქო-თბილისი-ჯეიჰანის ნავთობსადენი და ბაქო-თბილისი-ერზერუმის გაზსადენი). ქალაქი ისტორიული აბრეშუმის დიდი გზის ერთ-ერთ მარშრუტზე მდებარეობს და მნიშვნელოვანი სავაჭრო/სატრანზიტო ცენტრის პოზიცია უჭირავს რუსეთის ჩრდილო კავკასიას, თურქეთსა და ტრანსკავკასიის სომხეთისა და აზერბაიჯანის რესპუბლიკების გადაკვეთაზე სტრატეგიული მდებარეობით.");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Description",
                value: "ქუთაისი — ქალაქი და მუნიციპალიტეტი საქართველოში, იმერეთის მხარის ადმინისტრაციული ცენტრი, სიდიდით მეოთხე ქალაქი საქართველოში, საქართველოს სამეფოს ისტორიული დედაქალაქი, ქუთაისის საეპისკოპოსოს ისტორიული ცენტრი. მდებარეობს მდინარე რიონზე. მოსახლეობა 130 400 ადამიანი (2023). ");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "პარიზი (ფრანგ. Paris [paˈʁi] პაღი) — საფრანგეთის დედაქალაქი და ქვეყნის უდიდესი ქალაქია, ასევე ადმინისტრაციული ცენტრი ილ-დე-ფრანსის რეგიონის, რომელიც მოიცავს პარიზსა და მის შემოგარენს. პარიზი ევროპის წამყვანი კულტურული, ბიზნეს და პოლიტიკური ცენტრია, დამახასიათებელი ნეოკლასიკური არქიტექტურითა და მისი გავლენით მოდასა და ხელოვნებაზე. მეტსახელად „სინათლის ქალაქი“ (la Ville Lumière), პარიზი XIX საუკუნიდან მოყოლებული ყველაზე რომანტიკული ქალაქის რეპუტაციით სარგებლობს. ", "Los-AngelesCa.jfif" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Description",
                value: "ბათუმი — ქალაქი და მუნიციპალიტეტი[5] საქართველოში, არის აჭარის ავტონომიური რესპუბლიკის ადმინისტრაციული ცენტრი. ბათუმი არის მოსახლეობის რაოდენობით მეორე ქალაქი საქართველოში, მსხვილი საერთაშორისო ნავსადგური შავი ზღვის სამხრეთ-აღმოსავლეთ სანაპიროზე, მნიშვნელოვანი სამრეწველო, კულტურული და ტურისტული ცენტრი საქართველოში. ");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "მაიამი (ინგლ. Miami) — ქალაქი აშშ-ში, ფლორიდის შტატში. მდებარეობს შტატის სამხრეთ-აღმოსავლეთ ნაწილში, ატლანტის ოკეანის სანაპიროზე. 2013 წლის მონაცემებით მოსახლეობა 417,650 კაცი. ფორბსი მაიამი მოწინავე ქალაქია ფინანსების, კომერციის, კულტურის, მედიის, ხელოვნებისა და საერთაშორისო ვაჭრობის სექტორებში. მაიამის პორტი ცნობილია როგორც „მსოფლიოს კრუიზული დედაქალაქი“.[1] მაიამის პორტს ჰყავს მსოფლიოში ყველაზე მეტი კრუიზული ხაზი და მგზავრები.[2] 2010 წელს მაიამი შეფასდა როგორც მეშვიდე ყველაზე მნიშვნელოვანი ქალაქი აშშ-ში და 33-ე მსოფლიოში. 2008 წელს მაიამი ფორბსის მიერ შეფასდა როგორც „ამერიკის უსუფთავესი ქალაქი“. 2009 წელს ცნობილმა შვეიცარიულმა ბანკმა იუ-ბი-ესმა შეისწავლა მსოფლიოს 73 უმდიდრესი ქალაქი და მაიამი შეაფასა როგორც ყველაზე მდიდარი ქალაქი აშშ-ში, ხოლო მეთხუთმეტე უმდიდრესი ქალაქი მსოფლიოში.[3] ", "Brazil.jfif" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "გორი — ქალაქი საქართველოში, შიდა ქართლის მხარეში, გორის მუნიციპალიტეტისა და შიდა ქართლის მხარის ადმინისტრაციული ცენტრი. მდებარეობს მდინარეების მტკვრისა და ლიახვის შესართავთან, ძირითად სატრანსპორტო გზების გზასაყარზე, თბილისიდან 76-ე კილომეტრში (რკინიგზით).", "Denmark.jfif" });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "Description", "image_name" },
                values: new object[] { "მთელავი — ქალაქი საქართველოში, კახეთის მხარისა და თელავის მუნიციპალიტეტის ადმინისტრაციული ცენტრი. მოსახლეობა 19 629 (2014 წ.) ადამიანი. ", "Spain.jfif" });
        }
    }
}
