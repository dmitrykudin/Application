package com.example.project.Models;

import java.util.UUID;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class UserModel {
    private UUID _id;
    public UUID getId() { return _id; }
    public void setId(UUID value)
    {
        if (value != null){
            _id = value;
        }
    }

    private String _name;
    public String getName() { return  _name; }
    public void setName(String value)
    {
        if (!value.isEmpty())
        {
            _name = value;
        }
    }

    private String _surname;
    public String getSurname() { return  _surname; }
    public void setSurname(String value) { _surname = value; }

    private String _email;
    public String getEmail() { return _email; }
    public void setEmail(String value)
    {
        if (!value.isEmpty())
        {
            _email = value;
        }
    }

    private String _password;
    public String getPassword() { return _password; }
    public void setPassword(String value)
    {
        if (!value.isEmpty())
        {
            _password = value;
        }
    }

    private String _city;
    public String getCity() { return  _city; }
    public void setCity(String value) { _city = value; }

    private FileModel _photo;
    public FileModel getPhoto() { return _photo; }
    public void setPhoto(FileModel value) { _photo = value; }

    private int _age;
    public int getAge() { return _age; }
    public void setAge(int value) { _age = value; }

}

