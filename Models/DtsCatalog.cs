using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dts_231220886_de02.Models;

[Table("Catalog")]
[Index(nameof(DtsId), IsUnique = true)]
public partial class DtsCatalog
{
    [Required(ErrorMessage = "Mã danh mục không được để trống")]
    public string DtsId { get; set; } = null!;

    [Required(ErrorMessage = "Tên danh mục không được để trống")]
    public string? DtsCateName { get; set; }

    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng 100 đến 5000")]
    public int? DtsCatePrice { get; set; }

    public int? DtsCateQty { get; set; }

    [Required(ErrorMessage = "Hình ảnh không được để trống")]
    [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
    public string? DtsCatePicture { get; set; }

    public bool? DtsCateActive { get; set; }
}
