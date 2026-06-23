using Hospital_Management_System.Models;
using System.Numerics;

namespace Hospital_Management_System
{
    public class Program
    {


        public static void RegisterPatient(HospitalContext context)
        {
            //----1Patient Registration-----
            Console.WriteLine("Enter Patient Name:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Enter Patient Age:");
            int patientAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Patient Email:");
            string patientEmail = Console.ReadLine();

            Console.WriteLine("Enter Patient Phone");
            string patientPhone = Console.ReadLine();

            Console.WriteLine("Enter Patient Gender");
            string patientGender = Console.ReadLine();

            Console.WriteLine("Enter PatientBloodType");
            string patientBloodType = Console.ReadLine();

            int patientId = (context.patients.Count) + 1; //calculated

            
            //add patient

            context.patients.Add(
                 new Patient
                 {
                     patientId = patientId,
                     patientName = patientName,
                     patientEmail = patientEmail,
                     patientPhone = patientPhone,
                     patientAge = patientAge,
                     patientBloodType = patientBloodType,
                     patientGender= patientBloodType

                 }

                );

            Console.WriteLine("Patient Added Successfully with ID " + patientId);
        }



        //----2Add a New Doctor-----

        public static void AddDoctor(HospitalContext context)
        {
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

            int DoctorId = (context.doctors.Count) + 1;

            Doctor doctor = new Doctor
            {
                doctorId = DoctorId,
                doctorName = doctorName,
                doctorSpecialization = doctorSpecialization,
                doctorEmail = doctorEmail,
                doctorPhone = doctorPhone,
                consultationFee = consultationFee
            };

            context.doctors.Add(doctor);

            Console.WriteLine("Doctor Added Successfully");
            Console.WriteLine($"Assigned Doctor ID: {doctor.doctorId}");
        }



        //----3View All Patients---

