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
        };
    }
  }
}
