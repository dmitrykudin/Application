package com.example.project.Models;

import java.sql.Time;
import java.text.DateFormat;
import java.util.Date;
import java.util.UUID;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class EventModel
{
    private UUID _id;
    public UUID getId() { return _id; }
    public void setId(UUID value)
    {
        if (value != null){
            _id = value;
        }
    }

    private String _place;
    public String getPlace() { return  _place; }
    public void setPlace(String value)
    {
        if (!value.isEmpty())
        {
            _place = value;
        }
    }

    private int _participantcount;
    public int getParticipantCount() { return _participantcount; }
    public void setParticipantCount(int value) { _participantcount = value; }

    private String _description;
    public String getDescription() { return  _description; }
    public void setDescription(String value) { _description = value; }

    private FileModel _photo;
    public FileModel getPhoto() { return _photo; }
    public void setPhoto(FileModel value) { _photo = value; }

    private DateFormat _dateAndTime;
    public DateFormat getDateAndTime(){ return _dateAndTime; }
    public void setDateAndTime(DateFormat value){
        if (value != null){
            _dateAndTime = value;
        }
    }

}