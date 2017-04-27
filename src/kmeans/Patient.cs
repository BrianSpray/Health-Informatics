using System;

namespace kmeans
{
    public class Patient
    {

        public int patientId { get; set; }
        public int patientAge { get; set; }
        public String patientGender { get; set; }
        public String patientDisease { get; set; }

        public Patient(int patientId, int patientAge, String patientGender, String patientDisease)
        {
            this.patientId = patientId;
            this.patientAge = patientAge;
            this.patientGender = patientGender;
            this.patientDisease = patientDisease;
        }

        public int PatientGenderToInteger(String patientGender)
        {
            if (patientGender.Equals("Male"))
            {
                return 0;
            }
            else if (patientGender.Equals("Female"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}