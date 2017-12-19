package com.example.project;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;

public class User extends AppCompatActivity implements View.OnClickListener{

    /*FloatingActionButton btn = (FloatingActionButton) findViewById(R.id.add);
    Button ev = (Button) findViewById(R.id.event);
    Button ne = (Button) findViewById(R.id.near);
    Button like = (Button) findViewById(R.id.favourite);
    Button prof = (Button) findViewById(R.id.profile);*/

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

       /* ev.setOnClickListener(this);
        ne.setOnClickListener(this);
        like.setOnClickListener(this);
        prof.setOnClickListener(this);
        btn.setOnClickListener(this);*/
    }

    @Override
    public void onClick(View v) {
        /*switch (v.getId()) {

            case R.id.near:
                btn.setVisibility(View.GONE);
                //
                break;
            case R.id.event:
                //

                break;
            case R.id.favourite:
                btn.setVisibility(View.GONE);
                //
                break;
            case R.id.profile:
                btn.setVisibility(View.GONE);
                //
                break;
            case R.id.add:
                //
                Intent intent = new Intent(this, Create.class);
                startActivity(intent);
                break;

            default: break;
        }*/
    }

}
