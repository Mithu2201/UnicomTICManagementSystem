using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Repository
{
    internal class Migration
    {

        public static void CreateTables()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Roles (
                        RoleId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleCode TEXT NOT NULL,
                        RoleName TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS Users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        UserPass TEXT NOT NULL,
                        UserRole TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS Courses (
                        CouId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CouCode TEXT NOT NULL,
                        CouName TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS AddStatus (
                        StatusId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StatusName TEXT NOT NULL
                          
                    );

                        CREATE TABLE IF NOT EXISTS AddClasses (
                        ClId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClName TEXT NOT NULL,
                        ClMode TEXT NOT NULL
                        
                        
                    );

                        CREATE TABLE IF NOT EXISTS AddExams (
                        ExId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExName TEXT NOT NULL,
                        ExType TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS AddRooms (
                        RoId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoName TEXT NOT NULL,
                        RoType TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS AddTimes (
                        TiId INTEGER PRIMARY KEY AUTOINCREMENT,
                        TiDay TEXT NOT NULL,
                        TiSlot TEXT NOT NULL
                        
                    );

                        CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectCode TEXT NOT NULL,
                        SubjectName TEXT NOT NULL,
                        CourseId INTEGER NOT NULL,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CouId)
                        
                    );

                        CREATE TABLE IF NOT EXISTS Staffs (
                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        StaffPhone TEXT NOT NULL,
                        StaffAddress TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                        CREATE TABLE IF NOT EXISTS lectures (
                        LecId INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecName TEXT NOT NULL,
                        LecPhone TEXT NOT NULL,
                        LecAddress TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                        CREATE TABLE IF NOT EXISTS Students (
                        StdId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StdName TEXT NOT NULL,
                        StdPhone TEXT NOT NULL,
                        StdAddress TEXT NOT NULL,
                        UserId INTEGER,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                        CREATE TABLE IF NOT EXISTS StudentCourses (
                        SCId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER NOT NULL,
                        CourseId INTEGER NOT NULL,
                        FOREIGN KEY (StudentId) REFERENCES Students(StdId),
                        FOREIGN KEY (CourseId) REFERENCES Courses(CouId)
                    );
                        
                        CREATE TABLE IF NOT EXISTS Classes (
                        ClassId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClassMode TEXT NOT NULL,
                        ClassName TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)

                    );

                        CREATE TABLE IF NOT EXISTS Exams (
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        ExamMode TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                        
                    );

                        CREATE TABLE IF NOT EXISTS Rooms (
                        RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudyMode TEXT NOT NULL,
                        RooomName TEXT NOT NULL,
                        RoomMode TEXT NOT NULL,
                        ExamID INTEGER NULL,
                        ClassId INTEGER NULL,
                        FOREIGN KEY (ClassId) REFERENCES Classes(ClassId),
                        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                        
                    );

                        CREATE TABLE IF NOT EXISTS TimeTables (
                        TimeId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        TimeDay TEXT NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        RoomId INTEGER NOT NULL,
                        CourseID INTEGER NOT NULL,
                        SubID INTEGER NOT NULL,
                        LecID INTEGER NOT NULL,
                        FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
                        FOREIGN KEY (CourseID) REFERENCES Courses(CouId),
                        FOREIGN KEY (SubID) REFERENCES Subjects(SubjectId),
                        FOREIGN KEY (LecID ) REFERENCES lectures(LecId)
                    );

                        CREATE TABLE IF NOT EXISTS Attendances (
                        AttenId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date Text NOT NULL,
                        StdId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        StatusId INTEGER NOT NULL,
                        FOREIGN KEY (StdId) REFERENCES Students(StdId),
                        FOREIGN KEY (StatusId) REFERENCES AddStatus(StatusId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)

                    );

                        CREATE TABLE IF NOT EXISTS Marks (
                        MarksId INTEGER PRIMARY KEY AUTOINCREMENT,
                        MarkScore INTEGER NOT NULL,
                        MarksGrade TEXT NOT NULL,
                        StdId INTEGER NOT NULL,
                        CourseId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        FOREIGN KEY (StdId) REFERENCES Students(StdId),
                        FOREIGN KEY (CourseId) REFERENCES Courses(CouId),
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)

                    );

                        INSERT INTO Roles (RoleCode, RoleName)
                        SELECT 'R001', 'Admin'
                        WHERE NOT EXISTS (SELECT 1 FROM Roles WHERE RoleName = 'Admin');

                        INSERT INTO Users (UserName, UserPass, UserRole)
                        SELECT 'Admin', '123', 'Admin'
                        WHERE NOT EXISTS (SELECT 1 FROM Users WHERE UserName = 'Admin');

                        INSERT INTO Staffs (StaffName, StaffPhone, StaffAddress, UserId)
                        SELECT 'Default Admin', '0000000000', 'Admin Office', UserId
                        FROM Users
                        WHERE UserName = 'Admin'
                        AND NOT EXISTS (
                        SELECT 1 FROM Staffs
                        WHERE UserId = (SELECT UserId FROM Users WHERE UserName = 'Admin')

                    );

                         INSERT INTO AddStatus (StatusName)
                        SELECT 'Present'
                        WHERE NOT EXISTS (SELECT 1 FROM AddStatus WHERE StatusName = 'Present');

                        INSERT INTO AddStatus (StatusName)
                        SELECT 'Absent'
                        WHERE NOT EXISTS (SELECT 1 FROM AddStatus WHERE StatusName = 'Absent');

                        INSERT INTO AddStatus (StatusName)
                        SELECT 'Late'
                        WHERE NOT EXISTS (SELECT 1 FROM AddStatus WHERE StatusName = 'Late');
                ";

                cmd.ExecuteNonQuery();

            }
        }
    }
}
