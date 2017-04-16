using System;

public class Patient {

    public int patientId               { get; set; }
    public int patientAge              { get; set; }
    public String patientGender        { get; set; }
    public String patientDisease       { get; set; }

    public Patient(int patientId, int patientAge, String patientGender, String patientDisease) {
        this.patientId      = patientId;
        this.patientAge     = patientAge;
        this.patientGender  = patientGender;
        this.patientDisease = patientDisease;
    }

}