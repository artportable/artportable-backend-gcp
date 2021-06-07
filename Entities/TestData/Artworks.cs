using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Artwork[] Artworks
    {
      get =>
        new Artwork[]
        {
          new Artwork()
          {
            Id = 1,
            PublicId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
            UserId = 10,
            PrimaryFileId = 1,
            Title = "Bergskvinna",
            Description = "Kvinna blickar ut över en lång bergskedja",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 2,
            PublicId = new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
            UserId = 8,
            PrimaryFileId = 3,
            Title = "Nattvarden",
            Description = "Målad ca år 1495–1498 i klostret Santa Maria delle Grazie i Milano och föreställer Jesus sista måltid",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 3,
            PublicId = new Guid("b24e3df5-0394-468d-9c1d-db1252fea920"),
            UserId = 17,
            PrimaryFileId = 4,
            Title = "Blue Nude",
            Description = "Ett av mina tidigaste mästerverk från min blåa period",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 4,
            PublicId = new Guid("9f35e705-637a-4bbe-8c35-402b2ecf7128"),
            UserId = 17,
            PrimaryFileId = 5,
            Title = "The Old Guitarist",
            Description = "Oljemålning skapad år 1903-1904. Föreställer en äldre, blind man lutad över sin gitarr medan han spelar på gatorna i Barcelona. Tavlan finns utställd på Art Institute of Chicago.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 5,
            PublicId = new Guid("939df3fd-de57-4caf-96dc-c5e110322a96"),
            UserId = 2,
            PrimaryFileId = 6,
            Title = "Antibes",
            Description = "Mordern målning av Antibes",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 6,
            PublicId = new Guid("d70f656d-75a7-45fc-b385-e4daa834e6a8"),
            UserId = 14,
            PrimaryFileId = 7,
            Title = "Stonehenge",
            Description = "Mordern målning av Stonehenge",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 7,
            PublicId = new Guid("ce1d2b1c-7869-4df5-9a32-2cbaca8c3234"),
            UserId = 9,
            PrimaryFileId = 9,
            Title = "Stjärnenatt",
            Description = "Stjärnenatt i Saint-Rémy föreställer en nattlig sydfransk vy med solrosor och en virvlande natthimmel. Tavlan finns idag i Museum of Modern Art i New York.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 8,
            PublicId = new Guid("2645bd94-3624-43fc-b21f-1209d730fc71"),
            UserId = 15,
            PrimaryFileId = 12,
            Title = "At Cap d'Antibes",
            Description = "Ett av alla tallträd längs Cap d'Antibes. Originalverk av Claude Monet.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 9,
            PublicId = new Guid("3f41dc87-e8de-42ee-ac8d-355e4d3e1a2d"),
            UserId = 9,
            PrimaryFileId = 14,
            Title = "Potatisätarna",
            Description = "Oljemålning som skildrar proletär- och bondelivet i byn Neuen",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 10,
            PublicId = new Guid("d3118665-43e3-4905-8848-5e335a428dd5"),
            UserId = 10,
            PrimaryFileId = 8,
            SecondaryFileId = 11,
            Title = "Jovialisk",
            Description = "Abstrakt entusiasm fångad av en miljon penseldrag. I min studio har jag målat hundratals verk som detta.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 11,
            PublicId = new Guid("136f358d-98fb-4961-855c-59d5a6d1fa19"),
            UserId = 1,
            PrimaryFileId = 2,
            SecondaryFileId = 13,
            TertiaryFileId = 10,
            Title = "Vitlökskök",
            Description = "En vitlök som jag plockade från köket och målade av",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 12,
            PublicId = new Guid("d38a9805-0aea-4e4b-a882-5a91406d3287"),
            UserId = 6,
            PrimaryFileId = 17,
            SecondaryFileId = 20,
            Title = "Street in Birmingham",
            Description = "A busy street in Birmingham in the early 1900s",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 13,
            PublicId = new Guid("9d5a7c23-86b6-4e90-b305-e8349894e26c"),
            UserId = 6,
            PrimaryFileId = 18,
            Title = "Flicka på äng",
            Description = "Akvarellmålning av en liten flicka som sitter på knä på en äng och plockar blommor",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 14,
            PublicId = new Guid("c78706f9-b8b8-4fbf-bed8-f580e826b861"),
            UserId = 7,
            PrimaryFileId = 28,
            SecondaryFileId = 27,
            Title = "Color explosion",
            Description = "When the watercolors meet",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 15,
          //   PublicId = new Guid("ed1c9962-eaa0-454e-ac02-2b0f5cfc8fc4"),
          //   UserId = 4,
          //   PrimaryFileId = 29,
          //   Title = "Liggande fjäril",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 16,
            PublicId = new Guid("4a0de334-4ff4-4ff7-920a-8a99dfcd9cc9"),
            UserId = 7,
            PrimaryFileId = 35,
            SecondaryFileId = 59,
            TertiaryFileId = 52,
            Title = "Sommaräng",
            Description = "Grönt.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 17,
            PublicId = new Guid("ddef3c91-1102-422d-b2c5-661e79806001"),
            UserId = 12,
            PrimaryFileId = 46,
            Title = "Vintergård",
            Description = "Sverige År 1752. Tar med familjen på julmarknad.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 18,
            PublicId = new Guid("b4d44cc3-aa13-4eee-a713-e2e71de7ade7"),
            UserId = 12,
            PrimaryFileId = 47,
            SecondaryFileId = 87,
            Title = "Blomsterlandet",
            Description = "Stina plockar blommor en somring afton i maj månad. Målad med fingerfärg.",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 19,
          //   PublicId = new Guid("86d4e142-6d72-4e9b-bd6d-ceeea589b333"),
          //   UserId = 4,
          //   PrimaryFileId = 48,
          //   Title = "Självporträtt",
          //   Description = "Jag fast utan armar",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 20,
            PublicId = new Guid("251e53ad-1cd6-4878-924a-e58ebc6975e8"),
            UserId = 11,
            PrimaryFileId = 57,
            SecondaryFileId = 150,
            Title = "Tiger",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 21,
            PublicId = new Guid("659ec539-e7f5-4123-8e5a-3ec4d8c157c5"),
            UserId = 12,
            PrimaryFileId = 58,
            Title = "Skogsmänniskor",
            Description = "Man och kvinna med arborister som frisörer. Svartvit bild målad i Photoshop.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 22,
            PublicId = new Guid("bb7f7e01-e4e6-479a-8a7a-d42702599585"),
            UserId = 12,
            PrimaryFileId = 65,
            Title = "Blommor i färg",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 23,
            PublicId = new Guid("8a4d54f1-b3f3-4809-9175-95c8fb397cec"),
            UserId = 8,
            PrimaryFileId = 21,
            Title = "Mona Lisa",
            Description = "En av världens mest berömda målningar (just saying) som jag målat en gång när jag hade tråkigt i Italien.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 24,
            PublicId = new Guid("d4ec3acf-54a5-4f01-8bf2-2acb87821d1e"),
            UserId = 14,
            PrimaryFileId = 66,
            Title = "Berg",
            Description = "Vacker målning av ett berg med en levande himmel",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 25,
            PublicId = new Guid("567055b7-837c-4d98-9102-97752c97eac2"),
            UserId = 15,
            PrimaryFileId = 67,
            Title = "Tegelvägg med synfält",
            Description = "Rymdvägg som lämnar mycket åt fantasin",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 26,
            PublicId = new Guid("f931fc00-282e-4ec1-869f-39caf1e075c5"),
            UserId = 15,
            PrimaryFileId = 24,
            SecondaryFileId = 125,
            TertiaryFileId = 126,
            Title = "Blåbär",
            Description = "Blåbär som rymmer från sin skål",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 27,
            PublicId = new Guid("7ac18c58-8f58-4fde-8577-039c3ff09491"),
            UserId = 11,
            PrimaryFileId = 72,
            Title = "Petit svan",
            Description = "3x6 cm målning av en svan i kvällsljus",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 28,
            PublicId = new Guid("87a1711f-d846-48e7-986a-d6b7cc684e5f"),
            UserId = 11,
            PrimaryFileId = 73,
            Title = "Black panther",
            Description = "Svart panter målad i akvarell",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 29,
            PublicId = new Guid("b3699690-7984-45e5-b84e-2792259180f3"),
            UserId = 12,
            PrimaryFileId = 79,
            Title = "Rapsfält",
            Description = "Utsikt över rapsfält och ängar",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 30,
            PublicId = new Guid("798f9bda-11cd-4ed6-9c0d-85c27c01e101"),
            UserId = 1,
            PrimaryFileId = 80,
            Title = "Blå stad",
            Description = "Porslinsmålad stad i Vietnam med karaktäristiska berg som tornar upp i bakgrunden",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 31,
            PublicId = new Guid("0e7bfe73-a928-472d-a30d-46d09902a525"),
            UserId = 1,
            PrimaryFileId = 81,
            Title = "Glänta",
            Description = "Gläntan en sensommarkväll",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 32,
            PublicId = new Guid("e5128d1d-833f-4802-ae1d-ef7f264d1ef7"),
            UserId = 1,
            PrimaryFileId = 88,
            SecondaryFileId = 71,
            Title = "Berg och dal-bana",
            Description = "Målning som väcker en berg och dal-bana av känslor",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 33,
            PublicId = new Guid("fc7117cf-fb36-479b-b3b1-aa08c3ab51e0"),
            UserId = 1,
            PrimaryFileId = 89,
            Title = "Old Amsterdam",
            Description = "Amsterdams gator en höstdag 2005",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 34,
            PublicId = new Guid("282ad43c-6438-4b82-b4cd-ebf862081247"),
            UserId = 1,
            PrimaryFileId = 90,
            Title = "Blåklint på ängen",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 35,
          //   PublicId = new Guid("869c3fdf-a24e-40cb-8355-121e4e5bfc6b"),
          //   UserId = 4,
          //   PrimaryFileId = 91,
          //   Title = "Glad sol",
          //   Description = "Ett mästerverk utom dess like",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 36,
            PublicId = new Guid("3e7e1abc-2faa-4b93-a8de-93e46bc1944f"),
            UserId = 12,
            PrimaryFileId = 26,
            Title = "Traditionell stuga på Island",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 37,
            PublicId = new Guid("c050a04c-1a7a-4c7b-9c43-9107991fb3e7"),
            UserId = 12,
            PrimaryFileId = 96,
            SecondaryFileId = 68,
            TertiaryFileId = 86,
            Title = "Vattendelare",
            Description = "Abstrakt målning gjord med hårt blandade akrylfärger",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 38,
            PublicId = new Guid("beb73cae-4831-4b83-b7b4-04f83ca6c797"),
            UserId = 11,
            PrimaryFileId = 97,
            SecondaryFileId = 44,
            TertiaryFileId = 38,
            Title = "Ståtlig kråka",
            Description = "Kråka njuter av den blåa vardagen",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 39,
          //   PublicId = new Guid("7512794a-546e-4f06-bc70-0aa4415e5cf5"),
          //   UserId = 4,
          //   PrimaryFileId = 32,
          //   Title = "Mitt hus",
          //   Description = "Mitt hus från när jag växte upp. Färgvalet framhäver dörren på ett sätt man aldrig skulle kunna tänka sig var möjligt.",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 40,
            PublicId = new Guid("15bca89d-03f0-40c8-8537-8a7614c88040"),
            UserId = 15,
            PrimaryFileId = 41,
            SecondaryFileId = 60,
            Title = "Blommor i rosa nyanser",
            Description = "Ett vackert urval av blommor i en rosa färgexplosion",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 41,
            PublicId = new Guid("dd575506-fcb5-4314-b9cc-dbb4c49b1c7d"),
            UserId = 15,
            PrimaryFileId = 45,
            Title = "Insidan av ett hus",
            Description = "I huset finns det en säng, två stolar, ett nattduksbord/matbord, sex tavlor, en vas, grönt golv och blåa dörrar. Fönstret kan man inte se ut igenom för det är övermålat. Några krokar finns på väggen så att man kan hänga upp sina kläder efter en lång dag utomhus.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 42,
            PublicId = new Guid("3a8782d6-a233-4911-921a-40b65fa8cee5"),
            UserId = 1,
            PrimaryFileId = 62,
            Title = "Hus på landet",
            Description = "Mitt hus på landet, precis intill den gamla stadsmuren.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 43,
            PublicId = new Guid("f88e0692-5a41-4bb1-90e4-99de87eb6ec0"),
            UserId = 11,
            PrimaryFileId = 25,
            Title = "Gnägg",
            Description = "Häst som gnäggar",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 44,
            PublicId = new Guid("71515573-101a-4d37-af6c-55ebce289e33"),
            UserId = 15,
            PrimaryFileId = 78,
            Title = "Flicka matar får",
            Description = "Historisk bild av en ung flicka som tar hand om familjens får",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 45,
            PublicId = new Guid("5455f37d-b86f-46ec-940d-53cfb01960e5"),
            UserId = 18,
            PrimaryFileId = 85,
            Title = "Staty i Aten",
            Description = "Fotot föreställer en smutsig staty som jag hittade när jag reste runt i Grekland",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 46,
            PublicId = new Guid("dd270b3a-6cb1-41d8-b90d-96ea20fc4c05"),
            UserId = 12,
            PrimaryFileId = 92,
            Title = "Berg med spegelbild",
            Description = "Mäktigt berg som speglas mot vattenytan i en liten sjö",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 47,
            PublicId = new Guid("bc21e104-4f26-48c1-9ffb-f049ac970aba"),
            UserId = 12,
            PrimaryFileId = 54,
            Title = "Höstträd",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 48,
            PublicId = new Guid("7b9001d1-e5a2-4364-975d-5ca0e3f1b803"),
            UserId = 12,
            PrimaryFileId = 56,
            Title = "Bukett i vas",
            Description = "En blombukett i en vas som jag fick när jag fyllde jämnt och bestämde mig för att måla av",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 49,
            PublicId = new Guid("b1d933e6-d988-4ce3-a076-3be852885f26"),
            UserId = 8,
            PrimaryFileId = 23,
            Title = "Jesus Maria",
            Description = "En nunna från ett lokalt kloster",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 50,
            PublicId = new Guid("bd68cfb1-29ce-4836-8a6f-0c2536835a16"),
            UserId = 12,
            PrimaryFileId = 77,
            Title = "Skymningsskog",
            Description = "Trädtoppar som avbildas mot den rödlila himmlen en vårnatt i april",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 51,
            PublicId = new Guid("c99cf456-221d-4214-9c9f-9df85ce31aa8"),
            UserId = 8,
            PrimaryFileId = 31,
            Title = "Espresso",
            Description = "Skylt på café från min resa längs den italienska rivieran",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 52,
          //   PublicId = new Guid("3183d9ed-4daa-4be0-8d54-b477ff936cec"),
          //   UserId = 4,
          //   PrimaryFileId = 61,
          //   Title = "Nyckelpiga",
          //   Description = "Formidabel målning av en nyckelpiga med sex prickar avbildad med kritor i rött och svart",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 53,
            PublicId = new Guid("313d392e-6036-41a8-9178-f7d6123779a4"),
            UserId = 1,
            PrimaryFileId = 75,
            Title = "Den perfekta vågen",
            Description = "Surfare fångar den perfekta vågen",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 54,
            PublicId = new Guid("d743b5b4-5108-4b14-afbd-9cb1af025c28"),
            UserId = 11,
            PrimaryFileId = 83,
            SecondaryFileId = 43,
            Title = "Häst i stall",
            Description = "Ytterligare en häst",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 55,
            PublicId = new Guid("06db3b01-10e8-451e-88f3-9d2f49594a0a"),
            UserId = 12,
            PrimaryFileId = 22,
            Title = "Kråkträd",
            Description = "Ståtligt träd på äng en mörk åsknatt",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 56,
            PublicId = new Guid("cdf1dae1-1774-4d6e-8d0d-b6514f48ed4c"),
            UserId = 15,
            PrimaryFileId = 136,
            Title = "Hund möter igelkott",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 57,
            PublicId = new Guid("da86471c-9d70-48b0-b41b-314e4a5ff49c"),
            UserId = 15,
            PrimaryFileId = 69,
            Title = "Molnig soldag",
            Description = "Solen som sträcker sig genom molnen i akvarell",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 58,
            PublicId = new Guid("e110c657-283e-4864-a444-ce198dc7008a"),
            UserId = 2,
            PrimaryFileId = 84,
            Title = "Vårfågel",
            Description = "Fågel på gren. Målad i akvarell.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 59,
            PublicId = new Guid("cde5138b-2ab0-4698-888b-57b87da1a77e"),
            UserId = 12,
            PrimaryFileId = 51,
            Title = "Höstlöv på höstlov",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 60,
            PublicId = new Guid("de6f035e-cd91-48be-a7bb-802ab424b485"),
            UserId = 14,
            PrimaryFileId = 42,
            Title = "Skogsglänta",
            Description = "Glänta i skogen får finbesök i form av två ståtliga rådjur",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 61,
            PublicId = new Guid("46e7b1a8-92fc-4036-b2fb-47c7118221c1"),
            UserId = 8,
            PrimaryFileId = 94,
            Title = "Can't touch this",
            Description = "Två händer som inte rör vid varandra. Populärt motiv just nu.",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 62,
          //   PublicId = new Guid("373fb4e9-9d4e-47c5-8a26-f9db600138bf"),
          //   UserId = 4,
          //   PrimaryFileId = 95,
          //   Title = "Min kompis hus",
          //   Description = "Huset som min kompis Ludde bor i målad med många fönster och en dörr med ett konstigt handtag",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 63,
            PublicId = new Guid("4e03c237-4384-413d-8727-39a79afc6f54"),
            UserId = 12,
            PrimaryFileId = 99,
            SecondaryFileId = 142,
            Title = "Träd med sjöutsikt",
            Description = "Björkar vid strandenkanten av Mälaren",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 64,
            PublicId = new Guid("f484ae02-0897-4c96-8197-450becfc6a9f"),
            UserId = 12,
            PrimaryFileId = 100,
            Title = "Napoleon Bonaparte",
            Description = "Napoleon Bonaparte vid sin sista erövring",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 65,
            PublicId = new Guid("736cb4cf-3667-4510-a41a-51b41a0c2594"),
            UserId = 11,
            PrimaryFileId = 103,
            Title = "Två hästar",
            Description = "Ett möte mellan två hästar som itne har setts på länge",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 66,
          //   PublicId = new Guid("3798154d-fc5c-4c17-89fd-3aa6852c3585"),
          //   UserId = 4,
          //   PrimaryFileId = 104,
          //   Title = "Bi",
          //   Description = "Enastående avbildande av ett bi, naturens egen Rolls Royce",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 67,
            PublicId = new Guid("132e391d-95d0-4f84-ac7a-86c734b5c8c0"),
            UserId = 2,
            PrimaryFileId = 105,
            Title = "Flyttfåglar",
            Description = "Två fåglar sittandes på en pinne målad med lite glitter",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 68,
            PublicId = new Guid("94951259-47e2-4253-9e25-323b43bee568"),
            UserId = 12,
            PrimaryFileId = 107,
            Title = "Kvinna från Falun",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 69,
            PublicId = new Guid("02de9e6a-7dcb-46df-aa15-fb7181dad5b2"),
            UserId = 9,
            PrimaryFileId = 109,
            Title = "Skriet",
            Description = "Min tolkning av Munchs Skriet",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 70,
            PublicId = new Guid("d5438e8e-1e93-407f-91f4-4ee47dc4b568"),
            UserId = 2,
            PrimaryFileId = 102,
            Title = "Kingfisher",
            Description = "Bästa fågeln hitills om jag får säga det själv",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 71,
            PublicId = new Guid("0ac34b2c-3a8d-428f-b140-32df775f2183"),
            UserId = 12,
            PrimaryFileId = 101,
            SecondaryFileId = 70,
            Title = "Nya Guinea",
            Description = "Landskapsmålning av Nya Guinea",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 72,
            PublicId = new Guid("10279b02-b064-4693-92a5-39fa38bdafd7"),
            UserId = 9,
            PrimaryFileId = 108,
            Title = "Landet",
            Description = "Landskapsmålning av hus på landet med en krullig äng framför",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 73,
            PublicId = new Guid("1027050e-f713-4840-aab8-a47049501bf2"),
            UserId = 11,
            PrimaryFileId = 110,
            Title = "Fler hästar",
            Description = "Hästar och hundar slår följe i jakten på en nedgrävd boll",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 74,
            PublicId = new Guid("15294671-25ba-4e5c-89e6-2b7e4e7945da"),
            UserId = 11,
            PrimaryFileId = 112,
            Title = "Hund",
            Description = "Hund i akvarell",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 75,
            PublicId = new Guid("8b02305e-c04d-4ebe-87d5-dee748245610"),
            UserId = 5,
            PrimaryFileId = 113,
            SecondaryFileId = 53,
            Title = "Psychadelic art",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 76,
            PublicId = new Guid("70937f41-fc80-48d6-8098-03c73193c2f0"),
            UserId = 5,
            PrimaryFileId = 116,
            Title = "Krullig höstskog",
            Description = "Skog i höstens färger målad på en specialbeställd kanvas med en speciell penselteknik",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 77,
            PublicId = new Guid("9387fb6e-6bf9-4752-80b1-0440ae0d0284"),
            UserId = 5,
            PrimaryFileId = 117,
            Title = "Gäss på ö",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 78,
            PublicId = new Guid("75405148-37cc-478a-b8c6-3d3c6ed206c1"),
            UserId = 5,
            PrimaryFileId = 114,
            Title = "Månbarn",
            Description = "Motiv förestället två barn som tävlar om att inte vara först med att blinka",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 79,
            PublicId = new Guid("08a31894-b3a1-48f5-86be-96ffea179874"),
            UserId = 5,
            PrimaryFileId = 118,
            SecondaryFileId = 36,
            Title = "Räv",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 80,
            PublicId = new Guid("b4763f66-3048-4970-a3b2-d6eaca243364"),
            UserId = 5,
            PrimaryFileId = 121,
            Title = "Varmt möter kallt",
            Description = "Ett hav av färger står mot varandra",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 81,
            PublicId = new Guid("156496a4-23e9-46a9-a776-bff397077d1f"),
            UserId = 5,
            PrimaryFileId = 128,
            Title = "Berglandskap",
            Description = "Föreställer ett landskap med stig som leder ner till sjö. I horisonten syns berg med vita toppar.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 82,
            PublicId = new Guid("7a2e27ad-23c0-4673-a83d-3e4a954da9b4"),
            UserId = 5,
            PrimaryFileId = 129,
            Title = "Abstrakt konst",
            Description = "Ett färgglatt verk skapat på impuls",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 83,
          //   PublicId = new Guid("9dcb575d-8aaf-403c-8991-8fc3d9f7583f"),
          //   UserId = 4,
          //   PrimaryFileId = 130,
          //   Title = "Sol",
          //   Description = "En exakt avbildning av hur solen såg ut när denna målades sommaren 2020",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 84,
            PublicId = new Guid("f4f3791e-167c-4e71-9ec3-6fb7fe34d624"),
            UserId = 5,
            PrimaryFileId = 131,
            SecondaryFileId = 74,
            Title = "Stadskärna",
            Description = "Ståtliga hus som sträcker ut sig längs stadens kanal som ringlar genom stadskärnan",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 85,
            PublicId = new Guid("6c406dec-30c5-480c-a524-aef07c9140a9"),
            UserId = 8,
            PrimaryFileId = 134,
            Title = "Småbåtshamn",
            Description = "Föreställer småbåtshamnen i Veille Monte",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 86,
            PublicId = new Guid("9814a20b-b03c-42b1-b999-67f5c7919dfa"),
            UserId = 12,
            PrimaryFileId = 132,
            Title = "Tre blommor",
            Description = "Tre röda blommor",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 87,
            PublicId = new Guid("8d8392e7-2931-4a99-b62c-c52f5857e6ad"),
            UserId = 12,
            PrimaryFileId = 133,
            Title = "Bosättare",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 88,
            PublicId = new Guid("76f928eb-c594-4a4f-aefd-554eecc5c2f8"),
            UserId = 12,
            PrimaryFileId = 135,
            Title = "Björn",
            Description = "Björn gjord i mosaik",
            Published = DateTime.Now,
            Price = 9000
          },
          // new Artwork()
          // {
          //   Id = 89,
          //   PublicId = new Guid("b0f2df3e-c36f-48c1-a29f-d092acb83bdb"),
          //   UserId = 4,
          //   PrimaryFileId = 137,
          //   Title = "Fjäril",
          //   Description = "Glad fjäril i fyra färger",
          //   Published = DateTime.Now,
          //   Price = 9000
          // },
          new Artwork()
          {
            Id = 90,
            PublicId = new Guid("a4a45e2e-5c0d-4e24-b19e-28447abcf8ee"),
            UserId = 12,
            PrimaryFileId = 138,
            Title = "Vis man",
            Description = "Inspiration hämtad från en av våra resor till Nordafrika",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 91,
            PublicId = new Guid("0761b2da-2282-44b6-a8d9-f23d153d6b14"),
            UserId = 12,
            PrimaryFileId = 141,
            SecondaryFileId = 127,
            Title = "Fönster",
            Description = "Fönster avmålat i gamla stan i Madrid",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 92,
            PublicId = new Guid("b6e26d30-2caa-4888-a827-3007f4be3902"),
            UserId = 12,
            PrimaryFileId = 148,
            Title = "Kvinnan på bussen",
            Description = "Avtecknad kvinna som åker buss fyra mot Vevaldsvik i blått och rosa",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 93,
            PublicId = new Guid("2d9fdbae-c20e-473d-a419-75a37f01798f"),
            UserId = 12,
            PrimaryFileId = 146,
            SecondaryFileId = 50,
            TertiaryFileId = 115,
            Title = "Ögon som ser",
            Description = "Regnbågens ögon som ser det som ses",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 95,
            PublicId = new Guid("bc73bab2-0f30-486b-8b91-4a324798fa30"),
            UserId = 12,
            PrimaryFileId = 147,
            Title = "Olivträd",
            Description = "Olivträd avbildat i Greklands varma sommarhetta",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 96,
            PublicId = new Guid("00878c33-c3db-4000-b0a7-737dad308c29"),
            UserId = 12,
            PrimaryFileId = 151,
            SecondaryFileId = 111,
            Title = "Huset på kullen",
            Description = "Ett vackert landskap avmålat i akvarell",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 97,
            PublicId = new Guid("3f372f89-30f6-4f23-b4bf-e00aef5cd2cf"),
            UserId = 12,
            PrimaryFileId = 152,
            Title = "Jakt",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 98,
            PublicId = new Guid("73e5a7ec-85cd-4aa7-af8c-01415cf0198e"),
            UserId = 12,
            PrimaryFileId = 76,
            SecondaryFileId = 143,
            Title = "Lavendelkvinna",
            Description = "Min vän Katarina plockar lavendel i Provence",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 99,
            PublicId = new Guid("30942adb-a2bd-49df-aa8f-7d786c1c3a62"),
            UserId = 12,
            PrimaryFileId = 30,
            SecondaryFileId = 119,
            Title = "Black box",
            Description = "Ett abstrakt konstverk som jag kallar för black box",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 100,
            PublicId = new Guid("e3edab83-8356-4102-8615-f567b38796fc"),
            UserId = 12,
            PrimaryFileId = 123,
            Title = "Snowy mountains",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 101,
            PublicId = new Guid("bd19f38b-d2c5-4e4c-90cf-36fffecccb43"),
            UserId = 8,
            PrimaryFileId = 106,
            Title = "Se upp!",
            Description = "Kille pekar på någoting intressant. Originaltitel Saint John the Baptist. Oljemålning på valnötsträ.",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 102,
            PublicId = new Guid("ac721b2c-e6af-433d-9d44-55f955f0a9ba"),
            UserId = 9,
            PrimaryFileId = 16,
            SecondaryFileId = 93,
            TertiaryFileId = 122,
            Title = "Solrosor",
            Description = "Solrosor i vas",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 103,
            PublicId = new Guid("e4eb6096-4123-450f-8392-4f96abd64090"),
            UserId = 12,
            PrimaryFileId = 19,
            Title = "Vinterhöst",
            Description = "Träd med höstlöv som speglas i vattnet",
            Published = DateTime.Now,
            Price = 9000
          },
          new Artwork()
          {
            Id = 104,
            PublicId = new Guid("dbb3c4ae-f440-4f5d-be55-268ef83ac5d3"),
            UserId = 1,
            PrimaryFileId = 161,
            Title = "Vintervik",
            Description = "Vintermorgon i Edshagsberg med det gamla ploahuset i bakgrunden, byggt 1869.",
            Published = new DateTime(2021, 7, 20, 16, 59, 10),
            Price = 10000
          },
          new Artwork()
          {
            Id = 105,
            PublicId = new Guid("13491531-86a9-4859-962c-165a219e72b4"),
            UserId = 1,
            PrimaryFileId = 162,
            Title = "Solgult ängsträd",
            Description = "Ett gult träd på en gul äng mot en klarblå himmelsbakgrund",
            Published = new DateTime(2020, 8, 14, 6, 3, 35),
            Price = 78000
          },
          new Artwork()
          {
            Id = 106,
            PublicId = new Guid("d4b7612e-29f4-418f-859b-53bf785843e2"),
            UserId = 1,
            PrimaryFileId = 163,
            Title = "Vinteräng",
            Description = "Bistra och kalla vintern har dragit in över Österåkers slätter och biter sig fast i marken. Den vita snötäckta marken lyser upp omgivningen.",
            Published = new DateTime(2020, 9, 28, 19, 42, 39),
            Price = 51000
          },
          new Artwork()
          {
            Id = 107,
            PublicId = new Guid("8ec9a71f-14cd-477f-b7c5-b10fe26465fc"),
            UserId = 1,
            PrimaryFileId = 164,
            Title = "Golden gate-bron",
            Description = "En röd ståtlig konstruktion",
            Published = new DateTime(2021, 4, 2, 14, 5, 58),
            Price = 46000
          },
          new Artwork()
          {
            Id = 108,
            PublicId = new Guid("75711cab-c2cc-40e4-bedf-23a29574c8e2"),
            UserId = 1,
            PrimaryFileId = 165,
            Title = "Tre vita hästar",
            Description = "Tre vita vildhästar tar ett bad tillsammans i skymnningen",
            Published = new DateTime(2021, 7, 29, 22, 25, 40),
            Price = 88000
          },
          new Artwork()
          {
            Id = 109,
            PublicId = new Guid("1b961f79-0e3a-4be3-9ffe-022c4a606470"),
            UserId = 1,
            PrimaryFileId = 166,
            Title = "Fyr på Öland målad i vattenfäger",
            Description = "Ståtlig gammal fyr som står på Öland. Fyren var aktiv mellan år 1810-1928.",
            Published = new DateTime(2021, 10, 14, 22, 47, 14),
            Price = 14000
          },
          new Artwork()
          {
            Id = 110,
            PublicId = new Guid("85bb4e6b-76f5-47d6-adaf-8c5e69460e6a"),
            UserId = 1,
            PrimaryFileId = 167,
            Title = "Svandamm",
            Description = "Park i södra Holland där svanarna simmar i dammen",
            Published = new DateTime(2021, 11, 10, 7, 7, 42),
            Price = 42000
          },
          new Artwork()
          {
            Id = 111,
            PublicId = new Guid("687491b2-e695-48bf-a9c1-3dd79c4492a1"),
            UserId = 1,
            PrimaryFileId = 168,
            Title = "Vy från Alpby",
            Description = "Flyktiga berg över solblekt hage. Vy från Alpby i södra Tyskland där bergskossor betar i harmoni med byborna.",
            Published = new DateTime(2021, 3, 29, 17, 0, 39),
            Price = 54000
          },
          new Artwork()
          {
            Id = 112,
            PublicId = new Guid("627acdd7-1d70-4381-ae7b-5a240e4096de"),
            UserId = 1,
            PrimaryFileId = 169,
            Title = "Äppelkorg",
            Description = "Äppelkorg i blomsterträdgård målad med inspiration av Kiviks höjder.",
            Published = new DateTime(2021, 4, 23, 5, 25, 8),
            Price = 12000
          },
          new Artwork()
          {
            Id = 113,
            PublicId = new Guid("03b3e16f-0d56-49f2-b7bc-17d4fc235b87"),
            UserId = 1,
            PrimaryFileId = 170,
            Title = "Nyplockade syréner",
            Description = "Vackra lila syrénblommor i korg",
            Published = new DateTime(2021, 11, 23, 13, 39, 52),
            Price = 75000
          },
          new Artwork()
          {
            Id = 114,
            PublicId = new Guid("1a7a75ae-b12c-4bba-b784-3a050b5ba021"),
            UserId = 1,
            PrimaryFileId = 171,
            Title = "Pressblomma",
            Description = "Pressade blommor och ormbunke avmålade i akvarell",
            Published = new DateTime(2020, 12, 8, 2, 36, 6),
            Price = 28000
          },
          new Artwork()
          {
            Id = 115,
            PublicId = new Guid("99e75456-3915-4f61-b3e2-dc959d0279d7"),
            UserId = 1,
            PrimaryFileId = 172,
            Title = "Bear",
            Description = "Furry bear watching over the forest, ready to take back the title as king.",
            Published = new DateTime(2020, 8, 20, 0, 3, 15),
            Price = 33000
          },
          new Artwork()
          {
            Id = 116,
            PublicId = new Guid("451ead9a-39d2-4424-85da-d557d66bc2d8"),
            UserId = 1,
            PrimaryFileId = 173,
            Title = "Vildhäst",
            Description = "Vildhäst från svensk hage på oljemålning",
            Published = new DateTime(2020, 1, 8, 17, 43, 31),
            Price = 64000
          },
          new Artwork()
          {
            Id = 117,
            PublicId = new Guid("b5fcf0ee-5f46-4c7c-b18d-628589d30868"),
            UserId = 1,
            PrimaryFileId = 174,
            Title = "Blå vågor",
            Description = "Blå vågor på ängen",
            Published = new DateTime(2020, 11, 4, 4, 24, 40),
            Price = 77000
          },
          new Artwork()
          {
            Id = 118,
            PublicId = new Guid("1cbcfb5c-08df-4b6e-90dc-b3e733cf687b"),
            UserId = 1,
            PrimaryFileId = 175,
            Title = "Ståtligt 1600-talsskepp",
            Description = "Ståtligt skepp byggt på 1600-talet som seglar västerut",
            Published = new DateTime(2020, 6, 5, 20, 32, 41),
            Price = 46000
          },
          new Artwork()
          {
            Id = 119,
            PublicId = new Guid("33450ef8-db53-403b-a1bc-0c9fe16a4cc3"),
            UserId = 1,
            PrimaryFileId = 176,
            Title = "Höstko",
            Description = "Höstkossa njuter av årets sista soltimmar medan de brandgula höstlösen knappt klarar av att hålla sig kvar",
            Published = new DateTime(2021, 12, 9, 19, 2, 11),
            Price = 19000
          },
          new Artwork()
          {
            Id = 120,
            PublicId = new Guid("21861b76-7574-4c5a-9093-23a9b697686f"),
            UserId = 1,
            PrimaryFileId = 177,
            Title = "Indiana split",
            Published = new DateTime(2021, 12, 14, 2, 50, 1),
            Price = 66000
          },
          new Artwork()
          {
            Id = 121,
            PublicId = new Guid("88f48f30-a742-46ee-b85f-71509200839c"),
            UserId = 1,
            PrimaryFileId = 178,
            Title = "Metarpojke",
            Description = "Pojke som metar efter fisk på landet",
            Published = new DateTime(2020, 3, 13, 2, 36, 36),
            Price = 39000
          },
          new Artwork()
          {
            Id = 122,
            PublicId = new Guid("04798a7c-8f90-455f-89a5-680c87e379bd"),
            UserId = 1,
            PrimaryFileId = 179,
            Title = "Japansk trädgård",
            Description = "Enavmålning av den japanska trädgården ute i danska Røhdegaard",
            Published = new DateTime(2020, 5, 16, 2, 30, 22),
            Price = 72000
          },
          new Artwork()
          {
            Id = 123,
            PublicId = new Guid("03f04a2c-9271-4bc6-a82e-1948bb76535d"),
            UserId = 1,
            PrimaryFileId = 180,
            Title = "Naturkvinna",
            Description = "Kvinna tecknad på solblekt papper",
            Published = new DateTime(2020, 4, 26, 7, 4, 59),
            Price = 13000
          },
          new Artwork()
          {
            Id = 124,
            PublicId = new Guid("edc2acdb-4469-4013-9199-7a61842aa724"),
            UserId = 1,
            PrimaryFileId = 181,
            Title = "Höststuga",
            Description = "Stugan vid vattenkanten i skogsbrynet speglas mot den blanka vattenytan.",
            Published = new DateTime(2021, 1, 16, 2, 59, 4),
            Price = 2000
          },
          new Artwork()
          {
            Id = 125,
            PublicId = new Guid("4c83c77f-110c-447b-bee9-ad5b944a7495"),
            UserId = 1,
            PrimaryFileId = 182,
            Title = "Tre bärs, tack!",
            Description = "En hyllning till den lokala puben",
            Published = new DateTime(2021, 2, 6, 19, 58, 0),
            Price = 24000
          },
          new Artwork()
          {
            Id = 126,
            PublicId = new Guid("7dac205a-7b3b-4c46-964e-d3cb8f3bcf8e"),
            UserId = 1,
            PrimaryFileId = 183,
            Title = "Paris underifrån",
            Description = "Paris från ett annorlunda perspektiv. Framför ser man det berömda och ståtliga Notre dame.",
            Published = new DateTime(2020, 2, 6, 2, 27, 46),
            Price = 99000
          },
          new Artwork()
          {
            Id = 127,
            PublicId = new Guid("7eac34bc-29b3-4a8f-b72a-4e5f0b164702"),
            UserId = 1,
            PrimaryFileId = 184,
            Title = "Gammalt skogshus",
            Published = new DateTime(2021, 9, 20, 1, 51, 40),
            Price = 44000
          },
          new Artwork()
          {
            Id = 128,
            PublicId = new Guid("58abd842-a4dc-40a7-a17d-678874a0b8a6"),
            UserId = 1,
            PrimaryFileId = 185,
            Title = "Tunnel of darkness",
            Description = "Please enter the tunnel of... No, not light. Darkness.",
            Published = new DateTime(2020, 6, 6, 19, 17, 1),
            Price = 27000
          },
          new Artwork()
          {
            Id = 129,
            PublicId = new Guid("d1aa6bef-a4d5-4476-b634-781f066cc760"),
            UserId = 1,
            PrimaryFileId = 186,
            Title = "Landskap",
            Description = "Häftigt landskap avmålat i olja",
            Published = new DateTime(2021, 11, 29, 14, 13, 29),
            Price = 6000
          },
          new Artwork()
          {
            Id = 130,
            PublicId = new Guid("ecb721cb-4d92-4a37-aa36-3599afc5916a"),
            UserId = 1,
            PrimaryFileId = 187,
            Title = "Vik",
            Description = "Djupavik. Under sommaren är det här ett populärt badställe.",
            Published = new DateTime(2020, 10, 1, 12, 13, 21),
            Price = 88000
          },
          new Artwork()
          {
            Id = 131,
            PublicId = new Guid("c8650c1e-85f9-4e3c-9a4d-5855f45a18f9"),
            UserId = 1,
            PrimaryFileId = 188,
            Title = "Gul allé",
            Description = "Landsväg längs gula ängar",
            Published = new DateTime(2020, 4, 19, 18, 9, 48),
            Price = 9000
          },
          new Artwork()
          {
            Id = 132,
            PublicId = new Guid("9d5ab086-1109-4249-ace1-e97636b440f9"),
            UserId = 1,
            PrimaryFileId = 189,
            Title = "Storstad",
            Description = "Ett gäng höghus jämte varandra som tillsammans bildar en storstad",
            Published = new DateTime(2021, 9, 20, 23, 52, 5),
            Price = 69000
          },
          new Artwork()
          {
            Id = 133,
            PublicId = new Guid("41c571b9-2ec6-4171-bb8a-30c7de0fa9ea"),
            UserId = 1,
            PrimaryFileId = 190,
            Title = "Tecknad blomma",
            Description = "Vit blomma sedd från ovan",
            Published = new DateTime(2020, 2, 11, 4, 0, 13),
            Price = 16000
          },
          new Artwork()
          {
            Id = 134,
            PublicId = new Guid("8eee9498-1c3a-4326-b6e7-79a973f6e2c0"),
            UserId = 1,
            PrimaryFileId = 191,
            Title = "Vindkust",
            Description = "Blåsigt väder är ingenting för byborna bosatta i den här byn på Englands ostkust. Några segelbåtar seglar ut mot horisonten och en kille i röd mössa är på väg hem.",
            Published = new DateTime(2021, 6, 20, 2, 45, 53),
            Price = 20000
          },
          new Artwork()
          {
            Id = 135,
            PublicId = new Guid("453ed6ed-5d05-40f2-9c45-3b314bde8219"),
            UserId = 1,
            PrimaryFileId = 192,
            Title = "Brandlandskap",
            Published = new DateTime(2021, 1, 23, 6, 8, 5),
            Price = 21000
          },
          new Artwork()
          {
            Id = 136,
            PublicId = new Guid("9c819a33-8f82-4e9b-8c11-8326496f7e86"),
            UserId = 1,
            PrimaryFileId = 193,
            Title = "Körsbärstårta",
            Description = "En riktigt smarrig tårta",
            Published = new DateTime(2020, 10, 10, 18, 37, 9),
            Price = 98000
          },
          new Artwork()
          {
            Id = 137,
            PublicId = new Guid("94bfc06b-c42c-461f-82d7-b5c2d4649768"),
            UserId = 1,
            PrimaryFileId = 194,
            Title = "Äppelkorg",
            Description = "Färska plockade gröna äpplen",
            Published = new DateTime(2020, 11, 1, 12, 58, 0),
            Price = 70000
          },
          new Artwork()
          {
            Id = 138,
            PublicId = new Guid("d28739d1-d5e9-4b44-8b88-363f0ec3de85"),
            UserId = 1,
            PrimaryFileId = 195,
            Title = "Läslus",
            Description = "Kvinna läser en bok på en knallröd bänk",
            Published = new DateTime(2020, 5, 24, 0, 16, 16),
            Price = 45000
          },
          new Artwork()
          {
            Id = 139,
            PublicId = new Guid("0a245358-4ca8-4284-b4fb-c415532996df"),
            UserId = 1,
            PrimaryFileId = 196,
            Title = "Slaget vid Rom år 946",
            Description = "En avbildning av det stora slaget om Rom år 946 som senare kom att bli ett av de mest omskrivna historiska slagen",
            Published = new DateTime(2021, 3, 10, 8, 3, 40),
            Price = 75000
          },
          new Artwork()
          {
            Id = 140,
            PublicId = new Guid("de06149e-3e13-4126-922a-a32950444f38"),
            UserId = 1,
            PrimaryFileId = 197,
            Title = "Uppvaktande fågel",
            Description = "Hanfågel som uppvaktar sin honfågel med skönsång",
            Published = new DateTime(2020, 4, 25, 5, 36, 46),
            Price = 25000
          },
          new Artwork()
          {
            Id = 141,
            PublicId = new Guid("0145ba3b-cf90-469e-bcfd-132f96bd0299"),
            UserId = 1,
            PrimaryFileId = 198,
            Title = "Blomraket",
            Description = "En raket av blommor som blickar upp mot en blå himmel",
            Published = new DateTime(2020, 3, 24, 2, 29, 20),
            Price = 89000
          },
          new Artwork()
          {
            Id = 142,
            PublicId = new Guid("4ac249e0-bf9d-473e-a2bb-7a2c842050d0"),
            UserId = 1,
            PrimaryFileId = 199,
            Title = "Husfasader på vattenytan",
            Description = "Köpenhamns husfasader som speglas mot vattenytan i ån",
            Published = new DateTime(2020, 9, 20, 6, 11, 24),
            Price = 26000
          },
          new Artwork()
          {
            Id = 143,
            PublicId = new Guid("9ef585ae-ca34-44fc-b200-c55d4e96a47c"),
            UserId = 1,
            PrimaryFileId = 200,
            Title = "Boat town",
            Description = "Båtstad i sommarens Kroatien",
            Published = new DateTime(2020, 5, 29, 4, 57, 37),
            Price = 95000
          },
          new Artwork()
          {
            Id = 144,
            PublicId = new Guid("b4310d54-3bc5-4677-93a1-83fc8eb2f773"),
            UserId = 1,
            PrimaryFileId = 201,
            Title = "Varn rider efter get",
            Description = "En gettransport tar barnen till söndagsmarknaden",
            Published = new DateTime(2020, 5, 2, 21, 36, 8),
            Price = 66000
          },
          new Artwork()
          {
            Id = 145,
            PublicId = new Guid("78741177-f441-4172-8a1d-3021c1dd8d4f"),
            UserId = 1,
            PrimaryFileId = 202,
            Title = "Lila blommor",
            Description = "Vackra lila blommor målade i akvarell",
            Published = new DateTime(2021, 5, 12, 14, 18, 55),
            Price = 65000
          },
          new Artwork()
          {
            Id = 146,
            PublicId = new Guid("eb704f2d-d266-491c-acef-4fe489d3662d"),
            UserId = 1,
            PrimaryFileId = 203,
            Title = "Gammal bro",
            Description = "Gammal bro i södra Frankrike som sammanbinder den gamla bergsstaden Hostoire med huvudleden",
            Published = new DateTime(2021, 1, 9, 16, 16, 33),
            Price = 30000
          },
          new Artwork()
          {
            Id = 147,
            PublicId = new Guid("a13f3174-105f-4e4f-989c-ce6aa24c373a"),
            UserId = 1,
            PrimaryFileId = 204,
            Title = "Funky tree",
            Description = "Detta gamla krokiga träd gick jag förbi varje dag när jag gick till skolan som ung. Nu har det växt till sig och har lättare för att titta fram bakom muren.",
            Published = new DateTime(2020, 7, 28, 7, 40, 27),
            Price = 51000
          },
          new Artwork()
          {
            Id = 148,
            PublicId = new Guid("13e4925c-20ea-4378-a686-e0ecbe4bf140"),
            UserId = 1,
            PrimaryFileId = 205,
            SecondaryFileId = 235,
            Title = "Muskelknutte",
            Description = "Staty av muskelknutte",
            Published = new DateTime(2021, 1, 4, 9, 7, 7),
            Price = 99000
          },
          new Artwork()
          {
            Id = 149,
            PublicId = new Guid("58bbff2e-a0bb-4762-8841-9edcc5067b6b"),
            UserId = 1,
            PrimaryFileId = 206,
            Title = "Blomsteräng",
            Description = "Äng med röda blommor på",
            Published = new DateTime(2021, 4, 13, 14, 52, 21),
            Price = 51000
          },
          new Artwork()
          {
            Id = 150,
            PublicId = new Guid("16b21001-b11d-4e17-9bbb-f8134c0adb26"),
            UserId = 1,
            PrimaryFileId = 207,
            Title = "Grindtjej",
            Description = "Tjej tittar fram från grinden in till familjens gårdshus",
            Published = new DateTime(2021, 3, 15, 18, 51, 59),
            Price = 68000
          },
          new Artwork()
          {
            Id = 151,
            PublicId = new Guid("19da593c-8d8d-48d3-885a-03dee21d92d1"),
            UserId = 1,
            PrimaryFileId = 208,
            Title = "Strandad båt",
            Description = "Gammalt båtvrak som drivit upp på stranden",
            Published = new DateTime(2020, 11, 8, 11, 59, 50),
            Price = 69000
          },
          new Artwork()
          {
            Id = 152,
            PublicId = new Guid("8568c8ac-60d2-471c-a885-1788d56f31de"),
            UserId = 1,
            PrimaryFileId = 209,
            Title = "Blomster",
            Description = "Vita blommor som tittar fram i vårsolen",
            Published = new DateTime(2020, 7, 16, 4, 37, 31),
            Price = 88000
          },
          new Artwork()
          {
            Id = 153,
            PublicId = new Guid("57b657a7-1e1a-4e81-9f6c-3351a8a30c2f"),
            UserId = 1,
            PrimaryFileId = 210,
            Title = "Blomster 2",
            Description = "Röda blommor som håller på att slå ut",
            Published = new DateTime(2020, 10, 10, 8, 49, 14),
            Price = 83000
          },
          new Artwork()
          {
            Id = 154,
            PublicId = new Guid("2b1c5936-8e10-4158-b2c6-d9995f42c5d4"),
            UserId = 1,
            PrimaryFileId = 211,
            Title = "Bergsskog",
            Published = new DateTime(2020, 9, 2, 18, 47, 19),
            Price = 33000
          },
          new Artwork()
          {
            Id = 155,
            PublicId = new Guid("a8e338ce-881d-40e3-a42e-d9e3186d6dcd"),
            UserId = 1,
            PrimaryFileId = 212,
            Title = "Yellowstone",
            Description = "Ståtliga Yellowstone med en av dess ikoniska brunbjörnar som byfiket tittar fram",
            Published = new DateTime(2020, 2, 22, 3, 49, 42),
            Price = 63000
          },
          new Artwork()
          {
            Id = 156,
            PublicId = new Guid("2427d2ce-cd0d-4d18-add0-6f55be8a91f8"),
            UserId = 1,
            PrimaryFileId = 213,
            Title = "Fika",
            Description = "Fika i pastell",
            Published = new DateTime(2021, 7, 4, 15, 3, 35),
            Price = 90000
          },
          new Artwork()
          {
            Id = 157,
            PublicId = new Guid("bbfb6d20-9c14-4d7e-bf5e-ecdb3aba8cae"),
            UserId = 1,
            PrimaryFileId = 214,
            Title = "Lissabon",
            Description = "Lissabon under natthimmel",
            Published = new DateTime(2021, 3, 18, 7, 26, 45),
            Price = 41000
          },
          new Artwork()
          {
            Id = 158,
            PublicId = new Guid("800f0c9f-e83a-420f-9783-0008818c95aa"),
            UserId = 1,
            PrimaryFileId = 215,
            Title = "Enslig stuga",
            Description = "Ensligt hus vid skogens slut, liten gubbe tittar ut",
            Published = new DateTime(2021, 1, 30, 8, 34, 23),
            Price = 21000
          },
          new Artwork()
          {
            Id = 159,
            PublicId = new Guid("4e2ed6cf-248a-4da5-9568-49f891cdc6d5"),
            UserId = 1,
            PrimaryFileId = 216,
            Title = "Höstbänk",
            Description = "Bänk i höstskog med löv som faller ner",
            Published = new DateTime(2021, 5, 9, 14, 13, 43),
            Price = 59000
          },
          new Artwork()
          {
            Id = 160,
            PublicId = new Guid("810ba5d4-fde7-42bc-bc85-09b11b396c9a"),
            UserId = 1,
            PrimaryFileId = 217,
            Title = "Till häst",
            Description = "Resande sällskap",
            Published = new DateTime(2021, 8, 23, 7, 11, 23),
            Price = 95000
          },
          new Artwork()
          {
            Id = 161,
            PublicId = new Guid("f7bd7564-41cf-4a78-92b0-c76ebb3a6b8d"),
            UserId = 1,
            PrimaryFileId = 218,
            Title = "Båtvarv",
            Description = "En avmålning av ett gammalt båtvarv",
            Published = new DateTime(2021, 9, 27, 19, 56, 17),
            Price = 42000
          },
          new Artwork()
          {
            Id = 162,
            PublicId = new Guid("f0869654-c223-4c66-9973-98e4fdf6ca38"),
            UserId = 1,
            PrimaryFileId = 219,
            Title = "Horisont i skymning",
            Published = new DateTime(2021, 1, 4, 4, 21, 45),
            Price = 94000
          },
          new Artwork()
          {
            Id = 163,
            PublicId = new Guid("2ab2259f-1be2-40fc-9f16-3fb5d36bfa4b"),
            UserId = 1,
            PrimaryFileId = 220,
            Title = "London",
            Description = "London nattetid med Big Ben som ståtligt sträcker sig upp i himmelen",
            Published = new DateTime(2020, 7, 11, 21, 28, 29),
            Price = 18000
          },
          new Artwork()
          {
            Id = 164,
            PublicId = new Guid("5cb029c4-f8b7-4062-88b3-fed2e78bda75"),
            UserId = 1,
            PrimaryFileId = 221,
            Title = "Italiensk bygata",
            Description = "Promenadgator i liten by vid den Italienska rivieran",
            Published = new DateTime(2021, 8, 30, 8, 31, 13),
            Price = 42000
          },
          new Artwork()
          {
            Id = 165,
            PublicId = new Guid("6b5ad199-e282-4ebb-8644-c595bda34a6e"),
            UserId = 1,
            PrimaryFileId = 222,
            Title = "Blad",
            Published = new DateTime(2021, 11, 13, 7, 43, 1),
            Price = 13000
          },
          new Artwork()
          {
            Id = 166,
            PublicId = new Guid("dde8bbad-d7ef-4c2b-a30d-32d278e1b322"),
            UserId = 1,
            PrimaryFileId = 223,
            Title = "Akustisk gitarr",
            Published = new DateTime(2020, 6, 19, 9, 47, 34),
            Price = 88000
          },
          new Artwork()
          {
            Id = 167,
            PublicId = new Guid("71195089-5ed8-43de-b9ec-e72dec2da1e3"),
            UserId = 1,
            PrimaryFileId = 224,
            Title = "Flicka med katt",
            Description = "Flickan Anna och katten Nisse utanför huset på landet",
            Published = new DateTime(2021, 10, 1, 18, 18, 42),
            Price = 90000
          },
          new Artwork()
          {
            Id = 168,
            PublicId = new Guid("18b41bd6-e895-4a2e-810c-0bdb68eff533"),
            UserId = 1,
            PrimaryFileId = 225,
            Title = "Hus",
            Description = "Hus i en dal i alperna",
            Published = new DateTime(2021, 6, 2, 18, 38, 16),
            Price = 83000
          },
          new Artwork()
          {
            Id = 169,
            PublicId = new Guid("3cbcb9cb-8444-4fab-89f5-7b017e762b77"),
            UserId = 1,
            PrimaryFileId = 226,
            Title = "Träd i rad",
            Description = "Träd uppställda på rad i skymningen",
            Published = new DateTime(2021, 2, 1, 23, 30, 49),
            Price = 2000
          },
          new Artwork()
          {
            Id = 170,
            PublicId = new Guid("7c6b09d0-7524-4e79-a83e-2ad01b96f57f"),
            UserId = 1,
            PrimaryFileId = 227,
            Title = "Blomsterallé",
            Description = "Allé fylld av träd med blomster",
            Published = new DateTime(2021, 7, 7, 7, 31, 13),
            Price = 77000
          },
          new Artwork()
          {
            Id = 171,
            PublicId = new Guid("c2ccc6a2-6776-46ac-9f99-5e19210c9c55"),
            UserId = 1,
            PrimaryFileId = 228,
            Title = "Båten Anna",
            Description = "Förtöjd vid en brygga",
            Published = new DateTime(2020, 2, 6, 7, 52, 49),
            Price = 43000
          },
          new Artwork()
          {
            Id = 172,
            PublicId = new Guid("81d60be5-c8d4-48aa-882d-3897ec24f41f"),
            UserId = 1,
            PrimaryFileId = 229,
            Title = "Solur",
            Description = "Ett konstverk i samspel med solen",
            Published = new DateTime(2020, 5, 20, 8, 51, 30),
            Price = 89000
          },
          new Artwork()
          {
            Id = 173,
            PublicId = new Guid("65f606d7-d8ab-40ec-bcae-a3cad1c45560"),
            UserId = 1,
            PrimaryFileId = 230,
            Title = "Två blå fåglar",
            Description = "Två små blå fåglar på en pinne",
            Published = new DateTime(2021, 9, 23, 1, 40, 5),
            Price = 10000
          },
          new Artwork()
          {
            Id = 174,
            PublicId = new Guid("d87aa624-4c4f-44b9-893c-5b951b11c37c"),
            UserId = 1,
            PrimaryFileId = 231,
            Title = "Stig längs mur",
            Description = "En solig sommardag på en stig vid en mur",
            Published = new DateTime(2021, 7, 24, 18, 11, 1),
            Price = 13000
          },
          new Artwork()
          {
            Id = 175,
            PublicId = new Guid("35ff697e-b9d8-4654-9f74-fa9c2a26e860"),
            UserId = 1,
            PrimaryFileId = 232,
            Title = "Blå fönster",
            Published = new DateTime(2021, 11, 27, 18, 7, 9),
            Price = 93000
          },
          new Artwork()
          {
            Id = 176,
            PublicId = new Guid("4c927bfd-9fc1-4648-8c05-6e6795424dfe"),
            UserId = 1,
            PrimaryFileId = 233,
            Title = "Vinterdroppar i vas",
            Description = "En vas med vinterdroppar",
            Published = new DateTime(2020, 12, 24, 8, 40, 21),
            Price = 72000
          },
          new Artwork()
          {
            Id = 177,
            PublicId = new Guid("4ea9d175-08c2-4e3b-b609-17f8a45f2fb2"),
            UserId = 1,
            PrimaryFileId = 234,
            Title = "Blommande träd",
            Description = "Ett blommande japanskt träd",
            Published = new DateTime(2021, 12, 5, 4, 7, 0),
            Price = 20000
          },
          // new Artwork() TA BORT
          // {
          //   Id = 178,
          //   PublicId = new Guid("2ad9c5a5-b2ef-4b64-9273-b5ee01d91d96"),
          //   UserId = 1,
          //   PrimaryFileId = 235,
          //   Title = "Lorem ipsum dolor sit amet",
          //   Description = "",
          //   Published = new DateTime(2021, 1, 26, 14, 48, 0),
          //   Price = 99000
          // },
          new Artwork()
          {
            Id = 179,
            PublicId = new Guid("d9bb21bc-2e5f-4a10-bb71-d40d74a2089a"),
            UserId = 1,
            PrimaryFileId = 236,
            Title = "Ett glas mjölk och lite frukt",
            Description = "Ett glas mjölk och lite frukt på ett bord",
            Published = new DateTime(2020, 7, 4, 7, 53, 53),
            Price = 22000
          },
          new Artwork()
          {
            Id = 180,
            PublicId = new Guid("d9ad962e-106f-4b40-b3e5-f08a9a74660e"),
            UserId = 1,
            PrimaryFileId = 237,
            Title = "Fågel i päronträd",
            Description = "En vanlig typ av fågel som sitter och vilar i ett päronträd innan det är dags att flyga söderut",
            Published = new DateTime(2020, 4, 11, 5, 6, 48),
            Price = 41000
          },
          new Artwork()
          {
            Id = 181,
            PublicId = new Guid("6f23877f-8786-491a-8514-60b6d8effb13"),
            UserId = 1,
            PrimaryFileId = 238,
            Title = "Blombukett i vas",
            Description = "Lila blommor i dans kring en blå och en rosa",
            Published = new DateTime(2021, 4, 24, 5, 27, 47),
            Price = 68000
          },
          new Artwork()
          {
            Id = 182,
            PublicId = new Guid("002ae42c-214f-46eb-ac8d-662b89f155b9"),
            UserId = 1,
            PrimaryFileId = 239,
            Title = "Gråtande flicka",
            Description = "Gammal målning av en gråtande flicka i en stad",
            Published = new DateTime(2021, 7, 2, 23, 21, 31),
            Price = 69000
          },
          new Artwork()
          {
            Id = 183,
            PublicId = new Guid("b600f9e4-f7a7-450e-9cd9-ad60e292d422"),
            UserId = 1,
            PrimaryFileId = 240,
            Title = "Hus vid en bro",
            Description = "En lugn, stilla å rinner genom det lilla samhället i norra Belgien. Ett hus där någon bos ligger intill ån och över bron cyklar två turister för att komma över till andra sidan.",
            Published = new DateTime(2021, 9, 18, 12, 44, 30),
            Price = 50000
          },
          new Artwork()
          {
            Id = 184,
            PublicId = new Guid("84b2a6c7-efbd-42d3-b031-6004426cd095"),
            UserId = 1,
            PrimaryFileId = 241,
            Title = "Dans på rosor",
            Description = "...fast utan rosor",
            Published = new DateTime(2021, 5, 12, 9, 51, 5),
            Price = 86000
          },
          new Artwork()
          {
            Id = 185,
            PublicId = new Guid("73a84499-76d0-4b46-bfc6-5c5c826de09a"),
            UserId = 1,
            PrimaryFileId = 242,
            Title = "Öl",
            Description = "En öl i ett glas, jävligt najs",
            Published = new DateTime(2021, 11, 20, 23, 0, 55),
            Price = 88000
          },
          new Artwork()
          {
            Id = 186,
            PublicId = new Guid("5a7da2a8-803b-45b2-8d30-3c2df22f2c6b"),
            UserId = 1,
            PrimaryFileId = 243,
            Title = "Moskva",
            Description = "En byggnad i Moskva",
            Published = new DateTime(2020, 3, 29, 16, 25, 21),
            Price = 22000
          },
          new Artwork()
          {
            Id = 187,
            PublicId = new Guid("963a2900-d713-448a-b124-b98e16f5e7b3"),
            UserId = 1,
            PrimaryFileId = 244,
            Title = "Höstträd i spegelbild",
            Description = "Höstträd speglas mot vattenytan",
            Published = new DateTime(2020, 4, 16, 18, 29, 59),
            Price = 60000
          },
          new Artwork()
          {
            Id = 188,
            PublicId = new Guid("37b546fa-cf83-4a57-a43e-d28453b3951c"),
            UserId = 1,
            PrimaryFileId = 245,
            Title = "Balkong i söderläge",
            Description = "Många fina blommor har växt upp här genom åren",
            Published = new DateTime(2021, 12, 3, 13, 4, 43),
            Price = 18000
          },
          new Artwork()
          {
            Id = 189,
            PublicId = new Guid("302c3185-081d-46bd-b440-9eb1fbb5b7d5"),
            UserId = 1,
            PrimaryFileId = 246,
            Title = "Getting married",
            Description = "A bride getting ready for her big day",
            Published = new DateTime(2020, 9, 17, 17, 7, 54),
            Price = 97000
          },
          new Artwork()
          {
            Id = 190,
            PublicId = new Guid("826c935d-3acf-4f8f-8b9f-5ae8d931392e"),
            UserId = 1,
            PrimaryFileId = 247,
            Title = "Irländska bergsväggen",
            Description = "Irländska bergsväggen ut mot Atlanten med vågor som slår upp mot den hårda stenkanten",
            Published = new DateTime(2020, 9, 12, 20, 23, 36),
            Price = 100000
          },
          new Artwork()
          {
            Id = 191,
            PublicId = new Guid("22e89d7a-2d20-4b6c-8e03-8c2b7fb7e97b"),
            UserId = 1,
            PrimaryFileId = 248,
            Title = "Ett café i Paris",
            Description = "Le Bocal, ett klassiskt franskt litet café i centrala Paris",
            Published = new DateTime(2020, 11, 17, 4, 22, 43),
            Price = 82000
          },
          new Artwork()
          {
            Id = 192,
            PublicId = new Guid("7a6c62de-05ef-4a95-8811-719124e8495d"),
            UserId = 1,
            PrimaryFileId = 249,
            Title = "Fiskmås",
            Description = "En dramatisk bild av tre flygande fiskmåsar",
            Published = new DateTime(2020, 8, 20, 10, 28, 57),
            Price = 57000
          },
          new Artwork()
          {
            Id = 193,
            PublicId = new Guid("c9f47a7c-f781-4118-b6fa-3ddfb509c1bf"),
            UserId = 1,
            PrimaryFileId = 250,
            Title = "Blomvas",
            Description = "En blomvas till",
            Published = new DateTime(2021, 3, 18, 7, 56, 44),
            Price = 69000
          },
          new Artwork()
          {
            Id = 194,
            PublicId = new Guid("7988d3d9-a507-4283-8c2e-42bab89cce56"),
            UserId = 1,
            PrimaryFileId = 251,
            Title = "Arkitektur",
            Description = "Medeltida arkitektur i stor stad",
            Published = new DateTime(2020, 1, 8, 9, 14, 49),
            Price = 34000
          },
          new Artwork()
          {
            Id = 195,
            PublicId = new Guid("f29c9800-9026-4bf3-aa1f-37a2b5a1ca9f"),
            UserId = 1,
            PrimaryFileId = 252,
            Title = "Korg med mumsiga höstäpplen",
            Description = "Ett par har trillat ut",
            Published = new DateTime(2020, 4, 26, 12, 3, 16),
            Price = 91000
          },
          new Artwork()
          {
            Id = 196,
            PublicId = new Guid("49761fdf-3fdd-449b-a90c-e56091a328c3"),
            UserId = 1,
            PrimaryFileId = 253,
            Title = "Liten fiskarbåt",
            Description = "Gamle Olof står på sin fiskarbåt och gör iordningen nätet",
            Published = new DateTime(2021, 2, 9, 2, 21, 1),
            Price = 23000
          },
          new Artwork()
          {
            Id = 197,
            PublicId = new Guid("0a501892-d8cb-46df-994b-26a3aa23e574"),
            UserId = 1,
            PrimaryFileId = 254,
            Title = "Höstlöv",
            Published = new DateTime(2021, 12, 16, 8, 31, 32),
            Price = 6000
          },
          new Artwork()
          {
            Id = 198,
            PublicId = new Guid("fb2d9ef6-c21b-4382-84a5-b02106f2ba79"),
            UserId = 1,
            PrimaryFileId = 255,
            Title = "Landskap i gamla Grekland",
            Description = "Förestället en liten lokal vingård",
            Published = new DateTime(2020, 7, 23, 19, 33, 16),
            Price = 86000
          },
          new Artwork()
          {
            Id = 199,
            PublicId = new Guid("fddfa108-9a91-43ab-a502-725932437c64"),
            UserId = 1,
            PrimaryFileId = 256,
            Title = "Blomvas",
            Description = "Ytterligare en vas fylld med olika blommor",
            Published = new DateTime(2021, 9, 3, 23, 43, 42),
            Price = 71000
          },
          new Artwork()
          {
            Id = 200,
            PublicId = new Guid("3578d062-268c-40ac-a794-008852bbdccc"),
            UserId = 2,
            PrimaryFileId = 257,
            Title = "Lissabon",
            Description = "En målning av Lissabon målad i olja",
            Published = new DateTime(2020, 2, 17, 0, 59, 51),
            Price = 44000
          },
          new Artwork()
          {
            Id = 201,
            PublicId = new Guid("7565c51d-2f30-4183-ac13-a3959a8011c5"),
            UserId = 1,
            PrimaryFileId = 258,
            Title = "Taj Mahal",
            Description = "En målning av Taj Mahal",
            Published = new DateTime(2020, 11, 27, 18, 57, 49),
            Price = 50000
          },
          new Artwork()
          {
            Id = 202,
            PublicId = new Guid("93902021-fb17-4fc3-a393-641394c251ad"),
            UserId = 2,
            PrimaryFileId = 259,
            Title = "Fisk i kostym",
            Description = "Två fiskar i en typ av kostym tittar rakt upp i luften",
            Published = new DateTime(2020, 3, 19, 6, 0, 4),
            Price = 83000
          },
          new Artwork()
          {
            Id = 203,
            PublicId = new Guid("5627dc8c-3f28-4b3e-b99c-8556b005f2d4"),
            UserId = 1,
            PrimaryFileId = 260,
            Title = "Man med kamel",
            Description = "Man leder kamel till en oas med vatten",
            Published = new DateTime(2021, 8, 28, 14, 28, 36),
            Price = 88000
          },
          new Artwork()
          {
            Id = 204,
            PublicId = new Guid("694f2d9c-8c79-4331-824b-f7cab68478b0"),
            UserId = 1,
            PrimaryFileId = 261,
            Title = "Ängen",
            Description = "En äng med fina blommor målad i olja",
            Published = new DateTime(2021, 2, 19, 9, 24, 35),
            Price = 45000
          },
          new Artwork()
          {
            Id = 205,
            PublicId = new Guid("b99c37dc-480c-495e-8f26-4f82ad8fe4f7"),
            UserId = 1,
            PrimaryFileId = 262,
            Title = "Skepp",
            Description = "Ett skepp som seglar in mot en hamn för att lägga till",
            Published = new DateTime(2020, 2, 9, 12, 51, 35),
            Price = 5000
          },

          // Anneli Frisk
          new Artwork()
          {
            Id = 206,
            PublicId = new Guid("07ef30d0-31f2-4b72-b187-2b6bb2669221"),
            UserId = 27,
            PrimaryFileId = 263,
            Title = "Sjölejon",
            Published = new DateTime(2020, 2, 9, 12, 45, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 207,
            PublicId = new Guid("316ac518-eae6-4bc7-84b3-98d7e3886be1"),
            UserId = 27,
            PrimaryFileId = 264,
            Title = "Tiger",
            Published = new DateTime(2020, 2, 9, 12, 43, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 208,
            PublicId = new Guid("5f1b3e23-1f3d-4bc2-a627-a17507c46fd1"),
            UserId = 27,
            PrimaryFileId = 265,
            Title = "Monokrom Amaryllis",
            Published = new DateTime(2020, 2, 9, 12, 49, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 209,
            PublicId = new Guid("a697d370-c916-49d4-b9a3-ff9f56d10861"),
            UserId = 27,
            PrimaryFileId = 266,
            Title = "Cirkusdirektör",
            Published = new DateTime(2020, 2, 9, 12, 48, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 210,
            PublicId = new Guid("d3c1b13f-b93f-4259-893e-ef5ceb6d1431"),
            UserId = 27,
            PrimaryFileId = 267,
            Title = "Japansk bukett",
            Published = new DateTime(2020, 2, 9, 12, 13, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 211,
            PublicId = new Guid("0ad0e7f8-4bfa-45ce-9fde-dfe2bb4a7bb1"),
            UserId = 27,
            PrimaryFileId = 268,
            Title = "Grönsaker",
            Published = new DateTime(2020, 2, 9, 12, 23, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 212,
            PublicId = new Guid("4d920af9-bac0-4a79-a05b-f4d99a559221"),
            UserId = 27,
            PrimaryFileId = 269,
            Title = "Sommarblad",
            Published = new DateTime(2020, 2, 9, 12, 21, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 213,
            PublicId = new Guid("6f1dee3f-ca77-4642-8f34-8d34a9f23961"),
            UserId = 27,
            PrimaryFileId = 270,
            Title = "Cyklamen",
            Published = new DateTime(2020, 2, 9, 12, 36, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 214,
            PublicId = new Guid("a83676b6-5531-4d22-8927-c4cf1cfdd4d1"),
            UserId = 27,
            PrimaryFileId = 271,
            Title = "Engelsk bukett",
            Published = new DateTime(2020, 2, 9, 12, 59, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 215,
            PublicId = new Guid("e2b46ec9-9f5f-4ebb-b7cc-68bfadae3f81"),
            UserId = 27,
            PrimaryFileId = 272,
            Title = "Clown",
            Published = new DateTime(2020, 2, 9, 11, 51, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 216,
            PublicId = new Guid("152c85e5-3557-430f-853c-e341fd7c8e41"),
            UserId = 27,
            PrimaryFileId = 273,
            Title = "Röda tulpaner",
            Published = new DateTime(2020, 2, 9, 12, 55, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 217,
            PublicId = new Guid("550e63fe-b033-4cc4-90ae-24b7c6e4e071"),
            UserId = 27,
            PrimaryFileId = 274,
            Title = "Gula pioner",
            Published = new DateTime(2020, 2, 9, 12, 54, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 218,
            PublicId = new Guid("92989e51-f29c-4418-a9bd-2653c25015f1"),
            UserId = 27,
            PrimaryFileId = 275,
            Title = "Elefant",
            Published = new DateTime(2020, 2, 9, 12, 56, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 219,
            PublicId = new Guid("b1f5a50a-0e13-4012-9da3-14aa9b9d5f51"),
            UserId = 27,
            PrimaryFileId = 276,
            Title = "Sparris, aubergine och spetspaprika",
            Published = new DateTime(2020, 2, 9, 12, 57, 35),
            Price = 5000
          },
          new Artwork()
          {
            Id = 220,
            PublicId = new Guid("f8f11957-f867-427c-bcb8-d2fe21dd2261"),
            UserId = 27,
            PrimaryFileId = 277,
            Title = "Päron i sällskap av ananas",
            Published = new DateTime(2020, 2, 9, 12, 49, 35),
            Price = 5000
          },

          new Artwork()
          {
            Id = 221,
            PublicId = new Guid("e2a1c6bf-25a9-410c-8000-88bd3148e38c"),
            UserId = 28,
            PrimaryFileId = 278,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 2, 20, 3, 42, 38),
            Price = 94000
          },
          new Artwork()
          {
            Id = 222,
            PublicId = new Guid("2a46076a-c392-46b6-9def-e67ca2e6b31b"),
            UserId = 28,
            PrimaryFileId = 279,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 9, 23, 5, 14, 47),
            Price = 72000
          },
          new Artwork()
          {
            Id = 223,
            PublicId = new Guid("63c19a12-f1cd-400e-8f4e-562815f12b25"),
            UserId = 28,
            PrimaryFileId = 280,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 8, 25, 13, 37, 16),
            Price = 55000
          },
          new Artwork()
          {
            Id = 224,
            PublicId = new Guid("e732c172-3aeb-404f-853a-488f90ddf5f1"),
            UserId = 28,
            PrimaryFileId = 281,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 1, 12, 19, 39, 12),
            Price = 51000
          },
          new Artwork()
          {
            Id = 225,
            PublicId = new Guid("cf8bca04-36da-4708-a5cc-b7ffb9cf6a99"),
            UserId = 28,
            PrimaryFileId = 282,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 4, 24, 9, 51, 34),
            Price = 43000
          },
          new Artwork()
          {
            Id = 226,
            PublicId = new Guid("400b9a76-6972-404b-b202-74e13ccea19f"),
            UserId = 28,
            PrimaryFileId = 283,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 10, 20, 14, 12, 32),
            Price = 44000
          },
          new Artwork()
          {
            Id = 227,
            PublicId = new Guid("a91e228c-2689-4b65-b89a-05e87b71d9cd"),
            UserId = 28,
            PrimaryFileId = 284,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 2, 12, 19, 0, 59),
            Price = 33000
          },
          new Artwork()
          {
            Id = 228,
            PublicId = new Guid("b9f9e90a-e9af-4be9-a061-584fcda11a95"),
            UserId = 28,
            PrimaryFileId = 285,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 8, 11, 21, 31, 4),
            Price = 34000
          },
          new Artwork()
          {
            Id = 229,
            PublicId = new Guid("f3d8cea6-c157-4834-b123-250bd6bc0f62"),
            UserId = 28,
            PrimaryFileId = 286,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 2, 17, 22, 41, 20),
            Price = 29000
          },
          new Artwork()
          {
            Id = 230,
            PublicId = new Guid("2947f12f-0da5-463e-886c-08c59824db82"),
            UserId = 28,
            PrimaryFileId = 287,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 11, 18, 0, 3, 3),
            Price = 93000
          },
          new Artwork()
          {
            Id = 231,
            PublicId = new Guid("2362fe8b-716a-4c4e-b2c4-559691dc6d48"),
            UserId = 28,
            PrimaryFileId = 288,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 11, 7, 16, 41, 15),
            Price = 12000
          },
          new Artwork()
          {
            Id = 232,
            PublicId = new Guid("44297b07-4d8e-4c2f-8a69-9037c600e31c"),
            UserId = 28,
            PrimaryFileId = 289,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 11, 2, 23, 31, 46),
            Price = 32000
          },
          new Artwork()
          {
            Id = 233,
            PublicId = new Guid("99d40547-0c25-414b-97fd-8f4765650e12"),
            UserId = 28,
            PrimaryFileId = 290,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 4, 21, 2, 37, 2),
            Price = 62000
          },
          new Artwork()
          {
            Id = 234,
            PublicId = new Guid("335d1def-b389-4bac-a43b-d408e76600d7"),
            UserId = 28,
            PrimaryFileId = 291,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 5, 21, 10, 24, 4),
            Price = 67000
          },
          new Artwork()
          {
            Id = 235,
            PublicId = new Guid("ff9a97ef-2702-405d-b105-b32b004d58c9"),
            UserId = 28,
            PrimaryFileId = 292,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 3, 12, 19, 24, 40),
            Price = 22000
          },
          new Artwork()
          {
            Id = 236,
            PublicId = new Guid("63d9297e-3d09-4cf5-ae4e-d83286da3dc6"),
            UserId = 28,
            PrimaryFileId = 293,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 11, 30, 17, 57, 40),
            Price = 27000
          },
          new Artwork()
          {
            Id = 237,
            PublicId = new Guid("85479e5a-fd63-4373-92b4-944a3a5d92c4"),
            UserId = 28,
            PrimaryFileId = 294,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 4, 8, 10, 54, 50),
            Price = 87000
          },
          new Artwork()
          {
            Id = 238,
            PublicId = new Guid("22bda298-8eca-4f9c-9a87-9a46bdd6453d"),
            UserId = 28,
            PrimaryFileId = 295,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 3, 17, 4, 27, 20),
            Price = 85000
          },
          new Artwork()
          {
            Id = 239,
            PublicId = new Guid("08202f98-8bfc-45ed-b036-fdc51f2942ba"),
            UserId = 28,
            PrimaryFileId = 296,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 3, 14, 15, 51, 9),
            Price = 32000
          },
          new Artwork()
          {
            Id = 240,
            PublicId = new Guid("0217f852-5ab4-4ff9-9a65-0bbce91393a7"),
            UserId = 28,
            PrimaryFileId = 297,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 1, 13, 18, 55, 10),
            Price = 37000
          },

          new Artwork()
          {
            Id = 241,
            PublicId = new Guid("21c87279-014b-4a29-b485-d4b3ac5df309"),
            UserId = 29,
            PrimaryFileId = 298,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 1, 14, 21, 51, 7),
            Price = 99000
          },
          new Artwork()
          {
            Id = 242,
            PublicId = new Guid("2663c216-6ec1-4aca-b839-e774c39ab7f5"),
            UserId = 29,
            PrimaryFileId = 299,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 11, 20, 23, 57, 48),
            Price = 14000
          },
          new Artwork()
          {
            Id = 243,
            PublicId = new Guid("913513ae-c5f3-486d-8979-dea9f0ef0ea0"),
            UserId = 29,
            PrimaryFileId = 300,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 10, 3, 4, 53, 38),
            Price = 59000
          },
          new Artwork()
          {
            Id = 244,
            PublicId = new Guid("2aec6a22-dfc2-4178-9c3d-a499fc506141"),
            UserId = 29,
            PrimaryFileId = 301,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 11, 10, 2, 8, 11),
            Price = 22000
          },
          new Artwork()
          {
            Id = 245,
            PublicId = new Guid("d6e3b2bd-84c7-469b-909f-36d23c9e85ff"),
            UserId = 29,
            PrimaryFileId = 302,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 9, 22, 19, 31, 50),
            Price = 9000
          },
          new Artwork()
          {
            Id = 246,
            PublicId = new Guid("29ae2f0c-602e-47de-885e-f2403a6261ad"),
            UserId = 29,
            PrimaryFileId = 303,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 4, 1, 7, 6, 57),
            Price = 46000
          },
          new Artwork()
          {
            Id = 247,
            PublicId = new Guid("abf4403e-f211-4397-afaf-1adcdb534aa9"),
            UserId = 29,
            PrimaryFileId = 304,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 4, 18, 8, 25, 56),
            Price = 4000
          },
          new Artwork()
          {
            Id = 248,
            PublicId = new Guid("02235221-25f9-4a31-8e5b-1c351de130b9"),
            UserId = 29,
            PrimaryFileId = 305,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 6, 24, 8, 51, 58),
            Price = 43000
          },
          new Artwork()
          {
            Id = 249,
            PublicId = new Guid("d2097236-c9b3-4a24-a7f9-630449bd21f4"),
            UserId = 29,
            PrimaryFileId = 306,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 7, 21, 9, 59, 17),
            Price = 83000
          },
          new Artwork()
          {
            Id = 250,
            PublicId = new Guid("7938028d-eadc-4489-849c-ca05d9c5f18d"),
            UserId = 29,
            PrimaryFileId = 307,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 12, 24, 8, 9, 10),
            Price = 31000
          },
          new Artwork()
          {
            Id = 251,
            PublicId = new Guid("7d92aded-7171-4677-a685-60a0ed706d96"),
            UserId = 29,
            PrimaryFileId = 308,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 3, 24, 2, 17, 44),
            Price = 82000
          },
          new Artwork()
          {
            Id = 252,
            PublicId = new Guid("fa82abca-420f-4761-af17-309517de1845"),
            UserId = 29,
            PrimaryFileId = 309,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 7, 30, 14, 24, 29),
            Price = 96000
          },
          new Artwork()
          {
            Id = 253,
            PublicId = new Guid("719c15b6-8341-4fcf-8f31-b4b41e24822b"),
            UserId = 29,
            PrimaryFileId = 310,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2021, 9, 1, 13, 53, 33),
            Price = 3000
          },
          new Artwork()
          {
            Id = 254,
            PublicId = new Guid("cc323786-68f2-4f47-a149-2d94bb637dd3"),
            UserId = 29,
            PrimaryFileId = 311,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 10, 28, 15, 30, 7),
            Price = 65000
          },
          new Artwork()
          {
            Id = 255,
            PublicId = new Guid("3a5526fc-c968-46c1-8861-729f2fd31e2d"),
            UserId = 29,
            PrimaryFileId = 312,
            Title = "Lorem ipsum dolor sit amet",
            Description = "",
            Published = new DateTime(2020, 10, 6, 11, 12, 7),
            Price = 37000
          },

          new Artwork()
          {
            Id = 256,
            PublicId = new Guid("092067b0-5dde-4101-97e6-3e76c7bc67e6"),
            UserId = 30,
            PrimaryFileId = 313,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 21, 11, 26, 27),
            Price = 77000
          },
          new Artwork()
          {
            Id = 257,
            PublicId = new Guid("2237a2d3-13e9-4ee2-9a54-fe65dda9fc53"),
            UserId = 30,
            PrimaryFileId = 314,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 20, 8, 10, 35),
            Price = 72000
          },
          new Artwork()
          {
            Id = 258,
            PublicId = new Guid("c7815fbd-75d3-47ec-b718-230897a45e99"),
            UserId = 30,
            PrimaryFileId = 315,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 21, 0, 40, 57),
            Price = 7000
          },
          new Artwork()
          {
            Id = 259,
            PublicId = new Guid("42cb8476-4a84-4150-9411-e26bec78c5cb"),
            UserId = 30,
            PrimaryFileId = 316,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 15, 0, 47, 33),
            Price = 71000
          },
          new Artwork()
          {
            Id = 260,
            PublicId = new Guid("ea4ad690-7d40-4e13-be2a-750654c510b2"),
            UserId = 30,
            PrimaryFileId = 317,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 12, 0, 51, 11),
            Price = 32000
          },
          new Artwork()
          {
            Id = 261,
            PublicId = new Guid("5c012352-b18f-41ec-96b7-4a00578eedbc"),
            UserId = 30,
            PrimaryFileId = 318,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 11, 8, 45, 19),
            Price = 32000
          },
          new Artwork()
          {
            Id = 262,
            PublicId = new Guid("01a990ec-5d3d-4f5b-ac01-61ef2e1608e0"),
            UserId = 30,
            PrimaryFileId = 319,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 7, 11, 3, 57),
            Price = 42000
          },
          new Artwork()
          {
            Id = 263,
            PublicId = new Guid("21046b75-13ad-47d0-ad8a-6cad0a496b65"),
            UserId = 30,
            PrimaryFileId = 320,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 13, 20, 45, 47),
            Price = 75000
          },
          new Artwork()
          {
            Id = 264,
            PublicId = new Guid("13efc22c-9fda-4cb0-9f55-7be22ec3aace"),
            UserId = 30,
            PrimaryFileId = 321,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 2, 15, 10, 43),
            Price = 18000
          },
          new Artwork()
          {
            Id = 265,
            PublicId = new Guid("61600ed1-1952-4a99-b16d-60bcd9da3b6e"),
            UserId = 30,
            PrimaryFileId = 322,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 17, 0, 11, 49),
            Price = 95000
          },
          new Artwork()
          {
            Id = 266,
            PublicId = new Guid("1cc8614d-1943-4599-85a7-8c0594770a8c"),
            UserId = 30,
            PrimaryFileId = 323,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 3, 9, 6, 39),
            Price = 31000
          },
          new Artwork()
          {
            Id = 267,
            PublicId = new Guid("1ee1af47-65df-4dd3-bc12-1618ecc67bd2"),
            UserId = 30,
            PrimaryFileId = 324,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 18, 2, 37, 1),
            Price = 50000
          },
          new Artwork()
          {
            Id = 268,
            PublicId = new Guid("f7e5b3d3-10c8-4c53-994f-aac8a4fa7298"),
            UserId = 30,
            PrimaryFileId = 325,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 7, 21, 58, 33),
            Price = 57000
          },
          new Artwork()
          {
            Id = 269,
            PublicId = new Guid("72aa3a54-8a3a-4b20-8991-e7da77c046d3"),
            UserId = 30,
            PrimaryFileId = 326,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 18, 8, 20, 48),
            Price = 46000
          },
          new Artwork()
          {
            Id = 270,
            PublicId = new Guid("b5193e39-979b-492d-8e76-11400c540a85"),
            UserId = 30,
            PrimaryFileId = 327,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 22, 12, 0, 23),
            Price = 24000
          },
          new Artwork()
          {
            Id = 271,
            PublicId = new Guid("32678e9c-3869-4892-9cb4-8dc27a515f22"),
            UserId = 30,
            PrimaryFileId = 328,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 5, 14, 50, 16),
            Price = 49000
          },
          new Artwork()
          {
            Id = 272,
            PublicId = new Guid("3bcb958b-3bde-42d2-8fd6-74cb99cc8433"),
            UserId = 30,
            PrimaryFileId = 329,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 20, 14, 58, 38),
            Price = 25000
          },
          new Artwork()
          {
            Id = 273,
            PublicId = new Guid("7a721b4f-82ea-429f-9cb5-58c546a49880"),
            UserId = 30,
            PrimaryFileId = 330,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 7, 15, 43, 11),
            Price = 79000
          },
          new Artwork()
          {
            Id = 274,
            PublicId = new Guid("20f4fa53-007e-4eb1-a7f6-81a218795158"),
            UserId = 30,
            PrimaryFileId = 331,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 12, 3, 10, 21),
            Price = 51000
          },
          new Artwork()
          {
            Id = 275,
            PublicId = new Guid("086c6c47-af88-400f-9677-0260d4f4030e"),
            UserId = 30,
            PrimaryFileId = 332,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 6, 13, 17, 45),
            Price = 29000
          },
          new Artwork()
          {
            Id = 276,
            PublicId = new Guid("f3b977b8-d8b3-4299-a3d3-63d7339a4c7f"),
            UserId = 30,
            PrimaryFileId = 333,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 13, 4, 33, 29),
            Price = 33000
          },

          new Artwork()
          {
            Id = 277,
            PublicId = new Guid("dd23566c-6928-447f-8a28-58ef97213f3b"),
            UserId = 31,
            PrimaryFileId = 334,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 14, 12, 21, 12),
            Price = 16000
          },
          new Artwork()
          {
            Id = 278,
            PublicId = new Guid("acfdad08-7d5c-4df2-9892-509196a616d7"),
            UserId = 31,
            PrimaryFileId = 335,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 1, 16, 11, 1),
            Price = 27000
          },
          new Artwork()
          {
            Id = 279,
            PublicId = new Guid("4e89ac6b-c910-448d-847f-2c7e2046ec23"),
            UserId = 31,
            PrimaryFileId = 336,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 6, 21, 28, 17),
            Price = 54000
          },
          new Artwork()
          {
            Id = 280,
            PublicId = new Guid("7bb4f5a5-6d96-4495-a992-d5e1b406ce1b"),
            UserId = 31,
            PrimaryFileId = 337,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 15, 12, 50, 7),
            Price = 44000
          },
          new Artwork()
          {
            Id = 281,
            PublicId = new Guid("25c73b9e-07a2-47bf-9ae2-65e72424d5f7"),
            UserId = 31,
            PrimaryFileId = 338,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 5, 2, 39, 51),
            Price = 95000
          },
          new Artwork()
          {
            Id = 282,
            PublicId = new Guid("5dbf2554-7985-4c33-8ff8-8aaa14bd169c"),
            UserId = 31,
            PrimaryFileId = 339,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 10, 14, 45, 34),
            Price = 65000
          },
          new Artwork()
          {
            Id = 283,
            PublicId = new Guid("ce8c54aa-35bb-4374-8ffb-a458e907c360"),
            UserId = 31,
            PrimaryFileId = 340,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 19, 1, 14, 13),
            Price = 90000
          },
          new Artwork()
          {
            Id = 284,
            PublicId = new Guid("2059124f-7e2b-4916-a8ae-1ef1f272bb94"),
            UserId = 31,
            PrimaryFileId = 341,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 7, 1, 46, 53),
            Price = 86000
          },
          new Artwork()
          {
            Id = 285,
            PublicId = new Guid("d5c32e30-55d3-4d9a-91f0-775b49a9fcc7"),
            UserId = 31,
            PrimaryFileId = 342,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 4, 6, 49, 57),
            Price = 60000
          },
          new Artwork()
          {
            Id = 286,
            PublicId = new Guid("996c9fb6-6971-4cd1-a766-6c515c6a1010"),
            UserId = 31,
            PrimaryFileId = 343,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 24, 1, 22, 9),
            Price = 63000
          },
          new Artwork()
          {
            Id = 287,
            PublicId = new Guid("87b55015-d3ad-431a-afec-e4e133e1f897"),
            UserId = 31,
            PrimaryFileId = 344,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 2, 10, 41, 19),
            Price = 99000
          },
          new Artwork()
          {
            Id = 288,
            PublicId = new Guid("2c7333eb-e86d-4124-a70a-70fca12faa2d"),
            UserId = 31,
            PrimaryFileId = 345,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 17, 13, 3, 16),
            Price = 37000
          },
          new Artwork()
          {
            Id = 289,
            PublicId = new Guid("e278f4bf-bc63-430a-b882-1e56f9632bf0"),
            UserId = 31,
            PrimaryFileId = 346,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 26, 6, 13, 0),
            Price = 78000
          },
          new Artwork()
          {
            Id = 290,
            PublicId = new Guid("a23734b3-a64f-41c6-b643-b4677c9bda64"),
            UserId = 31,
            PrimaryFileId = 347,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 11, 7, 21, 50),
            Price = 97000
          },
          new Artwork()
          {
            Id = 291,
            PublicId = new Guid("8a5f855e-caa5-4bf8-87f5-c0bfeba14a07"),
            UserId = 31,
            PrimaryFileId = 348,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 19, 16, 55, 24),
            Price = 84000
          },
          new Artwork()
          {
            Id = 292,
            PublicId = new Guid("b3201d31-642d-496b-a82e-49c3c27c0c09"),
            UserId = 31,
            PrimaryFileId = 349,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 18, 23, 50, 19),
            Price = 95000
          },
          new Artwork()
          {
            Id = 293,
            PublicId = new Guid("6b9ab781-80c8-4e0f-8e59-7d90ab8bb682"),
            UserId = 31,
            PrimaryFileId = 350,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 27, 12, 32, 37),
            Price = 7000
          },
          new Artwork()
          {
            Id = 294,
            PublicId = new Guid("6298cd57-9cbf-4447-9194-527a4433e47e"),
            UserId = 31,
            PrimaryFileId = 351,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 26, 19, 5, 39),
            Price = 6000
          },
          new Artwork()
          {
            Id = 295,
            PublicId = new Guid("dd56a8da-ca0b-4cc2-979b-fbcbb45d8798"),
            UserId = 31,
            PrimaryFileId = 352,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 10, 13, 19, 30),
            Price = 9000
          },
          new Artwork()
          {
            Id = 296,
            PublicId = new Guid("cf8f4027-f2b9-4b36-bb86-4a287e3ef2b8"),
            UserId = 31,
            PrimaryFileId = 353,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 20, 13, 24, 39),
            Price = 14000
          },

          new Artwork()
          {
            Id = 297,
            PublicId = new Guid("51c01622-ba04-4161-befc-919c7c35ea56"),
            UserId = 32,
            PrimaryFileId = 354,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 12, 16, 6, 38),
            Price = 64000
          },
          new Artwork()
          {
            Id = 298,
            PublicId = new Guid("c7ce8a48-86f2-4248-80fe-ceea836bcb7e"),
            UserId = 32,
            PrimaryFileId = 355,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 19, 12, 7, 14),
            Price = 6000
          },
          new Artwork()
          {
            Id = 299,
            PublicId = new Guid("f4a1ca2b-dfa5-4edc-8f1a-ea7784fe291f"),
            UserId = 32,
            PrimaryFileId = 356,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 18, 12, 23, 0),
            Price = 24000
          },
          new Artwork()
          {
            Id = 300,
            PublicId = new Guid("5315c468-5d5e-44ba-91b7-fc31a6572d6d"),
            UserId = 32,
            PrimaryFileId = 357,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 18, 10, 5, 55),
            Price = 91000
          },
          new Artwork()
          {
            Id = 301,
            PublicId = new Guid("e28c8beb-50a0-4874-8828-fff0d315fd26"),
            UserId = 32,
            PrimaryFileId = 358,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 3, 1, 51, 24),
            Price = 65000
          },
          new Artwork()
          {
            Id = 302,
            PublicId = new Guid("14f21140-ca9e-4512-ad24-19c05d062315"),
            UserId = 32,
            PrimaryFileId = 359,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 12, 21, 20, 25),
            Price = 90000
          },
          new Artwork()
          {
            Id = 303,
            PublicId = new Guid("a28a6798-5428-4eab-9407-04beaddb5a92"),
            UserId = 32,
            PrimaryFileId = 360,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 24, 12, 25, 57),
            Price = 49000
          },
          new Artwork()
          {
            Id = 304,
            PublicId = new Guid("87d2e67a-70b3-437b-9f55-39462322e071"),
            UserId = 32,
            PrimaryFileId = 361,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 24, 3, 57, 5),
            Price = 59000
          },
          new Artwork()
          {
            Id = 305,
            PublicId = new Guid("3f6834ab-d8a3-41d1-8ec2-8e6e940becd2"),
            UserId = 32,
            PrimaryFileId = 362,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 27, 19, 51, 39),
            Price = 48000
          },
          new Artwork()
          {
            Id = 306,
            PublicId = new Guid("dbcc21da-f398-4e89-aecd-d44a90d1db3d"),
            UserId = 32,
            PrimaryFileId = 363,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 3, 15, 51, 13),
            Price = 7000
          },
          new Artwork()
          {
            Id = 307,
            PublicId = new Guid("36c2373a-170a-4b16-8320-d7edba642b49"),
            UserId = 32,
            PrimaryFileId = 364,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 16, 3, 4, 52),
            Price = 62000
          },
          new Artwork()
          {
            Id = 308,
            PublicId = new Guid("fc19a4a1-1f38-4bba-8e4c-12031cfb04e6"),
            UserId = 32,
            PrimaryFileId = 365,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 25, 15, 46, 47),
            Price = 43000
          },
          new Artwork()
          {
            Id = 309,
            PublicId = new Guid("6cbb97a3-5be2-4573-a868-1c5b7ff92d3f"),
            UserId = 32,
            PrimaryFileId = 366,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 17, 13, 28, 37),
            Price = 29000
          },
          new Artwork()
          {
            Id = 310,
            PublicId = new Guid("945dae75-1416-4368-b714-7faa88daa3c5"),
            UserId = 32,
            PrimaryFileId = 367,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 12, 6, 49, 44),
            Price = 51000
          },
          new Artwork()
          {
            Id = 311,
            PublicId = new Guid("09fdf4a6-1f5e-4ed7-977b-80278fe00446"),
            UserId = 32,
            PrimaryFileId = 368,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 13, 4, 42, 58),
            Price = 12000
          },
          new Artwork()
          {
            Id = 312,
            PublicId = new Guid("f84c4b15-2549-4246-b7c9-8334285cc56d"),
            UserId = 32,
            PrimaryFileId = 369,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 1, 4, 15, 9),
            Price = 65000
          },
          new Artwork()
          {
            Id = 313,
            PublicId = new Guid("058cc233-8005-4d06-96d3-db60c8900f1c"),
            UserId = 32,
            PrimaryFileId = 370,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 11, 7, 30, 5),
            Price = 37000
          },
          new Artwork()
          {
            Id = 314,
            PublicId = new Guid("4c3843f0-f95c-4784-8c7e-e2b2e4a3a055"),
            UserId = 32,
            PrimaryFileId = 371,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 9, 15, 25, 10),
            Price = 83000
          },
          new Artwork()
          {
            Id = 315,
            PublicId = new Guid("37bd4880-88f9-4f9a-b52d-78252931647b"),
            UserId = 32,
            PrimaryFileId = 372,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 27, 20, 30, 47),
            Price = 5000
          },
          new Artwork()
          {
            Id = 316,
            PublicId = new Guid("f99dffcf-8dcc-430c-bb24-9ca68bfeea1d"),
            UserId = 32,
            PrimaryFileId = 373,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 10, 21, 7, 17),
            Price = 79000
          },
          new Artwork()
          {
            Id = 317,
            PublicId = new Guid("b9b55de3-8a7f-4816-847f-0a8a5592f50a"),
            UserId = 32,
            PrimaryFileId = 374,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 2, 9, 50, 29),
            Price = 26000
          },
          new Artwork()
          {
            Id = 318,
            PublicId = new Guid("32f7da98-2109-434d-9f76-913e684bca80"),
            UserId = 32,
            PrimaryFileId = 375,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 20, 3, 50, 39),
            Price = 47000
          },
          new Artwork()
          {
            Id = 319,
            PublicId = new Guid("8c311bba-f686-4813-9676-1f9e43186120"),
            UserId = 32,
            PrimaryFileId = 376,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 12, 16, 51, 7),
            Price = 87000
          },
          new Artwork()
          {
            Id = 320,
            PublicId = new Guid("31e8c9e0-b843-447e-a550-f3125548e1a8"),
            UserId = 32,
            PrimaryFileId = 377,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 14, 9, 11, 3),
            Price = 39000
          },
          new Artwork()
          {
            Id = 321,
            PublicId = new Guid("feade43d-cc4b-4297-947f-3bcbb8436d19"),
            UserId = 32,
            PrimaryFileId = 378,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 21, 10, 53, 1),
            Price = 52000
          },
          new Artwork()
          {
            Id = 322,
            PublicId = new Guid("a26327b1-4fee-46c3-ae1e-4874f3364a5e"),
            UserId = 32,
            PrimaryFileId = 379,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 2, 20, 1, 32),
            Price = 59000
          },
          new Artwork()
          {
            Id = 323,
            PublicId = new Guid("f1ae01a4-9368-4cc8-b086-cbcb9f6b3aa4"),
            UserId = 32,
            PrimaryFileId = 380,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 5, 20, 36, 48),
            Price = 71000
          },
          new Artwork()
          {
            Id = 324,
            PublicId = new Guid("fce3f32b-59e6-4b49-ae77-888252006f58"),
            UserId = 32,
            PrimaryFileId = 381,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 15, 23, 27, 40),
            Price = 9000
          },
          new Artwork()
          {
            Id = 325,
            PublicId = new Guid("7886b756-3146-43f5-b96c-ffdfedd8542d"),
            UserId = 32,
            PrimaryFileId = 382,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 18, 9, 7, 21),
            Price = 95000
          },
          new Artwork()
          {
            Id = 326,
            PublicId = new Guid("ae422e5a-ca34-4c80-a5f7-e6af9e49b2ee"),
            UserId = 32,
            PrimaryFileId = 383,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 25, 21, 19, 7),
            Price = 61000
          },
          new Artwork()
          {
            Id = 327,
            PublicId = new Guid("93b577c1-e57c-429e-bb2e-839eee62c722"),
            UserId = 32,
            PrimaryFileId = 384,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 25, 10, 47, 20),
            Price = 19000
          },
          new Artwork()
          {
            Id = 328,
            PublicId = new Guid("be7a7b86-266a-452c-811c-bf2f61d51a7f"),
            UserId = 32,
            PrimaryFileId = 385,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 6, 11, 43, 33),
            Price = 54000
          },
          new Artwork()
          {
            Id = 329,
            PublicId = new Guid("147c9957-a5c9-4fc7-bf7f-dc68e6d2702f"),
            UserId = 32,
            PrimaryFileId = 386,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 16, 15, 21, 10),
            Price = 19000
          },
          new Artwork()
          {
            Id = 330,
            PublicId = new Guid("393cbc39-1efc-45dc-ab79-27791ef93528"),
            UserId = 32,
            PrimaryFileId = 387,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 10, 22, 18, 19),
            Price = 46000
          },
          new Artwork()
          {
            Id = 331,
            PublicId = new Guid("bf13ce30-525b-4d70-9a8f-539015ce359c"),
            UserId = 32,
            PrimaryFileId = 388,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 13, 12, 12, 17),
            Price = 99000
          },
          new Artwork()
          {
            Id = 332,
            PublicId = new Guid("74c04fb4-c05c-4726-9c2f-a14e373836b4"),
            UserId = 32,
            PrimaryFileId = 389,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 11, 23, 37, 8),
            Price = 73000
          },
          new Artwork()
          {
            Id = 333,
            PublicId = new Guid("a3e5da24-00a0-4e6b-a939-2a476f59b82c"),
            UserId = 32,
            PrimaryFileId = 390,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 8, 17, 19, 51),
            Price = 50000
          },
          new Artwork()
          {
            Id = 334,
            PublicId = new Guid("53e3d5ae-757c-42d8-ab58-baef67ad43d4"),
            UserId = 32,
            PrimaryFileId = 391,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 24, 15, 51, 30),
            Price = 37000
          },
          new Artwork()
          {
            Id = 335,
            PublicId = new Guid("28096cc3-5673-4e6b-9ec6-5a0a1f65cde1"),
            UserId = 32,
            PrimaryFileId = 392,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 9, 23, 50, 26),
            Price = 60000
          },
          new Artwork()
          {
            Id = 336,
            PublicId = new Guid("6dd7f23c-8d81-4f94-875c-bc0100d5e74b"),
            UserId = 32,
            PrimaryFileId = 393,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 10, 0, 21, 51),
            Price = 59000
          },
          new Artwork()
          {
            Id = 337,
            PublicId = new Guid("3d6e948b-b6a6-469c-a4bb-28a0d88b2d45"),
            UserId = 32,
            PrimaryFileId = 394,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 11, 1, 26, 9),
            Price = 79000
          },
          new Artwork()
          {
            Id = 338,
            PublicId = new Guid("d9f462f8-e6c5-4edb-93da-500142ef7b07"),
            UserId = 32,
            PrimaryFileId = 395,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 11, 18, 13, 4),
            Price = 1000
          },
          new Artwork()
          {
            Id = 339,
            PublicId = new Guid("2c0e6dde-0471-4bbb-b569-2b598a2dc180"),
            UserId = 32,
            PrimaryFileId = 396,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 2, 11, 26, 12),
            Price = 77000
          },
          new Artwork()
          {
            Id = 340,
            PublicId = new Guid("adbde337-cf4a-4b66-acbf-b0f27e18db3a"),
            UserId = 32,
            PrimaryFileId = 397,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 17, 8, 15, 47),
            Price = 79000
          },
          new Artwork()
          {
            Id = 341,
            PublicId = new Guid("0d8725c6-e024-4820-84b7-011daf2e2311"),
            UserId = 32,
            PrimaryFileId = 398,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 24, 19, 41, 41),
            Price = 73000
          },
          new Artwork()
          {
            Id = 342,
            PublicId = new Guid("f555e979-b342-4d95-a18d-08781fe12b7d"),
            UserId = 32,
            PrimaryFileId = 399,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 4, 18, 23, 25),
            Price = 46000
          },
          new Artwork()
          {
            Id = 343,
            PublicId = new Guid("41e6aeae-7f10-4354-9d22-5a8526632e7f"),
            UserId = 32,
            PrimaryFileId = 400,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 7, 8, 0, 11),
            Price = 27000
          },
          new Artwork()
          {
            Id = 344,
            PublicId = new Guid("31b5421d-948a-425f-b05a-53a283a5dab2"),
            UserId = 32,
            PrimaryFileId = 401,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 1, 20, 50, 25),
            Price = 87000
          },
          new Artwork()
          {
            Id = 345,
            PublicId = new Guid("bb6d0d2c-a8a2-45bb-90ca-105cc99011dc"),
            UserId = 32,
            PrimaryFileId = 402,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 25, 0, 29, 44),
            Price = 94000
          },
          new Artwork()
          {
            Id = 346,
            PublicId = new Guid("a863cadb-bf28-4655-8f36-996ff2454d60"),
            UserId = 32,
            PrimaryFileId = 403,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 16, 9, 31, 47),
            Price = 26000
          },
          new Artwork()
          {
            Id = 347,
            PublicId = new Guid("727aa12c-984c-4558-824b-bfd29ec4a0ee"),
            UserId = 32,
            PrimaryFileId = 404,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 3, 8, 52, 22),
            Price = 53000
          },
          new Artwork()
          {
            Id = 348,
            PublicId = new Guid("69141062-fffc-45aa-83dc-27757f437c69"),
            UserId = 32,
            PrimaryFileId = 405,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 4, 19, 36, 30),
            Price = 90000
          },
          new Artwork()
          {
            Id = 349,
            PublicId = new Guid("eca8eacc-8da8-42bf-9302-76a1e6d5644d"),
            UserId = 32,
            PrimaryFileId = 406,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 14, 23, 19, 32),
            Price = 49000
          },
          new Artwork()
          {
            Id = 350,
            PublicId = new Guid("34aa7bfc-fb2c-4f7f-a367-e7eec67416e8"),
            UserId = 32,
            PrimaryFileId = 407,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 25, 9, 20, 53),
            Price = 100000
          },
          new Artwork()
          {
            Id = 351,
            PublicId = new Guid("30af356e-42fd-45bd-86f0-8f5b0751ce56"),
            UserId = 32,
            PrimaryFileId = 408,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 19, 10, 57, 12),
            Price = 5000
          },
          new Artwork()
          {
            Id = 352,
            PublicId = new Guid("99624f37-cdc5-4702-b5fe-ac2151b8b5d5"),
            UserId = 32,
            PrimaryFileId = 409,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 16, 7, 35, 36),
            Price = 78000
          },
          new Artwork()
          {
            Id = 353,
            PublicId = new Guid("cda9a113-f5c3-480f-a80c-5494cbedc6eb"),
            UserId = 32,
            PrimaryFileId = 410,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 24, 0, 13, 12),
            Price = 91000
          },
          new Artwork()
          {
            Id = 354,
            PublicId = new Guid("46229129-b6ae-4caf-857c-a6266379f0b6"),
            UserId = 32,
            PrimaryFileId = 411,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 17, 12, 1, 1),
            Price = 19000
          },
          new Artwork()
          {
            Id = 355,
            PublicId = new Guid("9290566e-834f-42f7-8192-43b3e9772d7a"),
            UserId = 32,
            PrimaryFileId = 412,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 23, 20, 2, 30),
            Price = 45000
          },
          new Artwork()
          {
            Id = 356,
            PublicId = new Guid("dbbf4cac-a106-4543-ab0a-a086de3c4529"),
            UserId = 32,
            PrimaryFileId = 413,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 23, 19, 26, 25),
            Price = 13000
          },
          new Artwork()
          {
            Id = 357,
            PublicId = new Guid("aa6763a3-5f42-4935-8d2f-487daf453fbb"),
            UserId = 32,
            PrimaryFileId = 414,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 3, 12, 1, 21),
            Price = 97000
          },
          new Artwork()
          {
            Id = 358,
            PublicId = new Guid("9c67c53c-fdf6-4a8e-be9b-f7b1c21d1166"),
            UserId = 32,
            PrimaryFileId = 415,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 1, 9, 30, 8),
            Price = 86000
          },
          new Artwork()
          {
            Id = 359,
            PublicId = new Guid("9b40e732-787d-4b9e-b935-89f50c5664d8"),
            UserId = 32,
            PrimaryFileId = 416,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 2, 5, 13, 13),
            Price = 74000
          },
          new Artwork()
          {
            Id = 360,
            PublicId = new Guid("44113ef2-7941-4f9b-8ece-3c5f1e8093f9"),
            UserId = 32,
            PrimaryFileId = 417,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 10, 18, 32, 24),
            Price = 89000
          },
          new Artwork()
          {
            Id = 361,
            PublicId = new Guid("d3bd44e1-ac41-404a-8214-0182df45d3ed"),
            UserId = 32,
            PrimaryFileId = 418,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 6, 0, 58, 22),
            Price = 100000
          },
          new Artwork()
          {
            Id = 362,
            PublicId = new Guid("ff0012ee-743b-4542-82d0-fd3bf68df37e"),
            UserId = 32,
            PrimaryFileId = 419,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 5, 11, 28, 32),
            Price = 69000
          },
          new Artwork()
          {
            Id = 363,
            PublicId = new Guid("4cefabc9-fd59-4408-8f38-9461c8280691"),
            UserId = 32,
            PrimaryFileId = 420,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 24, 20, 45, 51),
            Price = 32000
          },
          new Artwork()
          {
            Id = 364,
            PublicId = new Guid("46d551c6-e77f-4240-b793-ae2509e4c4b4"),
            UserId = 32,
            PrimaryFileId = 421,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 23, 11, 26, 33),
            Price = 3000
          },
          new Artwork()
          {
            Id = 365,
            PublicId = new Guid("a93a7897-09f0-4b5e-b5ff-e31e2bd10abe"),
            UserId = 32,
            PrimaryFileId = 422,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 5, 16, 21, 35),
            Price = 87000
          },
          new Artwork()
          {
            Id = 366,
            PublicId = new Guid("ff305258-59d4-480c-84e2-6a3e3e9a4c69"),
            UserId = 32,
            PrimaryFileId = 423,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 4, 16, 11, 54),
            Price = 78000
          },
          new Artwork()
          {
            Id = 367,
            PublicId = new Guid("48c23f93-05de-4775-8b0b-1c001089f9ab"),
            UserId = 32,
            PrimaryFileId = 424,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 6, 5, 24, 25),
            Price = 76000
          },
          new Artwork()
          {
            Id = 368,
            PublicId = new Guid("6ee93c8a-11cd-46ac-a2ec-d72bdde8cdbd"),
            UserId = 32,
            PrimaryFileId = 425,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 2, 2, 12, 53),
            Price = 19000
          },
          new Artwork()
          {
            Id = 369,
            PublicId = new Guid("55b632f1-01bc-4c4f-835a-19a48117d1c7"),
            UserId = 32,
            PrimaryFileId = 426,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 3, 2, 36, 42),
            Price = 9000
          },
          new Artwork()
          {
            Id = 370,
            PublicId = new Guid("53a058fb-e694-4dda-9c35-dd0bde001d1a"),
            UserId = 32,
            PrimaryFileId = 427,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 9, 2, 41, 22),
            Price = 1000
          },
          new Artwork()
          {
            Id = 371,
            PublicId = new Guid("d7176261-6c88-4e1f-934a-ca313c3c5e29"),
            UserId = 32,
            PrimaryFileId = 428,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 12, 2, 57, 17),
            Price = 71000
          },
          new Artwork()
          {
            Id = 372,
            PublicId = new Guid("af129830-2b0e-4b82-b674-5e321d9eeb01"),
            UserId = 32,
            PrimaryFileId = 429,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 12, 17, 33, 54),
            Price = 62000
          },
          new Artwork()
          {
            Id = 373,
            PublicId = new Guid("97df175c-ab85-4d42-b506-c900a3a1da4f"),
            UserId = 32,
            PrimaryFileId = 430,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 10, 4, 22, 38),
            Price = 78000
          },
          new Artwork()
          {
            Id = 374,
            PublicId = new Guid("4c0a87ee-1075-4e31-8f4b-00dd7af0f823"),
            UserId = 32,
            PrimaryFileId = 431,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 5, 17, 22, 42),
            Price = 18000
          },
          new Artwork()
          {
            Id = 375,
            PublicId = new Guid("d8689f22-4b4a-43f0-beed-15be932e9de8"),
            UserId = 32,
            PrimaryFileId = 432,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 1, 12, 26, 7),
            Price = 50000
          },
          new Artwork()
          {
            Id = 376,
            PublicId = new Guid("bc8b29c1-befb-4d86-bf50-f23395cc0e61"),
            UserId = 32,
            PrimaryFileId = 433,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 8, 19, 43, 24),
            Price = 26000
          },
          new Artwork()
          {
            Id = 377,
            PublicId = new Guid("f9d86395-289e-4dcb-87ce-ed56132bbd69"),
            UserId = 32,
            PrimaryFileId = 434,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 3, 12, 3, 23),
            Price = 82000
          },
          new Artwork()
          {
            Id = 378,
            PublicId = new Guid("d8d111e8-8266-4aec-b811-0f1fb4866b77"),
            UserId = 32,
            PrimaryFileId = 435,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 15, 21, 7, 52),
            Price = 86000
          },
          new Artwork()
          {
            Id = 379,
            PublicId = new Guid("62e7e144-0e62-419c-a083-e2b3c6bbd80a"),
            UserId = 32,
            PrimaryFileId = 436,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 4, 9, 26, 29),
            Price = 39000
          },
          new Artwork()
          {
            Id = 380,
            PublicId = new Guid("b96b2900-b7e8-4e69-aa8d-4ddd97fea7a6"),
            UserId = 32,
            PrimaryFileId = 437,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 15, 17, 41, 3),
            Price = 7000
          },
          new Artwork()
          {
            Id = 381,
            PublicId = new Guid("b9eb0154-db93-4d30-9afa-889f9ee52d2b"),
            UserId = 32,
            PrimaryFileId = 438,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 5, 6, 51, 5),
            Price = 55000
          },
          new Artwork()
          {
            Id = 382,
            PublicId = new Guid("88080178-dfff-4767-b769-ec11ef856a48"),
            UserId = 32,
            PrimaryFileId = 439,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 11, 7, 3, 41),
            Price = 91000
          },
          new Artwork()
          {
            Id = 383,
            PublicId = new Guid("4f5ba17a-a4e1-48cc-ba21-d6a2f09c9b35"),
            UserId = 32,
            PrimaryFileId = 440,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 26, 5, 35, 46),
            Price = 80000
          },
          new Artwork()
          {
            Id = 384,
            PublicId = new Guid("b22eafa3-c22a-4997-96e8-10c1c12dedeb"),
            UserId = 32,
            PrimaryFileId = 441,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 12, 1, 41, 56),
            Price = 22000
          },
          new Artwork()
          {
            Id = 385,
            PublicId = new Guid("05dbf517-5142-4c93-8eef-7aad981ee698"),
            UserId = 32,
            PrimaryFileId = 442,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 18, 2, 9, 30),
            Price = 46000
          },
          new Artwork()
          {
            Id = 386,
            PublicId = new Guid("6649f462-1552-47c7-9c79-e9d2c8ef2eb6"),
            UserId = 32,
            PrimaryFileId = 443,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 10, 12, 50, 10),
            Price = 84000
          },
          new Artwork()
          {
            Id = 387,
            PublicId = new Guid("3ee13468-f2c2-4dc1-a876-dc4d2337633a"),
            UserId = 32,
            PrimaryFileId = 444,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 24, 10, 28, 44),
            Price = 28000
          },
          new Artwork()
          {
            Id = 388,
            PublicId = new Guid("b95ad96e-2c3c-45a4-90b8-f3e09e1acbdb"),
            UserId = 32,
            PrimaryFileId = 445,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 23, 11, 55, 44),
            Price = 52000
          },
          new Artwork()
          {
            Id = 389,
            PublicId = new Guid("7e074988-adf9-445f-80f7-52909e0c5c05"),
            UserId = 32,
            PrimaryFileId = 446,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 23, 14, 25, 17),
            Price = 97000
          },
          new Artwork()
          {
            Id = 390,
            PublicId = new Guid("f49aea04-729d-4829-8290-a5fe7fc9cc9a"),
            UserId = 32,
            PrimaryFileId = 447,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 24, 18, 9, 1),
            Price = 79000
          },
          new Artwork()
          {
            Id = 391,
            PublicId = new Guid("f96c48b3-0899-44fe-bdb0-ddcbc79d3293"),
            UserId = 32,
            PrimaryFileId = 448,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 26, 20, 44, 43),
            Price = 93000
          },
          new Artwork()
          {
            Id = 392,
            PublicId = new Guid("c4e81773-1847-44d4-821f-e3cba5727728"),
            UserId = 32,
            PrimaryFileId = 449,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 11, 11, 38, 4),
            Price = 57000
          },
          new Artwork()
          {
            Id = 393,
            PublicId = new Guid("93a4315e-ddfc-4331-bf7d-a9f598f40703"),
            UserId = 32,
            PrimaryFileId = 450,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 25, 1, 1, 58),
            Price = 17000
          },
          new Artwork()
          {
            Id = 394,
            PublicId = new Guid("c2baf4db-fec5-4435-add0-d3c0d2bf39be"),
            UserId = 32,
            PrimaryFileId = 451,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 20, 4, 35, 32),
            Price = 70000
          },
          new Artwork()
          {
            Id = 395,
            PublicId = new Guid("dd651007-aaa4-48a6-bae8-1cd0f0ff7995"),
            UserId = 32,
            PrimaryFileId = 452,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 17, 8, 18, 16),
            Price = 73000
          },
          new Artwork()
          {
            Id = 396,
            PublicId = new Guid("23c11a77-d824-456b-83fe-2ad6a1c63744"),
            UserId = 32,
            PrimaryFileId = 453,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 18, 4, 49, 14),
            Price = 22000
          },
          new Artwork()
          {
            Id = 397,
            PublicId = new Guid("721afba2-94b4-44fc-98f3-689a960b5efd"),
            UserId = 32,
            PrimaryFileId = 454,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 19, 21, 14, 15),
            Price = 69000
          },
          new Artwork()
          {
            Id = 398,
            PublicId = new Guid("3e72635d-60c7-425c-9f73-c0e6826b0bc8"),
            UserId = 32,
            PrimaryFileId = 455,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 7, 8, 47, 19),
            Price = 5000
          },
          new Artwork()
          {
            Id = 399,
            PublicId = new Guid("32cdb1d2-7ebe-4a78-b85d-31f0a8ae50fd"),
            UserId = 32,
            PrimaryFileId = 456,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 12, 3, 25, 26),
            Price = 48000
          },
          new Artwork()
          {
            Id = 400,
            PublicId = new Guid("45e74eb6-7b41-41fc-aa9d-1acd5bd76f18"),
            UserId = 32,
            PrimaryFileId = 457,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 4, 4, 49, 43),
            Price = 3000
          },
          new Artwork()
          {
            Id = 401,
            PublicId = new Guid("a1ac27b6-d383-4eee-a119-2591e4290380"),
            UserId = 32,
            PrimaryFileId = 458,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 27, 20, 17, 52),
            Price = 78000
          },
          new Artwork()
          {
            Id = 402,
            PublicId = new Guid("9bbb6095-904e-4436-89a8-bf51a11ea484"),
            UserId = 32,
            PrimaryFileId = 459,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 9, 9, 55, 38),
            Price = 46000
          },
          new Artwork()
          {
            Id = 403,
            PublicId = new Guid("4e0d85c5-f5ac-4ede-b435-12e21c6dddcc"),
            UserId = 32,
            PrimaryFileId = 460,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 4, 23, 43, 12),
            Price = 86000
          },
          new Artwork()
          {
            Id = 404,
            PublicId = new Guid("7ecafcd5-e24b-47e1-9ea2-650ad6f29da9"),
            UserId = 32,
            PrimaryFileId = 461,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 13, 4, 44, 57),
            Price = 52000
          },
          new Artwork()
          {
            Id = 405,
            PublicId = new Guid("f4509be1-de53-4fac-8d0b-a6d9b608d8bf"),
            UserId = 32,
            PrimaryFileId = 462,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 4, 13, 34, 32),
            Price = 92000
          },
          new Artwork()
          {
            Id = 406,
            PublicId = new Guid("7d57002b-eca0-48ab-acf8-5573b6075eb9"),
            UserId = 32,
            PrimaryFileId = 463,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 14, 20, 2, 39),
            Price = 64000
          },
          new Artwork()
          {
            Id = 407,
            PublicId = new Guid("920fd663-f32d-4a7e-8aa5-79c50682cad4"),
            UserId = 32,
            PrimaryFileId = 464,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 16, 12, 5, 37),
            Price = 39000
          },
          new Artwork()
          {
            Id = 408,
            PublicId = new Guid("cdc41892-bcc7-411e-8759-4c81e8938d0d"),
            UserId = 32,
            PrimaryFileId = 465,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 6, 8, 38, 57),
            Price = 96000
          },
          new Artwork()
          {
            Id = 409,
            PublicId = new Guid("75e440d4-ba1a-4f49-96d5-af7c0a2c247a"),
            UserId = 32,
            PrimaryFileId = 466,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 15, 0, 30, 17),
            Price = 98000
          },
          new Artwork()
          {
            Id = 410,
            PublicId = new Guid("37d49f3f-a89c-4fb2-86e2-f5cff6c1bb0b"),
            UserId = 32,
            PrimaryFileId = 467,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 24, 3, 44, 56),
            Price = 50000
          },
          new Artwork()
          {
            Id = 411,
            PublicId = new Guid("ae96e006-57ae-42c9-89be-7cc45d8a9d58"),
            UserId = 32,
            PrimaryFileId = 468,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 13, 15, 50, 30),
            Price = 94000
          },
          new Artwork()
          {
            Id = 412,
            PublicId = new Guid("9ad77df1-9e56-4972-afdc-f825a981fb56"),
            UserId = 32,
            PrimaryFileId = 469,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 26, 4, 53, 47),
            Price = 73000
          },
          new Artwork()
          {
            Id = 413,
            PublicId = new Guid("78b4714e-cbb2-408f-852c-0228d0abdb1a"),
            UserId = 32,
            PrimaryFileId = 470,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 26, 20, 22, 19),
            Price = 20000
          },

          new Artwork()
          {
            Id = 414,
            PublicId = new Guid("8a9a4006-0dda-44d9-9795-19e5adb9cfa6"),
            UserId = 33,
            PrimaryFileId = 471,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 2, 18, 7, 21),
            Price = 93000
          },
          new Artwork()
          {
            Id = 415,
            PublicId = new Guid("68803482-a67b-4597-93a1-42b93010afa3"),
            UserId = 33,
            PrimaryFileId = 472,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 7, 7, 54, 24),
            Price = 21000
          },
          new Artwork()
          {
            Id = 416,
            PublicId = new Guid("23ea4b46-87f5-44fc-84c0-6c416a22e6fd"),
            UserId = 33,
            PrimaryFileId = 473,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 14, 3, 58, 0),
            Price = 82000
          },
          new Artwork()
          {
            Id = 417,
            PublicId = new Guid("57600cdb-cdbb-4637-ac08-19feb93200f2"),
            UserId = 33,
            PrimaryFileId = 474,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 10, 2, 59, 36),
            Price = 46000
          },
          new Artwork()
          {
            Id = 418,
            PublicId = new Guid("edcf998c-2b7d-4d5b-8a15-b040c4ed7368"),
            UserId = 33,
            PrimaryFileId = 475,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 18, 23, 39, 43),
            Price = 56000
          },
          new Artwork()
          {
            Id = 419,
            PublicId = new Guid("fe89cca8-6ff0-4c14-99f8-94029bb24e61"),
            UserId = 33,
            PrimaryFileId = 476,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 24, 14, 37, 26),
            Price = 80000
          },
          new Artwork()
          {
            Id = 420,
            PublicId = new Guid("fb695fc5-2785-4eeb-a902-01bc95af6482"),
            UserId = 33,
            PrimaryFileId = 477,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 27, 10, 42, 46),
            Price = 84000
          },
          new Artwork()
          {
            Id = 421,
            PublicId = new Guid("55163dc1-1051-41a7-9b9e-89fa4ff880fc"),
            UserId = 33,
            PrimaryFileId = 478,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 13, 16, 42, 26),
            Price = 55000
          },
          new Artwork()
          {
            Id = 422,
            PublicId = new Guid("6d65aedc-5dec-404a-9056-dca0743721cc"),
            UserId = 33,
            PrimaryFileId = 479,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 18, 8, 41, 2),
            Price = 92000
          },
          new Artwork()
          {
            Id = 423,
            PublicId = new Guid("c4875c47-22b3-4627-96f1-bc34d1479e04"),
            UserId = 33,
            PrimaryFileId = 480,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 17, 20, 56, 54),
            Price = 14000
          },
          new Artwork()
          {
            Id = 424,
            PublicId = new Guid("c14f1ada-5230-480e-bdb3-8b8b4828ee68"),
            UserId = 33,
            PrimaryFileId = 481,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 7, 7, 9, 37),
            Price = 67000
          },
          new Artwork()
          {
            Id = 425,
            PublicId = new Guid("f0929811-488d-4d08-951f-fdc63ebefdd8"),
            UserId = 33,
            PrimaryFileId = 482,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 26, 12, 33, 25),
            Price = 19000
          },
          new Artwork()
          {
            Id = 426,
            PublicId = new Guid("fc6f3b65-44b1-469c-9e46-6512d020d639"),
            UserId = 33,
            PrimaryFileId = 483,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 9, 1, 5, 1),
            Price = 58000
          },
          new Artwork()
          {
            Id = 427,
            PublicId = new Guid("b37237e1-3ba0-412f-9cee-641fe8a107a2"),
            UserId = 33,
            PrimaryFileId = 484,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 8, 8, 8, 30),
            Price = 54000
          },
          new Artwork()
          {
            Id = 428,
            PublicId = new Guid("4bcc2a2f-5940-41e8-9ec6-87b5e25fc5eb"),
            UserId = 33,
            PrimaryFileId = 485,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 7, 20, 48, 24),
            Price = 18000
          },
          new Artwork()
          {
            Id = 429,
            PublicId = new Guid("54ed26d4-0791-4914-b855-7f41bdf99ec4"),
            UserId = 33,
            PrimaryFileId = 486,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 25, 13, 23, 6),
            Price = 33000
          },
          new Artwork()
          {
            Id = 430,
            PublicId = new Guid("0509c2c7-92cd-4128-bf96-bacfecdbe199"),
            UserId = 33,
            PrimaryFileId = 487,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 20, 5, 12, 5),
            Price = 98000
          },
          new Artwork()
          {
            Id = 431,
            PublicId = new Guid("7e268c28-a78c-4dcc-b28b-3f89311001b8"),
            UserId = 33,
            PrimaryFileId = 488,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 4, 22, 0, 29),
            Price = 80000
          },
          new Artwork()
          {
            Id = 432,
            PublicId = new Guid("300a8c4e-bf2d-4ce7-9ce8-0bfa1e7aa77d"),
            UserId = 33,
            PrimaryFileId = 489,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 19, 7, 18, 19),
            Price = 89000
          },
          new Artwork()
          {
            Id = 433,
            PublicId = new Guid("d52e9fd8-03d9-4f2a-a138-a879237a938a"),
            UserId = 33,
            PrimaryFileId = 490,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 3, 4, 54, 33),
            Price = 41000
          },
          new Artwork()
          {
            Id = 434,
            PublicId = new Guid("f906eba3-e04b-4a19-b8e1-5fbb30ea19f2"),
            UserId = 33,
            PrimaryFileId = 491,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 2, 7, 51, 36),
            Price = 14000
          },
          new Artwork()
          {
            Id = 435,
            PublicId = new Guid("692560f0-f780-4051-87c0-cdae967af2a4"),
            UserId = 33,
            PrimaryFileId = 492,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 20, 4, 17, 27),
            Price = 6000
          },
          new Artwork()
          {
            Id = 436,
            PublicId = new Guid("5b839fe7-3722-4c91-9e08-f1da312ae41b"),
            UserId = 33,
            PrimaryFileId = 493,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 7, 18, 21, 44),
            Price = 27000
          },
          new Artwork()
          {
            Id = 437,
            PublicId = new Guid("399ac9e0-5604-46cd-8198-7c4d3a1a5c0b"),
            UserId = 33,
            PrimaryFileId = 494,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 6, 8, 12, 32),
            Price = 63000
          },
          new Artwork()
          {
            Id = 438,
            PublicId = new Guid("594d83d6-c0a4-4792-a368-005afcdc1767"),
            UserId = 33,
            PrimaryFileId = 495,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 7, 22, 49, 27),
            Price = 69000
          },
          new Artwork()
          {
            Id = 439,
            PublicId = new Guid("65705a11-0628-4728-9557-6fb495bb838c"),
            UserId = 33,
            PrimaryFileId = 496,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 11, 12, 12, 50),
            Price = 59000
          },
          new Artwork()
          {
            Id = 440,
            PublicId = new Guid("14e6f5bb-016b-4749-9f14-5ce4a3cc4e20"),
            UserId = 33,
            PrimaryFileId = 497,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 21, 6, 13, 30),
            Price = 7000
          },
          new Artwork()
          {
            Id = 441,
            PublicId = new Guid("63a5f09d-77e9-48c2-b1ee-1f13c30fb375"),
            UserId = 33,
            PrimaryFileId = 498,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 9, 19, 14, 19),
            Price = 37000
          },
          new Artwork()
          {
            Id = 442,
            PublicId = new Guid("e5180602-8c17-4123-afc5-33a866a990ca"),
            UserId = 33,
            PrimaryFileId = 499,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 6, 15, 22, 55),
            Price = 30000
          },
          new Artwork()
          {
            Id = 443,
            PublicId = new Guid("a42902f2-12a0-467b-b60d-e6788b73405a"),
            UserId = 33,
            PrimaryFileId = 500,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 15, 19, 52, 27),
            Price = 48000
          },
          new Artwork()
          {
            Id = 444,
            PublicId = new Guid("adc20d74-7b95-4f8c-b6fd-c137a99eac86"),
            UserId = 33,
            PrimaryFileId = 501,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 24, 18, 13, 12),
            Price = 98000
          },
          new Artwork()
          {
            Id = 445,
            PublicId = new Guid("f802ebbd-d781-4cb7-b47c-f5176dbf4b06"),
            UserId = 33,
            PrimaryFileId = 502,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 10, 8, 3, 42),
            Price = 76000
          },
          new Artwork()
          {
            Id = 446,
            PublicId = new Guid("10b08752-a65a-407a-bf42-d7a075ad6b35"),
            UserId = 33,
            PrimaryFileId = 503,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 2, 20, 45, 29),
            Price = 11000
          },
          new Artwork()
          {
            Id = 447,
            PublicId = new Guid("bbb19736-4312-4eff-aee2-c37fad2cc274"),
            UserId = 33,
            PrimaryFileId = 504,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 11, 15, 37, 17),
            Price = 41000
          },
          new Artwork()
          {
            Id = 448,
            PublicId = new Guid("88802643-9471-45ba-9e7a-3e2c640bc0e1"),
            UserId = 33,
            PrimaryFileId = 505,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 10, 9, 49, 9),
            Price = 11000
          },
          new Artwork()
          {
            Id = 449,
            PublicId = new Guid("79f8226e-7dd2-41e6-8e21-71258e1715ab"),
            UserId = 33,
            PrimaryFileId = 506,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 10, 18, 44, 42),
            Price = 67000
          },
          new Artwork()
          {
            Id = 450,
            PublicId = new Guid("aa86ad2c-7641-4647-bd52-3b6462d52f98"),
            UserId = 33,
            PrimaryFileId = 507,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 8, 22, 36, 50),
            Price = 82000
          },
          new Artwork()
          {
            Id = 451,
            PublicId = new Guid("4d2d0780-7893-4f71-abb2-0b88fdd29d3c"),
            UserId = 33,
            PrimaryFileId = 508,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 23, 4, 7, 54),
            Price = 64000
          },
          new Artwork()
          {
            Id = 452,
            PublicId = new Guid("897a5021-3a39-454d-8f84-fdb05ef98591"),
            UserId = 33,
            PrimaryFileId = 509,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 26, 4, 4, 4),
            Price = 24000
          },
          new Artwork()
          {
            Id = 453,
            PublicId = new Guid("1fc43f1e-a402-426c-b074-5763eb46e9c1"),
            UserId = 33,
            PrimaryFileId = 510,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 19, 4, 1, 4),
            Price = 48000
          },
          new Artwork()
          {
            Id = 454,
            PublicId = new Guid("6ddcd874-6956-411d-97b3-bec2ae1f3b8b"),
            UserId = 33,
            PrimaryFileId = 511,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 15, 21, 9, 11),
            Price = 46000
          },
          new Artwork()
          {
            Id = 455,
            PublicId = new Guid("cd104f06-0ed1-427c-9173-df6e5c3a4294"),
            UserId = 33,
            PrimaryFileId = 512,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 25, 13, 34, 10),
            Price = 42000
          },
          new Artwork()
          {
            Id = 456,
            PublicId = new Guid("a8aafe2d-56dc-403e-91ec-9dcaf342d15f"),
            UserId = 33,
            PrimaryFileId = 513,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 19, 7, 35, 22),
            Price = 23000
          },
          new Artwork()
          {
            Id = 457,
            PublicId = new Guid("8f0515bc-ad25-4986-b0c4-b831ce77314a"),
            UserId = 33,
            PrimaryFileId = 514,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 20, 6, 29, 40),
            Price = 60000
          },
          new Artwork()
          {
            Id = 458,
            PublicId = new Guid("e793425f-678f-46c5-9c47-964045e38d41"),
            UserId = 33,
            PrimaryFileId = 515,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 13, 4, 56, 36),
            Price = 29000
          },
          new Artwork()
          {
            Id = 459,
            PublicId = new Guid("bfce64b8-9c21-409d-aba1-90eab2f58cc1"),
            UserId = 33,
            PrimaryFileId = 516,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 14, 0, 37, 10),
            Price = 7000
          },
          new Artwork()
          {
            Id = 460,
            PublicId = new Guid("459547e9-d89a-4b6c-a3a9-30032207a740"),
            UserId = 33,
            PrimaryFileId = 517,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 23, 12, 27, 41),
            Price = 47000
          },
          new Artwork()
          {
            Id = 461,
            PublicId = new Guid("7dccbb0f-cf07-4695-9c76-7d370126fa41"),
            UserId = 33,
            PrimaryFileId = 518,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 25, 6, 57, 16),
            Price = 60000
          },
          new Artwork()
          {
            Id = 462,
            PublicId = new Guid("1ba634ff-14f3-4611-9044-692808396dad"),
            UserId = 33,
            PrimaryFileId = 519,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 4, 2, 28, 13),
            Price = 74000
          },
          new Artwork()
          {
            Id = 463,
            PublicId = new Guid("55a36699-2784-432b-a783-0b4c35c9568a"),
            UserId = 33,
            PrimaryFileId = 520,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 7, 19, 35, 37),
            Price = 56000
          },
          new Artwork()
          {
            Id = 464,
            PublicId = new Guid("b9f61cc3-d499-4dc9-a1bf-47ced49cf98f"),
            UserId = 33,
            PrimaryFileId = 521,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 24, 2, 46, 33),
            Price = 31000
          },
          new Artwork()
          {
            Id = 465,
            PublicId = new Guid("f40e4e3b-8c08-4904-ac30-b4f0a6f5711e"),
            UserId = 33,
            PrimaryFileId = 522,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 20, 19, 6, 36),
            Price = 8000
          },
          new Artwork()
          {
            Id = 466,
            PublicId = new Guid("35a74ed4-2b11-4ce5-b554-4437f148b93a"),
            UserId = 33,
            PrimaryFileId = 523,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 4, 16, 47, 9),
            Price = 38000
          },
          new Artwork()
          {
            Id = 467,
            PublicId = new Guid("d83854b2-bce9-4fc3-89b5-3a1e61ceaca1"),
            UserId = 33,
            PrimaryFileId = 524,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 14, 12, 9, 50),
            Price = 69000
          },
          new Artwork()
          {
            Id = 468,
            PublicId = new Guid("3b30a2dd-724c-4952-b386-a34020571a93"),
            UserId = 33,
            PrimaryFileId = 525,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 6, 14, 1, 6),
            Price = 64000
          },
          new Artwork()
          {
            Id = 469,
            PublicId = new Guid("33902eb0-d53b-448b-9ff7-aa64871e0fea"),
            UserId = 33,
            PrimaryFileId = 526,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 9, 1, 36, 55),
            Price = 64000
          },
          new Artwork()
          {
            Id = 470,
            PublicId = new Guid("8aa4923a-27d6-453b-868b-db19fba0c860"),
            UserId = 33,
            PrimaryFileId = 527,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 25, 16, 28, 55),
            Price = 98000
          },
          new Artwork()
          {
            Id = 471,
            PublicId = new Guid("2af228a0-5ef8-49c0-aeec-69000737ed45"),
            UserId = 33,
            PrimaryFileId = 528,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 8, 12, 15, 14),
            Price = 35000
          },
          new Artwork()
          {
            Id = 472,
            PublicId = new Guid("7972923c-d917-4899-b0d2-ebe5b6290680"),
            UserId = 33,
            PrimaryFileId = 529,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 14, 22, 22, 19),
            Price = 51000
          },
          new Artwork()
          {
            Id = 473,
            PublicId = new Guid("329838a1-2b32-452b-b7d1-27b6817a0a15"),
            UserId = 33,
            PrimaryFileId = 530,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 13, 22, 3, 41),
            Price = 34000
          },
          new Artwork()
          {
            Id = 474,
            PublicId = new Guid("7abb0fc2-fba4-4685-9860-0e8344215e14"),
            UserId = 33,
            PrimaryFileId = 531,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 27, 4, 36, 16),
            Price = 1000
          },
          new Artwork()
          {
            Id = 475,
            PublicId = new Guid("f46d6f33-bfe6-423e-80d5-60414081697c"),
            UserId = 33,
            PrimaryFileId = 532,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 21, 23, 38, 58),
            Price = 54000
          },
          new Artwork()
          {
            Id = 476,
            PublicId = new Guid("022c9653-7bac-48df-93ea-f3ac3d3cac73"),
            UserId = 33,
            PrimaryFileId = 533,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 15, 22, 54, 39),
            Price = 19000
          },
          new Artwork()
          {
            Id = 477,
            PublicId = new Guid("100fbaab-413f-4986-8971-cd0131ec81fd"),
            UserId = 33,
            PrimaryFileId = 534,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 10, 4, 55, 54),
            Price = 39000
          },
          new Artwork()
          {
            Id = 478,
            PublicId = new Guid("d12b981f-3f4b-4759-9d02-c788f7207f37"),
            UserId = 33,
            PrimaryFileId = 535,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 17, 9, 41, 14),
            Price = 25000
          },
          new Artwork()
          {
            Id = 479,
            PublicId = new Guid("fdd6400e-7568-42f0-82be-fad3023f57f1"),
            UserId = 33,
            PrimaryFileId = 536,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 4, 7, 46, 37),
            Price = 84000
          },
          new Artwork()
          {
            Id = 480,
            PublicId = new Guid("834135c4-2139-4e1e-aa4a-e7208bcced2c"),
            UserId = 33,
            PrimaryFileId = 537,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 3, 12, 22, 54),
            Price = 96000
          },
          new Artwork()
          {
            Id = 481,
            PublicId = new Guid("6321376a-01ea-4426-97b0-cb7d0b9b8b7b"),
            UserId = 33,
            PrimaryFileId = 538,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 19, 17, 19, 33),
            Price = 78000
          },
          new Artwork()
          {
            Id = 482,
            PublicId = new Guid("ba2c0e3f-740f-4f71-a939-03e802168867"),
            UserId = 33,
            PrimaryFileId = 539,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 1, 2, 2, 35),
            Price = 50000
          },
          new Artwork()
          {
            Id = 483,
            PublicId = new Guid("19f22c70-a429-4687-a43b-f86b14fccdd1"),
            UserId = 33,
            PrimaryFileId = 540,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 10, 19, 58, 46),
            Price = 49000
          },
          new Artwork()
          {
            Id = 484,
            PublicId = new Guid("a6a6a297-4a86-4e87-91fe-76e5a5c66f03"),
            UserId = 33,
            PrimaryFileId = 541,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 7, 19, 34, 49),
            Price = 60000
          },
          new Artwork()
          {
            Id = 485,
            PublicId = new Guid("6d1a6129-f4bc-45f5-983a-3a82c7339e8c"),
            UserId = 33,
            PrimaryFileId = 542,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 5, 5, 26, 34),
            Price = 94000
          },
          new Artwork()
          {
            Id = 486,
            PublicId = new Guid("f68bb64d-ddfd-46f9-8f8b-673210f587f7"),
            UserId = 33,
            PrimaryFileId = 543,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 26, 9, 40, 18),
            Price = 73000
          },
          new Artwork()
          {
            Id = 487,
            PublicId = new Guid("5751a119-1c7b-4280-9528-7b08cd1f1c7a"),
            UserId = 33,
            PrimaryFileId = 544,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 21, 1, 13, 25),
            Price = 18000
          },
          new Artwork()
          {
            Id = 488,
            PublicId = new Guid("82942030-f982-462e-a980-fac3070292ac"),
            UserId = 33,
            PrimaryFileId = 545,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 24, 5, 18, 34),
            Price = 63000
          },
          new Artwork()
          {
            Id = 489,
            PublicId = new Guid("2133ff9a-17d2-4b68-ab76-ccad637d3a1a"),
            UserId = 33,
            PrimaryFileId = 546,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 23, 4, 20, 57),
            Price = 8000
          },
          new Artwork()
          {
            Id = 490,
            PublicId = new Guid("8dd262d0-a462-4338-ae0d-1f0ed7068b86"),
            UserId = 33,
            PrimaryFileId = 547,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 1, 0, 15, 51),
            Price = 35000
          },
          new Artwork()
          {
            Id = 491,
            PublicId = new Guid("ed6e506e-dab5-4d53-a462-af3ce8500985"),
            UserId = 33,
            PrimaryFileId = 548,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 15, 14, 22, 56),
            Price = 45000
          },
          new Artwork()
          {
            Id = 492,
            PublicId = new Guid("b6056f99-920e-42fe-a0ea-0ad14225cfa4"),
            UserId = 33,
            PrimaryFileId = 549,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 16, 7, 24, 13),
            Price = 81000
          },
          new Artwork()
          {
            Id = 493,
            PublicId = new Guid("47efb60d-2c62-4ae3-a689-01f06a3d7c10"),
            UserId = 33,
            PrimaryFileId = 550,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 3, 21, 21, 50),
            Price = 7000
          },
          new Artwork()
          {
            Id = 494,
            PublicId = new Guid("8c84b5f4-5ede-4085-a483-e83b3460517b"),
            UserId = 33,
            PrimaryFileId = 551,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 27, 8, 1, 40),
            Price = 85000
          },
          new Artwork()
          {
            Id = 495,
            PublicId = new Guid("e8769f13-b87d-432f-8238-3d4b86d35131"),
            UserId = 33,
            PrimaryFileId = 552,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 19, 5, 0, 18),
            Price = 37000
          },
          new Artwork()
          {
            Id = 496,
            PublicId = new Guid("7ce07d41-f566-4d59-80de-b3e0f4b3067a"),
            UserId = 33,
            PrimaryFileId = 553,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 9, 11, 13, 35),
            Price = 83000
          },
          new Artwork()
          {
            Id = 497,
            PublicId = new Guid("750dde1f-4f93-402d-8324-3916d85a6234"),
            UserId = 33,
            PrimaryFileId = 554,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 16, 7, 34, 36),
            Price = 84000
          },
          new Artwork()
          {
            Id = 498,
            PublicId = new Guid("224ec89c-58b4-4a7e-ba32-3ebad9aed2f6"),
            UserId = 33,
            PrimaryFileId = 555,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 20, 17, 34, 56),
            Price = 50000
          },
          new Artwork()
          {
            Id = 499,
            PublicId = new Guid("e947655c-2ed8-4aa4-ba7f-b268587d7037"),
            UserId = 33,
            PrimaryFileId = 556,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 27, 14, 6, 52),
            Price = 71000
          },
          new Artwork()
          {
            Id = 500,
            PublicId = new Guid("c7dfe68a-e406-4c15-b270-0644c72586da"),
            UserId = 33,
            PrimaryFileId = 557,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 5, 9, 50, 7),
            Price = 85000
          },
          new Artwork()
          {
            Id = 501,
            PublicId = new Guid("38bf8f1b-1c1d-41d1-9709-5e69de89fc7b"),
            UserId = 33,
            PrimaryFileId = 558,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 2, 6, 1, 50),
            Price = 42000
          },
          new Artwork()
          {
            Id = 502,
            PublicId = new Guid("7d0c5fa3-8d55-43c8-806c-4b0bcb8e9926"),
            UserId = 33,
            PrimaryFileId = 559,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 21, 12, 5, 35),
            Price = 59000
          },
          new Artwork()
          {
            Id = 503,
            PublicId = new Guid("f33d1d23-8d14-430c-b496-7adccc3bf54a"),
            UserId = 33,
            PrimaryFileId = 560,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 18, 2, 39, 18),
            Price = 100000
          },
          new Artwork()
          {
            Id = 504,
            PublicId = new Guid("3ac696e5-588e-4448-b0fd-8e53cfdb9919"),
            UserId = 33,
            PrimaryFileId = 561,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 27, 22, 49, 4),
            Price = 24000
          },
          new Artwork()
          {
            Id = 505,
            PublicId = new Guid("d140c0d2-2553-409b-bf2f-fe51a366357c"),
            UserId = 33,
            PrimaryFileId = 562,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 16, 3, 24, 54),
            Price = 3000
          },
          new Artwork()
          {
            Id = 506,
            PublicId = new Guid("ed5724d2-51a9-4cce-8421-f72c175140b5"),
            UserId = 33,
            PrimaryFileId = 563,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 4, 10, 40, 45),
            Price = 94000
          },
          new Artwork()
          {
            Id = 507,
            PublicId = new Guid("e6fa4a67-1990-4b1b-92f6-da921b32cf43"),
            UserId = 33,
            PrimaryFileId = 564,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 12, 7, 37, 25),
            Price = 96000
          },
          new Artwork()
          {
            Id = 508,
            PublicId = new Guid("45e0759f-f06d-4b8b-a6e5-bf7e7755994d"),
            UserId = 33,
            PrimaryFileId = 565,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 20, 0, 32, 17),
            Price = 4000
          },
          new Artwork()
          {
            Id = 509,
            PublicId = new Guid("c7e90311-41f9-4270-b1e3-e7c8d6f1ce61"),
            UserId = 33,
            PrimaryFileId = 566,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 18, 11, 9, 42),
            Price = 47000
          },
          new Artwork()
          {
            Id = 510,
            PublicId = new Guid("f49d6a6d-009a-463f-8a5d-12d7bd8e7594"),
            UserId = 33,
            PrimaryFileId = 567,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 17, 7, 19, 25),
            Price = 9000
          },
          new Artwork()
          {
            Id = 511,
            PublicId = new Guid("07c05132-2e8e-4eeb-85e4-cf12ccd5f7e3"),
            UserId = 33,
            PrimaryFileId = 568,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 15, 13, 29, 18),
            Price = 91000
          },
          new Artwork()
          {
            Id = 512,
            PublicId = new Guid("d7a8eff2-be06-4b92-9ec8-d3a2ea3358ab"),
            UserId = 33,
            PrimaryFileId = 569,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 4, 10, 12, 46),
            Price = 13000
          },
          new Artwork()
          {
            Id = 513,
            PublicId = new Guid("551cc290-daeb-4443-bfed-c477a6be89af"),
            UserId = 33,
            PrimaryFileId = 570,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 22, 13, 32, 3),
            Price = 47000
          },
          new Artwork()
          {
            Id = 514,
            PublicId = new Guid("470e6f1b-2eb1-4840-a6d8-83dbc7d5329e"),
            UserId = 33,
            PrimaryFileId = 571,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 4, 4, 7, 9),
            Price = 92000
          },
          new Artwork()
          {
            Id = 515,
            PublicId = new Guid("945c1593-f1b5-4c9e-b568-72f0dac74b78"),
            UserId = 33,
            PrimaryFileId = 572,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 4, 13, 0, 28),
            Price = 42000
          },
          new Artwork()
          {
            Id = 516,
            PublicId = new Guid("c833b42c-2e94-45e3-ae11-155c9059d08d"),
            UserId = 33,
            PrimaryFileId = 573,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 14, 17, 9, 27),
            Price = 60000
          },
          new Artwork()
          {
            Id = 517,
            PublicId = new Guid("0c4e1635-a59a-49e0-82b2-1a91d06ef469"),
            UserId = 33,
            PrimaryFileId = 574,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 25, 1, 22, 22),
            Price = 40000
          },
          new Artwork()
          {
            Id = 518,
            PublicId = new Guid("fee11bc1-181f-4c93-bbb1-5827f9f7e131"),
            UserId = 33,
            PrimaryFileId = 575,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 3, 15, 48, 0),
            Price = 6000
          },
          new Artwork()
          {
            Id = 519,
            PublicId = new Guid("4ac30d9e-bda2-4444-8693-ef0985117959"),
            UserId = 33,
            PrimaryFileId = 576,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 10, 23, 52, 3),
            Price = 8000
          },
          new Artwork()
          {
            Id = 520,
            PublicId = new Guid("d8fde31b-35bc-4431-b0d0-394ed5a6ea04"),
            UserId = 33,
            PrimaryFileId = 577,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 11, 17, 42, 14),
            Price = 97000
          },
          new Artwork()
          {
            Id = 521,
            PublicId = new Guid("79258bcd-2b7f-4032-bd8e-858362e0a7c2"),
            UserId = 33,
            PrimaryFileId = 578,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 3, 7, 16, 45),
            Price = 9000
          },
          new Artwork()
          {
            Id = 522,
            PublicId = new Guid("ab3095ad-ede3-45b1-a4dd-fac3e7c07ea9"),
            UserId = 33,
            PrimaryFileId = 579,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 25, 20, 30, 38),
            Price = 26000
          },
          new Artwork()
          {
            Id = 523,
            PublicId = new Guid("d7d79cac-8a7e-40bf-af48-7e448c6ae074"),
            UserId = 33,
            PrimaryFileId = 580,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 14, 16, 51, 28),
            Price = 6000
          },
          new Artwork()
          {
            Id = 524,
            PublicId = new Guid("e7e8342e-81a0-437b-b75a-362762edcc59"),
            UserId = 33,
            PrimaryFileId = 581,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 14, 7, 51, 35),
            Price = 66000
          },
          new Artwork()
          {
            Id = 525,
            PublicId = new Guid("bf51ea10-b618-4656-b39a-f69c03416e9d"),
            UserId = 33,
            PrimaryFileId = 582,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 14, 23, 47, 48),
            Price = 82000
          },
          new Artwork()
          {
            Id = 526,
            PublicId = new Guid("291bd795-0c55-48cf-8e66-ff45576399b5"),
            UserId = 33,
            PrimaryFileId = 583,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 11, 20, 21, 22),
            Price = 10000
          },
          new Artwork()
          {
            Id = 527,
            PublicId = new Guid("266e1955-03f8-4a56-a346-53d554a4436c"),
            UserId = 33,
            PrimaryFileId = 584,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 7, 3, 15, 40),
            Price = 90000
          },
          new Artwork()
          {
            Id = 528,
            PublicId = new Guid("31328b04-edd8-4b4d-87f5-11c915ab5487"),
            UserId = 33,
            PrimaryFileId = 585,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 8, 19, 20, 12),
            Price = 36000
          },
          new Artwork()
          {
            Id = 529,
            PublicId = new Guid("615a9e7d-a496-4efa-b501-c7d8bcc26580"),
            UserId = 33,
            PrimaryFileId = 586,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 9, 19, 22, 24),
            Price = 91000
          },
          new Artwork()
          {
            Id = 530,
            PublicId = new Guid("945e47e4-cf68-4643-a673-3bb13627b65c"),
            UserId = 33,
            PrimaryFileId = 587,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 16, 1, 57, 34),
            Price = 6000
          },
          new Artwork()
          {
            Id = 531,
            PublicId = new Guid("cce8fa1a-3477-4fdb-a466-e01b5159188e"),
            UserId = 33,
            PrimaryFileId = 588,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 23, 22, 42, 16),
            Price = 89000
          },
          new Artwork()
          {
            Id = 532,
            PublicId = new Guid("70c9336a-56ff-4931-aac5-1a847dfec489"),
            UserId = 33,
            PrimaryFileId = 589,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 20, 19, 24, 36),
            Price = 10000
          },
          new Artwork()
          {
            Id = 533,
            PublicId = new Guid("655a6557-45c2-4b4c-b974-409c7a9b7022"),
            UserId = 33,
            PrimaryFileId = 590,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 7, 14, 33, 20),
            Price = 39000
          },
          new Artwork()
          {
            Id = 534,
            PublicId = new Guid("3a748ee1-4fe1-4532-a708-7c787cec5799"),
            UserId = 33,
            PrimaryFileId = 591,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 3, 7, 6, 50),
            Price = 52000
          },
          new Artwork()
          {
            Id = 535,
            PublicId = new Guid("d6bc34ab-ea12-4612-861d-7d4b696f82d6"),
            UserId = 33,
            PrimaryFileId = 592,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 7, 14, 14, 40),
            Price = 99000
          },
          new Artwork()
          {
            Id = 536,
            PublicId = new Guid("64ff81a1-da5e-421c-b643-af11283dec1f"),
            UserId = 33,
            PrimaryFileId = 593,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 15, 20, 18, 20),
            Price = 79000
          },
          new Artwork()
          {
            Id = 537,
            PublicId = new Guid("001d0eda-7e39-40f1-af61-b57698f35510"),
            UserId = 33,
            PrimaryFileId = 594,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 3, 2, 8, 30),
            Price = 35000
          },
          new Artwork()
          {
            Id = 538,
            PublicId = new Guid("f751e7d4-2c70-4e8b-8d48-1cafc73a96b1"),
            UserId = 33,
            PrimaryFileId = 595,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 6, 21, 49, 36),
            Price = 42000
          },
          new Artwork()
          {
            Id = 539,
            PublicId = new Guid("89946c1b-adb5-4cbc-ac86-ce9505d597e3"),
            UserId = 33,
            PrimaryFileId = 596,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 9, 4, 55, 53),
            Price = 95000
          },
          new Artwork()
          {
            Id = 540,
            PublicId = new Guid("005fb9e4-8c14-42e9-bd89-240e813da724"),
            UserId = 33,
            PrimaryFileId = 597,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 11, 17, 35, 24),
            Price = 94000
          },
          new Artwork()
          {
            Id = 541,
            PublicId = new Guid("0e953330-0c81-4181-a1f2-f4aded3279ae"),
            UserId = 33,
            PrimaryFileId = 598,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 16, 6, 45, 32),
            Price = 65000
          },
          new Artwork()
          {
            Id = 542,
            PublicId = new Guid("fafba5a5-ead0-458d-9d7a-cb6415ebc27d"),
            UserId = 33,
            PrimaryFileId = 599,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 12, 17, 38, 34),
            Price = 61000
          },
          new Artwork()
          {
            Id = 543,
            PublicId = new Guid("afb4b6d4-6c8f-4a10-bd73-af17d17d1491"),
            UserId = 33,
            PrimaryFileId = 600,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 9, 12, 3, 19),
            Price = 23000
          },
          new Artwork()
          {
            Id = 544,
            PublicId = new Guid("c803b6ef-d1fe-48bb-a125-058b3209bca7"),
            UserId = 33,
            PrimaryFileId = 601,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 17, 7, 20, 26),
            Price = 17000
          },
          new Artwork()
          {
            Id = 545,
            PublicId = new Guid("cde43900-f51d-4536-af18-be17c794e987"),
            UserId = 33,
            PrimaryFileId = 602,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 19, 6, 54, 20),
            Price = 5000
          },
          new Artwork()
          {
            Id = 546,
            PublicId = new Guid("2b6c9eb0-4839-47f0-b7f6-ac161435b524"),
            UserId = 33,
            PrimaryFileId = 603,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 11, 18, 14, 46),
            Price = 39000
          },
          new Artwork()
          {
            Id = 547,
            PublicId = new Guid("85dded4e-b52c-4e7f-a087-9fb1a1cbeca4"),
            UserId = 33,
            PrimaryFileId = 604,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 26, 11, 43, 54),
            Price = 18000
          },
          new Artwork()
          {
            Id = 548,
            PublicId = new Guid("46efdc12-3f03-4994-8a68-f4cec8d4fcb1"),
            UserId = 33,
            PrimaryFileId = 605,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 13, 6, 33, 8),
            Price = 15000
          },
          new Artwork()
          {
            Id = 549,
            PublicId = new Guid("33a5c233-cae3-47c1-b898-2940a2af365d"),
            UserId = 33,
            PrimaryFileId = 606,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 10, 19, 2, 16),
            Price = 56000
          },
          new Artwork()
          {
            Id = 550,
            PublicId = new Guid("aabb51df-b61e-4754-a622-0abc03686cb5"),
            UserId = 33,
            PrimaryFileId = 607,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 25, 11, 9, 54),
            Price = 87000
          },
          new Artwork()
          {
            Id = 551,
            PublicId = new Guid("0eb0b05a-e04d-4666-a90e-3e8b1b94c79d"),
            UserId = 33,
            PrimaryFileId = 608,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 26, 2, 35, 54),
            Price = 15000
          },
          new Artwork()
          {
            Id = 552,
            PublicId = new Guid("9e2c9ead-bd70-44dd-9b45-e5c4ece2ba63"),
            UserId = 33,
            PrimaryFileId = 609,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 7, 9, 11, 57),
            Price = 77000
          },
          new Artwork()
          {
            Id = 553,
            PublicId = new Guid("1bf755ef-fba0-4458-aa91-7ecbf91add19"),
            UserId = 33,
            PrimaryFileId = 610,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 2, 19, 9, 7),
            Price = 39000
          },
          new Artwork()
          {
            Id = 554,
            PublicId = new Guid("c42b3d26-4984-4cc6-afb2-7bcf7ae03ae6"),
            UserId = 33,
            PrimaryFileId = 611,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 17, 10, 21, 54),
            Price = 34000
          },
          new Artwork()
          {
            Id = 555,
            PublicId = new Guid("001596ef-779f-49b3-a7bd-e170face8761"),
            UserId = 33,
            PrimaryFileId = 612,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 16, 8, 32, 53),
            Price = 51000
          },
          new Artwork()
          {
            Id = 556,
            PublicId = new Guid("9dffeeee-04ba-4404-ab9a-44d0f8069169"),
            UserId = 33,
            PrimaryFileId = 613,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 16, 20, 33, 17),
            Price = 21000
          },
          new Artwork()
          {
            Id = 557,
            PublicId = new Guid("54d7be7b-8853-48ca-9174-ee3d2b3546c0"),
            UserId = 33,
            PrimaryFileId = 614,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 25, 15, 42, 11),
            Price = 34000
          },
          new Artwork()
          {
            Id = 558,
            PublicId = new Guid("aac1b8d1-8e4d-4f56-9c77-57594ae3709d"),
            UserId = 33,
            PrimaryFileId = 615,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 14, 15, 18, 58),
            Price = 80000
          },
          new Artwork()
          {
            Id = 559,
            PublicId = new Guid("e1b1ff53-fb29-4942-9361-5359bc98f5f0"),
            UserId = 33,
            PrimaryFileId = 616,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 19, 3, 30, 19),
            Price = 44000
          },
          new Artwork()
          {
            Id = 560,
            PublicId = new Guid("9ba56840-6c1b-4c08-9c1d-7b72b30b020d"),
            UserId = 33,
            PrimaryFileId = 617,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 15, 2, 12, 58),
            Price = 63000
          },
          new Artwork()
          {
            Id = 561,
            PublicId = new Guid("b9ba5a48-d5d1-4c07-803d-91cd5d285437"),
            UserId = 33,
            PrimaryFileId = 618,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 22, 6, 30, 26),
            Price = 92000
          },
          new Artwork()
          {
            Id = 562,
            PublicId = new Guid("d8e9b634-4095-439e-bdfe-b2620680b21d"),
            UserId = 33,
            PrimaryFileId = 619,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 20, 10, 30, 6),
            Price = 98000
          },
          new Artwork()
          {
            Id = 563,
            PublicId = new Guid("95450ed6-d8c9-49a0-bd63-2c89f96eedb6"),
            UserId = 33,
            PrimaryFileId = 620,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 8, 23, 17, 11),
            Price = 20000
          },
          new Artwork()
          {
            Id = 564,
            PublicId = new Guid("cb186b1d-1c5c-46a1-bfab-38975dc0317a"),
            UserId = 33,
            PrimaryFileId = 621,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 9, 4, 46, 36),
            Price = 67000
          },
          new Artwork()
          {
            Id = 565,
            PublicId = new Guid("8eb631f0-62e6-4f52-9a0d-117b16d89a08"),
            UserId = 33,
            PrimaryFileId = 622,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 21, 21, 15, 17),
            Price = 14000
          },
          new Artwork()
          {
            Id = 566,
            PublicId = new Guid("aaea3868-0963-4d5e-a817-4a2b44d3d21a"),
            UserId = 33,
            PrimaryFileId = 623,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 15, 15, 35, 21),
            Price = 64000
          },
          new Artwork()
          {
            Id = 567,
            PublicId = new Guid("8bfa64a7-0c50-47b5-875f-b20639c3bef3"),
            UserId = 33,
            PrimaryFileId = 624,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 6, 15, 31, 59),
            Price = 2000
          },
          new Artwork()
          {
            Id = 568,
            PublicId = new Guid("c564dcb1-746e-4388-9c7b-d3536c0a9f38"),
            UserId = 33,
            PrimaryFileId = 625,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 5, 0, 22, 14),
            Price = 19000
          },
          new Artwork()
          {
            Id = 569,
            PublicId = new Guid("38b0827c-0e3c-455d-afbc-c57202947283"),
            UserId = 33,
            PrimaryFileId = 626,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 1, 7, 9, 7),
            Price = 37000
          },
          new Artwork()
          {
            Id = 570,
            PublicId = new Guid("254d5429-2021-4ef1-80a6-f13aa973bbb0"),
            UserId = 33,
            PrimaryFileId = 627,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 13, 10, 2, 49),
            Price = 89000
          },
          new Artwork()
          {
            Id = 571,
            PublicId = new Guid("c7b5b131-53ac-4bd3-af50-69fe9d010cbb"),
            UserId = 33,
            PrimaryFileId = 628,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 17, 16, 50, 14),
            Price = 11000
          },
          new Artwork()
          {
            Id = 572,
            PublicId = new Guid("63f7a534-1e44-443e-a237-52a7a748a447"),
            UserId = 33,
            PrimaryFileId = 629,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 25, 7, 56, 27),
            Price = 54000
          },
          new Artwork()
          {
            Id = 573,
            PublicId = new Guid("dc8cc0bb-f0df-4cdb-927b-351269424158"),
            UserId = 33,
            PrimaryFileId = 630,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 19, 10, 21, 23),
            Price = 87000
          },
          new Artwork()
          {
            Id = 574,
            PublicId = new Guid("6c296dfd-046f-4099-8006-80c460f26a0f"),
            UserId = 33,
            PrimaryFileId = 631,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 16, 23, 53, 1),
            Price = 78000
          },
          new Artwork()
          {
            Id = 575,
            PublicId = new Guid("14d964bf-96de-4502-9110-d3b8d2f8a586"),
            UserId = 33,
            PrimaryFileId = 632,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 18, 15, 50, 26),
            Price = 7000
          },
          new Artwork()
          {
            Id = 576,
            PublicId = new Guid("bed45d73-4325-4d80-826c-0917e8ba5fdd"),
            UserId = 33,
            PrimaryFileId = 633,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 10, 20, 6, 18),
            Price = 96000
          },
          new Artwork()
          {
            Id = 577,
            PublicId = new Guid("719cd0fd-9676-43b4-b9bb-ab6fdc426edd"),
            UserId = 33,
            PrimaryFileId = 634,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 14, 7, 59, 1),
            Price = 7000
          },
          new Artwork()
          {
            Id = 578,
            PublicId = new Guid("29ace17a-e68b-496b-9baf-f6aed44c3dd2"),
            UserId = 33,
            PrimaryFileId = 635,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 10, 19, 52, 43),
            Price = 25000
          },
          new Artwork()
          {
            Id = 579,
            PublicId = new Guid("ec9328e5-60cf-4c79-90d2-c663bf92ac62"),
            UserId = 33,
            PrimaryFileId = 636,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 11, 10, 16, 15),
            Price = 93000
          },
          new Artwork()
          {
            Id = 580,
            PublicId = new Guid("10f23a90-7aa2-4151-8bda-ef4a08662398"),
            UserId = 33,
            PrimaryFileId = 637,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 7, 23, 12, 14),
            Price = 15000
          },
          new Artwork()
          {
            Id = 581,
            PublicId = new Guid("39c94995-b746-4f68-9f68-9852dad70f06"),
            UserId = 33,
            PrimaryFileId = 638,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 24, 15, 34, 24),
            Price = 73000
          },
          new Artwork()
          {
            Id = 582,
            PublicId = new Guid("8505e3b9-00cb-4c1a-a53a-4713ded76ca7"),
            UserId = 33,
            PrimaryFileId = 639,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 26, 0, 43, 32),
            Price = 53000
          },
          new Artwork()
          {
            Id = 583,
            PublicId = new Guid("ba6f4e02-8b13-49f1-aa64-9e33f1549106"),
            UserId = 33,
            PrimaryFileId = 640,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 4, 20, 4, 14),
            Price = 98000
          },
          new Artwork()
          {
            Id = 584,
            PublicId = new Guid("c9a2ce07-2236-4451-8bca-f1a5d389046a"),
            UserId = 33,
            PrimaryFileId = 641,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 9, 16, 38, 51),
            Price = 36000
          },
          new Artwork()
          {
            Id = 585,
            PublicId = new Guid("4867d1cd-e323-443b-b06c-d40fb6655efa"),
            UserId = 33,
            PrimaryFileId = 642,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 17, 9, 34, 1),
            Price = 66000
          },
          new Artwork()
          {
            Id = 586,
            PublicId = new Guid("599dce7d-75cd-4b94-8a56-ec2c920bafcb"),
            UserId = 33,
            PrimaryFileId = 643,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 20, 8, 18, 31),
            Price = 50000
          },
          new Artwork()
          {
            Id = 587,
            PublicId = new Guid("5c7a1cfd-5896-42b2-8109-20c023820c60"),
            UserId = 33,
            PrimaryFileId = 644,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 2, 12, 54, 54),
            Price = 65000
          },
          new Artwork()
          {
            Id = 588,
            PublicId = new Guid("f2a60e02-d753-47b0-91fa-4f05cf246616"),
            UserId = 33,
            PrimaryFileId = 645,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 3, 16, 5, 1),
            Price = 6000
          },
          new Artwork()
          {
            Id = 589,
            PublicId = new Guid("905d332b-f854-4df6-bb53-074e1066cd40"),
            UserId = 33,
            PrimaryFileId = 646,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 7, 17, 3, 36),
            Price = 97000
          },
          new Artwork()
          {
            Id = 590,
            PublicId = new Guid("c97c7465-fc85-4206-9a11-a7ea64f2bd7c"),
            UserId = 33,
            PrimaryFileId = 647,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 1, 18, 46, 12),
            Price = 16000
          },
          new Artwork()
          {
            Id = 591,
            PublicId = new Guid("c13df342-8a28-4af1-bfce-c722a687ba00"),
            UserId = 33,
            PrimaryFileId = 648,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 13, 21, 7, 11),
            Price = 68000
          },
          new Artwork()
          {
            Id = 592,
            PublicId = new Guid("6481ee11-1cc7-4427-8153-26b5275191d8"),
            UserId = 33,
            PrimaryFileId = 649,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 7, 1, 35, 19),
            Price = 34000
          },
          new Artwork()
          {
            Id = 593,
            PublicId = new Guid("df239bca-c95a-4a27-babc-5cb2d2a77d2e"),
            UserId = 33,
            PrimaryFileId = 650,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 5, 8, 49, 48),
            Price = 59000
          },
          new Artwork()
          {
            Id = 594,
            PublicId = new Guid("e1defe24-b5e3-4767-8238-3abdf8fe173d"),
            UserId = 33,
            PrimaryFileId = 651,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 20, 13, 50, 29),
            Price = 81000
          },
          new Artwork()
          {
            Id = 595,
            PublicId = new Guid("f44b4f83-f784-4099-abcb-0252cace82ff"),
            UserId = 33,
            PrimaryFileId = 652,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 19, 22, 39, 17),
            Price = 71000
          },
          new Artwork()
          {
            Id = 596,
            PublicId = new Guid("eb8de831-5733-4749-b684-e142b0b9585f"),
            UserId = 33,
            PrimaryFileId = 653,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 5, 2, 11, 24),
            Price = 61000
          },
          new Artwork()
          {
            Id = 597,
            PublicId = new Guid("6c6fabe4-fb20-4b3e-a860-bb32197b33b5"),
            UserId = 33,
            PrimaryFileId = 654,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 2, 0, 1, 15),
            Price = 38000
          },
          new Artwork()
          {
            Id = 598,
            PublicId = new Guid("8650c161-9f63-4616-82ee-8da17bcc14b7"),
            UserId = 33,
            PrimaryFileId = 655,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 17, 10, 36, 24),
            Price = 14000
          },
          new Artwork()
          {
            Id = 599,
            PublicId = new Guid("35ff1e69-8d9a-424a-a09a-d09708e3dcb9"),
            UserId = 33,
            PrimaryFileId = 656,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 19, 23, 17, 2),
            Price = 25000
          },
          new Artwork()
          {
            Id = 600,
            PublicId = new Guid("fe927f13-5c4e-4965-ab07-dee179446ad0"),
            UserId = 33,
            PrimaryFileId = 657,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 10, 10, 15, 50),
            Price = 57000
          },
          new Artwork()
          {
            Id = 601,
            PublicId = new Guid("0c87da5f-663c-4d4d-b01f-05e009c0f5ad"),
            UserId = 33,
            PrimaryFileId = 658,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 12, 21, 25, 29),
            Price = 72000
          },
          new Artwork()
          {
            Id = 602,
            PublicId = new Guid("5ea78b77-fedb-4525-9ed8-9130d6dc6005"),
            UserId = 33,
            PrimaryFileId = 659,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 8, 11, 15, 27),
            Price = 72000
          },
          new Artwork()
          {
            Id = 603,
            PublicId = new Guid("104b36bf-3db9-4710-8cee-2f50a10afb00"),
            UserId = 33,
            PrimaryFileId = 660,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 25, 22, 56, 21),
            Price = 38000
          },
          new Artwork()
          {
            Id = 604,
            PublicId = new Guid("844aecc2-c739-4267-a9c3-8788e36df8ec"),
            UserId = 33,
            PrimaryFileId = 661,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 2, 21, 54, 56),
            Price = 36000
          },
          new Artwork()
          {
            Id = 605,
            PublicId = new Guid("8651f5cf-376d-45bf-9786-1c6c1b6f18ac"),
            UserId = 33,
            PrimaryFileId = 662,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 5, 20, 59, 15),
            Price = 63000
          },
          new Artwork()
          {
            Id = 606,
            PublicId = new Guid("67dcfcd9-b5cd-4889-915e-9ab5a1d44fa9"),
            UserId = 33,
            PrimaryFileId = 663,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 8, 1, 32, 12),
            Price = 19000
          },
          new Artwork()
          {
            Id = 607,
            PublicId = new Guid("502f6e69-58d9-41e2-9667-d56048c2e8de"),
            UserId = 33,
            PrimaryFileId = 664,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 27, 21, 53, 30),
            Price = 96000
          },
          new Artwork()
          {
            Id = 608,
            PublicId = new Guid("202ad5dc-1bb4-4f94-b029-f8ee3fbc121d"),
            UserId = 33,
            PrimaryFileId = 665,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 17, 5, 32, 30),
            Price = 74000
          },
          new Artwork()
          {
            Id = 609,
            PublicId = new Guid("d93056fa-a37c-47a6-972b-97fc7a5a9af7"),
            UserId = 33,
            PrimaryFileId = 666,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 16, 8, 1, 16),
            Price = 30000
          },
          new Artwork()
          {
            Id = 610,
            PublicId = new Guid("ab33e57f-8de7-44e4-96ef-09846b2e1c59"),
            UserId = 33,
            PrimaryFileId = 667,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 1, 18, 8, 49),
            Price = 36000
          },
          new Artwork()
          {
            Id = 611,
            PublicId = new Guid("1e104582-37e9-4fb4-8c83-96be38d7540e"),
            UserId = 33,
            PrimaryFileId = 668,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 9, 11, 52, 59),
            Price = 13000
          },
          new Artwork()
          {
            Id = 612,
            PublicId = new Guid("5d72e674-85b4-44c2-822e-1d316ad4eb89"),
            UserId = 33,
            PrimaryFileId = 669,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 26, 4, 46, 2),
            Price = 27000
          },
          new Artwork()
          {
            Id = 613,
            PublicId = new Guid("d809cc8b-de77-41fe-ae7f-95bdab0ade35"),
            UserId = 33,
            PrimaryFileId = 670,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 15, 13, 30, 8),
            Price = 74000
          },
          new Artwork()
          {
            Id = 614,
            PublicId = new Guid("5d5535c5-4e9c-4168-843d-a7a4b1b61f06"),
            UserId = 33,
            PrimaryFileId = 671,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 6, 8, 39, 0),
            Price = 38000
          },
          new Artwork()
          {
            Id = 615,
            PublicId = new Guid("2bab0ee3-41be-4fed-b247-d6d65ce90fed"),
            UserId = 33,
            PrimaryFileId = 672,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 1, 21, 8, 38, 22),
            Price = 99000
          },
          new Artwork()
          {
            Id = 616,
            PublicId = new Guid("b8d5cd42-8899-4c93-834f-5dc988d796a4"),
            UserId = 33,
            PrimaryFileId = 673,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 1, 17, 8, 9),
            Price = 86000
          },
          new Artwork()
          {
            Id = 617,
            PublicId = new Guid("b3485dd6-3e76-4d00-8444-ef2e361c5814"),
            UserId = 33,
            PrimaryFileId = 674,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 16, 7, 37, 24),
            Price = 32000
          },
          new Artwork()
          {
            Id = 618,
            PublicId = new Guid("4c0a9ebb-bcad-432a-8c74-918ad4870c99"),
            UserId = 33,
            PrimaryFileId = 675,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 5, 18, 6, 53, 51),
            Price = 63000
          },
          new Artwork()
          {
            Id = 619,
            PublicId = new Guid("36b877aa-ad62-4379-8ac2-d85bc015f73f"),
            UserId = 33,
            PrimaryFileId = 676,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 14, 5, 31, 58),
            Price = 12000
          },
          new Artwork()
          {
            Id = 620,
            PublicId = new Guid("fde160a9-a307-4e3f-b624-4ae89360d57e"),
            UserId = 33,
            PrimaryFileId = 677,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 3, 19, 17, 46, 43),
            Price = 10000
          },
          new Artwork()
          {
            Id = 621,
            PublicId = new Guid("434153e5-a8f1-4ff9-8dbc-9898668b5f17"),
            UserId = 33,
            PrimaryFileId = 678,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 26, 23, 50, 11),
            Price = 73000
          },
          new Artwork()
          {
            Id = 622,
            PublicId = new Guid("e79102e2-4fc5-44e4-80dc-e8c398ea79de"),
            UserId = 33,
            PrimaryFileId = 679,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 6, 11, 3, 24),
            Price = 37000
          },
          new Artwork()
          {
            Id = 623,
            PublicId = new Guid("669990d0-389d-4780-8f5e-f82e37240405"),
            UserId = 33,
            PrimaryFileId = 680,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 24, 14, 10, 13),
            Price = 30000
          },
          new Artwork()
          {
            Id = 624,
            PublicId = new Guid("2bf9c03b-b761-4eba-8a4e-88688c1ecb42"),
            UserId = 33,
            PrimaryFileId = 681,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 23, 12, 16, 47),
            Price = 6000
          },
          new Artwork()
          {
            Id = 625,
            PublicId = new Guid("8f8747cb-3f4a-4cab-b861-f7332c4346af"),
            UserId = 33,
            PrimaryFileId = 682,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 9, 10, 3, 53, 7),
            Price = 62000
          },
          new Artwork()
          {
            Id = 626,
            PublicId = new Guid("e29ac120-f64f-4f50-b923-b4623c6f8066"),
            UserId = 33,
            PrimaryFileId = 683,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 22, 3, 6, 47),
            Price = 9000
          },
          new Artwork()
          {
            Id = 627,
            PublicId = new Guid("c66a29ae-ca0a-4a6b-83ea-63fe20539259"),
            UserId = 33,
            PrimaryFileId = 684,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 9, 12, 30, 22),
            Price = 34000
          },
          new Artwork()
          {
            Id = 628,
            PublicId = new Guid("26604057-6f58-4d5b-b4aa-ff1aed468c0a"),
            UserId = 33,
            PrimaryFileId = 685,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 17, 11, 45, 32),
            Price = 75000
          },
          new Artwork()
          {
            Id = 629,
            PublicId = new Guid("52d43670-f38c-4071-84cc-b2d636478fa7"),
            UserId = 33,
            PrimaryFileId = 686,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 7, 21, 6, 11, 5),
            Price = 18000
          },
          new Artwork()
          {
            Id = 630,
            PublicId = new Guid("6f87f331-9d02-4bb6-bd18-5c2e220844b1"),
            UserId = 33,
            PrimaryFileId = 687,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 11, 20, 7, 5),
            Price = 73000
          },
          new Artwork()
          {
            Id = 631,
            PublicId = new Guid("fa1a24fc-b0fa-41cf-9f63-dec07a79fe68"),
            UserId = 33,
            PrimaryFileId = 688,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 1, 1, 24, 40),
            Price = 35000
          },
          new Artwork()
          {
            Id = 632,
            PublicId = new Guid("c2ec3031-0a18-499a-8a61-5abce675f342"),
            UserId = 33,
            PrimaryFileId = 689,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 19, 0, 25, 50),
            Price = 42000
          },
          new Artwork()
          {
            Id = 633,
            PublicId = new Guid("6626f91d-db73-4cd6-894b-c60ba12571ec"),
            UserId = 33,
            PrimaryFileId = 690,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 8, 18, 53, 28),
            Price = 90000
          },
          new Artwork()
          {
            Id = 634,
            PublicId = new Guid("b7896a1a-8fbf-4db4-9204-ef05733d40cf"),
            UserId = 33,
            PrimaryFileId = 691,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 2, 6, 1, 12, 49),
            Price = 51000
          },
          new Artwork()
          {
            Id = 635,
            PublicId = new Guid("d64fff94-37f7-4367-840e-a21fb106621c"),
            UserId = 33,
            PrimaryFileId = 692,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 11, 10, 18, 2),
            Price = 1000
          },
          new Artwork()
          {
            Id = 636,
            PublicId = new Guid("c2d5a234-7229-4594-8ee9-8b9902d11cb2"),
            UserId = 33,
            PrimaryFileId = 693,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 1, 23, 9, 43, 49),
            Price = 78000
          },
          new Artwork()
          {
            Id = 637,
            PublicId = new Guid("0718d1fc-43f5-4af7-8cbf-a84665204606"),
            UserId = 33,
            PrimaryFileId = 694,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 3, 13, 14, 50, 33),
            Price = 7000
          },
          new Artwork()
          {
            Id = 638,
            PublicId = new Guid("9d2b5837-b60e-4670-bf85-6fe4aa68d78a"),
            UserId = 33,
            PrimaryFileId = 695,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 7, 4, 34, 8),
            Price = 51000
          },
          new Artwork()
          {
            Id = 639,
            PublicId = new Guid("1a6f21f7-5668-4c8c-9169-7541519114c1"),
            UserId = 33,
            PrimaryFileId = 696,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 6, 7, 23, 23),
            Price = 55000
          },
          new Artwork()
          {
            Id = 640,
            PublicId = new Guid("edbd9d1d-6b65-46b0-a4c5-a102a6649572"),
            UserId = 33,
            PrimaryFileId = 697,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 8, 3, 13, 35, 3),
            Price = 98000
          },
          new Artwork()
          {
            Id = 641,
            PublicId = new Guid("12539ee5-7573-4b8d-96f8-54a52e3b0545"),
            UserId = 33,
            PrimaryFileId = 698,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 11, 2, 45, 28),
            Price = 8000
          },
          new Artwork()
          {
            Id = 642,
            PublicId = new Guid("9b9b01b4-90bb-422d-bef5-2e8c5f9385ec"),
            UserId = 33,
            PrimaryFileId = 699,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 9, 12, 7, 49, 31),
            Price = 39000
          },
          new Artwork()
          {
            Id = 643,
            PublicId = new Guid("8abc4dd3-0b86-4a50-9e6a-e4982c081f19"),
            UserId = 33,
            PrimaryFileId = 700,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 4, 25, 22, 56, 38),
            Price = 21000
          },
          new Artwork()
          {
            Id = 644,
            PublicId = new Guid("3a413d41-3a03-4aca-8299-efc14002838a"),
            UserId = 33,
            PrimaryFileId = 701,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 2, 4, 18, 40),
            Price = 37000
          },
          new Artwork()
          {
            Id = 645,
            PublicId = new Guid("72d263f9-968b-4cf5-a052-302541598d8e"),
            UserId = 33,
            PrimaryFileId = 702,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 5, 22, 9, 20, 56),
            Price = 26000
          },
          new Artwork()
          {
            Id = 646,
            PublicId = new Guid("69c7ae70-6a7f-4e41-8c5f-698621cf0096"),
            UserId = 33,
            PrimaryFileId = 703,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 3, 19, 1, 15),
            Price = 29000
          },
          new Artwork()
          {
            Id = 647,
            PublicId = new Guid("8fc78dcb-28e3-4278-9a67-3ad000465628"),
            UserId = 33,
            PrimaryFileId = 704,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 2, 9, 6, 20),
            Price = 79000
          },
          new Artwork()
          {
            Id = 648,
            PublicId = new Guid("8a84f4e1-52b2-4434-92f3-6223183f32d1"),
            UserId = 33,
            PrimaryFileId = 705,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 9, 10, 0, 41),
            Price = 99000
          },
          new Artwork()
          {
            Id = 649,
            PublicId = new Guid("76493007-2055-4ccc-b76f-e48af6bd6322"),
            UserId = 33,
            PrimaryFileId = 706,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 2, 23, 22, 51),
            Price = 71000
          },
          new Artwork()
          {
            Id = 650,
            PublicId = new Guid("8b35fd52-830d-4200-9c1c-f1828f1f582b"),
            UserId = 33,
            PrimaryFileId = 707,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 6, 13, 43, 23),
            Price = 50000
          },
          new Artwork()
          {
            Id = 651,
            PublicId = new Guid("4ece428c-b61a-4a24-baa7-ef560304a00d"),
            UserId = 33,
            PrimaryFileId = 708,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 10, 8, 10, 31, 30),
            Price = 76000
          },
          new Artwork()
          {
            Id = 652,
            PublicId = new Guid("071334be-9f17-4741-b434-e70739d9d793"),
            UserId = 33,
            PrimaryFileId = 709,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 17, 13, 13, 29),
            Price = 15000
          },
          new Artwork()
          {
            Id = 653,
            PublicId = new Guid("211de5dd-9d56-4d05-b51d-5d7c21057faa"),
            UserId = 33,
            PrimaryFileId = 710,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 4, 4, 9, 41, 2),
            Price = 43000
          },
          new Artwork()
          {
            Id = 654,
            PublicId = new Guid("aaf5eb77-c2b7-4a18-adfb-6aee8c2f3b1c"),
            UserId = 33,
            PrimaryFileId = 711,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 14, 5, 2, 12),
            Price = 63000
          },
          new Artwork()
          {
            Id = 655,
            PublicId = new Guid("f034a461-641b-4c2f-9eab-d6d533403c6e"),
            UserId = 33,
            PrimaryFileId = 712,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 10, 6, 22, 52),
            Price = 90000
          },
          new Artwork()
          {
            Id = 656,
            PublicId = new Guid("8a33fa3b-cd7d-4e83-a673-e8f33968aa7d"),
            UserId = 33,
            PrimaryFileId = 713,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 8, 20, 13, 19, 27),
            Price = 22000
          },
          new Artwork()
          {
            Id = 657,
            PublicId = new Guid("e49c3518-8352-4b1d-a73a-6acdd136488d"),
            UserId = 33,
            PrimaryFileId = 714,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 12, 23, 14, 5, 23),
            Price = 23000
          },
          new Artwork()
          {
            Id = 658,
            PublicId = new Guid("61523f41-2981-4163-b1ea-b0020e878811"),
            UserId = 33,
            PrimaryFileId = 715,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 6, 5, 22, 11, 31),
            Price = 83000
          },
          new Artwork()
          {
            Id = 659,
            PublicId = new Guid("7f55fa74-821c-4cb5-a202-feadf717bf11"),
            UserId = 33,
            PrimaryFileId = 716,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 11, 18, 14, 37, 51),
            Price = 36000
          },
          new Artwork()
          {
            Id = 660,
            PublicId = new Guid("631aba43-3561-42d3-9722-264cb9011299"),
            UserId = 33,
            PrimaryFileId = 717,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 12, 18, 14, 52, 51),
            Price = 66000
          },
          new Artwork()
          {
            Id = 661,
            PublicId = new Guid("89db9aa1-d597-48c6-904f-18ba19c286f5"),
            UserId = 33,
            PrimaryFileId = 718,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 15, 2, 8, 50),
            Price = 93000
          },
          new Artwork()
          {
            Id = 662,
            PublicId = new Guid("7886eea4-c342-4a4f-a676-02dd8865937e"),
            UserId = 33,
            PrimaryFileId = 719,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 11, 6, 23, 26, 53),
            Price = 6000
          },
          new Artwork()
          {
            Id = 663,
            PublicId = new Guid("2413209d-0694-425e-a354-cd2de7f30bad"),
            UserId = 33,
            PrimaryFileId = 720,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 6, 11, 11, 32, 14),
            Price = 85000
          },
          new Artwork()
          {
            Id = 664,
            PublicId = new Guid("c2e59a8b-8efe-421e-aa53-ef80cf01e05d"),
            UserId = 33,
            PrimaryFileId = 721,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 10, 7, 7, 17, 25),
            Price = 67000
          },
          new Artwork()
          {
            Id = 665,
            PublicId = new Guid("d55e3829-b5ca-47c5-af87-25e54a8d5c3a"),
            UserId = 33,
            PrimaryFileId = 722,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2021, 7, 2, 11, 0, 50),
            Price = 49000
          },
          new Artwork()
          {
            Id = 666,
            PublicId = new Guid("c491a773-de58-466c-8545-666c0a419533"),
            UserId = 33,
            PrimaryFileId = 723,
            Title = "Lorem ipsum",
            Description = "",
            Published = new DateTime(2020, 2, 26, 13, 38, 45),
            Price = 20000
          },
          new Artwork()
          {
            Id = 667,
            PublicId = new Guid("f4486c50-f6ec-4d57-ae58-fe99802a4804"),
            UserId = 34,
            PrimaryFileId = 725,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 2, 10, 11, 41, 27),
            Price = 30000
          },
          new Artwork()
          {
            Id = 668,
            PublicId = new Guid("ab305d7b-5800-460c-aa2e-57e88e4dd9af"),
            UserId = 34,
            PrimaryFileId = 726,
            Title = "",
            Description = "",
            Published = new DateTime(2020, 3, 10, 13, 6, 4),
            Price = 56000
          },
          new Artwork()
          {
            Id = 669,
            PublicId = new Guid("eafa2308-765e-46a8-9ad5-e1ebe3e869f9"),
            UserId = 34,
            PrimaryFileId = 727,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 7, 7, 6, 20, 50),
            Price = 2000
          },
          new Artwork()
          {
            Id = 670,
            PublicId = new Guid("0f993fc5-c589-462e-a653-a07f63a0c06e"),
            UserId = 34,
            PrimaryFileId = 728,
            Title = "",
            Description = "",
            Published = new DateTime(2020, 5, 4, 23, 42, 5),
            Price = 39000
          },
          new Artwork()
          {
            Id = 671,
            PublicId = new Guid("e04e6ee1-d257-4d56-885d-6431db5a29ba"),
            UserId = 34,
            PrimaryFileId = 729,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 11, 10, 19, 45, 5),
            Price = 31000
          },
          new Artwork()
          {
            Id = 672,
            PublicId = new Guid("996763be-1e83-405f-95ef-7b8cd48cd8ec"),
            UserId = 34,
            PrimaryFileId = 730,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 6, 3, 12, 8, 3),
            Price = 25000
          },
          new Artwork()
          {
            Id = 673,
            PublicId = new Guid("e5b5ad02-3322-4864-a1a6-2b45e5093d94"),
            UserId = 34,
            PrimaryFileId = 731,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 7, 17, 4, 14, 39),
            Price = 37000
          },
          new Artwork()
          {
            Id = 674,
            PublicId = new Guid("fb41119e-b2c3-4b9e-b494-582a62e999d5"),
            UserId = 34,
            PrimaryFileId = 732,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 8, 5, 13, 44, 48),
            Price = 20000
          },
          new Artwork()
          {
            Id = 675,
            PublicId = new Guid("87e6f6c6-b7e4-4327-adaf-bb002fca6764"),
            UserId = 34,
            PrimaryFileId = 733,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 10, 11, 1, 36, 24),
            Price = 93000
          },
          new Artwork()
          {
            Id = 676,
            PublicId = new Guid("51b330ce-c83a-4455-9a6f-216e7b4b10db"),
            UserId = 34,
            PrimaryFileId = 734,
            Title = "",
            Description = "",
            Published = new DateTime(2020, 11, 22, 17, 10, 49),
            Price = 61000
          },
          new Artwork()
          {
            Id = 677,
            PublicId = new Guid("8a20e0d3-c4dc-455c-bd74-c4e8c64ac6f6"),
            UserId = 34,
            PrimaryFileId = 735,
            Title = "",
            Description = "",
            Published = new DateTime(2020, 9, 11, 7, 40, 25),
            Price = 41000
          },
          new Artwork()
          {
            Id = 678,
            PublicId = new Guid("2683137a-00d2-4217-9e16-21eb274af5e2"),
            UserId = 34,
            PrimaryFileId = 736,
            Title = "",
            Description = "",
            Published = new DateTime(2021, 11, 20, 10, 4, 43),
            Price = 30000
          },
        };
    }
  }
}
