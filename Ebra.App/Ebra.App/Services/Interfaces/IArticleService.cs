﻿using Ebra.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.App.Services.Interfaces
{
    public interface IArticleService
    {
        //obtener versión listas de hoy
        Task<string> GetVersionAsync(Type type);

        string GetVersion(Type type);

        //obtener articulos
        Task<List<Article>> GetArticlesAsync();

        List<Article> GetArticles();
    }

}