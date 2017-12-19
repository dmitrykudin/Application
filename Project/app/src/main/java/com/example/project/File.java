package com.example.project;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class File
{
    private String _path;
    public String getPath() { return _path; }
    public void setPath(String value)
    {
        if (!value.isEmpty())
        {
            _path = value;
        }
    }

    private User _owner;
    public User getOwner() { return _owner; }
    public void setOwner(User value)
    {
        if (!value.equals(null))
        {
            _owner = value;
        }
    }

    private String _fileextension;
    public String getFileExtension() { return _fileextension; }
}