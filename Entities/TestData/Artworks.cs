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
            UserId = 2,
            PrimaryFileId = 1,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 2,
            PublicId = new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
            UserId = 2,
            PrimaryFileId = 2,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 3,
            PublicId = new Guid("b24e3df5-0394-468d-9c1d-db1252fea920"),
            UserId = 2,
            PrimaryFileId = 3,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 4,
            PublicId = new Guid("9f35e705-637a-4bbe-8c35-402b2ecf7128"),
            UserId = 3,
            PrimaryFileId = 4,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 5,
            PublicId = new Guid("939df3fd-de57-4caf-96dc-c5e110322a96"),
            UserId = 3,
            PrimaryFileId = 5,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 6,
            PublicId = new Guid("d70f656d-75a7-45fc-b385-e4daa834e6a8"),
            UserId = 3,
            PrimaryFileId = 6,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 7,
            PublicId = new Guid("ce1d2b1c-7869-4df5-9a32-2cbaca8c3234"),
            UserId = 3,
            PrimaryFileId = 7,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 8,
            PublicId = new Guid("2645bd94-3624-43fc-b21f-1209d730fc71"),
            UserId = 6,
            PrimaryFileId = 8,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 9,
            PublicId = new Guid("3f41dc87-e8de-42ee-ac8d-355e4d3e1a2d"),
            UserId = 2,
            PrimaryFileId = 9,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 10,
            PublicId = new Guid("d3118665-43e3-4905-8848-5e335a428dd5"),
            UserId = 3,
            PrimaryFileId = 10,
            SecondaryFileId = 11,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 11,
            PublicId = new Guid("136f358d-98fb-4961-855c-59d5a6d1fa19"),
            UserId = 6,
            PrimaryFileId = 12,
            SecondaryFileId = 13,
            TertiaryFileId = 14,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 13,
            PublicId = new Guid("9d5a7c23-86b6-4e90-b305-e8349894e26c"),
            UserId = 6,
            PrimaryFileId = 18,
            Title = "Flicka på äng",
            Description = "Akvarellmålning av en liten flicka som sitter på knä på en äng och plockar blommor",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 15,
            PublicId = new Guid("ed1c9962-eaa0-454e-ac02-2b0f5cfc8fc4"),
            UserId = 4,
            PrimaryFileId = 29,
            Title = "Liggande fjäril",
            Published = DateTime.Now
          },
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 17,
            PublicId = new Guid("ddef3c91-1102-422d-b2c5-661e79806001"),
            UserId = 12,
            PrimaryFileId = 46,
            Title = "Vintergård",
            Description = "Sverige År 1752. Tar med familjen på julmarknad.",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 19,
            PublicId = new Guid("86d4e142-6d72-4e9b-bd6d-ceeea589b333"),
            UserId = 4,
            PrimaryFileId = 48,
            Title = "Självporträtt",
            Description = "Jag fast utan armar",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 20,
            PublicId = new Guid("251e53ad-1cd6-4878-924a-e58ebc6975e8"),
            UserId = 11,
            PrimaryFileId = 57,
            SecondaryFileId = 150,
            Title = "Tiger",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 21,
            PublicId = new Guid("659ec539-e7f5-4123-8e5a-3ec4d8c157c5"),
            UserId = 12,
            PrimaryFileId = 58,
            Title = "Skogsmänniskor",
            Description = "Man och kvinna med arborister som frisörer. Svartvit bild målad i Photoshop.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 22,
            PublicId = new Guid("bb7f7e01-e4e6-479a-8a7a-d42702599585"),
            UserId = 12,
            PrimaryFileId = 65,
            Title = "Blommor i färg",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 23,
            PublicId = new Guid("8a4d54f1-b3f3-4809-9175-95c8fb397cec"),
            UserId = 8,
            PrimaryFileId = 21,
            Title = "Mona Lisa",
            Description = "En av världens mest berömda målningar (just saying) som jag målat en gång när jag hade tråkigt i Italien.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 24,
            PublicId = new Guid("d4ec3acf-54a5-4f01-8bf2-2acb87821d1e"),
            UserId = 14,
            PrimaryFileId = 66,
            Title = "Berg",
            Description = "Vacker målning av ett berg med en levande himmel",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 25,
            PublicId = new Guid("567055b7-837c-4d98-9102-97752c97eac2"),
            UserId = 15,
            PrimaryFileId = 67,
            Title = "Tegelvägg med synfält",
            Description = "Rymdvägg som lämnar mycket åt fantasin",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 27,
            PublicId = new Guid("7ac18c58-8f58-4fde-8577-039c3ff09491"),
            UserId = 11,
            PrimaryFileId = 72,
            Title = "Petit svan",
            Description = "3x6 cm målning av en svan i kvällsljus",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 28,
            PublicId = new Guid("87a1711f-d846-48e7-986a-d6b7cc684e5f"),
            UserId = 11,
            PrimaryFileId = 73,
            Title = "Black panther",
            Description = "Svart panter målad i akvarell",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 29,
            PublicId = new Guid("b3699690-7984-45e5-b84e-2792259180f3"),
            UserId = 12,
            PrimaryFileId = 79,
            Title = "Rapsfält",
            Description = "Utsikt över rapsfält och ängar",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 30,
            PublicId = new Guid("798f9bda-11cd-4ed6-9c0d-85c27c01e101"),
            UserId = 1,
            PrimaryFileId = 80,
            Title = "Blå stad",
            Description = "Porslinsmålad stad i Vietnam med karaktäristiska berg som tornar upp i bakgrunden",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 31,
            PublicId = new Guid("0e7bfe73-a928-472d-a30d-46d09902a525"),
            UserId = 1,
            PrimaryFileId = 81,
            Title = "Glänta",
            Description = "Gläntan en sensommarkväll",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 33,
            PublicId = new Guid("fc7117cf-fb36-479b-b3b1-aa08c3ab51e0"),
            UserId = 1,
            PrimaryFileId = 89,
            Title = "Old Amsterdam",
            Description = "Amsterdams gator en höstdag 2005",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 34,
            PublicId = new Guid("282ad43c-6438-4b82-b4cd-ebf862081247"),
            UserId = 1,
            PrimaryFileId = 90,
            Title = "Blåklint på ängen",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 35,
            PublicId = new Guid("869c3fdf-a24e-40cb-8355-121e4e5bfc6b"),
            UserId = 4,
            PrimaryFileId = 91,
            Title = "Glad sol",
            Description = "Ett mästerverk utom dess like",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 36,
            PublicId = new Guid("3e7e1abc-2faa-4b93-a8de-93e46bc1944f"),
            UserId = 12,
            PrimaryFileId = 26,
            Title = "Traditionell stuga på Island",
            Published = DateTime.Now
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
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 39,
            PublicId = new Guid("7512794a-546e-4f06-bc70-0aa4415e5cf5"),
            UserId = 4,
            PrimaryFileId = 32,
            Title = "Mitt hus",
            Description = "Mitt hus från när jag växte upp. Färgvalet framhäver dörren på ett sätt man aldrig skulle kunna tänka sig var möjligt.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 40,
            PublicId = new Guid("15bca89d-03f0-40c8-8537-8a7614c88040"),
            UserId = 15,
            PrimaryFileId = 41,
            SecondaryFileId = 60,
            Title = "Blommor i rosa nyanser",
            Description = "Ett vackert urval av blommor i en rosa färgexplosion",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 41,
            PublicId = new Guid("dd575506-fcb5-4314-b9cc-dbb4c49b1c7d"),
            UserId = 15,
            PrimaryFileId = 45,
            Title = "Insidan av ett hus",
            Description = "I huset finns det en säng, två stolar, ett nattduksbord/matbord, sex tavlor, en vas, grönt golv och blåa dörrar. Fönstret kan man inte se ut igenom för det är övermålat. Några krokar finns på väggen så att man kan hänga upp sina kläder efter en lång dag utomhus.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 42,
            PublicId = new Guid("3a8782d6-a233-4911-921a-40b65fa8cee5"),
            UserId = 1,
            PrimaryFileId = 62,
            Title = "Hus på landet",
            Description = "Mitt hus på landet, precis intill den gamla stadsmuren.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 43,
            PublicId = new Guid("f88e0692-5a41-4bb1-90e4-99de87eb6ec0"),
            UserId = 11,
            PrimaryFileId = 25,
            Title = "Gnägg",
            Description = "Häst som gnäggar",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 44,
            PublicId = new Guid("71515573-101a-4d37-af6c-55ebce289e33"),
            UserId = 15,
            PrimaryFileId = 78,
            Title = "Flicka matar får",
            Description = "Historisk bild av en ung flicka som tar hand om familjens får",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 45,
            PublicId = new Guid("5455f37d-b86f-46ec-940d-53cfb01960e5"),
            UserId = 18,
            PrimaryFileId = 85,
            Title = "Staty i Aten",
            Description = "Fotot föreställer en smutsig staty som jag hittade när jag reste runt i Grekland",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 46,
            PublicId = new Guid("dd270b3a-6cb1-41d8-b90d-96ea20fc4c05"),
            UserId = 12,
            PrimaryFileId = 92,
            Title = "Berg med spegelbild",
            Description = "Mäktigt berg som speglas mot vattenytan i en liten sjö",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 47,
            PublicId = new Guid("bc21e104-4f26-48c1-9ffb-f049ac970aba"),
            UserId = 12,
            PrimaryFileId = 54,
            Title = "Höstträd",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 48,
            PublicId = new Guid("7b9001d1-e5a2-4364-975d-5ca0e3f1b803"),
            UserId = 12,
            PrimaryFileId = 56,
            Title = "Bukett i vas",
            Description = "En blombukett i en vas som jag fick när jag fyllde jämnt och bestämde mig för att måla av",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 49,
            PublicId = new Guid("b1d933e6-d988-4ce3-a076-3be852885f26"),
            UserId = 8,
            PrimaryFileId = 23,
            Title = "Jesus Maria",
            Description = "En nunna från ett lokalt kloster",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 50,
            PublicId = new Guid("bd68cfb1-29ce-4836-8a6f-0c2536835a16"),
            UserId = 12,
            PrimaryFileId = 77,
            Title = "Skymningsskog",
            Description = "Trädtoppar som avbildas mot den rödlila himmlen en vårnatt i april",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 51,
            PublicId = new Guid("c99cf456-221d-4214-9c9f-9df85ce31aa8"),
            UserId = 8,
            PrimaryFileId = 31,
            Title = "Espresso",
            Description = "Skylt på café från min resa längs den italienska rivieran",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 52,
            PublicId = new Guid("3183d9ed-4daa-4be0-8d54-b477ff936cec"),
            UserId = 4,
            PrimaryFileId = 61,
            Title = "Nyckelpiga",
            Description = "Formidabel målning av en nyckelpiga med sex prickar avbildad med kritor i rött och svart",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 53,
            PublicId = new Guid("313d392e-6036-41a8-9178-f7d6123779a4"),
            UserId = 1,
            PrimaryFileId = 75,
            Title = "Den perfekta vågen",
            Description = "Surfare fångar den perfekta vågen",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 55,
            PublicId = new Guid("06db3b01-10e8-451e-88f3-9d2f49594a0a"),
            UserId = 12,
            PrimaryFileId = 22,
            Title = "Kråkträd",
            Description = "Ståtligt träd på äng en mörk åsknatt",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 56,
            PublicId = new Guid("cdf1dae1-1774-4d6e-8d0d-b6514f48ed4c"),
            UserId = 15,
            PrimaryFileId = 136,
            Title = "Hund möter igelkott",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 57,
            PublicId = new Guid("da86471c-9d70-48b0-b41b-314e4a5ff49c"),
            UserId = 15,
            PrimaryFileId = 69,
            Title = "Molnig soldag",
            Description = "Solen som sträcker sig genom molnen i akvarell",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 58,
            PublicId = new Guid("e110c657-283e-4864-a444-ce198dc7008a"),
            UserId = 2,
            PrimaryFileId = 84,
            Title = "Vårfågel",
            Description = "Fågel på gren. Målad i akvarell.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 59,
            PublicId = new Guid("cde5138b-2ab0-4698-888b-57b87da1a77e"),
            UserId = 12,
            PrimaryFileId = 51,
            Title = "Höstlöv på höstlov",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 60,
            PublicId = new Guid("de6f035e-cd91-48be-a7bb-802ab424b485"),
            UserId = 14,
            PrimaryFileId = 42,
            Title = "Skogsglänta",
            Description = "Glänta i skogen får finbesök i form av två ståtliga rådjur",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 61,
            PublicId = new Guid("46e7b1a8-92fc-4036-b2fb-47c7118221c1"),
            UserId = 8,
            PrimaryFileId = 94,
            Title = "Can't touch this",
            Description = "Två händer som inte rör vid varandra. Populärt motiv just nu.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 62,
            PublicId = new Guid("373fb4e9-9d4e-47c5-8a26-f9db600138bf"),
            UserId = 4,
            PrimaryFileId = 95,
            Title = "Min kompis hus",
            Description = "Huset som min kompis Ludde bor i målad med många fönster och en dörr med ett konstigt handtag",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 63,
            PublicId = new Guid("4e03c237-4384-413d-8727-39a79afc6f54"),
            UserId = 12,
            PrimaryFileId = 99,
            SecondaryFileId = 142,
            Title = "Träd med sjöutsikt",
            Description = "Björkar vid strandenkanten av Mälaren",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 64,
            PublicId = new Guid("f484ae02-0897-4c96-8197-450becfc6a9f"),
            UserId = 12,
            PrimaryFileId = 100,
            Title = "Napoleon Bonaparte",
            Description = "Napoleon Bonaparte vid sin sista erövring",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 65,
            PublicId = new Guid("736cb4cf-3667-4510-a41a-51b41a0c2594"),
            UserId = 11,
            PrimaryFileId = 103,
            Title = "Två hästar",
            Description = "Ett möte mellan två hästar som itne har setts på länge",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 66,
            PublicId = new Guid("3798154d-fc5c-4c17-89fd-3aa6852c3585"),
            UserId = 4,
            PrimaryFileId = 104,
            Title = "Bi",
            Description = "Enastående avbildande av ett bi, naturens egen Rolls Royce",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 67,
            PublicId = new Guid("132e391d-95d0-4f84-ac7a-86c734b5c8c0"),
            UserId = 2,
            PrimaryFileId = 105,
            Title = "Flyttfåglar",
            Description = "Två fåglar sittandes på en pinne målad med lite glitter",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 68,
            PublicId = new Guid("94951259-47e2-4253-9e25-323b43bee568"),
            UserId = 12,
            PrimaryFileId = 107,
            Title = "Kvinna från Falun",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 69,
            PublicId = new Guid("02de9e6a-7dcb-46df-aa15-fb7181dad5b2"),
            UserId = 9,
            PrimaryFileId = 109,
            Title = "Skriet",
            Description = "Min tolkning av Munchs Skriet",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 70,
            PublicId = new Guid("d5438e8e-1e93-407f-91f4-4ee47dc4b568"),
            UserId = 2,
            PrimaryFileId = 102,
            Title = "Kingfisher",
            Description = "Bästa fågeln hitills om jag får säga det själv",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 72,
            PublicId = new Guid("10279b02-b064-4693-92a5-39fa38bdafd7"),
            UserId = 9,
            PrimaryFileId = 108,
            Title = "Landet",
            Description = "Landskapsmålning av hus på landet med en krullig äng framför",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 73,
            PublicId = new Guid("1027050e-f713-4840-aab8-a47049501bf2"),
            UserId = 11,
            PrimaryFileId = 110,
            Title = "Fler hästar",
            Description = "Hästar och hundar slår följe i jakten på en nedgrävd boll",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 74,
            PublicId = new Guid("15294671-25ba-4e5c-89e6-2b7e4e7945da"),
            UserId = 11,
            PrimaryFileId = 112,
            Title = "Hund",
            Description = "Hund i akvarell",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 75,
            PublicId = new Guid("8b02305e-c04d-4ebe-87d5-dee748245610"),
            UserId = 5,
            PrimaryFileId = 113,
            SecondaryFileId = 53,
            Title = "Psychadelic art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 76,
            PublicId = new Guid("70937f41-fc80-48d6-8098-03c73193c2f0"),
            UserId = 5,
            PrimaryFileId = 116,
            Title = "Krullig höstskog",
            Description = "Skog i höstens färger målad på en specialbeställd kanvas med en speciell penselteknik",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 77,
            PublicId = new Guid("9387fb6e-6bf9-4752-80b1-0440ae0d0284"),
            UserId = 5,
            PrimaryFileId = 117,
            Title = "Gäss på ö",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 78,
            PublicId = new Guid("75405148-37cc-478a-b8c6-3d3c6ed206c1"),
            UserId = 5,
            PrimaryFileId = 114,
            Title = "Månbarn",
            Description = "Motiv förestället två barn som tävlar om att inte vara först med att blinka",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 79,
            PublicId = new Guid("08a31894-b3a1-48f5-86be-96ffea179874"),
            UserId = 5,
            PrimaryFileId = 118,
            SecondaryFileId = 36,
            Title = "Räv",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 80,
            PublicId = new Guid("b4763f66-3048-4970-a3b2-d6eaca243364"),
            UserId = 5,
            PrimaryFileId = 121,
            Title = "Varmt möter kallt",
            Description = "Ett hav av färger står mot varandra",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 81,
            PublicId = new Guid("156496a4-23e9-46a9-a776-bff397077d1f"),
            UserId = 5,
            PrimaryFileId = 128,
            Title = "Berglandskap",
            Description = "Föreställer ett landskap med stig som leder ner till sjö. I horisonten syns berg med vita toppar.",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 82,
            PublicId = new Guid("7a2e27ad-23c0-4673-a83d-3e4a954da9b4"),
            UserId = 5,
            PrimaryFileId = 129,
            Title = "Abstrakt konst",
            Description = "Ett färgglatt verk skapat på impuls",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 83,
            PublicId = new Guid("9dcb575d-8aaf-403c-8991-8fc3d9f7583f"),
            UserId = 4,
            PrimaryFileId = 130,
            Title = "Sol",
            Description = "En exakt avbildning av hur solen såg ut när denna målades sommaren 2020",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 84,
            PublicId = new Guid("f4f3791e-167c-4e71-9ec3-6fb7fe34d624"),
            UserId = 5,
            PrimaryFileId = 131,
            SecondaryFileId = 74,
            Title = "Stadskärna",
            Description = "Ståtliga hus som sträcker ut sig längs stadens kanal som ringlar genom stadskärnan",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 85,
            PublicId = new Guid("6c406dec-30c5-480c-a524-aef07c9140a9"),
            UserId = 8,
            PrimaryFileId = 134,
            Title = "Småbåtshamn",
            Description = "Föreställer småbåtshamnen i Veille Monte",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 86,
            PublicId = new Guid("9814a20b-b03c-42b1-b999-67f5c7919dfa"),
            UserId = 12,
            PrimaryFileId = 132,
            Title = "Tre blommor",
            Description = "Tre röda blommor",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 87,
            PublicId = new Guid("8d8392e7-2931-4a99-b62c-c52f5857e6ad"),
            UserId = 12,
            PrimaryFileId = 133,
            Title = "Bosättare",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 88,
            PublicId = new Guid("76f928eb-c594-4a4f-aefd-554eecc5c2f8"),
            UserId = 12,
            PrimaryFileId = 135,
            Title = "Björn",
            Description = "Björn gjord i mosaik",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 89,
            PublicId = new Guid("b0f2df3e-c36f-48c1-a29f-d092acb83bdb"),
            UserId = 4,
            PrimaryFileId = 137,
            Title = "Fjäril",
            Description = "Glad fjäril i fyra färger",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 90,
            PublicId = new Guid("a4a45e2e-5c0d-4e24-b19e-28447abcf8ee"),
            UserId = 12,
            PrimaryFileId = 138,
            Title = "Vis man",
            Description = "Inspiration hämtad från en av våra resor till Nordafrika",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 92,
            PublicId = new Guid("b6e26d30-2caa-4888-a827-3007f4be3902"),
            UserId = 12,
            PrimaryFileId = 148,
            Title = "Kvinnan på bussen",
            Description = "Avtecknad kvinna som åker buss fyra mot Vevaldsvik i blått och rosa",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 94,
            PublicId = new Guid("3288e991-288c-43bb-b683-524eecc0a77e"),
            UserId = 12,
            PrimaryFileId = 145,
            Title = "Blå barn",
            Description = "Blå barn med färgglada fåglar målad på en vägg",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 95,
            PublicId = new Guid("bc73bab2-0f30-486b-8b91-4a324798fa30"),
            UserId = 12,
            PrimaryFileId = 147,
            Title = "Olivträd",
            Description = "Olivträd avbildat i Greklands varma sommarhetta",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 97,
            PublicId = new Guid("3f372f89-30f6-4f23-b4bf-e00aef5cd2cf"),
            UserId = 12,
            PrimaryFileId = 152,
            Title = "Jakt",
            Published = DateTime.Now
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
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 100,
            PublicId = new Guid("e3edab83-8356-4102-8615-f567b38796fc"),
            UserId = 12,
            PrimaryFileId = 123,
            Title = "Snowy mountains",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 101,
            PublicId = new Guid("bd19f38b-d2c5-4e4c-90cf-36fffecccb43"),
            UserId = 12,
            PrimaryFileId = 106,
            Title = "Se upp!",
            Description = "Kille pekar på någoting intressant",
            Published = DateTime.Now
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
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 103,
            PublicId = new Guid("e4eb6096-4123-450f-8392-4f96abd64090"),
            UserId = 12,
            PrimaryFileId = 19,
            Title = "Vinterhöst",
            Description = "Träd med höstlöv som speglas i vattnet",
            Published = DateTime.Now
          },
        };
    }
  }
}
