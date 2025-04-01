package edu.miu.cs.cs489appsd.lab1a.utils.exception;

public class JsonException extends Exception{
    public JsonException(String message) {
        super(message);
    }

    public JsonException(String message, Throwable cause) {super(message, cause);}
}
