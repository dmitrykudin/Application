package leti.application.Models;

import java.util.UUID;

/**
 * Created by Дмитрий on 22.10.2017.
 */

public class CreativeTeam
{
    private UUID _id;
    public UUID getId() { return _id; }
    public void setId() { _id.randomUUID(); }

    private String _name;
    public String getName() { return  _name; }
    public void setName(String value)
    {
        if (!value.isEmpty())
        {
            _name = value;
        }
    }

    private File _photo;
    public File getPhoto() { return _photo; }
    public void setPhoto(File value) { _photo = value; }

    private String _genre;
    public String getGenre() { return _genre; }
    public void setGenre(String value) { _genre = value; }

    private String _about;
    public String getAbout() { return _about; }
    public void setAbout(String value) { _about = value; }

    private int _subscriberscount;
    public int getSubscriberscount() { return _subscriberscount; }
    public void setSubscriberscount(int value) { _subscriberscount = value; }

    private double _rating;
    public double getRating() { return _rating; }
    public void setRating(double value) { _rating = value; }

}
