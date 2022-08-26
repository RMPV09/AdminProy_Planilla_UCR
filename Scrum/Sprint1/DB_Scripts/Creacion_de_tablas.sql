use [PatatasConSueno]


Create Table Person(
Email varchar(255) NOT NULL primary key,
Name varchar(255) NOT NULL,
LastName1 varchar(255),
LastName2 varchar(255),
SSN int NOT NULL,
BankAccount varchar(255) NOT NULL,
Adress varchar(255),
PhoneNumber varchar(255)
);

CREATE TABLE Account
(
	Email varchar(255) NOT NULL PRIMARY KEY,
	UserPassword VARBINARY(500) NOT NULL,
	[IsAuthenticated] BIT NOT NULL, 
    FOREIGN KEY(Email) REFERENCES Person(Email),
);

CREATE TABLE Employer(
	Email varchar(255) NOT NULL PRIMARY KEY,
	FOREIGN KEY(Email) REFERENCES Person(Email)
);

CREATE TABLE Employee(
	Email varchar(255) NOT NULL PRIMARY KEY,
	FOREIGN KEY(Email) REFERENCES Person(Email)
);

CREATE TABLE Project(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	ProjectDescription varchar(255),
	MaximumAmountForBenefits int, 
	MaximumBenefitAmount int,
	PaymentInterval varchar(255),
	PRIMARY KEY(EmployerEmail, ProjectName),
	FOREIGN KEY(EmployerEmail) REFERENCES Employer(Email)
);

CREATE TABLE AgreementType(
	TypeAgreement varchar(255) NOT NULL,
	MountPerHour int NOT NULL,
	PRIMARY KEY(TypeAgreement, MountPerHour)
);

CREATE TABLE Subscription
(
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	SubscriptionName varchar(255) NOT NULL,
	ProviderName varchar(255),
	SubscriptionDescription varchar(255),
	Cost int NOT NULL,
	TypeSubscription int NOT NULL,
	IsEnabled int NOT NULL,
	PRIMARY KEY(EmployerEmail, ProjectName, SubscriptionName),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName)
);

CREATE TABLE Agreement(
	EmployeeEmail varchar(255) NOT NULL,
	EmployerEmail varchar(255) NOT NULL,
	ProjectName varchar(255) NOT NULL,
	ContractDate date NOT NULL,
	ContractType varchar(255) NOT NULL,
	MountPerHour int NOT NULL,
	Duration date NOT NULL,
	PRIMARY KEY(EmployeeEmail,EmployerEmail,ProjectName,ContractDate),
	FOREIGN KEY(EmployeeEmail) REFERENCES Employee(Email),
	FOREIGN KEY(EmployerEmail, ProjectName) REFERENCES Project(EmployerEmail, ProjectName),
	FOREIGN KEY(ContractType, MountPerHour) REFERENCES AgreementType(TypeAgreement, MountPerHour)
);