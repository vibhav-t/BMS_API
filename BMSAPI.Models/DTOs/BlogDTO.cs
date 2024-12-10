﻿/*
 * DTO for the Blog post
 */
namespace BMSAPI.Models.DTOs
{
    public class BlogDTO
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public string Text { get; set; }

    }
}
