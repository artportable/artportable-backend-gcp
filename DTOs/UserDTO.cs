﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
    public class UserDTO
    {
        [Required, StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        [Required, StringLength(254), EmailAddress]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public DateTime Created { get; set; }

        public string CustomerId { get; set; }

        public DateTime? EmailInformedFollowersDate { get; set; }

        public bool EmailDeclinedArtworkUpload { get; set; }

        public bool MonthlyUser { get; set; }

        public int ProductId { get; set; }

        public string PhoneNumber { get; set; }

        public int Artworks { get; set; }
    }
}
