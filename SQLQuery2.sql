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

set identity_insert Airport on;

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

set identity_insert Aircraft on;

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

set identity_insert Flight on;

CREATE TABLE Available_Routes(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	From_Airport_Id bigint NOT NULL,
	To_Airport_Id bigint NOT NULL,
	FOREIGN KEY (From_Airport_Id) REFERENCES Airport (ID),
	FOREIGN KEY (To_Airport_Id) REFERENCES Airport (ID)
);

set identity_insert Available_Routes on;

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

set identity_insert Passenger on;

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

set identity_insert Ticket on;

CREATE TABLE Authority (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Authority_Name varchar(255) NOT NULL
);

set identity_insert Authority on;

CREATE TABLE User_Type(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	Type_Name varchar(255) NOT NULL
);

set identity_insert User_Type on;

CREATE TABLE Base_User (
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	User_Name varchar(255) NOT NULL,
	Password varchar(255) NOT NULL,
	User_Type_Id bigint NOT NULL,
	FOREIGN KEY (User_Type_Id) REFERENCES User_Type(ID)
);

set identity_insert Base_User on;

CREATE TABLE User_Authorities(
	ID bigint IDENTITY(1,1) PRIMARY KEY,
	Creation_Date datetime,
	Update_Date datetime,
	User_Type_Id bigint NOT NULL,
	Authority_Id bigint NOT NULL,
	FOREIGN KEY (User_Type_Id) REFERENCES User_Type (ID),
	FOREIGN KEY (Authority_Id) REFERENCES Authority (ID)
);

set identity_insert User_Authorities on;

INSERT INTO Authority(ID, Creation_Date, Update_Date, Authority_Name)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ADD_FLIGHT');

INSERT INTO Authority(ID, Creation_Date, Update_Date, Authority_Name)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ADD_ROUTE');

INSERT INTO Authority(ID, Creation_Date, Update_Date, Authority_Name)
VALUES (3, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ADD_AIRPORT');

INSERT INTO Authority(ID, Creation_Date, Update_Date, Authority_Name)
VALUES (4, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ADD_COUNTRY');

INSERT INTO Authority(ID, Creation_Date, Update_Date, Authority_Name)
VALUES (5, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'BOOK');

INSERT INTO User_Type(ID, Creation_Date, Update_Date, Type_Name)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ADMINSTRATOR');

INSERT INTO User_Type(ID, Creation_Date, Update_Date, Type_Name)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'CUSTOMER');

INSERT INTO User_Authorities(ID, Creation_Date, Update_Date, User_Type_Id, Authority_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 1, 1);

INSERT INTO User_Authorities(ID, Creation_Date, Update_Date, User_Type_Id, Authority_Id)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 1, 2);

INSERT INTO User_Authorities(ID, Creation_Date, Update_Date, User_Type_Id, Authority_Id)
VALUES (3, '2022-01-16 00:00:00','2022-01-16 00:00:00', 1, 3);

INSERT INTO User_Authorities(ID, Creation_Date, Update_Date, User_Type_Id, Authority_Id)
VALUES (4, '2022-01-16 00:00:00','2022-01-16 00:00:00', 1, 4);

INSERT INTO User_Authorities(ID, Creation_Date, Update_Date, User_Type_Id, Authority_Id)
VALUES (5, '2022-01-16 00:00:00','2022-01-16 00:00:00', 2, 5);

INSERT INTO Base_User(ID, Creation_Date, Update_Date, User_Name, Password, User_Type_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'SUPER USER', 'Password?', 1);

INSERT INTO Base_User(ID, Creation_Date, Update_Date, User_Name, Password, User_Type_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'Customer', 'Password?', 2);



INSERT INTO Country (ID, Creation_Date, Update_Date, Country_Name)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00','Turkiye');

INSERT INTO Country (ID, Creation_Date, Update_Date, Country_Name)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00','Netherlands');

