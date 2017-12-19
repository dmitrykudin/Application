package com.example.project.Models;

import com.example.project.User;

import java.util.UUID;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class FileModel
{
    private UUID _id;
    public UUID getId() { return _id; }
    public void setId(UUID value)
    {
        if (value != null){
            _id = value;
        }
    }

    private byte[] _bytes;
    public byte[] getBytes() { return _bytes; }
    public void setBytes(byte[] value)
    {
        if (value != null)
        {
            _bytes = value;
        }
    }

    private String _fileextension;
    public String getFileExtension() { return _fileextension; }
    public void setFileExtension(String value){
        if (!value.isEmpty()){
            _fileextension = value;
        }
    }

    private String _filename;
    public String getFileName() { return _filename; }
    public void setFileName(String value){
        if (!value.isEmpty()){
            _filename = value;
        }
    }
}