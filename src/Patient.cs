using System;

public class Patient {

    private int patientId               { get; set; }
    private int patientAge              { get; set; }
    private String patientGender        { get; set; }
    private String patientDisease       { get; set; }

    public Patient(int patientId, int patientAge, String patientGender, String patientDisease) {
        this.patientId      = patientId;
        this.patientAge     = patientAge;
        this.patientGender  = patientGender;
        this.patientDisease = patientDisease;
    }

}