using SaraTort.BLL.DTOs.Order;
using SaraTort.Domain.Entities.Catalog;
using System.Collections.Generic;

namespace SaraTort.Admin.Models
{
    public class DashboardViewModel
    {
        public decimal BugungiTushum { get; set; }
        public int BugungiBuyurtmalarSoni { get; set; }
        public int FaolMijozlarSoni { get; set; }
        public int KatalogdagiTortlarSoni { get; set; }
        public List<Cake> TortlarRoyxati { get; set; } = new();
        public List<OrderForResultDto> OxirgiBuyurtmalar { get; set; } = new();
    }
}