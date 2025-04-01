package edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting;

import edu.miu.cs.cs489appsd.lab1a.model.Product;

import java.util.List;

public interface FormatterStrategy {
    String format(List<Product> products) throws Exception;
}
