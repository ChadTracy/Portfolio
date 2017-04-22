--Chad Tracy
--CIS 310
--Assignment 12
--Due: 4/23/2016


--Time Dimension table
CREATE TABLE DimTime(
TimeID int not null identity(1,1) ,
Char_Date datetime,
Day int,
Month int,
Year int
);
--time primary key
ALTER TABLE DimTime
ADD CONSTRAINT PK_DimTime PRIMARY KEY (TimeID)

--Pilot dimension table
CREATE TABLE DimPilot(
PilotID int not null identity(1,1),
Emp_Num int,
Emp_Fname varchar(15),
Emp_Lname varchar(15)
);
--pilot primary key
ALTER TABLE DimPilot
ADD CONSTRAINT PK_DimPilot PRIMARY KEY (PilotID)

--facts table
CREATE TABLE Facts(
TimeID int not null,
PilotID int not null,
ModelID int not null,
Revenue decimal (10,2),
Distance decimal (10,2),
Fuel_Used decimal (10,2));
--primary keys
ALTER TABLE Facts
ADD CONSTRAINT PK_Facts PRIMARY KEY(TimeID, PilotID, ModelID)
--foreign keys
ALTER TABLE Facts
ADD CONSTRAINT FK_Facts
FOREIGN KEY (TimeID)
REFERENCES DimTime(TimeID)
ALTER TABLE Facts
ADD CONSTRAINT FKP_Facts
FOREIGN KEY (PilotID)
REFERENCES DimPilot(PilotID)
ALTER TABLE Facts
ADD CONSTRAINT FKM_Facts
FOREIGN KEY (ModelID)
REFERENCES DimModel(ModelID)

--Model dimension table
CREATE TABLE DimModel(
ModelID int not null identity(1,1),
Model_Code varchar(10),
Model_Name varchar(20),
MOD_CHG_MILE int );
--model primary key
ALTER TABLE DimModel
ADD CONSTRAINT PK_DimModel PRIMARY KEY (ModelID)


--begin stored procedure for populating database
go
CREATE PROCEDURE A_12
AS BEGIN
--Population for Time Dimension Table
INSERT INTO DimTime(Char_Date,Day, Month, Year)
Select Distinct Char_Date, DATEPART(Day, Char_Date) as Day, DATEPART(Month, Char_Date) as Month, DATEPART(Year, CHAR_DATE) as Year
FROM CHARTER;
--Population for Pilot Dimension Table
INSERT INTO DimPilot(Emp_Num, Emp_Fname, Emp_Lname)
select p.EMP_NUM, EMP_FNAME, Emp_Lname
from  pilot p inner join EMPLOYEE e on p.Emp_Num=e.Emp_Num
--Population for Model Dimension Table
INSERT INTO DimModel(Model_Code, Model_Name, MOD_CHG_MILE)
select MOD_CODE, MOD_NAME, MOD_CHG_MILE
from Model;
--Population for Facts Dimension Table
INSERT INTO Facts 
Select TimeID, PilotID, ModelID,Revenue, CHAR_DISTANCE,CHAR_FUEL_GALLONS
from
(select CHAR_TRIP, TIMEID, CHAR_FUEL_GALLONS
from CHARTER c inner join DimTime t on c.CHAR_DATE=t.Char_Date) a
inner join
(select Char_Trip,ModelID, PilotID, Char_Distance, MOD_CHG_MILE, (MOD_CHG_MILE*Char_Distance) as Revenue
from
(select a.CHAR_TRIP, PilotID, MOD_CODE, CHAR_DISTANCE
from
(select CHAR_TRIP, PilotID 
from CHARTER c inner join DimPilot p on c.CHAR_PILOT=p.Emp_Num) a
inner join
(Select CHAR_Trip, Mod_Code, MOD_CHG_MILE, CHAR_DISTANCE
from
(select AC_Number, m.MOD_CODE, MOD_CHG_MILE
from AIRCRAFT a inner join MODEL m on a.MOD_CODE=m.MOD_CODE) a
inner join
(select CHAR_TRIP, a.AC_Number, CHAR_DISTANCE
from Aircraft a inner join Charter c on a.AC_NUMBER=c.AC_NUMBER) b
on a.AC_NUMBER=b.AC_NUMBER) b on a.CHAR_TRIP=b.CHAR_TRIP) a
inner join DimModel m on a.MOD_CODE=m.Model_Code) b
on a.CHAR_TRIP=b.CHAR_TRIP;
end 

--end