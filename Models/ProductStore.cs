using wt_lab6_6minimalapi_alasevic.Models;

namespace wt_lab6_6minimalapi_alasevic.Data;

public static class ProductStore
{

    public static List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Ноутбук Lenovo IdeaPad 5", Category = "Компьютеры",  Price = 74999m, IsAvailable = true  },
        new Product { Id = 2, Name = "Смартфон Samsung S24",      Category = "Смартфоны",   Price = 89999m, IsAvailable = true  },
        new Product { Id = 3, Name = "Мышь Logitech MX Master",   Category = "Аксессуары",  Price = 9990m,  IsAvailable = true  },
        new Product { Id = 4, Name = "Клавиатура Keychron K2",    Category = "Аксессуары",  Price = 12990m, IsAvailable = false },
        new Product { Id = 5, Name = "Монитор Dell 27\"",          Category = "Мониторы",    Price = 24990m, IsAvailable = true  }
    };
}