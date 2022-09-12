using GerenciadorDeLivrosLidos.Data;
using GerenciadorDeLivrosLidos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeLivrosLidos.Controllers
{
    public class LivrosController : Controller
    {
        private readonly GerenciadorContext _context;

        public LivrosController(GerenciadorContext context, SeedingService seedService)
        {
            _context = context;
            seedService.Seed();
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            ViewBag.LivrosNaoLidos = _context.Livros.Include(x => x.Autor).Where(x => x.Lido == false).OrderBy(x => x.Autor.Nome).ToList();

            return View(_context.Livros.Include(x => x.Autor).Where(x => x.Lido == true).OrderBy(x => x.Autor.Nome).ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros.Include(x => x.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        public IActionResult Create()
        {
            var autores = _context.Autores.ToList();
            var selectList = new SelectList(autores, "Id", "Nome");

            ViewBag.Autores = selectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AutorId,Lido")] Livro livro)
        {
            livro.Autor = _context.Autores.Find(livro.AutorId);
            _context.Add(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros.FindAsync(id);

            var autores = _context.Autores.ToList();
            var selectList = new SelectList(autores, "Id", "Nome");

            ViewBag.Autores = selectList;

            if (livros == null)
            {
                return NotFound();
            }
            return View(livros);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AutorId,Lido")] Livro livro)
        {
            try
            {
                livro.Autor = _context.Autores.Find(livro.AutorId);
                _context.Update(livro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(livro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livros = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livros = await _context.Livros.FindAsync(id);
            _context.Livros.Remove(livros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
