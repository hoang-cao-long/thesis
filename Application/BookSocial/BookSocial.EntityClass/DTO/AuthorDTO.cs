﻿namespace BookSocial.EntityClass.DTO
{
    public class AuthorStatistic
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public int NumberOfBooks { get; set; }
    }

    public class AuthorListByBookId
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorDescription { get; set; }
        public DateTime? AuthorBirthday { get; set; }
    }
}
