package com.example.chadpc.hw3;

import android.nfc.Tag;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    public EditText name;
    String nameVal;
    public EditText city;
    String cityVal;
    public EditText state;
    String stateVal;
    public EditText zip;
    String zipVal;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button = (Button)findViewById(R.id.SubmitButton);

        button.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {

        String TAG = "";

        name = (EditText)findViewById(R.id.NameField);
        nameVal = name.getText().toString();
        Log.d(TAG, nameVal);

        city = (EditText)findViewById(R.id.CityField);
        cityVal = city.getText().toString();
        Log.d(TAG, cityVal);

        state = (EditText)findViewById(R.id.StateField);
        stateVal = state.getText().toString();
        Log.d(TAG, stateVal);

        zip = (EditText)findViewById(R.id.ZipField);
        zipVal = zip.getText().toString();
        Log.d(TAG, zipVal);

        Toast toast = Toast.makeText(this, "Data has been submitted to Log", Toast.LENGTH_SHORT);
        toast.show();

    }
}
