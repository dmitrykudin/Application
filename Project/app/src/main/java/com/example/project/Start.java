package com.example.project;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class Start extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_start);
        TextView tv = (TextView) findViewById(R.id.textView);
        tv.setEnabled(true);
        try{Thread.sleep(3000);} catch (Exception e) {return;}
        setContentView(R.layout.activity_sign_in);
    }
}