        public static void ViewAllPatients(HospitalContext context)
        {
            if (context.patients.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            foreach (Patient patient in context.patients)
            {
                Console.WriteLine($"ID: {patient.patientId}");
                Console.WriteLine($"Name: {patient.patientName}");
                Console.WriteLine($"Age: {patient.patientAge}");
                Console.WriteLine($"Gender: {patient.patientGender}");
                Console.WriteLine($"Phone: {patient.patientPhone}");
                Console.WriteLine($"Email: {patient.patientEmail}");
                Console.WriteLine($"blood:{patient.patientBloodType}");
            }
        }




        //----4View All Doctors by Specialization----
        public static void ViewAllDoctorsBySpecialization(HospitalContext context)
        {
            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine();

            bool found = false;

            foreach (Doctor doctor in context.doctors)
            {
                if (doctor.doctorSpecialization== specialization)
                {
                    found = true;

                    Console.WriteLine($"ID: {doctor.doctorId}");
                    Console.WriteLine($"Name: {doctor.doctorName}");
                    Console.WriteLine($"Specialization: {doctor.doctorSpecialization}");
                    Console.WriteLine($"Email: {doctor.doctorEmail}");
                    Console.WriteLine($"Phone: {doctor.doctorPhone}");
                    Console.WriteLine($"Consultation Fee: {doctor.consultationFee}");
                    
                }
            }

            if (!found)
            {
                Console.WriteLine("No doctors found with this specialization.");
            }
        }



        //----5Add an Available Time Slot for a Doctor----

        
        public static void AddAvailableSlot(HospitalContext context)
        {
            Console.Write("Enter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            bool found = false;

            foreach (Doctor d in context.doctors)
            {
                if (d.doctorId == doctorId)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.Write("Enter Date: ");
            string slotDate = Console.ReadLine();

            Console.Write("Enter Time: ");
            string slotTime = Console.ReadLine();

            int slotId = context.availableSlots.Count + 1;

            AvailableSlot slot = new AvailableSlot
            {
                slotId = slotId,
                doctorId = doctorId,
                slotDate = slotDate,
                slotTime = slotTime,
                isBooked = false
            };

            context.availableSlots.Add(slot);

            Console.WriteLine("Available slot added successfully.");
        }



        //--6Book an Appointment----
        public static void BookAppointment(HospitalContext context)
        {
            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            Patient patient = context.patients
                .FirstOrDefault(p => p.patientId == patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Enter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Doctor doctor = context.doctors
                .FirstOrDefault(d => d.doctorId == doctorId);

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            List<AvailableSlot> availableSlots = new List<AvailableSlot>();

            foreach (AvailableSlot slot in context.availableSlots)
            {
                if (slot.doctorId == doctorId && slot.isBooked == false)
                {
                    availableSlots.Add(slot);
                }
            }

            Console.WriteLine("Available Slots:");

            foreach (AvailableSlot slot in availableSlots)
            {
                Console.WriteLine(
                    $"Slot ID: {slot.slotId}, Date: {slot.slotDate}, Time: {slot.slotTime}");
            }

            Console.Write("Enter Slot ID: ");
            int slotId = int.Parse(Console.ReadLine());

            AvailableSlot selectedSlot = availableSlots
                .FirstOrDefault(s => s.slotId == slotId);

            if (selectedSlot == null)
            {
                Console.WriteLine("Invalid Slot ID.");
                return;
            }
            Appointment appointment = new Appointment();

            appointment.appointmentId = context.appointments.Count + 1;

            appointment.patientId = patientId;
            appointment.doctorId = doctorId;
            appointment.appointmentDate = selectedSlot.slotDate;
            appointment.appointmentTime = selectedSlot.slotTime;
            appointment.status = "Booked";

            context.appointments.Add(appointment);

            selectedSlot.isBooked = true;

            Console.WriteLine("Appointment booked successfully.");
            Console.WriteLine($"Appointment ID: {appointment.appointmentId}");
        }





        //------7Cancel an Appointment-----------
        public static void CancelAppointment(HospitalContext context)
        {
            Console.Write("Enter Appointment ID: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Appointment appointment = context.appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            if (appointment.status == "Cancelled")
            {
                Console.WriteLine("Appointment is already cancelled.");
                return;
            }

            appointment.status = "Cancelled";

            AvailableSlot slot = context.availableSlots
                .FirstOrDefault(s =>
                    s.doctorId == appointment.doctorId &&
                    s.slotDate == appointment.appointmentDate &&
                    s.slotTime == appointment.appointmentTime);

            if (slot == null)
            {
                Console.WriteLine("Slot not found.");
            }
            else
            {
                slot.isBooked = false;
            }

            
            Console.WriteLine("Appointment cancelled successfully.");
        }





        //----8Create a Medical Record After a Visit-----
        public static void CreateMedicalRecord(HospitalContext context)
        {
            Console.Write("Enter Appointment ID: ");
            int appointmentId = int.Parse(Console.ReadLine());

            Appointment appointment = context.appointments
                .FirstOrDefault(a => a.appointmentId == appointmentId);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter Prescription: ");
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

        

        //10----Doctor Workload and Revenue Summary-----
       




        static void Main(string[] args)
        {
            //data storage for the system ( in memory )
            HospitalContext context = new HospitalContext();

            context.patients = new List<Patient>();
            context.doctors = new List<Doctor>();
            context.appointments = new List<Appointment>();
            context.medicalRecords = new List<MedicalRecord>();
            context.availableSlots = new List<AvailableSlot>();



            bool exit = false;
                while (exit == false)
                {
                    //let the system begin 
                    Console.WriteLine("Welcome to the Hospital Management System!");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("1- RegisterPatient ");
                    Console.WriteLine("2- AddDoctor");
                    Console.WriteLine("3- ViewAllPatients");
                    Console.WriteLine("4- ViewAllDoctorsBySpecialization");
                    Console.WriteLine("5- AddAvailableSlot");
                    Console.WriteLine("6- BookAppointment");
                    Console.WriteLine("7- CancelAppointment");
                   Console.WriteLine("8- CreateMedicalRecord");
                    Console.WriteLine("0- Exit");
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

                    

                    case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;

                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();// to wait for user input before clearing the console
                    Console.Clear();
                }
            }
            

        }


        }
    
    