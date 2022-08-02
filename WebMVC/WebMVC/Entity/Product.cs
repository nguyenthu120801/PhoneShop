﻿namespace WebMVC.Entity
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public bool isSell { get; set; }
    }
}
