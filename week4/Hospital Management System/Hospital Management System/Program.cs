using Hospital_Management_System.Models;
using System.Numerics;

namespace Hospital_Management_System
{
    public class Program
    {
        //system storage ( actual storage in memory for all lists ) 
        public static HospitalContext context = new HospitalContext
        {
            patients = new List<Patient>(),
            doctors = new List<Doctor>(),
            appointments = new List<Appointment>(),
            medicalRecords = new List<MedicalRecord>(),
            availableSlots = new List<AvailableSlot>()
        };
        public static void RegisterPatient(HospitalContext context)
        {
            Console.WriteLine("\n*** Register New Patient ***");
            //----1Patient Registration-----
            Console.WriteLine("Enter Patient Name:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Enter Patient Age:");
            int patientAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Patient Email:");
            string patientEmail = Console.ReadLine();

            Console.WriteLine("Enter Patient Phone");
            string patientPhone = Console.ReadLine();

            Console.WriteLine("Enter Patient Gender (Male/Female):");
            string patientGender = Console.ReadLine();

            Console.WriteLine("Enter PatientBloodType");
            string patientBloodType = Console.ReadLine();

            int patientId = context.patients.Count + 1; //calculated


            //add patient


            context.patients.Add(new Patient
            {
                patientId = patientId,
                patientName = patientName,
                patientEmail = patientEmail,
                patientPhone = patientPhone,
                patientAge = patientAge,
                patientBloodType = patientBloodType,
                patientGender = patientGender

            }
            );
            //context.patients.Add(new Patient(patientId, patientName, patientAge, patientEmail, patientPhone, patientGender, patientBloodType));
            ////    );
            Console.WriteLine($"Patient Added Successfully with ID {patientId}");
        }


        //----2Add a New Doctor-----

        public static void AddDoctor(HospitalContext context)
        {

            Console.WriteLine("\n=== Add New Doctor ===");

            Console.WriteLine("Enter doctor name:");
            string doctorName = Console.ReadLine();

            Console.WriteLine("Enter doctor specialization:");
            string doctorSpecialization = Console.ReadLine();

            Console.WriteLine("Enter doctor Email:");
            string doctorEmail = Console.ReadLine();

            Console.WriteLine("Enter doctor Phone");
            string doctorPhone = Console.ReadLine();

            Console.WriteLine("Enter consultationFee");
            int consultationFee = int.Parse(Console.ReadLine());

            int DoctorId = context.doctors.Count + 1;
            //int DoctorId = context.doctors.Any()
            //   ? context.doctors.Count() + 1
            //   : 1;


            //Doctor doctor = new Doctor
            context.doctors.Add(new Doctor
            {


                doctorId = DoctorId,
                doctorName = doctorName,
                doctorSpecialization = doctorSpecialization,
                doctorEmail = doctorEmail,
                doctorPhone = doctorPhone,
                consultationFee = consultationFee

            });

            Console.WriteLine($"Doctor added successfully. Assigned ID: {DoctorId}");

        }



        //----3View All Patients---

        public static void ViewAllPatients(HospitalContext context)
        {
            Console.WriteLine("\n *** ALL Registered Patients ***");

            foreach (Patient p in context.patients)
            {
                Console.WriteLine($"ID: {p.patientId}  |  Name: {p.patientName}  |  Age: {p.patientAge}" +
                                  $"  |  Gender: {p.patientGender}  |  Blood Type: {p.patientBloodType}" +
                                  $"  |  Phone: {p.patientPhone}  |  Email: {p.patientEmail}");
            }
        }
        //if (context.patients.Count == 0)
        //    if (!context.patients.Any())
        //    {
        //        Console.WriteLine("No patients registered.");
        //        return;
        //    }
        //    



        //----4View All Doctors by Specialization----
        public static void ViewAllDoctorsBySpecialization(HospitalContext context)
        {
            Console.WriteLine("\n*** Search Doctor by Specialization ***");
            string specialization = Console.ReadLine();
            Console.WriteLine("Enter Specialization to search: ");
            string input = Console.ReadLine().ToLower();

            //LINQ:WHERE() to filter by specialization

            List<Doctor> doctors = context.doctors.Where(d => d.doctorSpecialization == specialization).ToList();


            foreach (Doctor d in doctors)
            {
                Console.WriteLine($"ID: {d.doctorId}  |  Name: {d.doctorName}" +
                                  $"  |  Phone: {d.doctorPhone}  |  Fee: {d.consultationFee:C}");
            }
        }



