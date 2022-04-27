﻿using BookSocial.EntityClass.DTO;
using BookSocial.EntityClass.Entity;

namespace BookSocial.Service.ServiceInterface
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewStatistic>> GetReviewStatistic();
        Task<IEnumerable<Review>> GetByBookId(int bookId);
        Task<IEnumerable<Review>> GetByUserId(int userId);
        Task<Review> GetById(int articleId);
        Task<int> Delete(int articleId);
    }
}