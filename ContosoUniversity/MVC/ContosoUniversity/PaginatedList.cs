using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
{
    public class PaginatedList<T>:List<T>   
    {
        public int PageIndex { get; set; }
        public int TotalPages {  get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling((double)count/pageSize);
            this.AddRange(items);
        }


        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;


        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,
                                                                int pageIndex,
                                                                int pageSize
                                                                )
        {
            //int count = await source.CountAsync();
            //List<T> items = await source.Skip((pageIndex - 1) * pageSize)
            //                            .Take(pageSize)
            //                            .ToListAsync();

            //return new PaginatedList<T>(items, count, pageIndex, pageSize);

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    "Размер страницы должен быть больше нуля.");
            }

            int count = await source.CountAsync();

            int totalPages = (int)Math.Ceiling(count / (double)pageSize);

            // Нижняя граница — первая страница.
            pageIndex = Math.Max(pageIndex, 1);

            // Если номер слишком большой, показываем последнюю страницу.
            if (totalPages > 0)
            {
                pageIndex = Math.Min(pageIndex, totalPages);
            }

            List<T> items = await source
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex,pageSize);
        }

    }
}
