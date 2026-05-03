using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400030.Models;

[ApiController]
[Route("api/[controller]")]
public class FilmController : ControllerBase
{
	public static List<Film> listFilm = new List<Film>
	{
        new Film {Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0"},
        new Film {Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi",Rating = "8.7"},
        new Film {Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6"}
    };

	[HttpGet]
	public ActionResult<List<Film>> Get()
	{
		return listFilm;
	}

	[HttpGet("{i}")]
	public ActionResult<Film> GetByIndex(int i)
	{
		if (i < 0 || i >= listFilm.Count)
			return NotFound();

		return listFilm[i];
	}

    [HttpPost]
    public ActionResult<Film> AddFilm([FromBody] Film film)
    {
        listFilm.Add(film);
		return Ok(film);
    }

	[HttpDelete("{i}")]
	public ActionResult DeleteFilm(int i)
    {
        if (i < 0 || i >= listFilm.Count)
            return NotFound();

		listFilm.RemoveAt(i);
        return Ok();
    }

    public FilmController()
	{
	}
}
