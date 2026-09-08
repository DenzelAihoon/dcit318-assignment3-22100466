namespace Question2;

public class HealthSystemApp
{
    private readonly Repository<Patient> patientRepository = new();
    private readonly Repository<Prescription> prescriptionRepository = new();

    private readonly Dictionary<int, List<Prescription>> prescriptionMap = new();

    public void SeedData()
    {
        patientRepository.Add(
            new Patient(1, "Alice Smith", 25, "Female")
        );

        patientRepository.Add(
            new Patient(2, "John Mensah", 32, "Male")
        );

        patientRepository.Add(
            new Patient(3, "Michael Brown", 45, "Male")
        );

        prescriptionRepository.Add(
            new Prescription(
                1,
                1,
                "Paracetamol",
                DateTime.Now.AddDays(-5)
            )
        );

        prescriptionRepository.Add(
            new Prescription(
                2,
                1,
                "Amoxicillin",
                DateTime.Now.AddDays(-3)
            )
        );

        prescriptionRepository.Add(
            new Prescription(
                3,
                2,
                "Ibuprofen",
                DateTime.Now.AddDays(-2)
            )
        );

        prescriptionRepository.Add(
            new Prescription(
                4,
                3,
                "Vitamin C",
                DateTime.Now
            )
        );
    }

    public void BuildPrescriptionMap()
    {
        foreach (Prescription prescription in prescriptionRepository.GetAll())
        {
            if (!prescriptionMap.ContainsKey(prescription.PatientId))
            {
                prescriptionMap[prescription.PatientId] = new List<Prescription>();
            }

            prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (prescriptionMap.ContainsKey(patientId))
        {
            return prescriptionMap[patientId];
        }

        return new List<Prescription>();
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("=== ALL PATIENTS ===");

        foreach (Patient patient in patientRepository.GetAll())
        {
            Console.WriteLine(
                $"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}"
            );
        }
    }

    public void PrintPrescriptionsForPatient(int patientId)
    {
        Patient? patient = patientRepository.GetById(
            p => p.Id == patientId
        );

        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine(
            $"=== PRESCRIPTIONS FOR {patient.Name} ==="
        );

        List<Prescription> prescriptions =
            GetPrescriptionsByPatientId(patientId);

        foreach (Prescription prescription in prescriptions)
        {
            Console.WriteLine(
                $"Medication: {prescription.MedicationName}, " +
                $"Date Issued: {prescription.DateIssued:d}"
            );
        }
    }
}
