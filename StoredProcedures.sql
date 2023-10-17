
---------------------Stored Procedure for adding------------------------------------------------------------------------

--Adding in Students Table
CREATE PROCEDURE StudentAdd
    @StudentID INT,
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
    @Age INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Students(StudentID, FirstName, LastName, Age, CourseID)
    VALUES (@StudentID, @FirstName, @LastName,@Age,@CourseID);
END;
GO

--Adding in Courses Table
CREATE PROCEDURE CourseAdd
    @CourseID INT,
	@CourseName VARCHAR(50)
AS
BEGIN
    INSERT INTO Courses(CourseID,CourseName)
    VALUES (@CourseID,@CourseName);
END;
GO



---------------------------------Stored Procedure For Updating-----------------------------------------------------------

--Updating a Student Age
CREATE PROCEDURE UpdateStudent
    @StudentID INT,
	@FirstName VARCHAR(40),
	@LastName VARCHAR(40),
    @Age INT,
	@CourseID INT
AS
BEGIN
    UPDATE Students
    SET FirstName = @FirstName,
		LastName = @LastName,
		Age=@Age,
		CourseID=@CourseID		
    WHERE StudentID = @StudentID;
END;  
GO

--Updating a Course Name
CREATE PROCEDURE UpdateCourse
    @CourseID INT,
    @CourseName VARCHAR(50)
AS
BEGIN
    UPDATE Courses
    SET CourseName = @CourseName
    WHERE CourseID = @CourseID;
END;
GO


-----------------------------Stored Procedure for Deleting--------------------

--Deleting one entry from students
CREATE PROCEDURE DeleteStudent
	@StudentID int
AS
BEGIN
	DELETE 
	FROM Students
	WHERE StudentID=@StudentID;
END;
GO

--Deleting a course
CREATE PROCEDURE DeleteCourse
	@CourseID int
AS
BEGIN
	DELETE 
	FROM Courses
	WHERE CourseID=@CourseID;
END;
GO


------------------------------Stored Procedure for retrieving data from both tables--------

--Retrieving All Data from students Table
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT * FROM Students;
END;
GO

--Retrieving All Data from Courses Table
CREATE PROCEDURE GetAllCourses
AS
BEGIN
    SELECT * FROM Courses;
END;
GO




----------1.Create an API method to list all students older than 20.
CREATE PROCEDURE studentsOlderthan20
AS
BEGIN
	SELECT *FROM Students
	WHERE Age>20
END;
GO


----------2.Create an API method to list all students enrolled in a specific course.
CREATE PROCEDURE specificCourse
AS
BEGIN
	SELECT FirstName,LastName,CourseID
	FROM Students
	WHERE courseID IN (SELECT CourseID FROM Courses WHERE CourseName='Immunology & Allergy')
END;
GO



---------------3.Create an API method to find the most popular course.
CREATE PROCEDURE mostPopularCourse
AS
BEGIN
	SELECT *FROM Courses
	WHERE CourseID = (
	SELECT CourseID FROM Students
	GROUP BY CourseID
	ORDER BY COUNT(CourseID) DESC
	OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY
	)
END;
GO

EXEC mostPopularCourse