        //bool found = false;

        //foreach (Doctor doctor in doctors)
        //{
        //if (doctor.doctorSpecialization== specialization)
        //{
        //    found = true;

        //        Console.WriteLine($"ID: {doctor.doctorId}");
        //        Console.WriteLine($"Name: {doctor.doctorName}");
        //        Console.WriteLine($"Specialization: {doctor.doctorSpecialization}");
        //        Console.WriteLine($"Email: {doctor.doctorEmail}");
        //        Console.WriteLine($"Phone: {doctor.doctorPhone}");
        //        Console.WriteLine($"Consultation Fee: {doctor.consultationFee}");

        //    }
        //}

        //    if (!found)
        //    {
        //        Console.WriteLine("No doctors found with this specialization.");
        //    }
        //}



        //----5Add an Available Time Slot for a Doctor----


        public static void AddAvailableSlot(HospitalContext context)
        {

            Console.WriteLine("\n *** Add Available Slot for Doctor ***");
            foreach (Doctor d in context.doctors)
            {
                Console.WriteLine($"  ID: {d.doctorId}  |  {d.doctorName}  ({d.doctorSpecialization})");
            }


            //if (context.doctors.Count==0)
            //{
            //    Console.WriteLine("No doctor in this system yet");
            //    return;
            //}

            //Console.WriteLine("Available doctor:");

            //LINQ: ForEach to print all doctors


            //context.doctors.ForEach(d =>
            //Console.WriteLine($" ID: {d.doctorId} | {d.doctorName} ({d.doctorSpecialization})"));

            Console.WriteLine("Enter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            //bool found = false;

            //foreach (Doctor d in context.doctors)
            //{
            //    if (d.doctorId == doctorId)
            //    {
            //        found = true;
            //        break;
            //    }
            //}
            bool found = context.doctors.Any(d => d.doctorId == doctorId);

            if (!found)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine("Enter slot date: ");
            string slotDate = Console.ReadLine();

            Console.WriteLine("Enter slot time: ");
            string slotTime = Console.ReadLine();

            int slotId = context.availableSlots.Count + 1;

            context.availableSlots.Add(new AvailableSlot

            //AvailableSlot slot = new AvailableSlot
            {
                slotId = slotId,
                doctorId = doctorId,
                slotDate = slotDate,
                slotTime = slotTime,
                isBooked = false
            });

            //context.availableSlots.Add(slot);

            Console.WriteLine($"Slot added successfully with slotId: {slotId}");
        }



        //--6Book an Appointment----
        public static void BookAppointment(HospitalContext context)
        {
            Console.WriteLine("\n===Book an Appintment");

            Console.WriteLine("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());


            //LINQ: FirstOrDefault() to find patient by ID

            //Patient patient = context.patients
            //    .FirstOrDefault(p => p.patientId == patientId);


            //if (patient == null)
            //{
            //    Console.WriteLine("Patient not found.");
            //    return;
            //}

            Console.WriteLine("Enter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            List<AvailableSlot> openSlots = context.availableSlots
               .Where(s => s.doctorId == doctorId && s.isBooked == false)
               .ToList();

            Console.WriteLine($"\nAvailable slots :");
            foreach (AvailableSlot s in openSlots)
            {
                Console.WriteLine($"  Slot ID: {s.slotId}  |  Date: {s.slotDate}  |  Time: {s.slotTime}");
            }

            Console.Write("Enter slot ID to book: ");
            int slotId = int.Parse(Console.ReadLine());

            AvailableSlot selectedSlot = openSlots.FirstOrDefault(s => s.slotId == slotId);

            int appointmentId = context.appointments.Count + 1;

            context.appointments.Add(new Appointment
            {
                appointmentId = appointmentId, //genretaed
                patientId = patientId,         // user input his number
                doctorId = doctorId,           // user input from list viewed
                slotId = slotId,               // user input from list viewed
                appointmentDate = selectedSlot.slotDate, // system calcuated 
                appointmentTime = selectedSlot.slotTime,  // system calcuated 
                status = "Scheduled"              // default value
            });

            selectedSlot.isBooked = true;

            Console.WriteLine($"Appointment booked successfully! Appointment ID: {appointmentId}" +
                              $" | Date: {selectedSlot.slotDate} | Time: {selectedSlot.slotTime}");
        }

        //LINQ: FirstOrDefault() to find doctor by ID

        //Doctor doctor = context.doctors
        //    .FirstOrDefault(d => d.doctorId == doctorId);

        //if (doctor == null)
        //{
        //    Console.WriteLine("Doctor not found.");
        //    return;
        //}

        //List<AvailableSlot> availableSlots = new List<AvailableSlot>();

        //foreach (AvailableSlot slot in context.availableSlots)
        //{
        //    if (slot.doctorId == doctorId && slot.isBooked == false)
        //    {
        //        availableSlots.Add(slot);
        //    }
        //}

        //LINO :where() to filter unbooked slots for this doctor
        //    List<AvailableSlot> availableSlots = context.availableSlots .Where(slot => slot.doctorId == doctorId && !slot.isBooked).ToList();
        //    //if (availableSlots.Count == 0)
        //    if (!availableSlots.Any())
        //    {
        //        Console.WriteLine("No available slots.");
        //        return;
        //    }

        //    Console.WriteLine("Available Slots:");

        //    foreach (AvailableSlot slot in availableSlots)
        //    {
        //        Console.WriteLine(
        //            $"Slot ID: {slot.slotId}, Date: {slot.slotDate}, Time: {slot.slotTime}");
        //    }

        //    Console.WriteLine("Enter Slot ID: ");
        //    int slotId = int.Parse(Console.ReadLine());

        //    AvailableSlot selectedSlot = availableSlots
        //        .FirstOrDefault(s => s.slotId == slotId);

        //    if (selectedSlot == null)
        //    {
        //        Console.WriteLine("Invalid Slot ID.");
        //        return;
        //    }
        //    Appointment appointment = new Appointment();

        //    appointment.appointmentId = context.appointments.Count + 1;

        //    appointment.patientId = patientId;
        //    appointment.doctorId = doctorId;
        //    appointment.appointmentDate = selectedSlot.slotDate;
        //    appointment.appointmentTime = selectedSlot.slotTime;
        //    appointment.status = "Booked";

        //    context.appointments.Add(appointment);

        //    selectedSlot.isBooked = true;

        //    Console.WriteLine("Appointment booked successfully.");
        //    Console.WriteLine($"Appointment ID: {appointment.appointmentId}");
        //}





        //------7Cancel an Appointment-----------
        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("\n ===== Cancel Appointment======");

            Console.Write("Enter Appointment ID: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Appointment appointment = context.appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId);

            AvailableSlot slot = context.availableSlots
                               .FirstOrDefault(s => s.slotId == appointment.slotId);

            slot.isBooked = false;

            appointment.status = "Cancelled";

            Console.WriteLine($"Appointment {appointmentId} has been cancelled and the time slot is now available again.");
        }



        //    if (appointment == null)
        //    {
        //        Console.WriteLine("Appointment not found.");
        //        return;
        //    }

        //    if (appointment.status == "Cancelled")
        //    {
        //        Console.WriteLine("Appointment is already cancelled.");
        //        return;
        //    }

        //    appointment.status = "Cancelled";

        //    AvailableSlot slot = context.availableSlots
        //        .FirstOrDefault(s =>
        //            s.doctorId == appointment.doctorId &&
        //            s.slotDate == appointment.appointmentDate &&
        //            s.slotTime == appointment.appointmentTime);

        //    if (slot == null)
        //    {
        //        Console.WriteLine("Slot not found.");
        //    }
        //    else
        //    {
        //        slot.isBooked = false;
        //    }


        //    Console.WriteLine("Appointment cancelled successfully.");
        //}



        ////----8Create a Medical Record After a Visit-----
        public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.Write("Enter Appointment ID: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Appointment appointment = context.appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId);

            //if (appointment == null)
            //{
            //    Console.WriteLine("Appointment not found.");
            //    return;
            //}

            Console.WriteLine("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.WriteLine("Enter Prescription: ");
            string prescription = Console.ReadLine();

            Doctor doctor = context.doctors
                .FirstOrDefault(d => d.doctorId == appointment.doctorId);

            MedicalRecord record = new MedicalRecord();

            record.recordId = context.medicalRecords.Count + 1;
            record.patientId = appointment.patientId;
            record.doctorId = appointment.doctorId;
            record.appointmentId = appointment.appointmentId;
            record.diagnosis = diagnosis;
            record.prescription = prescription;
            record.visitDate = appointment.appointmentDate;
            record.visitFee = doctor.consultationFee;

            context.medicalRecords.Add(record);

            appointment.status = "Completed";

            Console.WriteLine("Medical record created successfully.");
        }




        //9---Generate a Patient Medical History Report---

        public static void GeneratePatientMedicalHistory(HospitalContext context)
        {
            Console.WriteLine("\n=== Patient Medical History Report ===");

            Console.WriteLine("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            List<MedicalRecord> records = context.medicalRecords
                .Where(r => r.patientId == patientId)
                .ToList();

            Console.WriteLine($"\n--- Medical History for (ID: {patientId}) ---");

            foreach (MedicalRecord r in records)
            {
                Console.WriteLine($"\n  Record ID   : {r.recordId}");
                Console.WriteLine($"  Visit Date  : {r.visitDate}");
                Console.WriteLine($"  Doctor      : {r.doctorId}");
                Console.WriteLine($"  Diagnosis   : {r.diagnosis}");
                Console.WriteLine($"  Prescription: {r.prescription}");
                Console.WriteLine($"  Fee Charged : {r.visitFee:C}");
            }

            decimal totalCharged = records.Sum(r => r.visitFee);
            Console.WriteLine($"\n  TOTAL AMOUNT CHARGED: {totalCharged:C}");
        }


        //    Patient patient = context.patients
        //        .FirstOrDefault(p => p.patientId == patientId);

        //    if (patient == null)
        //    {
        //        Console.WriteLine("Patient not found.");
        //        return;
        //    }

        //    var records = context.medicalRecords
        //.Where(r => r.patientId == patientId)
        //.ToList();

        //    if (!records.Any())
        //    {
        //        Console.WriteLine("No medical records found.");
        //        return;
        //    }

        //    //List<MedicalRecord> records = new List<MedicalRecord>();

        //    //foreach (MedicalRecord record in context.medicalRecords)
        //    //{
        //    //    if (record.patientId == patientId)
        //    //    {
        //    //        records.Add(record);
        //    //    }
        //    //}

        //    //if (records.Count == 0)
        //    //{
        //    //    Console.WriteLine("No medical records found.");
        //    //    return;
        //    //}

        //    decimal totalFees = 0;

        //    Console.WriteLine($"Medical History for {patient.patientName}");

        //    foreach (MedicalRecord record in records)
        //    {
        //        Doctor doctor = context.doctors
        //            .FirstOrDefault(d => d.doctorId == record.doctorId);
        //        Console.WriteLine($"Visit Date: {record.visitDate}");
        //        Console.WriteLine($"Doctor: {doctor.doctorName}");
        //        Console.WriteLine($"Diagnosis: {record.diagnosis}");
        //        Console.WriteLine($"Prescription: {record.prescription}");

        //        totalFees += record.visitFee;
        //    }

        //    Console.WriteLine($"Total Charges: {totalFees}");
        //}





        //10----Doctor Workload and Revenue Summary-----
        public static void DoctorWorkloadAndRevenueSummary(HospitalContext context)
        {



            if (!context.appointments.Any())
            {

                //    if (context.appointments.Count == 0)
                //    {
                Console.WriteLine("No appointments recorded.");
                return;
            }



            var summary = context.doctors
        .Select(doctor => new
        {
            DoctorName = doctor.doctorName,

            CompletedCount = context.appointments
                .Count(a => a.doctorId == doctor.doctorId &&
                            a.status == "Completed"),

            CancelledCount = context.appointments
                .Count(a => a.doctorId == doctor.doctorId &&
                            a.status == "Cancelled"),

            Revenue = context.medicalRecords
                .Where(r => r.doctorId == doctor.doctorId)
                .Sum(r => r.visitFee)
        })
        .OrderByDescending(d => d.Revenue);

            foreach (var doctor in summary)
            {

                Console.WriteLine($"Doctor Name: {doctor.DoctorName}");
                Console.WriteLine($"Completed Appointments: {doctor.CompletedCount}");
                Console.WriteLine($"Cancelled Appointments: {doctor.CancelledCount}");
                Console.WriteLine($"Total Revenue: {doctor.Revenue}");



                //foreach (Doctor doctor in context.doctors)
                //{
                //    int completedCount = 0;
                //    int cancelledCount = 0;
                //    decimal revenue = 0;

                //    foreach (Appointment appointment in context.appointments)
                //    {
                //        if (appointment.doctorId == doctor.doctorId)
                //        {
                //            if (appointment.status == "Completed")
                //            {
                //                completedCount++;
                //            }
                //            else if (appointment.status == "Cancelled")
                //            {
                //                cancelledCount++;
                //            }
                //        }
                //    }

                //    foreach (MedicalRecord record in context.medicalRecords)
                //    {
                //        if (record.doctorId == doctor.doctorId)
                //        {
                //            revenue += record.visitFee;
                //        }
                //    }

                //Console.WriteLine($"Doctor Name: {doctor.DoctorName}");
                //Console.WriteLine($"Completed Appointments: {CompletedCount}");
                //Console.WriteLine($"Cancelled Appointments: {cancelledCount}");
                //Console.WriteLine($"Total Revenue: {revenue}");
            }
        }






        // MAIN — Menu Loop

        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your name");
            //string name = Console.ReadLine();

            ////object initializer
            //Patient p2 = new Patient {patientId =2, patientName=name  };

            bool exit = false;
            while (exit == false)
            {
                //let the system begin 
                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("Welcome to the Hospital Management System!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1- RegisterPatient ");
                Console.WriteLine("2- AddDoctor");
                Console.WriteLine("3- ViewAllPatients");
                Console.WriteLine("4- ViewAllDoctorsBySpecialization");
                Console.WriteLine("5- AddAvailableSlot");
                Console.WriteLine("6- BookAppointment");
                Console.WriteLine("7- CancelAppointment");
                Console.WriteLine("8- CreateMedicalRecord");
                Console.WriteLine("9 -GeneratePatientMedicalHistory ");
                Console.WriteLine("10- DoctorWorkloadAndRevenueSummary");
                Console.WriteLine("0- Exit");
                Console.WriteLine("-----------------------------");

                Console.WriteLine("Please select an option:");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        // code for RegisterPatient
                        RegisterPatient(context);
                        break;

                    case 2:
                        // code for add Doctor
                        AddDoctor(context);
                        break;

                    case 3:
                        // code for ViewAllPatients
                        ViewAllPatients(context);
                        break;

                    case 4:
                        // code for ViewAllDoctorsBySpecialization
                        ViewAllDoctorsBySpecialization(context);
                        break;

                    case 5:
                        // code for AddAvailableSlot
                        AddAvailableSlot(context);
                        break;

                    case 6:
                        // code for BookAppointment
                        BookAppointment(context);
                        break;

                    case 7:
                        // code for view reviews
                        CancelAppointment(context);
                        break;

                    case 8:
                        //code for CreateMedicalRecord
                        CreateMedicalRecord(context);
                        break;

                    case 9:
                        //code for GeneratePatientMedicalHistory 
                        GeneratePatientMedicalHistory(context);
                        break;

                    case 10:
                        //code for DoctorWorkloadAndRevenueSummary
                        DoctorWorkloadAndRevenueSummary(context);
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }

                if (!exit)
                {

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();// to wait for user input before clearing the console
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");


        }


    }
}
