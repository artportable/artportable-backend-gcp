using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public UserProfile[] UserProfiles
    {
      get =>
        new UserProfile[]
        {
          new UserProfile
          {
            Id = 1,
            UserId = 1,
            Name = "Jimmy",
            Surname = "Lord",
            DateOfBirth = new DateTime(2002, 01, 11),
            Location = "Vallentuna",
            Title = "Konstnär",
            Headline = "Inspirerad av naturens krafter, målar gärna skog",
            About = "I am an experienced joiner with well developed skills and experience in groundwork, concrete finishing and steel fixing and have worked in the construction industry since 1982. I am also a skilled labourer who has supported many different trades over the years. I have a full clean UK driving licence with entitlement of up to 7.5 tonne. I am keen to return to work after a period of training and personal development which has broadened my skills and experiences.",
            InspiredBy = "Långa månskenspromenader",
            StudioText = "Min ataljé",
            StudioLocation = "S:t Eriksplan 89, Stockholm",
            Website = "jimmylord.com",
            InstagramUrl = "www.instagram.com/jimmy",
            FacebookUrl = "www.facebook.com/jimmy",
            BehanceUrl = "www.behance.net/jimmy",
            DribbleUrl = "www.dribble.com/jimmy",
            LinkedInUrl = "www.linkedin.com/jimmy"
          },
          new UserProfile
          {
            Id = 2,
            UserId = 2,
            Name = "Anders",
            Surname = "Rosen",
            DateOfBirth = new DateTime(1990, 02, 12),
            Location = "Bromölla",
            Title = "Konstintresserad",
            Headline = "Intresserad av historiska personer och fruktskålar",
            InspiredBy = "Frukt, historiska personer och god mat",
            StudioText = "Välkommen till min ataljé i stan! Öppet alla vardagar 11-16.",
            StudioLocation = "Valhallavägen 171, Stockholm",
            Website = "www.andersmålarstudio.se"
          },
          new UserProfile
          {
            Id = 3,
            UserId = 3,
            Name = "Ludwig",
            Surname = "Slotte",
            DateOfBirth = new DateTime(1964, 03, 23),
            Location = "Vemdalen",
            Title = "Konstintresserad",
            Headline = "Ny i konstens värld och nyfiken på utbudet"
          },
          new UserProfile
          {
            Id = 4,
            UserId = 4,
            Name = "Niclas",
            Surname = "Kamlind",
            DateOfBirth = new DateTime(1989, 05, 09),
            Location = "Sollentuna",
            Title = "Konstnär",
            Headline = "Ambitös och kreativ konstnär som målar på heltid",
            InspiredBy = "Världen runt omkring mig",
            StudioText = "Min målarbod ligger i utkanten av Nynäshamn och det är här jag skapar alla mina mästerverk. Ring för besök.",
            StudioLocation = "Bagaregatan 20, Nynäshamn",
            Website = "niclasbod.se"
          },
          new UserProfile
          {
            Id = 5,
            UserId = 5,
            Name = "Linus",
            Surname = "Linus",
            DateOfBirth = new DateTime(1972, 11, 06),
            Location = "Stockholm",
            Title = "Konstintresserad",
            Headline = "Jag har kollat på tavlor sen -92"
          },
          new UserProfile
          {
            Id = 6,
            UserId = 6,
            Name = "Svenne",
            Surname = "Banan",
            DateOfBirth = new DateTime(1981, 09, 15),
            Location = "Västerås",
            Title = "Hobbykonstnär",
            Headline = "Kan allt om konst",
            InspiredBy = "Allt och inget"
          },
          new UserProfile
          {
            Id = 7,
            UserId = 7,
            Name = "Lena",
            Surname = "Granris",
            DateOfBirth = new DateTime(1953, 06, 20),
            Location = "Öland",
            Title = "Konstköpare",
            Headline = "Älskar allt som har med konst att göra",
            InspiredBy = "Historisk ariktektur"
          },
          new UserProfile
          {
            Id = 8,
            UserId = 8,
            Name = "Leonardo",
            Surname = "da Vinci",
            DateOfBirth = new DateTime(1452, 04, 15),
            Location = "Florens",
            Title = "Konstnär",
            Headline = "Målar porträtt av människor med dubbel-namn och sånt",
            About = "I’m a nice fun and friendly person, I’m honest and punctual, I work well in a team but also on my own as I like to set myself goals which I will achieve, I have good listening and communication skills. I have a creative mind and am always up for new challenges. I am well organized and always plan ahead to make sure I manage my time well.",
            InspiredBy = "Människor",
            InstagramUrl = "www.instagram.com/leonardo_vinci",
            FacebookUrl = "www.facebook.com/leonardo.da.vinci"
          },
          new UserProfile
          {
            Id = 9,
            UserId = 9,
            Name = "Vincent",
            Surname = "van Gogh",
            DateOfBirth = new DateTime(1853, 03, 10),
            Location = "Holland",
            Title = "Konstnär",
            Headline = "Gillar långa månskenspromenader, oljemålning och absinth",
            InspiredBy = "Tulpaner, träskor och målarfärg"
          },
          new UserProfile
          {
            Id = 10,
            UserId = 10,
            Name = "Alva",
            Surname = "Arnbjørg",
            DateOfBirth = new DateTime(1993, 04, 02),
            Location = "Oslo",
            Headline = "Kreativ konstnärssjäl med sinne för färg och form",
            BehanceUrl = "www.behance.net/alva"
          },
          new UserProfile
          {
            Id = 11,
            UserId = 11,
            Name = "Glenna",
            Surname = "Eilidh",
            DateOfBirth = new DateTime(1994, 12, 06),
            Location = "Kramfors",
            Title = "Målare & kock",
            Headline = "Matglad tjej som gärna målar djur",
            About = "I am a flexible and experienced insurance administrator with excellent time management skills. I am a good communicator with proven inter personal skills and am used to working in a team whilst also being capable of using own initiative. I am skilled In dealing with problems in a resourceful manner and negotiating to achieve beneficial agreement. I am always enthusiastic to learn and undertake new challenges.",
            InspiredBy = "Alla sorters mat men främst italiensk",
            StudioLocation = "Pellevägen 11, Kramfors"
          },
          new UserProfile
          {
            Id = 12,
            UserId = 12,
            Name = "Maggan",
            Surname = "Karlsson",
            DateOfBirth = new DateTime(1959, 12, 19),
            Location = "Malmö",
            Title = "Intresserad",
            Headline = "Målar lite själv men mest intresserad av andras skapelser",
            About = "I am a professionally qualified fire engineer with 7 years experience. I have recently achieved RTITB accreditation in the use of Counterbalance fork lift trucks and I am seeking employment that will make best use of my skills and allow me to develop them further. I am determined and enthusiastic, I have developed good planning & organisational skills and am confident working independently or as part of a team. I am flexible regarding working hours and am able to work a range of shifts.",
            InspiredBy = "Hav och klippor",
            Website = "magganmedpenseln.com"
          },
          new UserProfile
          {
            Id = 13,
            UserId = 13,
            Name = "Vilhelmina",
            Surname = "Henrika",
            DateOfBirth = new DateTime(1948, 10, 15),
            Location = "Växjö",
            Title = "Lärare",
            Headline = "Kollar runt lite bara"
          },
          new UserProfile
          {
            Id = 14,
            UserId = 14,
            Name = "Kaja",
            Surname = "Judit",
            DateOfBirth = new DateTime(1986, 08, 29),
            Location = "Göteborg",
            Title = "Konstnär",
            Headline = "Målar portträtt med akvarell och blyerts",
            About = "I am a hard working, honest individual. I am a good timekeeper, always willing to learn new skills. I am friendly, helpful and polite, have a good sense of humour. I am able to work independently in busy environments and also within a team setting. I am outgoing and tactful, and able to listen effectively when solving problems.",
            InspiredBy = "Staden och människorna i rörelse"
          },
          new UserProfile
          {
            Id = 15,
            UserId = 15,
            Name = "Elena",
            Surname = "Yaroslava",
            DateOfBirth = new DateTime(1979, 06, 20),
            Location = "St Petersburg",
            Title = "Konstnär",
            Headline = "Passionerad artist med huvudet mellan himmel och jord",
            About = "I am a punctual and motivated individual who is able to work in a busy environment and produce high standards of work. I am an excellent team worker and am able to take instructions from all levels and build up good working relationships with all colleagues. I am flexible, reliable and possess excellent time keeping skills.",
            DribbleUrl = "www.dribble.com/yaroslava"
          },
          new UserProfile
          {
            Id = 16,
            UserId = 16,
            Name = "Tom-Lennart",
            Surname = "Bernt",
            DateOfBirth = new DateTime(1984, 07, 31),
            Location = "Nacka",
            Title = "Serietecknare",
            Headline = "Tecknar serier",
            About = "I am an enthusiastic, self-motivated, reliable, responsible and hard working person. I am a mature team worker and adaptable to all challenging situations. I am able to work well both in a team environment as well as using own initiative. I am able to work well under pressure and adhere to strict deadlines.",
            Website = "www.tomlennartsserier.se"
          },
          new UserProfile
          {
            Id = 17,
            UserId = 17,
            Name = "Pablo",
            Surname = "Picasso",
            DateOfBirth = new DateTime(1881, 10, 25),
            Location = "Mougins",
            Title = "Konstnär",
            Headline = "Målar rätt mycket"
          },
          new UserProfile
          {
            Id = 18,
            UserId = 18,
            Name = "Urban",
            Surname = "Loui",
            DateOfBirth = new DateTime(1990, 07, 12),
            Location = "Mariestad",
            Title = "Fotograf",
            Headline = "Åker runt i världen och knäpper bilder",
            About = "I am a dedicated, organized and methodical individual. I have good interpersonal skills, am an excellent team worker and am keen and very willing to learn and develop new skills. I am reliable and dependable and often seek new responsibilities within a wide range of employment areas. I have an active and dynamic approach to work and getting things done. I am determined and decisive. I identify and develop opportunities.",
            LinkedInUrl = "linkedin.com/urban.loui861"
          },
          new UserProfile
          {
            Id = 19,
            UserId = 19,
            Name = "Claude",
            Surname = "Monet",
            DateOfBirth = new DateTime(1840, 11, 14),
            Location = "Paris",
            Title = "Konstnär",
            Headline = "Founder of French Impressionist painting",
            About = "Founder of French Impressionist painting and the most consistent and prolific practitioner of the movement's philosophy of expressing one's perceptions before nature.",
            InspiredBy = "The French countryside",
            DribbleUrl = "dribble.com/monet"
          },
          new UserProfile
          {
            Id = 20,
            UserId = 20,
            Name = "Henri",
            Surname = "Matisse",
            DateOfBirth = new DateTime(1869, 12, 31),
            Location = "Nice",
            Title = "Konstnär",
            Headline = "French artist, known for both my use of colour and my fluid and original draughtsmanship",
            About = "My mastery of the expressive language of colour and drawing, displayed in a body of work spanning over a half-century, won me recognition as a leading figure in modern art.",
            InspiredBy = "Fauves, wild beasts"
          },
          new UserProfile
          {
            Id = 21,
            UserId = 21,
            Name = "Salvador",
            Surname = "Dalí",
            DateOfBirth = new DateTime(1904, 05, 11),
            Location = "Figueres, Spain",
            Title = "Konstnär",
            Headline = "Spanish surrealist artist",
            About = "I'm a Spanish surrealist artist renowned for my technical skill, precise draftsmanship, and the striking and bizarre images in my work. I live in Figueres, Catalonia, Spain. My artistic repertoire includes painting, graphic arts, film, sculpture, design and photography, at times in collaboration with other artists.",
            InspiredBy = "Impressionism and the Renaissance"
          },
          new UserProfile
          {
            Id = 22,
            UserId = 22,
            Name = "Michelangelo",
            Surname = "di Lodovico Buonarroti Simoni",
            DateOfBirth = new DateTime(1475, 03, 06),
            Location = "Tuscany",
            Title = "Konstnär",
            Headline = "Italian sculptor, painter, architect and poet of the High Renaissance",
            About = "I was born in the Republic of Florence, and exerted an unparalleled influence on the development of Western art. Artistic versatility was of such a high order that I'm often considered a contender for the title of the archetypal Renaissance man, along with my rival and elder contemporary, Leonardo da Vinci. Several scholars have described me as the greatest artist of my age and even as the greatest artist of all time.",
          },
          new UserProfile
          {
            Id = 23,
            UserId = 23,
            Name = "Rembrandt",
            Surname = "Harmenszoon van Rijn",
            DateOfBirth = new DateTime(1906, 07, 15),
            Location = "Leiden",
            Title = "Konstnär",
            Headline = "Innovative and prolific master in three media",
            About = "I'm generally considered one of the greatest visual artists in the history of art and the most important in Dutch art history. Unlike most Dutch masters of the 17th century, my work depict a wide range of style and subject matter, from portraits and self-portraits to landscapes, genre scenes, allegorical and historical scenes, and biblical and mythological themes as well as animal studies. My contributions to art came in a period of great wealth and cultural achievement that historians call the Dutch Golden Age, when Dutch art (especially Dutch painting), although in many ways antithetical to the Baroque style that dominated Europe, was extremely prolific and innovative and gave rise to important new genres. Like many artists of the Dutch Golden Age, such as Jan Vermeer of Delft, I was also an avid art collector and dealer. I have never been abroad.",
            InspiredBy = "Nederländerna, tulpanerna och väderkvarnanas land"
          },
          new UserProfile
          {
            Id = 24,
            UserId = 24,
            Name = "Edvard",
            Surname = "Munch",
            DateOfBirth = new DateTime(1863, 12, 12),
            Location = "Oslo",
            Title = "Konstnär",
            Headline = "Skaparen av Skriet, ett one hit wonder",
            About = "Jeg er en norsk maler, grafiker, tidlig representant for ekspresjonismen, og den internasjonalt best kjente norske bildende kunstner.",
            InspiredBy = "Skrik"
          },
          new UserProfile
          {
            Id = 25,
            UserId = 25,
            Name = "Carl Olof",
            Surname = "Larsson",
            DateOfBirth = new DateTime(1853, 05, 28),
            Location = "Stockholm",
            Title = "Konstnär",
            Headline = "En av de mest berömda svenska konstnärerna och kanske den mest folkkäre",
            About = "Jag räknas som en av Sveriges mest betydelsefulla akvarellmålare. Jag är känd för mina akvareller av idylliskt familjeliv.",
            InspiredBy = "Idylliskt familjeliv"
          },
          new UserProfile
          {
            Id = 26,
            UserId = 26,
            Name = "Anders",
            Surname = "Zorn",
            DateOfBirth = new DateTime(1860, 02, 18),
            Location = "Mora",
            Title = "Konstnär",
            Headline = "Svensk konstnär från Dalarna",
            About = "Jag betraktas som en betydande konstnär i Sverige och är även uppskattad utanför Sverige, inte minst i USA, där jag anlitats som porträttmålare av presidenter, företagsledare och societetsfolk. Namnet Zorn kommer efter min tyska far, som på ett bryggeri i Uppsala träffade den där säsongsarbetande modern.",
            InspiredBy = "Dalarna"
          },
          new UserProfile
          {
            Id = 27,
            UserId = 27,
            Name = "Anneli",
            Surname = "Frisk",
            DateOfBirth = new DateTime(1970, 01, 01),
            Location = "Stockholm",
            Title = "Illustratör och Konstnär",
            Headline = "Jag är en konstnär och illustratör som älskar att måla blommor och frukt från min egen trädgård",
            About = "Jag har varit verksam sedan början av 2000-talet och illustrerar för bland annat förlag, företag och organisationer. Jag illustrerar högt och brett, allt från utbildningsmaterial till privata uppdrag. På sidan av mitt eget konstnärskap håller jag kurser och arbetar som bildlärare.",
            InspiredBy = "I livet självt och dess underverk. Jag hittar också inspiration i mina barns inre fantasivärld. De är min största kärlek och motivation.",
            StudioText = "Ja. Boka en tid med mig så jag är på plats",
            Website = "https://artbyanneli.se/",
            FacebookUrl = "https://www.facebook.com/artbyanneli",
            InstagramUrl = "https://www.instagram.com/anneliz74/"
          },
          new UserProfile
          {
            Id = 28,
            UserId = 28,
            Name = "Michael",
            Surname = "Nilsson Ström",
            DateOfBirth = new DateTime(1970, 01, 01),
            Location = "Västerås",
            Title = "Konstnär & Fotograf",
            Headline = "Fotograf och konstnär Michael Nilsson-Ström född 1957",
            About = "Michael har fotograferat sedan barnsben, men under bl.a. Grafic Art studier 1974/75 i San Diego, USA upplevde Michael spelet mellan starka färger och naturligt ljus som spännande och Michael fastnade för impressionismens konstnärer. Under 2000-talet har Michael arbetat med motiv innehållande oftast mer skarpa kontraster och starka färger tillsammans med det naturliga ljuset som ett viktigt redskap. Motiven är hämtade från olika delar av världen. Michael är sedan 1986 bosatt i Västerås och mestadels autodidakt inom foto och konst.",
            InspiredBy = "Konstnären Monet och övriga inom Impressionismen.",
            Website = "http://www.artn-s.se/",
            InstagramUrl = "https://www.instagram.com/artns.se/"
          },
          new UserProfile
          {
            Id = 29,
            UserId = 29,
            Name = "Khrystyna",
            Surname = "Barabanova",
            DateOfBirth = new DateTime(1970, 01, 01),
            Location = "Stockholm",
            Title = "Artist",
            Headline = "I am an aspiring illustrator based in Stockholm, Sweden",
            About = "I have been shaping my art vision through different materials, but watercolor took a special place in my heart. Watercolor is the main interest for me and the most difficult material I’ve ever used. But I like the challenge. The uniqueness of textures and shapes of aquarelle is something that fascinates me to this day. After moving to Sweden in 2018, I joined Stardoll team as an illustrator. I drew countless outfits inspired by famous designers and my interest in fashion began to grow. I started developing my own artistic way in illustration by painting portrait and figure illustrations. My passion led me towards my own unique art style, which I’m proud to share with the world.",
            InspiredBy = "Fashion",
            Website = "https://artbarabanova.com/",
            FacebookUrl = "https://www.facebook.com/khrystyna.barabanova",
            InstagramUrl = "https://www.instagram.com/barabanova_artist/"
          },
          new UserProfile
          {
            Id = 30,
            UserId = 30,
            Name = "Maria",
            Surname = "Segerström",
            DateOfBirth = new DateTime(1970, 01, 01),
            Location = "Falköping",
            Title = "Grafiker",
            Headline = "Arbetar och bor på Mössebergs sluttningar i Vilske-Kleva, Falköping",
            About = "Arbetar i min ateljé samt vid Skaraborgs konstgrafiska verkstad. Arbetar med olika grafiska tekniker som koppargrafik serigrafi. Blandar föreställande bilder med förenklingar för att få olika grafiska uttryck, de starka effekter man kan uppnå genom mönster och upprepningar, innehållsmässigt uttrycka det som finns runt omkring sett genom mina ögon.",
            InspiredBy = "Människor, djur och natur, det som finns runt omkring. Är intresserad av mönster och kontraster samt äldre målningar och skulpturer",
            Website = "http://www.mariasegerstrom.se/",
          }
        };
    }
  }
}
