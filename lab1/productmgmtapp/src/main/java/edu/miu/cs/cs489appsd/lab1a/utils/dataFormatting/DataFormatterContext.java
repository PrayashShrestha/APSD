package edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting;

import edu.miu.cs.cs489appsd.lab1a.model.Product;

import java.util.List;

public class DataFormatterContext {
    private FormatterStrategy strategy;

    public void setFormatterStrategy(FormatterStrategy strategy) {
        this.strategy = strategy;
    }

    public String formatData(List<Product> products) throws Exception{
        if(strategy == null){
            throw new IllegalAccessException("No formatting strategy set");
        }
        return strategy.format(products);
    }
}
