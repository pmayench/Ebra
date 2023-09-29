﻿using Ebra.App.Models;
using System.Collections.Generic;

namespace Ebra.App.Repositories
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> GetAll();
        Offer GetById(int articleId);
        void Insert(Offer article);
        void Update(Offer article);
        void Delete(int articleId);
        void DeleteAll();
        void Save();
        void AddRange(List<Offer> range);
    }
}