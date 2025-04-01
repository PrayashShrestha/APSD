package edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import edu.miu.cs.cs489appsd.lab1a.model.Product;
import edu.miu.cs.cs489appsd.lab1a.utils.exception.XMLException;

import java.util.List;

public class XMLFormatter implements FormatterStrategy{
    @Override
    public String format(List<Product> products) throws XMLException{
        try{
            XmlMapper xmlMapper = new XmlMapper();
            xmlMapper.registerModule(new JavaTimeModule());
            return xmlMapper.writerWithDefaultPrettyPrinter().writeValueAsString(products);
        }catch (JsonProcessingException exception){
            throw new XMLException(exception.getMessage());
        }
    }
}