INSERT INTO Airport(ID, Creation_Date, Update_Date, IATA_CODE, Airport_Name, Airport_City, Country_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ISE', 'Isparta Süleyman Demirel Havalimanı', 'Isparta', 1)

INSERT INTO Airport(ID, Creation_Date, Update_Date, IATA_CODE, Airport_Name, Airport_City, Country_Id)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'ESB', 'Ankara Esenboğa Havalimanı', 'Ankara', 1)

INSERT INTO Airport(ID, Creation_Date, Update_Date, IATA_CODE, Airport_Name, Airport_City, Country_Id)
VALUES (3, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'AMS', 'Amsterdam Schiphol Havalimanı', 'Amsterdam', 2);

INSERT INTO Airport(ID, Creation_Date, Update_Date, IATA_CODE, Airport_Name, Airport_City, Country_Id)
VALUES (4, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'EIN', 'Eindhoven Havaalanı', 'Eindhoven', 2);

INSERT INTO Aircraft(ID, Creation_Date, Update_Date, Tail_Number, Aircraft_Manufacturer, Aircraft_Model, Date_Of_Manufacture, Plane_Economy_Capacity, Plane_Business_Capacity)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'F-GUGA', 'Airbus', 'A318', '2002-01-15 00:00:00', 92, 26);

INSERT INTO Available_Routes(ID, Creation_Date, Update_Date, From_Airport_Id, To_Airport_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 2, 3);

INSERT INTO Available_Routes(ID, Creation_Date, Update_Date, From_Airport_Id, To_Airport_Id)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 3, 2);

INSERT INTO Flight(ID, Creation_Date, Update_Date, Flight_Number, Flight_Time_By_Minutes, Gate_No, Departure_Time, Arrival_Time, Aircraft_Id, Departure_Airport_Id, Arrival_Airport_Id)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'BA1', 245, 'D-12', '2022-01-16 07:30:00', '2022-01-16 11:35:00', 1, 2, 3);

INSERT INTO Passenger(ID, Creation_Date, Update_Date, First_Name, Last_Name, Gender, Age, Phone_Number, Adress)
VALUES (1, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'John', 'Doe', 'MALE', 'ADULT', '012345678901', 'Europe');

INSERT INTO Passenger(ID, Creation_Date, Update_Date, First_Name, Last_Name, Gender, Age, Phone_Number, Adress)
VALUES (2, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'Gwen ', 'Sims', 'MALE', 'ADULT', '012345674901', 'TURKIYE');

INSERT INTO Passenger(ID, Creation_Date, Update_Date, First_Name, Last_Name, Gender, Age, Phone_Number, Adress)
VALUES (3, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'Amanda', 'Valdez', 'FEMALE', 'ADULT', '012345674901', 'Europe');

INSERT INTO Passenger(ID, Creation_Date, Update_Date, First_Name, Last_Name, Gender, Age, Phone_Number, Adress)
VALUES (4, '2022-01-16 00:00:00','2022-01-16 00:00:00', 'Herman', 'Montgomery', 'MALE', 'ADULT', '012385674901', 'Europe');

INSERT INTO Ticket(ID, Creation_Date, Update_Date, Passenger_Seat, Flight_Id, Passenger_Id, Flight_Class)
VALUES (1, '2022-01-16 00:00:00', '2022-01-16 00:00:00', '22A', 1, 1, 'ECONOMY');

INSERT INTO Ticket(ID, Creation_Date, Update_Date, Passenger_Seat, Flight_Id, Passenger_Id, Flight_Class)
VALUES (1, '2022-01-16 00:00:00', '2022-01-16 00:00:00', '2A', 1, 2, 'BUSINESS');

INSERT INTO Ticket(ID, Creation_Date, Update_Date, Passenger_Seat, Flight_Id, Passenger_Id, Flight_Class)
VALUES (1, '2022-01-16 00:00:00', '2022-01-16 00:00:00', '1A', 1, 3, 'BUSINESS');

INSERT INTO Ticket(ID, Creation_Date, Update_Date, Passenger_Seat, Flight_Id, Passenger_Id, Flight_Class)
VALUES (1, '2022-01-16 00:00:00', '2022-01-16 00:00:00', '1A', 1, 3, 'BUSINESS');