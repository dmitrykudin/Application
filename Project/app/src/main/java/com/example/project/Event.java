package com.example.project;

import java.sql.Time;
import java.util.Date;
import java.util.UUID;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class Event
{
    private UUID _id;
    public UUID getId() { return _id; }
    public void setId() { _id.randomUUID(); }

    private Date _date;
    public Date getDate() { return _date; }
    public void setDate(Date value)
    {
        if (!value.equals(null))
        {
            _date = value;
        }
    }

    private Time _time;
    public Time getTime() { return _time; }
    public void setTime(Time value)
    {
        if (!value.equals(null))
        {
            _time = value;
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

    private CreativeTeam _creativeTeam;
    public CreativeTeam getCreativeTeam() { return _creativeTeam; }
    public void setCreativeTeam(CreativeTeam value)
    {
        if (!value.equals(null))
        {
            _creativeTeam = value;
        }
    }

    private int _participantcount;
    public int getParticipantCount() { return _participantcount; }
    public void setParticipantCount(int value) { _participantcount = value; }

    private String _description;
    public String getDescription() { return  _description; }
    public void setDescription(String value) { _description = value; }

    private File _photo;
    public File getPhoto() { return _photo; }
    public void setPhoto(File value) { _photo = value; }

}