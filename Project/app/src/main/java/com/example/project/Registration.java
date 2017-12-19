package com.example.project;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

public class Registration extends AppCompatActivity implements View.OnClickListener {

    final Button breg = (Button) findViewById(R.id.registration);
    final RadioButton look = (RadioButton) findViewById(R.id.rbtn1);
    final RadioButton conc = (RadioButton) findViewById(R.id.rbtn2);
    TextView name, email, password;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        final EditText etName = (EditText) findViewById(R.id.name);
        final EditText etEmail = (EditText) findViewById(R.id.email);
        final EditText etPassword = (EditText) findViewById(R.id.password);



        /*String names = name.getText().toString();
        String mail = email.getText().toString();
        String pas = password.getText().toString();
*/
        //button.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.registration:


                //ЗАНОСИМ В БД

                Intent intent = new Intent(this, SignIn.class);
                startActivity(intent);
                break;
            default: break;
        }
    }


}
