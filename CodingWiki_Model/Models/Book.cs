using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    //Mỗi sách có một chi tiết(BookDetail).
    //Mỗi sách có một nhà xuất bản(Publisher).
    //Một sách có thể có nhiều tác giả thông qua bảng trung gian BookAuthorMap.
    public class Book
    {
        public int BookId { get; set; }// khóa chính
        public string Title { get; set; }
        [MaxLength(20)]
        [Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }// Thuộc tính không được ánh xạ vào database

        public BookDetail BookDetail { get; set; } // Liên kết 1-1 với `BookDetail`
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; } // Khóa ngoại đến `Publisher`
        public Publisher Publisher { get; set; } // Đối tượng nhà xuất bản

        public List<BookAuthorMap> BookAuthorMap{ get; set; } // Liên kết nhiều-nhiều với `Author`
    } 
}
