# Assignment3
1.	Objective
The objective of this assignment is to allow students to become familiar with the client-server architectural style and the Observer design pattern.

2.	Application Description
Use Java/C# API to design and implement a client-server application for managing the consultations of doctors in a clinic. The application has three types of users: the clinic secretary, the doctors and an administrator.
The clinic secretary can perform the following operations:
-	Add/update patients (patient information: name, identity card number, personal numerical code, date of birth, address).
-	CRUD on patients’ consultations (e.g. scheduling a consultation, assigning a doctor to a patient based on the doctor’s availability).
The doctors can perform the following operations:
-	Add/view the details of a patient’s (past) consultation.
The administrator can perform the following operations:
-	CRUD on user accounts.
In addition, when a patient having a consultation has arrived at the clinic and checked in at the secretary desk, the application should inform the associated doctor by displaying a message.

3.	Application Constraints

•	The application should be client-server and the data will be stored in a database. Use the Observer design pattern for notifying the doctors when their patients have arrived.

•	All the inputs of the application will be validated against invalid data before submitting the data and saving it.   
