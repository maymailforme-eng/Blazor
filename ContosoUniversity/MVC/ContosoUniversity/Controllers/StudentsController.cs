using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ContosoUniversityContext _context;

        public StudentsController(ContosoUniversityContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index
        (
            string sortOrder,
            string searchString,
            int? pageIndex,
            int itemsPerPage = 3
        )
        {
            // Размер страницы приходит из query string, поэтому разрешаем только значения из списка в интерфейсе.
            int[] allowedPageSizes = { 3, 5, 8 };
            if (!allowedPageSizes.Contains(itemsPerPage))
            {
                itemsPerPage = 3;
            }

            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["CurrentSort"] = sortOrder;
            //ASC  - Ascending (По возрастанию)
            //DESC - Descending (По убыванию)
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Student> students = from student in _context.Students select student;
            if (!(String.IsNullOrEmpty(searchString) && String.IsNullOrWhiteSpace(searchString)))
            {
                // Новый поиск начинается с первой страницы, так как форма не отправляет pageIndex.
                // Ссылки пагинации передают pageIndex вместе с фильтром, поэтому здесь его не сбрасываем.
                students = students.Where
                (
                    student =>
                    student.LastName.Contains(searchString) ||
                    student.FirstName.Contains(searchString)
                );
            }

            // Дополнительная сортировка по ID делает порядок стабильным для одинаковых фамилий и дат.
            switch (sortOrder)
            {
                case "name_desc": students = students.OrderByDescending(s => s.LastName).ThenBy(s => s.ID); break;
                case "date_desc": students = students.OrderByDescending(s => s.EnrollmentDate).ThenBy(s => s.ID); break;
                case "date_asc": students = students.OrderBy(s => s.EnrollmentDate).ThenBy(s => s.ID); break;
                default: students = students.OrderBy(s => s.LastName).ThenBy(s => s.ID); break;
            }

            ViewData["ItemsPerPage"] = itemsPerPage;
            int pageSize = itemsPerPage;
            return View
            (
                await PaginatedList<Student>.CreateAsync
                (
                    students.AsNoTracking(),
                    pageIndex ?? 1,
                    pageSize
                )
            );
            //return View(await students.ToListAsync());
            //return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
