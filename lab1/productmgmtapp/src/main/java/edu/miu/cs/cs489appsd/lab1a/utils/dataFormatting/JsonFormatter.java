package edu.miu.cs.cs489appsd.lab1a.utils.dataFormatting;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import edu.miu.cs.cs489appsd.lab1a.model.Product;
import edu.miu.cs.cs489appsd.lab1a.utils.exception.JsonException;

import java.util.List;

public class JsonFormatter implements FormatterStrategy{
    @Override
    public String format(List<Product> products) throws JsonException {
        try{
            ObjectMapper objectMapper = new ObjectMapper();
            objectMapper.registerModule(new JavaTimeModule());
            return objectMapper.writerWithDefaultPrettyPrinter().writeValueAsString(products);
        }catch (JsonProcessingException exception){
            throw new JsonException(exception.getMessage());
        }
    }
}
