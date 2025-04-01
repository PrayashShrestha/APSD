package edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting;

import edu.miu.cs.cs489appsd.lab1a.model.Product;

import java.util.List;
import java.util.stream.Collectors;

public class CSVFormatter implements FormatterStrategy{
    @Override
    public String format(List<Product> products){
        return "ProductId,Name,DateSupplied,QuantityInStock,UnitPrice\n" +
                products.stream()
                        .map(p -> String.format(
                                "%d, %s, %s,  %d,  %.2f",
                                p.getProductId(), p.getName(), p.getDateSupplied(), p.getQuantityInStock(), p.getUnitPrice()))
                        .collect(Collectors.joining("\n")
                        );
    }

}
