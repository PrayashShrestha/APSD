package edu.miu.cs.cs489appsd.lab1a;

import edu.miu.cs.cs489appsd.lab1a.model.Product;
import edu.miu.cs.cs489appsd.lab1a.service.ProductService;
import edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting.CSVFormatter;
import edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting.DataFormatterContext;
import edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting.JsonFormatter;
import edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting.XMLFormatter;

import java.util.List;

public class App
{
    public static void main( String[] args )
    {
        try{
            // Get Singleton instance of ProductService
            ProductService productService = ProductService.getInstance();

            List<Product> products = productService.getSampleProducts();
            products = productService.sortProductsByPriceDescending(products);

            // Creating Data Formatter Context
            DataFormatterContext formatterContext = new DataFormatterContext();

            // JSON Output
            formatterContext.setFormatterStrategy(new JsonFormatter());
            System.out.println("JSON Format");
            System.out.println(formatterContext.formatData(products));
            System.out.println("=============================================");

            // XML Output
            formatterContext.setFormatterStrategy(new XMLFormatter());
            System.out.println("XML Format");
            System.out.println(formatterContext.formatData(products));
            System.out.println("=============================================");

            // CSV Formatter
            formatterContext.setFormatterStrategy(new CSVFormatter());
            System.out.println("CSV Format");
            System.out.println(formatterContext.formatData(products));
        }catch (Exception e) {
            System.err.println("Error: " + e.getMessage());
        }
    }
}
