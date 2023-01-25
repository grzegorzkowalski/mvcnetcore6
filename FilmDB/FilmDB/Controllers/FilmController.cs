﻿using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var filmManager = new FilmManager();
            // filmManager.AddFilm(film);

            //filmManager.RemoveFilm(3);

            var film = filmManager.GetFilm(2);
            var film2 = filmManager.GetFilm(7);
            filmManager.ChangeTitle(2, "   ");
            film.Year = 1999;
            filmManager.UpdateFilm(film);

            return View();
        }
    }
}
