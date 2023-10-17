--Task-1: Create a Database

--CREATE DATABASE 5052_DB;
--USE 5052_DB;
--G0





--Creating Students Table
CREATE TABLE Students(
	StudentID int Primary key NOT NULL,
	FirstName VARCHAR(30),
	LastName VARCHAR(30),
	Age int,
	CourseID int
);

----Creating Courses Table
CREATE TABLE Courses(
	CourseID int Primary key,
	CourseName VARCHAR(40)
);

--CourseID in Students table is Foreign Key
ALTER TABLE Students
	ADD Foreign Key(CourseID) 
	REFERENCES Courses(CourseID)
	ON DELETE set NULL;




--inserting data into courses table
INSERT INTO Courses (CourseID,CourseName) values 
		(1, 'Biochemistry'),
		(2, 'Immunology & Allergy'),
		(3, 'Microbiology'),
		(4, 'Political Science'),
		(5, 'Punjabi');

SELECT *FROM Courses

--inserting data into Students table
INSERT INTO Students(StudentID,FirstName,LastName,Age,CourseID)
VALUES
	(1,'Stanley', 'Hudson',32,2),
	(2,'Angela', 'Martin',27,1),
	(3,'Kelly', 'Kapoor',18,5),
	(4,'Josh', 'Porter',42,4),
	(5,'Andy', 'Bernard',13,5),
	(6,'Jim', 'Halpert',52,3),
	(7,'Michael', 'Scott',39,5),
	(8,'Jan', 'Levinson',20,1),
	(9,'Zafar','Iqbal',8,4),
	(10,'Ayesha','Khan',62,5);

SELECT *FROM Students