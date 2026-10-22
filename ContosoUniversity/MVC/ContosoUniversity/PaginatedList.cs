using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            //count - общее количество элементов
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling((double)count / pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync
        (
            IQueryable<T> source,
            int pageIndex,
            int pageSize
        )
        {
            // Параметры приходят из URL, поэтому исправляем их, а не прерываем запрос исключением.
            pageSize = pageSize > 0 ? pageSize : 3;
            pageIndex = Math.Max(pageIndex, 1);

            int count = await source.CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            // Защищаем запрос от отрицательного OFFSET и перехода на несуществующую страницу.
            int normalizedPageIndex = totalPages == 0
                ? 1
                : Math.Clamp(pageIndex, 1, totalPages);

            List<T> items = await source.Skip((normalizedPageIndex - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return new PaginatedList<T>(items, count, normalizedPageIndex, pageSize);
        }
    }
}
