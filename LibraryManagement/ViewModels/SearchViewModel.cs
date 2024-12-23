using LibraryManagement.Models;

namespace LibraryManagement.ViewModels
{
    public class SearchViewModel
    {
        public string Keyword { get; set; } // Từ khóa tìm kiếm
        public List<Books> Books { get; set; } // Kết quả tìm kiếm sách
        public List<Authors> Authors { get; set; } // Kết quả tìm kiếm tác giả
        public List<Categories> Categories { get; set; } // Kết quả tìm kiếm thể loại
    }
}
