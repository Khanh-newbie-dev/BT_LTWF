using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework_Core
{
    public class Product
    {
        public int Id { get; set; } // Khóa chính (Primary Key, Identity tự tăng)
        public required string Name { get; set; } // Bắt buộc (NOT NULL)
        public decimal Price { get; set; } // Kiểu tiền tệ chuẩn xác (SQL: decimal(18,2))
        public int Quantity { get; set; } // Số lượng tồn kho
    }
}
