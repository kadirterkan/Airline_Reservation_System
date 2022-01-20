CREATE TABLE Country(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Country_Name varchar(255) NOT NULL
);

CREATE TABLE Airport(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	IATA_CODE varchar(255) NOT NULL,
	Airport_Name varchar(255) NOT NULL,
	Airport_City varchar(255) NOT NULL,
	Country_Id bigint NOT NULL,
	FOREIGN KEY (Country_Id) REFERENCES Country(ID)
);

CREATE TABLE Aircraft(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Tail_Number varchar(255) NOT NULL,
	Aircraft_Manufacturer varchar(255) NOT NULL,
	Aircraft_Model varchar(255) NOT NULL,
	Date_Of_Manufacture datetime NOT NULL,
	Plane_Economy_Capacity int NOT NULL,
	Plane_Business_Capacity int NOT NULL
);

CREATE TABLE Flight(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Flight_Number varchar(255) NOT NULL,
	Flight_Time_By_Minutes int NOT NULL,
	Gate_No varchar(255) NOT NULL,
	Departure_Time datetime NOT NULL,
	Arrival_Time datetime NOT NULL,
	Aircraft_Id bigint NOT NULL,
	Departure_Airport_Id bigint NOT NULL,
	Arrival_Airport_Id bigint NOT NULL,
	FOREIGN KEY (Aircraft_Id) REFERENCES Aircraft(ID),
	FOREIGN KEY (Departure_Airport_Id) REFERENCES Airport(ID),
	FOREIGN KEY (Arrival_Airport_Id) REFERENCES Airport(ID)
);

CREATE TABLE Available_Routes(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Airport1 bigint NOT NULL,
	Airport2 bigint NOT NULL,
	FOREIGN KEY (Airport1) REFERENCES Airport (ID),
	FOREIGN KEY (Airport2) REFERENCES Airport (ID)
);

CREATE TABLE Passenger (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	First_Name varchar(255) NOT NULL,
	Last_Name varchar(255) NOT NULL,
	Gender varchar(255) NOT NULL,
	Age varchar(255) NOT NULL,
	Phone_Number varchar(255) NOT NULL,
	Adress varchar(255) NOT NULL
);

CREATE TABLE Ticket (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Passenger_Seat varchar(255) NOT NULL,
	Flight_Class varchar(255) NOT NULL,
	Flight_Id bigint,
	Passenger_Id bigint,
	FOREIGN KEY (Flight_Id) REFERENCES Flight(ID),
	FOREIGN KEY (Passenger_Id) REFERENCES Passenger(ID)
);

CREATE TABLE Authority (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	User_Type_Id bigint NOT NULL,
	Authority_Name varchar(255) NOT NULL,
	FOREIGN KEY (User_Type_Id) REFERENCES User_Type(ID)
);

CREATE TABLE User_Type(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Type_Name varchar(255) NOT NULL
);

CREATE TABLE Base_User (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	User_Name varchar(255) NOT NULL,
	Password varchar(255) NOT NULL,
	Email varchar(255) NOT NULL,
	User_Type_Id bigint NOT NULL,
	FOREIGN KEY (User_Type_Id) REFERENCES User_Type(ID)
);