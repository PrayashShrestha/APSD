package edu.miu.cs.cs489appsd.lab1a.service;

import edu.miu.cs.cs489appsd.lab1a.model.Product;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class ProductService {
    // Implementation of Singleton
    private static ProductService instance;

    private ProductService() {} //private constructor

    public static ProductService getInstance() {
        if(instance == null) {
          synchronized (ProductService.class){
              if(instance == null) {
                  instance = new ProductService();
              }
          }
        }
        return instance;
    }

    public List<Product> getSampleProducts() {
        return Arrays.asList(
                new Product.ProductBuilder()
                        .productId(3128874119L)
                        .name("Banana")
                        .dateSupplied(java.time.LocalDate.parse("2023-01-24"))
                        .quantityInStock(124)
                        .unitPrice(0.55)
                        .build(),

                new Product.ProductBuilder()
                        .productId(2927458265L)
                        .name("Apple")
                        .dateSupplied(java.time.LocalDate.parse("2022-12-09"))
                        .quantityInStock(18)
                        .unitPrice(1.09)
                        .build(),

                new Product.ProductBuilder()
                        .productId(9189927460L)
                        .name("Carrot")
                        .dateSupplied(java.time.LocalDate.parse("2023-03-31"))
                        .quantityInStock(89)
                        .unitPrice(2.99)
                        .build()
        );
    }

    public List<Product> sortProductsByPriceDescending(List<Product> products) {
        products.sort(Comparator.comparing(Product::getUnitPrice).reversed());
        return products;
    }
}
