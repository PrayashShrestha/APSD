package edu.miu.cs.cs489appsd.lab1a.model;

import java.time.LocalDate;

public class Product {
    private long productId;
    private String name;
    private LocalDate dateSupplied;
    private int quantityInStock;
    private double unitPrice;

    public Product(ProductBuilder productBuilder){
        this.productId = productBuilder.productId;
        this.name = productBuilder.name;
        this.dateSupplied = productBuilder.dateSupplied;
        this.quantityInStock = productBuilder.quantityInStock;
        this.unitPrice = productBuilder.unitPrice;
    }

    // Getters
    public long getProductId() { return productId; }
    public String getName() { return name; }
    public LocalDate getDateSupplied() { return dateSupplied; }
    public int getQuantityInStock() { return quantityInStock; }
    public double getUnitPrice() { return unitPrice; }

    // Using Builder Design Pattern
    public static class ProductBuilder{
        private long productId;
        private String name;
        private LocalDate dateSupplied;
        private int quantityInStock;
        private double unitPrice;

        public ProductBuilder productId(long productId){
            this.productId = productId;
            return this;
        }

        public ProductBuilder name(String name){
            this.name = name;
            return this;
        }

        public ProductBuilder dateSupplied(LocalDate dateSupplied){
            this.dateSupplied = dateSupplied;
            return this;
        }

        public ProductBuilder quantityInStock(int quantityInStock){
            this.quantityInStock = quantityInStock;
            return this;
        }

        public ProductBuilder unitPrice(double unitPrice){
            this.unitPrice = unitPrice;
            return this;
        }

        public Product build(){
            return new Product(this);
        }
    }

    @Override
    public String toString() {
        return String.format("Product{id=%d, name='%s', dateSupplied=%s, quantity=%d, price=%.2f}", productId, name, dateSupplied, quantityInStock, unitPrice);
    }
}
