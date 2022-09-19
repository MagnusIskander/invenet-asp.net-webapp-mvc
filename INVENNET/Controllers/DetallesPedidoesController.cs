using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INVENNET.Models;

namespace INVENNET.Controllers
{
    public class DetallesPedidoesController : Controller
    {
        private readonly INVENETContext _context;

        public DetallesPedidoesController(INVENETContext context)
        {
            _context = context;
        }

        // GET: DetallesPedidoes
        public async Task<IActionResult> Index()
        {
            var iNVENETContext = _context.DetallesPedidos.Include(d => d.IdPedidoNavigation).Include(d => d.IdProductoNavigation);
            return View(await iNVENETContext.ToListAsync());
        }

        // GET: DetallesPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesPedidos == null)
            {
                return NotFound();
            }

            var detallesPedido = await _context.DetallesPedidos
                .Include(d => d.IdPedidoNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallesPedido == null)
            {
                return NotFound();
            }

            return View(detallesPedido);
        }

        // GET: DetallesPedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: DetallesPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,Subtotal,Fecha,IdProducto,IdPedido")] DetallesPedido detallesPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedido.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", detallesPedido.IdProducto);
            return View(detallesPedido);
        }

        // GET: DetallesPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesPedidos == null)
            {
                return NotFound();
            }

            var detallesPedido = await _context.DetallesPedidos.FindAsync(id);
            if (detallesPedido == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedido.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", detallesPedido.IdProducto);
            return View(detallesPedido);
        }

        // POST: DetallesPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,Subtotal,Fecha,IdProducto,IdPedido")] DetallesPedido detallesPedido)
        {
            if (id != detallesPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesPedidoExists(detallesPedido.Id))
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
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", detallesPedido.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", detallesPedido.IdProducto);
            return View(detallesPedido);
        }

        // GET: DetallesPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesPedidos == null)
            {
                return NotFound();
            }

            var detallesPedido = await _context.DetallesPedidos
                .Include(d => d.IdPedidoNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallesPedido == null)
            {
                return NotFound();
            }

            return View(detallesPedido);
        }

        // POST: DetallesPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesPedidos == null)
            {
                return Problem("Entity set 'INVENETContext.DetallesPedidos'  is null.");
            }
            var detallesPedido = await _context.DetallesPedidos.FindAsync(id);
            if (detallesPedido != null)
            {
                _context.DetallesPedidos.Remove(detallesPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesPedidoExists(int id)
        {
          return _context.DetallesPedidos.Any(e => e.Id == id);
        }
    }
}
