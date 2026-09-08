using Question2;

HealthSystemApp app = new HealthSystemApp();

app.SeedData();

app.BuildPrescriptionMap();

app.PrintAllPatients();

app.PrintPrescriptionsForPatient(1);
app.PrintPrescriptionsForPatient(2);
app.PrintPrescriptionsForPatient(3);
